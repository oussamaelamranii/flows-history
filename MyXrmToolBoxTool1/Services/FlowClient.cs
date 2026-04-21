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
                    CorrelationId = corrId
                };

                flowRuns.Add(flowRun);
            }

            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount * 4
            };

            // Fetch trigger inputs in parallel
            Parallel.ForEach(flowRuns, options, fr =>
            {
                try
                {
                    var dto = flowRunDtos.FirstOrDefault(d => d.name == fr.Id);
                    var outputsUri = dto?.properties?.trigger?.outputsLink?.uri;
                    if (!string.IsNullOrWhiteSpace(outputsUri))
                    {
                        var json = _client.GetStringAsync(outputsUri).Result;
                        var root = JObject.Parse(json);
                        var body = root["body"] ?? root;
                        fr.TriggerInputs = FlattenJson(body as JObject);
                    }
                }
                catch
                {
                    // Silently ignore trigger input fetch failures
                }
            });

            // Get error details for failed runs in parallel
            var options2 = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount * 4
            };

            Parallel.ForEach(flowRuns, options2, fr =>
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
        /// Recursively flattens a JObject into a string dictionary of leaf values.
        /// Handles common email trigger fields: Subject, From, To, Body, etc.
        /// </summary>
        private static Dictionary<string, string> FlattenJson(JObject obj, string prefix = "")
        {
            var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            if (obj == null) return result;

            foreach (var prop in obj.Properties())
            {
                var key = string.IsNullOrEmpty(prefix) ? prop.Name : $"{prefix}.{prop.Name}";

                if (prop.Value.Type == JTokenType.Object)
                {
                    foreach (var kv in FlattenJson((JObject)prop.Value, key))
                        result[kv.Key] = kv.Value;
                }
                else if (prop.Value.Type == JTokenType.Array)
                {
                    result[key] = prop.Value.ToString(Formatting.None);
                }
                else
                {
                    result[key] = prop.Value.ToString();
                }
            }
            return result;
        }
    }
}
