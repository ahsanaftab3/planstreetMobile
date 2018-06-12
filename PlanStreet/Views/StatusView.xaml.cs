using System;
using System.Collections.Generic;
using PlanStreet.ViewModels;
using Xamarin.Forms;

namespace PlanStreet.Views
{
    public partial class StatusView : ContentPage
    {
        StatusViewModel _statusViewModel;
        public StatusView()
        {
            _statusViewModel = App.Locator.StatusViewModel;
            InitializeComponent();
            BindingContext = _statusViewModel;
            if (App.ScreenWidth == 320 || App.ScreenHeight == 320)
            {
                LblActivity.FontSize = 12;
                LblStreetCenterTab.FontSize = 12;
                LblScheduler.FontSize = 12;
                LblNewTask.FontSize = 12;
                LblNewFrame.FontSize = 12;
            }
        }
    }
}
