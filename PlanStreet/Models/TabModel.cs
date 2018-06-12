using System;
using Xamarin.Forms;

namespace PlanStreet.Models
{
    public class TabModel
    {
        public TabModel()
        {
        }
        public string Name { get; set; }
        public ImageSource Icon { get; set; }
        public ImageSource SelectedIcon { get; set; }
    }
}
