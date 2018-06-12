using System;
using PlanStreet.Enums;
namespace PlanStreet.Messages
{
    public class PriorityChangedMessage
    {
        public PriorityType SelectedPriority { get; set; }
    }
}
