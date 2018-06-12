using System;
using GalaSoft.MvvmLight.Command;
using PlanStreet.Interfaces;
namespace PlanStreet.ViewModels
{
    public class TimeLineTopTabbedPageViewModel : BaseViewModel
    {
        #region Fields
        private readonly IPlanStreetNavigationService _planStreetNavigationService;
        #endregion

        #region Commands
        public RelayCommand CreateProjectCommand { get; set; }

        #endregion
        public TimeLineTopTabbedPageViewModel(IPlanStreetNavigationService planStreetNavigationService)
        {
            _planStreetNavigationService = planStreetNavigationService;
            CreateProjectCommand = new RelayCommand(CreateProject);

        }

        private void CreateProject()
        {
            _planStreetNavigationService.NavigateTo(PlanStreet.Enums.AppPages.BottomTabPage);
        }
    }
}
