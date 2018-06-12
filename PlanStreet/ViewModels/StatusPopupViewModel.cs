using System;
using System.Linq;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using PlanStreet.Interfaces;
using PlanStreet.Models;
using Xamarin.Forms;

namespace PlanStreet.ViewModels
{
   
    public class StatusPopupViewModel : BaseViewModel
    {
        #region Fields
        private readonly IPlanStreetNavigationService _planStreetNavigationService;
        private StatusModelItem _selectedStatus;
        private ObservableCollection<StatusModelItem> _statuses;
        private const double RowHeights = 40;
        private double _listHeights;
        #endregion

        #region Properties

        public StatusModelItem SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                _selectedStatus = value;
                RaisePropertyChanged("SelectedStatus");
            }
        }

        public ObservableCollection<StatusModelItem> Statuses
        {
            get { return _statuses; }
            set
            {
                _statuses = value;
                RaisePropertyChanged("Statuses");
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
        public RelayCommand StatusSelectedCommand { get; set; }
        public RelayCommand OkCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        #endregion
        public StatusPopupViewModel(IPlanStreetNavigationService planStreetNavigationService)
        {
            
            _planStreetNavigationService = planStreetNavigationService;

            StatusSelectedCommand = new RelayCommand(StatusUpdated);
            OkCommand = new RelayCommand(() =>
            {
                var status = Statuses.Where(x => x.IsSelected == true).FirstOrDefault();
                if (status == null)
                    return;
                App.Locator.CreateProjectViewModel.StatusColor = status.StatusColor;
                App.Locator.CreateProjectViewModel.StatusName = status.Status;
                _planStreetNavigationService.ClosePopup();
            });
            CancelCommand = new RelayCommand(() =>
            {
                _planStreetNavigationService.ClosePopup();
            });
            Statuses = new ObservableCollection<StatusModelItem>();
            Statuses.Add(new StatusModelItem("Not Started", Color.FromRgb(93,126,253), true));
            Statuses.Add(new StatusModelItem("In Progress", Color.FromRgb(77,160,254), false));
            Statuses.Add(new StatusModelItem("In Review", Color.FromRgb(253,196,79), false));
            Statuses.Add(new StatusModelItem("Completed", Color.FromRgb(112,216,124), false));
            ListHeights = Statuses.Count * RowHeights;
        }

        private void StatusUpdated()
        {
            if (SelectedStatus == null)
                return;
            var status = Statuses.Where(x => x.IsSelected == true).FirstOrDefault();
            if (status != null)
                status.IsSelected = false;
            SelectedStatus.IsSelected = true;
            SelectedStatus = null;
        }
    }
}
