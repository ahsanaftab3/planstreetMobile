using System;
using System.Collections.Generic;

namespace PlanStreet.Models
{
    public class PersonalTaskModelItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Comments { get; set; }
        public int CommentsCount { get; set; }
    }
}
