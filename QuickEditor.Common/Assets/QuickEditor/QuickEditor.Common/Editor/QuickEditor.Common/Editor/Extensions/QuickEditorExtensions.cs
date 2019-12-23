namespace QuickEditor.Common
{
    using System;
    using System.Collections;
    using System.Text.RegularExpressions;
    using UnityEditor;
    using UnityEngine;

    public static class QuickEditorExtensions
    {

        public static IList ForEach(this IList source, Action action)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            foreach (var item in source)
                action();

            return source;
        }

        #region String Extensions

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            if (value != null)
            {
                int length = value.Length;
                for (int i = 0; i < length; i++)
                {
                    if (!char.IsWhiteSpace(value[i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="value"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string Format(this string value, params object[] args)
        {
            return args.Length > 0 ? string.Format(value, args) : value;
        }

        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="value"></param>
        /// <param name="arg0"></param>
        /// <returns></returns>
        public static string Format(this string value, object arg0)
        {
            return arg0 != null ? string.Format(value, arg0) : value;
        }

        public static int ToInt(this string value)
        {
            return Int32.Parse(value);
        }

        public static int TryParseInt32(this string str, int defaultValue)
        {
            int result = defaultValue;
            return int.TryParse(str, out result) ? result : defaultValue;
        }

        public static bool IsURL(this string source)
        {
            if (source.IsNullOrEmpty()) { return false; }// TODO: raise exception or log error
            Uri uriResult;
            return Uri.TryCreate(source, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        public static bool IsMatch(this string input, string pattern)
        {
            if (input.IsNullOrEmpty()) return false;
            else return Regex.IsMatch(input, pattern);
        }

        public static string Match(this string input, string pattern)
        {
            if (input.IsNullOrEmpty()) return string.Empty;
            return Regex.Match(input, pattern).Value;
        }

        #endregion String Extensions
    }

    public static class QuickEditorWindowExtensions
    {
        public static EditorWindow minSize(this EditorWindow window, Vector2 minSize)
        {
            window.minSize = minSize;
            return window;
        }

        public static EditorWindow maxSize(this EditorWindow window, Vector2 maxSize)
        {
            window.maxSize = maxSize;
            return window;
        }
    }

    public static class QuickEditorRectExtensions
    {
        public static Rect WindowRect(this Rect rect)
        {
            return new Rect(rect)
            {
                x = 0,
                y = 0
            };
        }

        public static Rect WithPadding(this Rect rect, float padding)
        {
            rect.x += padding;
            rect.xMax -= padding * 2;
            rect.y += padding;
            rect.yMax -= padding * 2;

            return rect;
        }

        public static Rect WithX(this Rect rect, float newX)
        {
            rect.x = newX;
            return rect;
        }

        public static Rect WithY(this Rect rect, float newY)
        {
            rect.y = newY;
            return rect;
        }

        public static Rect WithXMax(this Rect rect, float newXMax)
        {
            rect.xMax = newXMax;
            return rect;
        }

        public static Rect WithYMax(this Rect rect, float newYMax)
        {
            rect.yMax = newYMax;
            return rect;
        }

        public static Rect WithW(this Rect rect, float newW)
        {
            rect.width = newW;
            return rect;
        }

        public static Rect WithH(this Rect rect, float newH)
        {
            rect.height = newH;
            return rect;
        }
    }

}
