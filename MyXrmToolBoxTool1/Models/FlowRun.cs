using System;

namespace MyXrmToolBoxTool1.Models
{
    public class FlowRun
    {
        public string Id { get; set; }
        public string CorrelationId { get; set; }
        public string Status { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public int DurationInMilliseconds { get; set; }
        public string FormattedDuration { get; set; }
        public string Url { get; set; }
        public Flow Flow { get; set; }
        public FlowRunError Error { get; set; }
        public string ErrorDetails { get => Error?.Details; }
    }
}
