using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using PlanStreet.Interfaces;
using PlanStreet.Models;
using Xamarin.Forms;

namespace PlanStreet.ViewModels
{
    public class StreetCenterViewModel : BaseViewModel
    {
        #region Fields
        private readonly IPlanStreetNavigationService _planStreetNavigationService;
        private const double RowHeights = 50;
        private const double PersonalRowHeights = 94;
        private bool _isStreetCenterSelected;
        private bool _isSchedulerSelected;
        private bool _isActivitySelected;
        private bool _isVisibleTaskView;
        private ProjectStatusModelItem _selectedToDos;
        private ProjectStatusModelItem _selectedInProgressTask;

        private PersonalTaskModelItem _selectedPersonalItem;
        private List<PersonalTaskModelItem> _personalList;
        private ObservableCollection<ProjectStatusModelItem> _toDoTasks;

        private ObservableCollection<ProjectStatusModelItem> _inProgressTasks;
        private double _listHeights;
        private double _inProgressListHeights;

        #endregion

        #region Properties
        public bool IsStreetCenterSelected
        {
            get { return _isStreetCenterSelected; }
            set
            {
                _isStreetCenterSelected = value;
                RaisePropertyChanged("IsStreetCenterSelected");
            }
        }

        public bool IsSchedulerSelected
        {
            get { return _isSchedulerSelected; }
            set
            {
                _isSchedulerSelected = value;
                RaisePropertyChanged("IsSchedulerSelected");
            }
        }

        public bool IsActivitySelected
        {
            get { return _isActivitySelected; }
            set
            {
                _isActivitySelected = value;
                RaisePropertyChanged("IsActivitySelected");
            }
        }

        public bool IsVisibleTaskView
        {
            get { return _isVisibleTaskView; }
            set
            {
                _isVisibleTaskView = value;
                RaisePropertyChanged("IsVisibleTaskView");
            }
        }

        public ProjectStatusModelItem SelectedToDos
        {
            get { return _selectedToDos; }
            set
            {
                _selectedToDos = value;
                RaisePropertyChanged("SelectedToDos");
            }
        }
        public ProjectStatusModelItem SelectedInProgressTask
        {
            get { return _selectedInProgressTask; }
            set
            {
                _selectedInProgressTask = value;
                RaisePropertyChanged("SelectedInProgressTask");
            }
        }
        public ObservableCollection<ProjectStatusModelItem> ToDoTasks
        {
            get { return _toDoTasks; }
            set
            {
                _toDoTasks = value;
                RaisePropertyChanged("ToDoTasks");
            }
        }

        public ObservableCollection<ProjectStatusModelItem> InProgressTasks
        {
            get { return _inProgressTasks; }
            set
            {
                _inProgressTasks = value;
                RaisePropertyChanged("InProgressTasks");
            }
        }
        public PersonalTaskModelItem SelectedPersonalItem
        {
            get { return _selectedPersonalItem; }
            set
            {
                _selectedPersonalItem = value;
                RaisePropertyChanged("SelectedPersonalItem");
            }
        }
        public List<PersonalTaskModelItem> PersonalList
        {
            get { return _personalList; }
            set
            {
                _personalList = value;
                RaisePropertyChanged("PersonalList");
            }
        }

        public double ListRowHeights => RowHeights;
        public double PersonalListRowHeights => PersonalRowHeights;

        public double ListHeights
        {
            get { return _listHeights; }

            set
            {
                _listHeights = value;
                RaisePropertyChanged("ListHeights");
            }
        }
        public double InProgressListHeights
        {
            get { return _inProgressListHeights; }

            set
            {
                _inProgressListHeights = value;
                RaisePropertyChanged("InProgressListHeights");
            }
        }

        #endregion

        #region Commands
        public RelayCommand StreetCenterCommand { get; set; }
        public RelayCommand SchedulerCommand { get; set; }
        public RelayCommand ActivityCommand { get; set; }
        public RelayCommand ProjectSelectedCommand { get; set; }
        public RelayCommand AddTaskCommand { get; set; }
        public RelayCommand AddNewTaskCommand { get; set; }
        public RelayCommand AddNewFrameCommand { get; set; }
        #endregion



        public StreetCenterViewModel(IPlanStreetNavigationService planStreetNavigationService)
        {
            _planStreetNavigationService = planStreetNavigationService;
            StreetCenterCommand = new RelayCommand(ExecuteStreetCenter);
            SchedulerCommand = new RelayCommand(ExecuteScheduler);
            ActivityCommand = new RelayCommand(ExecuteActivity);
            ToDoTasks = new ObservableCollection<ProjectStatusModelItem>();
            ToDoTasks.Add(new ProjectStatusModelItem());
            ToDoTasks.Add(new ProjectStatusModelItem());
            ToDoTasks.Add(new ProjectStatusModelItem());
            ToDoTasks.Add(new ProjectStatusModelItem());

            InProgressTasks = new ObservableCollection<ProjectStatusModelItem>();
            InProgressTasks.Add(new ProjectStatusModelItem());
            InProgressTasks.Add(new ProjectStatusModelItem());
            InProgressTasks.Add(new ProjectStatusModelItem());
            InProgressTasks.Add(new ProjectStatusModelItem());

            PersonalList = new List<PersonalTaskModelItem>();
            PersonalList.Add(new PersonalTaskModelItem());
 
            ExecuteStreetCenter();
        }
        private void RemoveAllSelected()
        {
            IsStreetCenterSelected = false;
            IsSchedulerSelected = false;
            IsActivitySelected = false;
        }

        private void ExecuteStreetCenter()
        {
            if (IsStreetCenterSelected)
                return;
            RemoveAllSelected();
            IsStreetCenterSelected = true;
        }

        private void ExecuteScheduler()
        {
            if (IsSchedulerSelected)
                return;
            RemoveAllSelected();
            IsSchedulerSelected = true;
        }

        private void ExecuteActivity()
        {
            if (IsActivitySelected)
                return;
            RemoveAllSelected();
            IsActivitySelected = true;
        }
    }
}

