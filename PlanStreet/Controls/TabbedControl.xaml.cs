using System;
using System.Collections.Generic;
using PlanStreet.Models;
using Xamarin.Forms;
using PlanStreet.Constants;

namespace PlanStreet.Controls
{
    public partial class TabbedControl : ContentView
    {
        public static readonly BindableProperty TitlesProperty = BindableProperty.Create("Titles", typeof(List<TabModel>), typeof(TabbedControl), null, BindingMode.TwoWay, null, (bindable, oldValue, newValue) =>
        {
            ((TabbedControl)bindable).AddTitlesInStack();
        });

        public static readonly BindableProperty ViewsProperty = BindableProperty.Create("Views", typeof(List<View>), typeof(TabbedControl), null, BindingMode.TwoWay, null, (bindable, oldValue, newValue) =>
        {
            ((TabbedControl)bindable).AddViewsInCarousel();
        });

        public static readonly BindableProperty SelectedPositionProperty = BindableProperty.Create("SelectedPosition", typeof(int), typeof(TabbedControl), -1, BindingMode.TwoWay, null, (bindable, oldValue, newValue) =>
        {
            ((TabbedControl)bindable).setSelectedPosition((int)newValue);
        });

        public event EventHandler<int> PositionChanged;

        public List<TabModel> Titles
        {
            get { return (List<TabModel>)GetValue(TitlesProperty); }

            set { SetValue(TitlesProperty, value); }
        }
       
        public List<Xamarin.Forms.View> Views
        {
            get { return (List<Xamarin.Forms.View>)GetValue(ViewsProperty); }
            set { SetValue(ViewsProperty, value); }
        }

        public int SelectedPosition
        {
            get { return (int)GetValue(SelectedPositionProperty); }
            set { SetValue(SelectedPositionProperty, value); }
        }

        private List<Grid> buttonsList = new List<Grid>();

        public TabbedControl()
        {
            InitializeComponent();

            TabbedCarousel.ItemTemplate = new DataTemplate(typeof(View));
            TabbedCarousel.PositionSelected += TabbedCarousel_PositionSelected;

        }

        private void AddTitlesInStack()
        {
            TabContainerStack.Children.Clear();
            foreach (var title in this.Titles)
            {
                Grid buttonGrid = GetTitleAndIndicatorGrid(title.Name, title.Icon);
                buttonsList.Add(buttonGrid);
                TabContainerStack.Children.Add(buttonGrid);
            }
        }


        private void AddViewsInCarousel()
        {
            TabbedCarousel.ItemsSource = this.Views;
        }

        private Grid GetTitleAndIndicatorGrid(string title, ImageSource icon)
        {
            Grid buttonIndicator = new Grid()
            {

                RowDefinitions = new RowDefinitionCollection()
                {
                    new RowDefinition(){ Height = new GridLength(1, GridUnitType.Auto), },
                    new RowDefinition(){ Height = new GridLength(1, GridUnitType.Auto), },
                    new RowDefinition(){ Height = new GridLength(2, GridUnitType.Absolute), }
                },

                ColumnDefinitions = new ColumnDefinitionCollection() {
                    new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star), }
                },

                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            buttonIndicator.RowSpacing = 5;
            Label btnTitleButton = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Text = title,
                FontSize = 10,
                TextColor = AppThemeConstants.UnSelectedTabColor,
            };

          //  btnTitleButton.Clicked += BtnTitleButton_Clicked;

            BoxView boxView = new BoxView()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.End,
                BackgroundColor = AppThemeConstants.UnSelectedTabColor
            };
            Image image = new Image()
            {
                Aspect = Aspect.AspectFit,
                Margin = new Thickness(0, 10, 0, 0),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Source = icon
            };
            if (icon != null)
            {
                image.WidthRequest = 20;
                HeightRequest = 20;
            }
            buttonIndicator.Children.Add(image, 0, 0);
            buttonIndicator.Children.Add(btnTitleButton, 0, 1);
            buttonIndicator.Children.Add(boxView, 0, 2);
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
            buttonIndicator.GestureRecognizers.Add(tapGestureRecognizer);
            return buttonIndicator;
        }

        private void TabbedCarousel_PositionSelected(object sender, CarouselView.FormsPlugin.Abstractions.PositionSelectedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Position Selected : {e.NewValue}");
            setSelectedPosition(e.NewValue);
        }

        void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Grid grid = (Grid)sender;
            //Button clickedButton = (Button)sender;

           // System.Diagnostics.Debug.WriteLine($"clicked button text : {clickedButton.Text}");
            for (int i = 0; i < buttonsList.Count; i++)
            {
                if (grid == buttonsList[i])
                {
                    buttonsList[i].Children[2].BackgroundColor = AppThemeConstants.SelectedTabColor;
                    Image img = buttonsList[i].Children[0] as Image;
                    if (img != null)
                    {
                        img.Source = this.Titles[i].SelectedIcon;
                    }
                    Label btn = buttonsList[i].Children[1] as Label;
                    if (btn != null)
                    {
                        btn.TextColor = AppThemeConstants.SelectedTabColor;
                    }
                    TabbedCarousel.Position = i;
                    SelectedPosition = TabbedCarousel.Position;
                    PositionChanged?.Invoke(this, SelectedPosition);
                }
                else
                {
                    buttonsList[i].Children[2].BackgroundColor = AppThemeConstants.UnSelectedTabColor;
                    Label btn = buttonsList[i].Children[1] as Label;
                    if (btn != null)
                    {
                        btn.TextColor = AppThemeConstants.UnSelectedTabColor;
                    }
                    Image img = buttonsList[i].Children[0] as Image;
                    if (img != null)
                    {
                        img.Source = this.Titles[i].Icon;
                    }

                }
            }
        }


        private void BtnTitleButton_Clicked(object sender, System.EventArgs e)
        {
            Button clickedButton = (Button)sender;

            System.Diagnostics.Debug.WriteLine($"clicked button text : {clickedButton.Text}");
            for (int i = 0; i < buttonsList.Count; i++)
            {
                if (clickedButton.Text.Equals(((Button)buttonsList[i].Children[1]).Text))
                {
                    buttonsList[i].Children[2].BackgroundColor = AppThemeConstants.SelectedTabColor;
                    Image img = buttonsList[i].Children[0] as Image;
                    if (img != null)
                    {
                        img.Source = this.Titles[i].SelectedIcon;
                    }
                    Label btn = buttonsList[i].Children[1] as Label;
                    if (btn != null)
                    {
                        btn.TextColor = AppThemeConstants.SelectedTabColor;
                    }
                    TabbedCarousel.Position = i;
                    SelectedPosition = TabbedCarousel.Position;
                    PositionChanged?.Invoke(this, SelectedPosition);
                }
                else
                {
                    buttonsList[i].Children[2].BackgroundColor = AppThemeConstants.UnSelectedTabColor;
                    Label btn = buttonsList[i].Children[1] as Label;
                    if (btn != null)
                    {
                        btn.TextColor = AppThemeConstants.UnSelectedTabColor;
                    }
                    Image img = buttonsList[i].Children[0] as Image;
                    if (img != null)
                    {
                        img.Source = this.Titles[i].Icon;
                    }

                }
            }
        }

        private void setSelectedPosition(int selectedPosition)
        {
            if (SelectedPosition == selectedPosition && TabbedCarousel.Position == SelectedPosition)
                return;

            for (int i = 0; i < buttonsList.Count; i++)
            {

                buttonsList[i].Children[2].BackgroundColor = selectedPosition == i ? AppThemeConstants.SelectedTabColor : AppThemeConstants.UnSelectedTabColor;

                Image img = buttonsList[i].Children[0] as Image;
                if (img != null)
                {
                    img.Source = selectedPosition == i ? this.Titles[i].SelectedIcon : this.Titles[i].Icon;
                }
                Label btn = buttonsList[i].Children[1] as Label;
                if (btn != null)
                {
                    btn.TextColor = selectedPosition == i ? AppThemeConstants.SelectedTabColor : AppThemeConstants.UnSelectedTabColor;
                }
            }

            if (TabbedCarousel.Position != selectedPosition)
                TabbedCarousel.Position = selectedPosition;

            PositionChanged?.Invoke(this, selectedPosition);

            if (SelectedPosition != TabbedCarousel.Position)
                SelectedPosition = TabbedCarousel.Position;
        }
    }
}
