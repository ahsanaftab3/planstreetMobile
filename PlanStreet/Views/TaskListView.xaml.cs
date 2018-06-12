using System;
using System.Collections.Generic;
using Xamarin.Forms;
using PlanStreet.ViewModels;

namespace PlanStreet.Views
{
    public partial class TaskListView : ContentView
    {
        TaskListViewModel _taskListViewModel;
        public TaskListView()
        {
            _taskListViewModel = App.Locator.TaskListViewModel;
            InitializeComponent();
            BindingContext = _taskListViewModel;
        }
    }
}
