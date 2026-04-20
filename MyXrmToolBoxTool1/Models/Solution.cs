using System;
using System.Collections.Generic;

namespace MyXrmToolBoxTool1.Models
{
    public class Solution
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid> FlowIds { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
