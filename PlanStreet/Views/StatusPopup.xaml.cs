using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using PlanStreet.ViewModels;

namespace PlanStreet.Views
{
    public partial class StatusPopup : PopupPage
    {
        StatusPopupViewModel _statusPopupViewModel;
        public StatusPopup()
        {
            _statusPopupViewModel = App.Locator.StatusPopupViewModel;
            InitializeComponent();
            BindingContext = _statusPopupViewModel;
        }
    }
}
