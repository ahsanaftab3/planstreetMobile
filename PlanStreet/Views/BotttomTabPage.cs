using System;
using System.Collections.Specialized;
using BottomBar.XamarinForms;
using Xamarin.Forms;

namespace PlanStreet.Views
{
    public class BotttomTabPage : BottomBarPage
    {
        public BotttomTabPage()
        {

            //Move to create projects
            Title = "Details";
            Icon = "ic_folder_selected.png";
            var AnalistView = new CreateProjectView()
            {
                Title = "Details",
                Icon = "ic_folder_selected.png",
            };

            var messageView = new ContentPage()
            {
                Title = "Message",
                Icon = "ic_folder_selected.png",
            };

            var MeustradesView = new ContentPage()
            {
                Title = "Times",
                Icon = "ic_folder_selected.png",

            };

            var RepeateView = new ContentPage()
            {
                Title = "Repeate",
                Icon = "ic_folder_selected.png"
            };

            if (Device.RuntimePlatform.Equals(Device.iOS))
                this.BarBackgroundColor = Color.FromHex("#000000");

            BarTheme = BottomBarPage.BarThemeTypes.DarkWithAlpha;
            BarTextColor = Color.FromHex("#FFFFFF");
            FixedMode = false;

            BottomBarPageExtensions.SetTabColor(AnalistView, Color.FromHex("#FFFFFF"));
            this.Children.Add(AnalistView);

            BottomBarPageExtensions.SetTabColor(messageView, Color.FromHex("#FFFFFF"));
            this.Children.Add(messageView);

            BottomBarPageExtensions.SetTabColor(MeustradesView, Color.FromHex("#FFFFFF"));
            this.Children.Add(MeustradesView);

            BottomBarPageExtensions.SetTabColor(RepeateView, Color.FromHex("#FFFFFF"));
            this.Children.Add(RepeateView);
            CurrentPageChanged += BotttomTabPage_CurrentPageChanged;
        }


        void BotttomTabPage_CurrentPageChanged(object sender, EventArgs e)
        {
            Title = this.CurrentPage.Title;
            Icon = this.CurrentPage.Icon;
        }

    }
}

