using PlanStreet.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PlanStreet
{
	public partial class App : Application
    {
        public static int ScreenWidth;
        public static int ScreenHeight;
		private static ViewModelLocator _locator;        

        public static ViewModelLocator Locator
        {
            get { return _locator ?? (_locator = new ViewModelLocator()); }
        }

        public App()
        {
            InitializeComponent();
            Locator.PlanStreetNavigationService.NavigateTo(Enums.AppPages.MainTopTabbedPage);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
