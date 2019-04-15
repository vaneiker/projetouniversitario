using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.EntityLayer
{
    public class MovementsPrerequisites
    {
        public int IdPrerequisiteMovement { get; set; }
        public string PrerequisiteMovementName { get; set; }
        public int Ordinal { get; set; }
        public string HelpContent { get; set; }
        public int IdExecutionState { get; set; }
        public string ExecutionStateName { get; set; }
    }
}
