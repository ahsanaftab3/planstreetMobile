using System;
using PlanStreet.Models;
using PlanStreet.Interfaces;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace PlanStreet.ViewModels
{
	public class TimelineViewModel : BaseViewModel
    {
        #region Fields
        private readonly IPlanStreetNavigationService _planStreetNavigationService;
        private ProjectItemModel _selectedProject;
        private ObservableCollection<ProjectItemModel> _projects;
        private const double RowHeights = 120;
        private double _listHeights;
        #endregion

        #region Properties

        public ProjectItemModel SelectedProject
        {
            get { return _selectedProject; }
            set
            {
                _selectedProject = value;
                RaisePropertyChanged("SelectedProject");
            }
        }

        public ObservableCollection<ProjectItemModel> Projects
        {
            get { return _projects; }
            set
            {
                _projects = value;
                RaisePropertyChanged("Projects");
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
        public RelayCommand ProjectSelectedCommand { get; set; }
        public RelayCommand CreateProjectCommand { get; set; }
        #endregion
        public TimelineViewModel(IPlanStreetNavigationService planStreetNavigationService)
        {
            _planStreetNavigationService = planStreetNavigationService;
            ProjectSelectedCommand = new RelayCommand(ExecuteSelectedProject);
            CreateProjectCommand = new RelayCommand(CreateProject);
            Projects = new ObservableCollection<ProjectItemModel>();
            Projects.Add(new ProjectItemModel());
            Projects.Add(new ProjectItemModel());
            ListHeights = Projects.Count * RowHeights;
        }

        private void CreateProject()
        {
            _planStreetNavigationService.NavigateTo(Enums.AppPages.CreateProjectView);
        }
        private void ExecuteSelectedProject()
        {
            if (SelectedProject == null)
                return;
            SelectedProject = null;
        
        }
    }
}
