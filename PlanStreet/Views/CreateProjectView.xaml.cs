using System;
using System.Collections.Generic;
using PlanStreet.Constants;
using PlanStreet.ViewModels;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using PlanStreet.Enums;
using PlanStreet.Messages;
using Xamarin.Forms;

namespace PlanStreet.Views
{
    public partial class CreateProjectView : ContentPage
    {
        CreateProjectViewModel _createProjectViewModel;
        PriorityType Type = PriorityType.Medium;
        public CreateProjectView()
        {
            _createProjectViewModel = App.Locator.CreateProjectViewModel;

            InitializeComponent();
            BindingContext = _createProjectViewModel;
            NavigationPage.SetBackButtonTitle(this, "");
            ImgProfile1.Transformations.Add(new FFImageLoading.Transformations.CircleTransformation());
            ImgProfile2.Transformations.Add(new FFImageLoading.Transformations.CircleTransformation());
            ImgProfile3.Transformations.Add(new FFImageLoading.Transformations.CircleTransformation());

            CanvasView.PaintSurface += SKCanvasView_PaintSurface;
            MessagingCenter.Subscribe<PriorityChangedMessage>(this, MessageConstants.PriorityChangedMessage, (obj) =>
            {
                Type = obj.SelectedPriority;
                CanvasView.InvalidateSurface();
            });
        }

        void SKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();

            var color = AppThemeConstants.LowPriorityColor;
            switch (Type)
            {
                case PriorityType.Low:
                    color = AppThemeConstants.LowPriorityColor;
                    break;
                case PriorityType.Medium:
                    color = AppThemeConstants.MediumPriorityColor;
                    break;
                case PriorityType.High:
                    color = AppThemeConstants.HighPriorityColor;
                    break;
                default:
                    break;
            }
            canvas.DrawRoundRect(0, 0, info.Width, info.Height - 5, 15, 15, new SKPaint()
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 3,
                StrokeCap = SKStrokeCap.Round,
                StrokeJoin = SKStrokeJoin.Round,
                Color = color.ToSKColor(),
                PathEffect = SKPathEffect.CreateDash(new float[] { 4, 4 }, 3f),
            });
        }

        void DatePicker_Tapped(object sender, System.EventArgs e)
        {
            datePicker.Focus();
        }

        void DatePicker_Unfocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            LblDate.Text = datePicker.Date.ToString("MMM dd, yyyy");
        }


        void TimePicker_Tapped(object sender, System.EventArgs e)
        {
            timePicker.Focus();
        }

        void SelectProject_Tapped(object sender, System.EventArgs e)
        {
            ProjectsPicker.Focus();
        }

        void ProjectPicker_Unfocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            
        }

        void TimePicker_Unfocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            LblTime.Text = $"{timePicker.Time.Hours} hrs : {timePicker.Time.Minutes} min";
        }

    }
}
