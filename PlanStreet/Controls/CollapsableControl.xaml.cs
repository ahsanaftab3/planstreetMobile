using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PlanStreet.Controls
{
    public partial class CollapsableControl : ContentView
    {
        public CollapsableControl()
        {
            InitializeComponent();
            BXSaperator.BindingContext = this;
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string), typeof(CollapsableControl), null, BindingMode.TwoWay, null, (bindable, oldValue, newValue) =>
        {
            ((CollapsableControl)bindable).SetTitle();
        });

        private void SetTitle()
        {
            LblTitle.Text = Title;

        }

        public static readonly BindableProperty ViewsProperty = BindableProperty.Create("Views", typeof(View), typeof(CollapsableControl), null, BindingMode.TwoWay, null, (bindable, oldValue, newValue) =>
        {
            ((CollapsableControl)bindable).AddViewsInCarousel();
        });

        private void AddViewsInCarousel()
        {
            ContainerStack.Children.Add(this.Views);
        }

        public static readonly BindableProperty IsExpandedProperty = BindableProperty.Create("IsExpanded", typeof(bool), typeof(CollapsableControl), true, BindingMode.TwoWay,null,(bindable, oldValue, newValue) => {
            ((CollapsableControl)bindable).SetContentExpanded();
        });


        private void SetContentExpanded()
        {
            ContainerStack.IsVisible = IsExpanded;
            ImgDropDown.Source = ContainerStack.IsVisible ? "ic_dropup_arrow.png" : "ic_dropdown_arrow.png";
        }
        public Xamarin.Forms.View Views
        {
            get { return (Xamarin.Forms.View)GetValue(ViewsProperty); }
            set { SetValue(ViewsProperty, value); }
        }

        void ExpandCollapse_Tapped(object sender, System.EventArgs e)
        {
            
            IsExpanded = !IsExpanded;

        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }

            set { SetValue(TitleProperty, value); }
        }

        public bool IsExpanded
        {
            get { return (bool)GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); }
        }
    }
}
