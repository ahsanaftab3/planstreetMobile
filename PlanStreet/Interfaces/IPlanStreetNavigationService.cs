using System;
using System.Threading.Tasks;
using PlanStreet.Enums;

namespace PlanStreet.Interfaces
{
	public interface IPlanStreetNavigationService
    {
		void PresentSideMenu();
        void HideSideMenu();
        void Configure(AppPages pageKey, Type pageType);
        void GoBack(int numberOfPagesToSkip = 0);
        void NavigateTo(AppPages pageKey, object parameter = null);
        void NavigateToFirstPage();
        void PopToRoot(bool isAnimate = true);
        string CurrentPageKey { get; }

        Task NavigateToPopup(AppPages pageKey);
        void ClosePopup();
    }
}
