using System;
using System.Collections.Generic;
using PlanStreet.Models;
using Xamarin.Forms;
using PlanStreet.ViewModels;

namespace PlanStreet.Views
{
    public partial class TimeLineTopTabbedPage : ContentPage
    {
        TimeLineTopTabbedPageViewModel _timeLineTopTabbedPageViewModel;
        public TimeLineTopTabbedPage()
        {
            _timeLineTopTabbedPageViewModel = App.Locator.TimeLineTopTabbedPageViewModel;
            InitializeComponent();
            BindingContext = _timeLineTopTabbedPageViewModel;
            tabbedControl.Titles = new List<TabModel>()
            {
                new TabModel()
                {
                    Name = "Project Detail",
                    Icon = "ic_folder.png",
                    SelectedIcon = "ic_folder_selected.png"
                },
                new TabModel()
                {
                    Name = "Task",
                    Icon = "ic_folder.png",
                    SelectedIcon = "ic_folder_selected.png"
                },
                new TabModel()
                {
                    Name = "Budget Expense",
                    Icon = "ic_folder.png",
                    SelectedIcon = "ic_folder_selected.png"
                },
                new TabModel()
                {
                    Name = "Documents",
                    Icon = "ic_folder.png",
                    SelectedIcon = "ic_folder_selected.png"
                        
                }
            };

            tabbedControl.Views = new List<View>() {
                new TimelineView(),
                new StackLayout(),
                new StackLayout(),
                new StackLayout()
            };

        }

    }
}
