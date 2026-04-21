using System;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>Trigger input key-value pairs fetched from the trigger outputs link.</summary>
        public Dictionary<string, string> TriggerInputs { get; set; } = new Dictionary<string, string>();

        /// <summary>Flat human-readable string of trigger inputs for display and search.</summary>
        public string TriggerInputsDisplay
        {
            get
            {
                if (TriggerInputs == null || !TriggerInputs.Any()) return string.Empty;
                return string.Join(" | ", TriggerInputs.Select(kv => $"{kv.Key}: {kv.Value}"));
            }
        }
    }
}
