using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PlanStreet.Cells
{
    public partial class ProjectItemCell : ViewCell
    {
        public ProjectItemCell()
        {
            InitializeComponent();
            ImgProfile1.Transformations.Add(new FFImageLoading.Transformations.CircleTransformation());
            ImgProfile2.Transformations.Add(new FFImageLoading.Transformations.CircleTransformation());
            ImgProfile3.Transformations.Add(new FFImageLoading.Transformations.CircleTransformation());
        }
    }
}
