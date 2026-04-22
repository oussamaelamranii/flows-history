using System;
using System.Collections.Generic;

namespace MyXrmToolBoxTool1.Models.DTOs
{
    public class FlowRunActionsResponseDto
    {
        public List<FlowRunActionDto> value { get; set; }
        public string nextLink { get; set; }
    }

    public class FlowRunActionDto
    {
        public string name { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public FlowRunActionPropertiesDto properties { get; set; }
    }

    public class FlowRunActionPropertiesDto
    {
        public DateTimeOffset startTime { get; set; }
        public DateTimeOffset endTime { get; set; }
        public string status { get; set; }
        public string code { get; set; }
        public FlowRunActionContentLinkDto inputsLink { get; set; }
        public FlowRunActionContentLinkDto outputsLink { get; set; }
        public FlowRunErrorDto error { get; set; }
        public FlowRunActionCorrelationDto correlation { get; set; }
        public string iterationCount { get; set; }
    }

    public class FlowRunActionContentLinkDto
    {
        public string uri { get; set; }
        public int contentSize { get; set; }
        public string contentVersion { get; set; }
        public FlowRunActionContentHashDto contentHash { get; set; }
    }

    public class FlowRunActionContentHashDto
    {
        public string algorithm { get; set; }
        public string value { get; set; }
    }

    public class FlowRunActionCorrelationDto
    {
        public string actionTrackingId { get; set; }
        public string clientTrackingId { get; set; }
    }
}
