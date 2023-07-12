using Android.Graphics;

using AndroidX.Core.Graphics;

namespace Tiny.Toolkits.Android
{
    public static class ColorExtensions
    {
        public static bool IsColorDark(this Color color)
        {
            return ColorUtils.CalculateLuminance(color) < 0.5;
        }

        public static Color ToAndroidColor(this System.Drawing.Color color)
        {
            Color acolor = new(color.A, color.R, color.G, color.B);

            return acolor;
        }
         
        public static Color ToDisabledColor(this Color color)
        {
            const float disabledOpacity = 0.38f;
            int r = Color.GetRedComponent(color);
            int g = Color.GetGreenComponent(color);
            int b = Color.GetBlueComponent(color);
            return Color.Argb(Convert.ToInt32(Math.Round(Color.GetAlphaComponent(color) * disabledOpacity)), r, g, b);
        }

        public static Color ToDarkenColor(this Color color)
        {
            const float factor = 0.75f;
            var a = Color.GetAlphaComponent(color);
            var r = Convert.ToInt32(Math.Round(Color.GetRedComponent(color) * factor));
            var g = Convert.ToInt32(Math.Round(Color.GetGreenComponent(color) * factor));
            var b = Convert.ToInt32(Math.Round(Color.GetBlueComponent(color) * factor));
            return Color.Argb(a,
                    Math.Min(r, 255),
                    Math.Min(g, 255),
                    Math.Min(b, 255));
        }

    }
}