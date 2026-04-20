using MyXrmToolBoxTool1.Enums;
using System;
using System.Collections.Generic;

namespace MyXrmToolBoxTool1.Models
{
    public class Flow
    {
        public FlowStatus Status { get; set; }
        public bool IsSelected { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public FlowClientData ClientData { get; set; }
        public List<FlowRun> FlowRuns { get; set; }
        public string TriggerType { get; set; }
        public bool IsManaged { get; set; }
        public Guid WorkflowId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
