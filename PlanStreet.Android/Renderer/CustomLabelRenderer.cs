using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Util;
using PlanStreet.Controls;
using PlanStreet.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
namespace PlanStreet.Droid.Renderer
{
    public class CustomLabelRenderer : LabelRenderer
    {
        private GradientDrawable _gradientBackground;
        public CustomLabelRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;
            }
            var view = (CustomLabel)Element;
            if (view == null) return;

            _gradientBackground = new GradientDrawable();
            _gradientBackground.SetShape(ShapeType.Rectangle);
            _gradientBackground.SetColor(view.CurvedBackgroundColor.ToAndroid());

            // Thickness of the stroke line
            _gradientBackground.SetStroke(4, Color.White.ToAndroid());

            // Radius for the curves
            _gradientBackground.SetCornerRadius(DpToPixels(Forms.Context, (float)view.CornerRadius));

            // set the background of the label
            Control.SetBackground(_gradientBackground);
        
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var view = (CustomLabel)Element;
            if (view == null) return;

            // creating gradient drawable for the curved background

            _gradientBackground.SetShape(ShapeType.Rectangle);
            _gradientBackground.SetColor(view.CurvedBackgroundColor.ToAndroid());

            // Thickness of the stroke line
            _gradientBackground.SetStroke(4, Color.White.ToAndroid());

            // Radius for the curves
            _gradientBackground.SetCornerRadius(DpToPixels(Forms.Context, (float)view.CornerRadius));

            // set the background of the label
            Control.SetBackground(_gradientBackground);
        }

        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}
