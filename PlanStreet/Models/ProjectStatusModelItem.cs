using System;
using PlanStreet.Enums;
using Xamarin.Forms;
namespace PlanStreet.Models
{
    public class ProjectStatusModelItem
    {
        public ProjectStatusModelItem()
        {
        }
        public ImageSource Profile { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ProjectStatus Status { get; set; }
        public int AttachmentCount { get; set; }
        public string Days { get; set; }
        public int TotalDays { get; set; }
    }
}
