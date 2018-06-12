using System;
using GalaSoft.MvvmLight.Command;
using PlanStreet.Interfaces;
using Xamarin.Forms;

namespace PlanStreet.ViewModels
{
    public class CreateProjectViewModel : BaseViewModel
    {
        #region Fields
        private readonly IPlanStreetNavigationService _planStreetNavigationService;
        private Color _statusColor;
        private Color _priorityColor;
        private string _statusName;
        private string _priorityName;

        #endregion

        #region Properties
        public Color StatusColor
        {
            get { return _statusColor; }
            set
            {
                _statusColor = value;
                RaisePropertyChanged("StatusColor");
            }
        }

        public Color PriorityColor
        {
            get { return _priorityColor; }
            set
            {
                _priorityColor = value;
                RaisePropertyChanged("PriorityColor");
            }
        }

        public string StatusName
        {
            get { return _statusName; }
            set
            {
                _statusName = value;
                RaisePropertyChanged("StatusName");
            }
        }

        public string PriorityName
        {
            get { return _priorityName; }
            set
            {
                _priorityName = value;
                RaisePropertyChanged("PriorityName");
            }
        }
        #endregion

        #region Commands
        public RelayCommand UpdateStatusCommand { get; set; }
        public RelayCommand UpdatePriorityCommand { get; set; }
        #endregion
        public CreateProjectViewModel(IPlanStreetNavigationService planStreetNavigationService)
        {
            _planStreetNavigationService = planStreetNavigationService;
            StatusColor = Color.FromRgb(93, 126, 253);
            StatusName = "Not Started";
            PriorityName = "Medium Priority";
            PriorityColor = Color.FromRgb(253, 196, 79);

            UpdateStatusCommand = new RelayCommand(() => {
                _planStreetNavigationService.NavigateToPopup(Enums.AppPages.StatusPopup);
            });
            UpdatePriorityCommand = new RelayCommand(() =>
            {
                _planStreetNavigationService.NavigateToPopup(Enums.AppPages.PriorityPopup);
            });
        }

    }
}
