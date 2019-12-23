namespace QuickEditor.Common
{
    using UnityEngine;

    public static class QuickEditorColorExtensions
    {
        public static Color WithRed(this Color c, float red)
        {
            return new Color(red, c.g, c.b, c.a);
        }

        public static Color WithGreen(this Color c, float green)
        {
            return new Color(c.r, green, c.b, c.a);
        }

        public static Color WithBlue(this Color c, float blue)
        {
            return new Color(c.r, c.g, blue, c.a);
        }

        public static Color WithAlpha(this Color c, float alpha)
        {
            return new Color(c.r, c.g, c.b, alpha);
        }

        public static Color32 WithRed(this Color32 c, byte red)
        {
            return new Color32(red, c.g, c.b, c.a);
        }

        public static Color32 WithGreen(this Color32 c, byte green)
        {
            return new Color32(c.r, green, c.b, c.a);
        }

        public static Color32 WithBlue(this Color32 c, byte blue)
        {
            return new Color32(c.r, c.g, blue, c.a);
        }

        public static Color32 WithAlpha(this Color32 c, byte alpha)
        {
            return new Color32(c.r, c.g, c.b, alpha);
        }

        public static Color HexToColor(this string s)
        {
            byte r = byte.Parse(s.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte g = byte.Parse(s.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte b = byte.Parse(s.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            return new Color32(r, g, b, 255);
        }
    }
}