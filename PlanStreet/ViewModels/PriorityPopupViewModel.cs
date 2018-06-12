using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using PlanStreet.Interfaces;
using PlanStreet.Models;
using PlanStreet.ViewModels;
using Xamarin.Forms;
using PlanStreet.Messages;
using PlanStreet.Constants;

namespace PlanStreet.ViewModels
{

    public class PriorityPopupViewModel : BaseViewModel
    {
        #region Fields
        private readonly IPlanStreetNavigationService _planStreetNavigationService;
        private PriorityModelItem _selectedPriority;
        private ObservableCollection<PriorityModelItem> _priorities;
        private const double RowHeights = 40;
        private double _listHeights;
        #endregion

        #region Properties
        public PriorityModelItem SelectedPriority
        {
            get { return _selectedPriority; }
            set
            {
                _selectedPriority = value;
                RaisePropertyChanged("SelectedPriority");
            }
        }

        public ObservableCollection<PriorityModelItem> Priorities
        {
            get { return _priorities; }
            set
            {
                _priorities = value;
                RaisePropertyChanged("Priorities");
            }
        }

        public double ListRowHeights => RowHeights;

        public double ListHeights
        {
            get { return _listHeights; }

            set
            {
                _listHeights = value;
                RaisePropertyChanged("ListHeights");
            }
        }
        #endregion

        #region Commands
        public RelayCommand PrioritySelectedCommand { get; set; }
        public RelayCommand OkCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        #endregion
        public PriorityPopupViewModel(IPlanStreetNavigationService planStreetNavigationService)
        {
            _planStreetNavigationService = planStreetNavigationService;
            PrioritySelectedCommand = new RelayCommand(PriorityUpdated);
            OkCommand = new RelayCommand(() =>
            {
                var status = Priorities.Where(x => x.IsSelected == true).FirstOrDefault();
                if (status == null)
                    return;
                App.Locator.CreateProjectViewModel.PriorityColor = status.PriorityColor;
                App.Locator.CreateProjectViewModel.PriorityName = status.PriorityName;
                _planStreetNavigationService.ClosePopup();
                var message = new PriorityChangedMessage()
                {
                    SelectedPriority = status.PriorityType
                };
                MessagingCenter.Send(message, MessageConstants.PriorityChangedMessage);
            });

            CancelCommand = new RelayCommand(() =>
            {
                _planStreetNavigationService.ClosePopup();
            });

            Priorities = new ObservableCollection<PriorityModelItem>();

            Priorities.Add(new PriorityModelItem("Low Priority", Color.FromRgb(112, 216, 124), false, Enums.PriorityType.Low));
            Priorities.Add(new PriorityModelItem("Medium Priority", Color.FromRgb(253, 196, 79), true, Enums.PriorityType.Medium));
            Priorities.Add(new PriorityModelItem("High Priority", Color.FromRgb(255, 0, 0), false, Enums.PriorityType.High));
            ListHeights = Priorities.Count * RowHeights;
        }
        private void PriorityUpdated()
        {
            if (SelectedPriority == null)
                return;
            var priority = Priorities.Where(x => x.IsSelected == true).FirstOrDefault();
            if (priority != null)
                priority.IsSelected = false;
            SelectedPriority.IsSelected = true;
            SelectedPriority = null;
        }

    }
}
