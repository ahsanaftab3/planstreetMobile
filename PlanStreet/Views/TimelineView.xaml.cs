using System;
using System.Collections.Generic;
using PlanStreet.ViewModels;
using Xamarin.Forms;
using PlanStreet.Controls;
using BottomBar.XamarinForms;

namespace PlanStreet.Views
{
    public partial class TimelineView : ContentView
    {
        
		private readonly TimelineViewModel _timeLineViewModel;

        public TimelineView()
        {
            _timeLineViewModel = App.Locator.TimelineViewModel;
            InitializeComponent();
            BindingContext = _timeLineViewModel;
            StackContainer.Children.Add(new CollapsableControl()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Fill,
                Title = "1. Project",
                Views = ProjectList,

            });


        }

    }
}
