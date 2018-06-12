using System;
using System.ComponentModel;
using PlanStreet.Controls;
using PlanStreet.iOS.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
namespace PlanStreet.iOS.Renderer
{
	public class CustomLabelRenderer : LabelRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var _xfViewReference = (CustomLabel)Element;
            this.Layer.CornerRadius = (float)_xfViewReference.CornerRadius;
            this.BackgroundColor = _xfViewReference.CurvedBackgroundColor.ToUIColor();
        
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var _xfViewReference = (CustomLabel)Element;
                // Radius for the curves
                this.Layer.CornerRadius = (float)_xfViewReference.CornerRadius;
                this.BackgroundColor = _xfViewReference.CurvedBackgroundColor.ToUIColor();
                this.Layer.MasksToBounds = true;
            }
        }



    }
}
