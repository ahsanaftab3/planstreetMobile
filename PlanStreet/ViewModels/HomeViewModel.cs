using System;
using GalaSoft.MvvmLight.Command;
using PlanStreet.Interfaces;
namespace PlanStreet.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region Fields
        private readonly IPlanStreetNavigationService _planStreetNavigationService;
        #endregion

        #region Properties

        #endregion

        #region Commands
        public RelayCommand TaskStatusCommand { get; set; }
        #endregion

        public HomeViewModel(IPlanStreetNavigationService planStreetNavigationService)
        {
            _planStreetNavigationService = planStreetNavigationService;
            TaskStatusCommand = new RelayCommand(() =>
            {

                _planStreetNavigationService.NavigateTo(Enums.AppPages.StatusView);
            });
        }
    }
}
