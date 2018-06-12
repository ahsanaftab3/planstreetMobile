using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using PlanStreet.Interfaces;
using PlanStreet.Models;

namespace PlanStreet.ViewModels
{
    public class StatusViewModel : BaseViewModel
    {
        #region Fields
        private readonly IPlanStreetNavigationService _planStreetNavigationService;
        private const double RowHeights = 120;

        private bool _isStreetCenterSelected;
        private bool _isSchedulerSelected;
        private bool _isActivitySelected;
        private bool _isVisibleTaskView;
        private ProjectStatusModelItem _selectedProject;
        private ObservableCollection<ProjectStatusModelItem> _projects;

        private ObservableCollection<ProjectStatusModelItem> _inProgressProjects;
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

        public ProjectStatusModelItem SelectedProject
        {
            get { return _selectedProject; }
            set
            {
                _selectedProject = value;
                RaisePropertyChanged("SelectedProject");
            }
        }

        public ObservableCollection<ProjectStatusModelItem> Projects
        {
            get { return _projects; }
            set
            {
                _projects = value;
                RaisePropertyChanged("Projects");
            }
        }

        public ObservableCollection<ProjectStatusModelItem> InProgressProjects
        {
            get { return _inProgressProjects; }
            set
            {
                _inProgressProjects = value;
                RaisePropertyChanged("InProgressProjects");
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

        public StatusViewModel(IPlanStreetNavigationService planStreetNavigationService)
        {
            _planStreetNavigationService = planStreetNavigationService;
            StreetCenterCommand = new RelayCommand(ExecuteStreetCenter);
            SchedulerCommand = new RelayCommand(ExecuteScheduler);
            ActivityCommand = new RelayCommand(ExecuteActivity);
            ProjectSelectedCommand = new RelayCommand(ExecuteSelectedProject);
            Projects = new ObservableCollection<ProjectStatusModelItem>();
            Projects.Add(new ProjectStatusModelItem()
            {
                Title = "Marketing Plan",
                Description = "Lorem ipsum doller sit emur sun orem ipsum doller sit emur sun ",
                Status = Enums.ProjectStatus.Ready,
                Profile = "ic_folder.png",
                AttachmentCount = 3,
                Days = "In 5 days",
                TotalDays = 6
            });
            Projects.Add(new ProjectStatusModelItem()
            {
                Title = "Marketing Plan",
                Description = "Lorem ipsum doller sit emur sun orem ipsum doller sit emur sun ",
                Status = Enums.ProjectStatus.Ready,
                Profile = "ic_folder.png",
                AttachmentCount = 3,
                Days = "In 5 days",
                TotalDays = 6
            });
            ListHeights = Projects.Count * RowHeights;

            InProgressProjects = new ObservableCollection<ProjectStatusModelItem>();
            InProgressProjects.Add(new ProjectStatusModelItem()
            {
                Title = "Marketing Plan",
                Description = "Lorem ipsum doller sit emur sun orem ipsum doller sit emur sun ",
                Status = Enums.ProjectStatus.InProgress,
                Profile = "ic_folder.png",
                AttachmentCount = 3,
                Days = "In 5 days",
                TotalDays = 6
            });
            InProgressProjects.Add(new ProjectStatusModelItem()
            {
                Title = "Marketing Plan",
                Description = "Lorem ipsum doller sit emur sun orem ipsum doller sit emur sun ",
                Status = Enums.ProjectStatus.InProgress,
                Profile = "ic_folder.png",
                AttachmentCount = 3,
                Days = "In 5 days",
                TotalDays = 6
            });
            AddTaskCommand = new RelayCommand(ExecuteAddTask);
            AddNewTaskCommand = new RelayCommand(ExecuteAddNewTask);
            AddNewFrameCommand = new RelayCommand(ExecuteAddNewFrame);
            InProgressListHeights = InProgressProjects.Count * RowHeights;
            ExecuteStreetCenter();
        }

        private void ExecuteAddTask()
        {
            IsVisibleTaskView = !IsVisibleTaskView;
        }
        private void ExecuteAddNewTask()
        {
            IsVisibleTaskView = false;
            _planStreetNavigationService.NavigateTo(Enums.AppPages.StreetCenterView);
        }
        private void ExecuteAddNewFrame()
        {
            IsVisibleTaskView = false;
        }
        private void ExecuteSelectedProject()
        {
            if (SelectedProject == null)
                return;
            SelectedProject = null;
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
