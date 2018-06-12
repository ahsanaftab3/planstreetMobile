using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using PlanStreet.Enums;
using PlanStreet.Interfaces;
using PlanStreet.Messages;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace PlanStreet.Services
{
	public class PlanStreetNavigationService : IPlanStreetNavigationService
	{
		private readonly Dictionary<AppPages, Type> _pagesByKey = new Dictionary<AppPages, Type>();
		private NavigationPage _navigation;
		private MasterDetailPage _masterDetailPage;
		private bool _isNavigating;

		public PlanStreetNavigationService()
		{
		}

		public string CurrentPageKey
		{
			get
			{
				lock (_pagesByKey)
				{
					if (_navigation?.CurrentPage == null)
					{
						return null;
					}

					var pageType = _navigation.CurrentPage.GetType();

					return _pagesByKey.ContainsValue(pageType)
									  ? _pagesByKey.First(p => p.Value == pageType).Key.ToString() : null;
				}
			}
		}

		// Register pages and add them to the dictionary:
		public void Configure(AppPages pageKey, Type pageType)
		{
			lock (_pagesByKey)
			{
				if (_pagesByKey.ContainsKey(pageKey))
				{
					_pagesByKey[pageKey] = pageType;
				}
				else
				{
					_pagesByKey.Add(pageKey, pageType);
				}
			}
		}

		// GoBack implementation (just pop page from the navigation stack):
		public void GoBack(int numberOfPagesToSkip = 0)
		{
			IReadOnlyList<Page> navigationStack = _navigation.Navigation.NavigationStack;
			while (numberOfPagesToSkip > 0)
			{
				_navigation.Navigation.RemovePage(navigationStack[navigationStack.Count - 1]);
				numberOfPagesToSkip--;
			}

			_navigation.PopAsync();
		}

		// NavigateTo method to navigate between pages with passing parameter:
		public void NavigateTo(AppPages pageKey, object parameter = null)
		{
			if (_navigation != null && pageKey.ToString().Equals(this.CurrentPageKey))
				return;
            
			lock (this)
			{
				if (_isNavigating)
					return;

				_isNavigating = true;
				System.Diagnostics.Debug.WriteLine($"Navigating to {pageKey} from {this.CurrentPageKey}");
				try
				{
                        
                    var page = GetPageObject(pageKey, parameter);
                    if (_navigation == null)
                    {
                        _navigation = new NavigationPage(page);
                        _navigation.BarBackgroundColor = Color.Black;
                        _navigation.BarTextColor = Color.White;

                        App.Current.MainPage = _navigation;
                    } else
                    {
                        _navigation.PushAsync(page);
                    }
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					_isNavigating = false;
				}
			}
		}

		public void NavigateToFirstPage()
		{
			throw new NotImplementedException();
		}

        public async Task NavigateToPopup(AppPages pageKey)
        {
            var page = GetPageObject(pageKey, null);
            //MessagingCenter.Send<PageNavigationMessage>(new PageNavigationMessage() { PageKey = pageKey }, MessageNameConstants.PageNavigationMessage);
            await PopupNavigation.PushAsync((PopupPage)page);
        }

        public async void ClosePopup()
        {
            await PopupNavigation.PopAsync();
        }


		// GoBack to root of the page.
		public void PopToRoot(bool isAnimated = true)
		{
			_navigation.PopToRootAsync(isAnimated);
			ShowHideSideMenu(false);
		}

		public void PresentSideMenu()
		{
			ShowHideSideMenu(true);
		}

		public void HideSideMenu()
		{
			ShowHideSideMenu(false);
		}

		private void ShowHideSideMenu(bool isPresent)
		{
			if (_masterDetailPage == null)
				return;

			MessagingCenter.Send<PresentSideMenuMessage>(new PresentSideMenuMessage(isPresent), typeof(PresentSideMenuMessage).ToString());
			_masterDetailPage.IsPresented = isPresent;
		}

		private Page GetPageObject(AppPages pageKey, object parameter)
		{
			if (_pagesByKey.ContainsKey(pageKey))
			{
				var type = _pagesByKey[pageKey];
				ConstructorInfo constructor = null;
				object[] parameters = null;

				if (parameter == null)
				{
					constructor = type.GetTypeInfo()
						.DeclaredConstructors
						.FirstOrDefault(c => !c.GetParameters().Any());

					parameters = new object[]
					{
                        
					};
				}
				else
				{
					constructor = type.GetTypeInfo()
						.DeclaredConstructors
						.FirstOrDefault(
							c =>
							{
								var p = c.GetParameters();
								return p.Count() == 1
										&& p[0].ParameterType == parameter.GetType();
							});

					parameters = new[]
					{
						parameter
					};
				}

				if (constructor == null)
					throw new InvalidOperationException($"No suitable constructor found for page {pageKey}");

				var page = constructor.Invoke(parameters) as Page;
				return page;
			}
			else
				throw new ArgumentException($"No such page: {pageKey}. Did you forget to call NavigationService.Configure?");
		}
	}
}
