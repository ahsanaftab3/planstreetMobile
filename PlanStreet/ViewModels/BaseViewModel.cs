using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;

namespace PlanStreet.ViewModels
{
	public class BaseViewModel : ViewModelBase
    {
        public BaseViewModel()
        {
        }
        //protected void SetObservableProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        //{
        //    if (EqualityComparer<T>.Default.Equals(field, value)) return;
        //    field = value;
        //    RaisePropertyChanged(propertyName);
        //}
    }
}
