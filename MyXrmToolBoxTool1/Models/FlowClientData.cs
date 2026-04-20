using System.Collections.Generic;

namespace MyXrmToolBoxTool1.Models
{
    public class FlowClientData
    {
        public FlowClientDataProperties properties { get; set; }
    }

    public class FlowClientDataProperties
    {
        public FlowDefinition definition { get; set; }
    }

    public class FlowDefinition
    {
        public Dictionary<string, TriggerInfo> triggers { get; set; }
    }

    public class TriggerInfo
    {
        public string type { get; set; }
    }
}
