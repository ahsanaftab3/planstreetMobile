using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using PlanStreet.Interfaces;
using PlanStreet.Services;
using PlanStreet.Views;

namespace PlanStreet.ViewModels
{
	public class ViewModelLocator
    {
        public ViewModelLocator()
        {			
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			// ViewModel registration goes here.
			SimpleIoc.Default.Register<TimelineViewModel>();
            SimpleIoc.Default.Register<CreateProjectViewModel>();
            SimpleIoc.Default.Register<TimeLineTopTabbedPageViewModel>();
            SimpleIoc.Default.Register<StatusPopupViewModel>();
            SimpleIoc.Default.Register<PriorityPopupViewModel>();
            SimpleIoc.Default.Register<MainTopTabbedPageViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<StatusViewModel>();
            SimpleIoc.Default.Register<StreetCenterViewModel>();
            SimpleIoc.Default.Register<TaskListViewModel>();


            // ViewModel registration over                       

			// Service registration start                                  
            IPlanStreetNavigationService navigationService = new PlanStreetNavigationService();
			SimpleIoc.Default.Register<IPlanStreetNavigationService>(() => navigationService);
			// Service registration over

			// View registration goes here.
            navigationService.Configure(Enums.AppPages.TimeLineTopTabbedPage, typeof(TimeLineTopTabbedPage));
			navigationService.Configure(Enums.AppPages.Timeline, typeof(TimelineView));
            navigationService.Configure(Enums.AppPages.CreateProjectView, typeof(CreateProjectView));
            navigationService.Configure(Enums.AppPages.StatusPopup, typeof(StatusPopup));
            navigationService.Configure(Enums.AppPages.PriorityPopup, typeof(PriorityPopup));
            navigationService.Configure(Enums.AppPages.BottomTabPage, typeof(BotttomTabPage));
            navigationService.Configure(Enums.AppPages.MainTopTabbedPage, typeof(MainTopTabbedPage));
            navigationService.Configure(Enums.AppPages.HomeView, typeof(HomeView));
            navigationService.Configure(Enums.AppPages.StatusView, typeof(StatusView));
            navigationService.Configure(Enums.AppPages.StreetCenterView, typeof(StreetCenterView));
            navigationService.Configure(Enums.AppPages.TaskListView, typeof(TaskListView));

            // View registration over.
        }

		public TimelineViewModel TimelineViewModel 
		{
			get { return ServiceLocator.Current.GetInstance<TimelineViewModel>(); }
		} 

        public CreateProjectViewModel CreateProjectViewModel
        {
            get { return ServiceLocator.Current.GetInstance<CreateProjectViewModel>(); }
        } 

        public StatusPopupViewModel StatusPopupViewModel
        {
            get { return ServiceLocator.Current.GetInstance<StatusPopupViewModel>(); }
        } 

        public PriorityPopupViewModel PriorityPopupViewModel
        {
            get { return ServiceLocator.Current.GetInstance<PriorityPopupViewModel>(); }
        } 

        public MainTopTabbedPageViewModel MainTopTabbedPageViewModel
        {
            get { return ServiceLocator.Current.GetInstance<MainTopTabbedPageViewModel>(); }
        } 

        public HomeViewModel HomeViewModel
        {
            get { return ServiceLocator.Current.GetInstance<HomeViewModel>(); }
        } 

        public StatusViewModel StatusViewModel
        {
            get { return ServiceLocator.Current.GetInstance<StatusViewModel>(); }
        } 

        public StreetCenterViewModel StreetCenterViewModel
        {
            get { return ServiceLocator.Current.GetInstance<StreetCenterViewModel>(); }
        } 
        public TaskListViewModel TaskListViewModel
        {
            get { return ServiceLocator.Current.GetInstance<TaskListViewModel>(); }
        } 

        public TimeLineTopTabbedPageViewModel TimeLineTopTabbedPageViewModel
        {
            get { return ServiceLocator.Current.GetInstance<TimeLineTopTabbedPageViewModel>(); }
        } 

		public IPlanStreetNavigationService PlanStreetNavigationService 
		{
			get { return ServiceLocator.Current.GetInstance<IPlanStreetNavigationService>(); }
		} 
    }
}
