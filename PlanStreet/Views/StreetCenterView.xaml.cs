using System;
using System.Collections.Generic;
using PlanStreet.Controls;
using PlanStreet.ViewModels;
using Xamarin.Forms;

namespace PlanStreet.Views
{
    public partial class StreetCenterView : ContentPage
    {
        StreetCenterViewModel _streetCenterViewModel;
        public StreetCenterView()
        {
            _streetCenterViewModel = App.Locator.StreetCenterViewModel;
            InitializeComponent();
            BindingContext = _streetCenterViewModel;

            TaskCenterStackLayout.Children.Add(new CollapsableControl()
            {
                Margin = new Thickness(10,10,10,0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Fill,
                Title = "To Do",
                Views = TodoLists,
                IsExpanded = false
            });

            TaskCenterStackLayout.Children.Add(new CollapsableControl()
            {
                Margin = new Thickness(10, 10, 10, 0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Fill,
                Title = "In Progress",
                Views = InProgressLists,
                IsExpanded = false
            });


            StreetBoardStack.Children.Add(new CollapsableControl()
            {
                Margin = new Thickness(10, 10, 10, 0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Fill,
                Title = "Personal",
                Views = PersonalList,
                IsExpanded = false
            });

            StreetBoardStack.Children.Add(new CollapsableControl()
            {
                Margin = new Thickness(10, 10, 10, 0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Fill,
                Title = "Team",

                IsExpanded = false
            });

            if (App.ScreenWidth == 320 || App.ScreenHeight == 320)
            {
                LblActivity.FontSize = 12;
                LblStreetCenterTab.FontSize = 12;
                LblScheduler.FontSize = 12;
            }
        }
    }
}
