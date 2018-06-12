using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using PlanStreet.ViewModels;
namespace PlanStreet.Views
{
    public partial class PriorityPopup : PopupPage
    {
        PriorityPopupViewModel _priorityPopupViewModel;
        public PriorityPopup()
        {
            _priorityPopupViewModel = App.Locator.PriorityPopupViewModel;
            InitializeComponent();
            BindingContext = _priorityPopupViewModel;
        }
    }
}
