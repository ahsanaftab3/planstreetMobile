using System;
using Xamarin.Forms;
using PlanStreet.ViewModels;
using PlanStreet.Enums;

namespace PlanStreet.Models
{
    public class PriorityModelItem : BaseViewModel
    {
       
        public string PriorityName { get; set; }
        public Color PriorityColor { get; set; }
        public PriorityType PriorityType { get; set; }
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
        public PriorityModelItem()
        {
        }
        public PriorityModelItem(string name, Color color, bool isSelected, PriorityType type)
        {
            PriorityName = name;
            PriorityColor = color;
            IsSelected = isSelected;
            PriorityType = type;
        }
    }
}
