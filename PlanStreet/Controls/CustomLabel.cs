using System;
using Xamarin.Forms;
namespace PlanStreet.Controls
{
    public class CustomLabel : Label
    {
        public static readonly BindableProperty CurvedCornerRadiusProperty =
    BindableProperty.Create(
        nameof(CornerRadius),
        typeof(double),
                typeof(CustomLabel),
        2.0);

        public static readonly BindableProperty CurvedBackgroundColorProperty =
    BindableProperty.Create(
        nameof(CurvedBackgroundColor),
        typeof(Color),
                typeof(CustomLabel),
        Color.Default);
        public Color CurvedBackgroundColor
        {
            get { return (Color)GetValue(CurvedBackgroundColorProperty); }
            set { SetValue(CurvedBackgroundColorProperty, value); }
        }


        public double CornerRadius
        {
            get { return (double)GetValue(CurvedCornerRadiusProperty); }
            set { SetValue(CurvedCornerRadiusProperty, value); }
        }
        public CustomLabel()
        {
        }


    }
}
