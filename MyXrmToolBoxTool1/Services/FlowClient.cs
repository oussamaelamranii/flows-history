using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MyXrmToolBoxTool1.Enums;
using MyXrmToolBoxTool1.Helpers;
using MyXrmToolBoxTool1.Models;
using MyXrmToolBoxTool1.Models.DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyXrmToolBoxTool1.Services
{
    public class FlowClient
    {
        private readonly HttpClient _client;
        private readonly string _envId;

        private string BaseUrl { get; set; }
        private string MakePowerAutomateUrl { get; set; }

        public FlowClient(string envId, string accessToken, OrganizationGeo geo)
        {
            BaseUrl = FlowEndpointHelper.GetFlowApiBaseUrl(geo);
            MakePowerAutomateUrl = FlowEndpointHelper.GetMakerUrl(geo);

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);

            _client = client;
            _envId = envId;
        }

        public FlowRunRemediationResponse GetFlowRunErrorDetails(FlowRun flowRun)
        {
            var urlBuilder = new UriBuilder(BaseUrl)
            {
                Path = $"/providers/Microsoft.ProcessSimple/environments/{_envId}/flows/{flowRun.Flow.Id}/runs/{flowRun.Id}/remediation",
                Query = "api-version=2016-11-01"
            };

            var responseJson = _client.GetAsync(urlBuilder.Uri).Result.Content.ReadAsStringAsync().Result;
            var flowRunRemediationResponse = JsonConvert.DeserializeObject<FlowRunRemediationResponse>(responseJson);

            return flowRunRemediationResponse;
        }

        public bool CancelFlowRun(FlowRun flowRun)
        {
            var urlBuilder = new UriBuilder(BaseUrl)
            {
                Path = $"/providers/Microsoft.ProcessSimple/environments/{_envId}/flows/{flowRun.Flow.Id}/runs/{flowRun.Id}/cancel",
                Query = "api-version=2016-11-01"
            };

            var request = new HttpRequestMessage(HttpMethod.Post, urlBuilder.Uri);
            var response = _client.SendAsync(request).Result;

            return response.IsSuccessStatusCode;
        }

        public List<FlowRun> GetFlowRuns(Flow flow, string status, DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            var flowRuns = new List<FlowRun>();
            var flowRunDtos = new List<FlowRunDto>();

            var dateFilter = $"StartTime gt {dateFrom.ToUniversalTime():s}Z";
            var statusFilter = status != "All" ? $"Status eq '{status}'" : string.Empty;

            var filterQuery = statusFilter == string.Empty
                ? $"$filter={dateFilter}"
                : $"$filter={statusFilter} and {dateFilter}";

            var urlBuilder = new UriBuilder(BaseUrl)
            {
                Path = $"/providers/Microsoft.ProcessSimple/environments/{_envId}/flows/{flow.Id}/runs/",
                Query = $"api-version=2016-11-01&$top=250&{filterQuery}"
            };

            var url = urlBuilder.Uri.ToString();

            while (!string.IsNullOrWhiteSpace(url))
            {
                var response = _client.GetAsync(url).Result;
                var responseJson = response.Content.ReadAsStringAsync().Result;
                var flowRunsResponse = JsonConvert.DeserializeObject<FlowRunsResponseDto>(responseJson);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"{flowRunsResponse?.error?.code}: {flowRunsResponse?.error?.message}");
                }

                if (flowRunsResponse?.value != null)
                {
                    flowRunDtos.AddRange(flowRunsResponse.value);
                }

                url = flowRunsResponse?.nextLink;
            }

            foreach (var fr in flowRunDtos)
            {
                var duration = (fr.properties.endTime - fr.properties.startTime).TotalMilliseconds;
                var runUrl = $"{MakePowerAutomateUrl}/environments/{_envId}/flows/{flow.Id}/runs/{fr.name}";

                var corrId = fr.properties.correlation?.clientTrackingId ?? string.Empty;

                var flowRun = new FlowRun
                {
                    Id = fr.name,
                    Status = fr.properties.status,
                    StartDate = fr.properties.startTime.ToLocalTime(),
                    EndDate = fr.properties.endTime.ToLocalTime(),
                    DurationInMilliseconds = (int)duration,
                    FormattedDuration = TimeFormatter.MillisecondsTimeString((int)duration),
                    Url = runUrl,
                    Flow = flow,
                    CorrelationId = corrId,
                    TriggerOutputsLinkUri = fr.properties.trigger?.outputsLink?.uri
                };

                flowRuns.Add(flowRun);
            }

            // Get error details for failed runs in parallel
            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount * 4
            };

            Parallel.ForEach(flowRuns, options, fr =>
            {
                if (fr.Status == FlowRunStatus.Failed)
                {
                    try
                    {
                        var errorDetails = GetFlowRunErrorDetails(fr);
                        fr.Error = new FlowRunError
                        {
                            Message = errorDetails?.errorSubject,
                            Details = errorDetails?.errorDescription
                        };
                    }
                    catch
                    {
                        // Silently ignore error detail fetch failures
                    }
                }
            });

            // Apply date range filter (dateTo)
            flowRuns = flowRuns
                .Where(x => x.StartDate >= dateFrom && x.StartDate <= dateTo)
                .ToList();

            if (status != "All")
            {
                flowRuns = flowRuns.Where(x => x.Status == status).ToList();
            }

            return flowRuns;
        }

        /// <summary>
        /// Lazily loads all action steps for a specific run. Called when the user double-clicks a run row.
        /// </summary>
        public List<FlowRunAction> GetFlowRunActions(FlowRun flowRun)
        {
            var actions = new List<FlowRunAction>();
            var actionDtos = new List<FlowRunActionDto>();

            var urlBuilder = new UriBuilder(BaseUrl)
            {
                Path = $"/providers/Microsoft.ProcessSimple/environments/{_envId}/flows/{flowRun.Flow.Id}/runs/{flowRun.Id}/actions",
                Query = "api-version=2016-11-01"
            };

            var url = urlBuilder.Uri.ToString();

            while (!string.IsNullOrWhiteSpace(url))
            {
                var response = _client.GetAsync(url).Result;
                var responseJson = response.Content.ReadAsStringAsync().Result;
                var actionsResponse = JsonConvert.DeserializeObject<FlowRunActionsResponseDto>(responseJson);

                if (actionsResponse?.value != null)
                    actionDtos.AddRange(actionsResponse.value);

                url = actionsResponse?.nextLink;
            }

            // Parallel-fetch inputs/outputs blobs (with size guard: skip if > 500KB)
            var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 2 };

            Parallel.ForEach(actionDtos, parallelOptions, dto =>
            {
                var props = dto.properties;
                if (props == null) return;

                var durationMs = (int)(props.endTime - props.startTime).TotalMilliseconds;

                var action = new FlowRunAction
                {
                    Name = dto.name,
                    Status = props.status,
                    StartTime = props.startTime.ToLocalTime(),
                    EndTime = props.endTime.ToLocalTime(),
                    DurationMs = durationMs,
                    FormattedDuration = TimeFormatter.MillisecondsTimeString(durationMs),
                    ErrorCode = props.error?.code,
                    ErrorMessage = props.error?.message,
                };

                if (!string.IsNullOrWhiteSpace(props.inputsLink?.uri) && props.inputsLink.contentSize < 512_000)
                {
                    try { action.InputsJson = FetchAndPrettyPrintJson(props.inputsLink.uri); }
                    catch { action.InputsJson = "(Failed to load inputs)"; }
                }
                else if (props.inputsLink?.contentSize >= 512_000)
                {
                    action.InputsJson = $"(Content too large: {props.inputsLink.contentSize / 1024} KB)";
                }

                if (!string.IsNullOrWhiteSpace(props.outputsLink?.uri) && props.outputsLink.contentSize < 512_000)
                {
                    try { action.OutputsJson = FetchAndPrettyPrintJson(props.outputsLink.uri); }
                    catch { action.OutputsJson = "(Failed to load outputs)"; }
                }
                else if (props.outputsLink?.contentSize >= 512_000)
                {
                    action.OutputsJson = $"(Content too large: {props.outputsLink.contentSize / 1024} KB)";
                }

                lock (actions) { actions.Add(action); }
            });

            return actions.OrderBy(a => a.StartTime).ToList();
        }

        /// <summary>
        /// Fetches and prettifies the trigger inputs JSON from its SAS blob URI.
        /// </summary>
        public string GetTriggerInputsJson(string uri)
        {
            if (string.IsNullOrWhiteSpace(uri)) return null;
            return FetchAndPrettyPrintJson(uri);
        }

        private string FetchAndPrettyPrintJson(string uri)
        {
            // Blob URIs are pre-signed — no Authorization header needed
            using (var httpClient = new HttpClient())
            {
                var json = httpClient.GetStringAsync(uri).Result;
                try
                {
                    var token = JToken.Parse(json);
                    return token.ToString(Formatting.Indented);
                }
                catch
                {
                    return json;
                }
            }
        }
    }
}
