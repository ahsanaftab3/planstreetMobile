using System;
using Naxam.Controls.Forms;
using Xamarin.Forms;

namespace PlanStreet.Views
{
    public class TimeLineTopTabbedPage : TopTabbedPage
    {
        public TimeLineTopTabbedPage()
        {
            
            Title = "Timeline";

            this.Children.Add(new TimelineView
            {
                Title = "Project Detail",
                Icon = "ic_folder.png",
            });
            this.Children.Add(new TimelineView
            {
                Title = "Tasks",
                Icon = "ic_folder.png"
            });
            this.Children.Add(new TimelineView
            {
                Title = "Budget Expense",
                Icon = "ic_folder.png"
            });
            this.Children.Add(new TimelineView
            {
                Title = "Documents",
                Icon = "ic_folder.png"
            });
            this.BarBackgroundColor = Color.White;
            BarIndicatorColor = Color.Green;
            BarTextColor = Color.GreenYellow;

        }

    }
}

