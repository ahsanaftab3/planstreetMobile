using System;
using System.Collections.Generic;
using PlanStreet.Models;
using PlanStreet.ViewModels;
using Xamarin.Forms;

namespace PlanStreet.Views
{
    public partial class MainTopTabbedPage : ContentPage
    {
        MainTopTabbedPageViewModel _mainTopTabbedPageViewModel;
        public MainTopTabbedPage()
        {
            _mainTopTabbedPageViewModel = App.Locator.MainTopTabbedPageViewModel;
            InitializeComponent();
            BindingContext = _mainTopTabbedPageViewModel;
            NavigationPage.SetBackButtonTitle(this, "");
            tabbedControl.Titles = new List<TabModel>()
            {
                new TabModel()
                {
                    Name = "",
                    Icon = "ic_folder.png",
                    SelectedIcon = "ic_folder_selected.png"
                },
                new TabModel()
                {
                    Name = "",
                    Icon = "ic_folder.png",
                    SelectedIcon = "ic_folder_selected.png"
                },
                new TabModel()
                {
                    Name = "",
                    Icon = "ic_folder.png",
                    SelectedIcon = "ic_folder_selected.png"
                },
                new TabModel()
                {
                    Name = "",
                    Icon = "ic_folder.png",
                    SelectedIcon = "ic_folder_selected.png"
                }
            };

            tabbedControl.Views = new List<View>() {
                new HomeView(),
                new TaskListView(),
                new StackLayout(),
                new StackLayout()
            };
            tabbedControl.PositionChanged += (s, e) =>
            {
                switch (e)
                {
                    case 0:
                        Title = "Overview";
                        break;
                    case 1:
                        Title = "Task Board";
                        break;
                    case 2:
                        Title = "";
                        break;
                    default:
                        break;
                }

            };

        }
    }
}
