using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace xyLOGIX.DarkMessageBox
{
    /// <summary>
    /// Defines customizable appearance and behavior settings for
    /// <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox" /> dialogs.
    /// </summary>
    public static class DarkMessageBoxMetrics
    {
        /// <summary>
        /// Gets or sets the distance, in pixels, of the bottom-most edge of the buttons from the bottom of the client area of a <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox"/>.
        /// </summary>
        /// <remarks>The default value of this property is 12 pixels.<para/>This value must be set to one (1) or greater.  If it is not, then the default value of 12 pixels is used.</remarks>
        public static int BottomMargin
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = 12;

        public static Color ButtonBackgroundColor
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = Color.FromArgb(50, 50, 50);

        public static Color ButtonBorderColor
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = Color.FromArgb(70, 70, 70);

        public static int ButtonHeight
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = 27;

        public static int ButtonSpacing
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = 6;

        public static Color ButtonTextColor
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = Color.White;

        // Button text overrides
        public static Dictionary<DialogResult, string> ButtonTexts { get; } =
            new Dictionary<DialogResult, string>
            {
                { DialogResult.OK, "OK" },
                { DialogResult.Cancel, "Cancel" },
                { DialogResult.Yes, "&Yes" },
                { DialogResult.No, "&No" },
                { DialogResult.Abort, "&Abort" },
                { DialogResult.Retry, "&Retry" },
                { DialogResult.Ignore, "&Ignore" }
            };

        // Layout and sizing
        public static int ButtonWidth
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = 87;

        public static Color DefaultButtonBackgroundColor
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = Color.FromArgb(60, 60, 90);

        public static Color DefaultButtonBorderColor
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = Color.FromArgb(180, 200, 255);

        public static int DefaultButtonBorderThickness
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = 2;

        public static Color FooterBackgroundColor
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = Color.FromArgb(45, 45, 45);

        // Overall form and layout colors
        public static Color FormBackgroundColor
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = Color.FromArgb(32, 32, 32);

        public static int FormFooterHeight
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = 42;

        // Default button visual style
        public static bool HighlightDefaultButtonBackground
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }

        public static int MaximumFormWidth
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = 600;

        // Optional content (body) icon override
        public static Icon MessageBodyIcon
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }

        public static int MinimumFormWidthMultiButton
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = 284;

        public static int MinimumFormWidthSingleButton
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = 117;

        public static int RightMargin
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = 12;

        public static int SpacerHeight
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = 18;

        public static bool SuppressAutoReset
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }

        // Titlebar behavior
        public static bool TitleBarIsLight
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }

        // Optional form icon
        public static Icon WindowIcon
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }
    }
}