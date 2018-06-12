using System;
using GalaSoft.MvvmLight.Command;
using PlanStreet.Interfaces;

namespace PlanStreet.ViewModels
{
    public class MainTopTabbedPageViewModel : BaseViewModel
    {
        #region Fields
        private readonly IPlanStreetNavigationService _planStreetNavigationService;
        #endregion

        #region Properties
        #endregion

        #region Commands
        public RelayCommand AddProjectCommand { get; set; }
        public RelayCommand MoveToTimeLineCommand { get; set; }
        #endregion
        public MainTopTabbedPageViewModel(IPlanStreetNavigationService planStreetNavigationService)
        {
            _planStreetNavigationService = planStreetNavigationService;
            AddProjectCommand = new RelayCommand(() =>
            {
                _planStreetNavigationService.NavigateTo(Enums.AppPages.BottomTabPage);
               
            });
            MoveToTimeLineCommand = new RelayCommand(() =>
            {
                _planStreetNavigationService.NavigateTo(Enums.AppPages.TimeLineTopTabbedPage);
            });
        }
    }
}
