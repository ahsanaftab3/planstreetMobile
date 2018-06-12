using System;
namespace PlanStreet.Models
{
    public class ProjectItemModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Predecessors { get; set; }
        public string Successors { get; set; }
    }
}
