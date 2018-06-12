using System;
using PlanStreet.ViewModels;
using Xamarin.Forms;

namespace PlanStreet.Models
{
    public class StatusModelItem : BaseViewModel
    {
        public string Status { get; set; }
        public Color StatusColor { get; set; }
        private bool _isSelected;

        public bool IsSelected 
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                RaisePropertyChanged("IsSelected");
            }
        }
        public StatusModelItem()
        {
        }
        public StatusModelItem(string name, Color color, bool isSelected)
        {
            Status = name;
            StatusColor = color;
            IsSelected = isSelected;
        }
    }
}
