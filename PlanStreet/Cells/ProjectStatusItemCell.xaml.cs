using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PlanStreet.Cells
{
    public partial class ProjectStatusItemCell : ViewCell
    {
        public ProjectStatusItemCell()
        {
            InitializeComponent();
            ImgProfile1.Transformations.Add(new FFImageLoading.Transformations.CircleTransformation());
            if (App.ScreenWidth == 320 || App.ScreenHeight == 320)
            {
                LblStatus.FontSize = 12;
            }
        }
    }
}
