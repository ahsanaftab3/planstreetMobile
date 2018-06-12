using System;
using Xamarin.Forms;

namespace PlanStreet.Constants
{
    public class AppThemeConstants
    {
        // Color Constants Start
        public static Color SelectedTabColor = Color.FromHex("#83CA69");
        public static Color UnSelectedTabColor = Color.FromHex("#000000");
        public static Color BlackColor = Color.FromHex("#000000");
        public static Color LightGrayColor = Color.FromHex("#E1E1E1");
        public static Color DarkGrayColor = Color.Gray;
        public static Color WhiteColor = Color.White;
		public static Color TransparentWhiteColor = Color.FromHex("#55FFFFFF");
        public static Color ButtonBackgroundColor = Color.Pink;
		public static Color BackgroundColor = Color.FromHex("#F0F3F9");
		public static Color LightPurpleColor = Color.FromHex("#B7BEFF");

        public static Color StatusNotStartedColor = Color.FromRgb(93, 126, 253);
        public static Color StatusInProcessColor = Color.FromRgb(77, 160, 254);
        public static Color StatusInReviewColor = Color.FromRgb(253, 196, 79);
        public static Color StatusCompletedColor = Color.FromRgb(112, 216, 124);

        public static Color LowPriorityColor = Color.FromRgb(112, 216, 124);
		public static Color MediumPriorityColor = Color.Orange;
		public static Color HighPriorityColor = Color.Red.MultiplyAlpha(0.8);
        // Color Constants Over.

        // Fonts Constants Start
        public static double TitleFontSize = 26;
        public static double LargeFontSize = 24;
        public static double MediumFontSize = 22;
        public static double SmallFontSize = 20;
        public static double XtraSmallFontSize = 16;
        public static double XXSmallFontSize = 14;
        public static double VerySmallFontSize = 12;
        // Fonts Constants Over
    }
}
