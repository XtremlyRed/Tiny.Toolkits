using System.Drawing;

namespace Tiny.Toolkits
{
    /// <summary>
    /// 
    /// </summary>
    public static class ColorExtensions
    {

        public static Color Lerp(this Color colour, Color to, float amount)
        {
            // start colours as lerp-able floats
            float sr = colour.R, sg = colour.G, sb = colour.B;

            // end colours as lerp-able floats
            float er = to.R, eg = to.G, eb = to.B;

            // lerp the colours to get the difference
            byte r = (byte)Lerp(sr, er, amount),
                 g = (byte)Lerp(sg, eg, amount),
                 b = (byte)Lerp(sb, eb, amount);

            // return the new colour
            return Color.FromArgb(r, g, b);

            static float Lerp(float start, float end, float amount)
            {
                float difference = end - start;
                float adjusted = difference * amount;
                return start + adjusted;
            }
        }
    }
}
