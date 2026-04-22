using System;
using System.Collections.Generic;

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

        /// <summary>Prettified JSON of the trigger inputs — lazily loaded when details are opened.</summary>
        public string TriggerInputsJson { get; set; }

        /// <summary>All action steps for this run — lazily loaded when details are opened.</summary>
        public List<FlowRunAction> Actions { get; set; }

        /// <summary>URI for fetching trigger outputs/inputs JSON blob.</summary>
        public string TriggerOutputsLinkUri { get; set; }
    }
}
