using System;

namespace MyXrmToolBoxTool1.Models
{
    /// <summary>
    /// Represents a single action/step within a flow run, with full input/output/error data.
    /// </summary>
    public class FlowRunAction
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public int DurationMs { get; set; }
        public string FormattedDuration { get; set; }

        /// <summary>Prettified JSON of the action inputs (fetched from SAS blob URI).</summary>
        public string InputsJson { get; set; }

        /// <summary>Prettified JSON of the action outputs (fetched from SAS blob URI).</summary>
        public string OutputsJson { get; set; }

        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public bool HasError => !string.IsNullOrWhiteSpace(ErrorCode) || !string.IsNullOrWhiteSpace(ErrorMessage);
    }
}
