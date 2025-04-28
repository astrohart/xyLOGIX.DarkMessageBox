using System.Collections.Generic;
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
        public static int BottomMargin { get; set; } = 12;

        public static Color ButtonBackgroundColor { get; set; } =
            Color.FromArgb(50, 50, 50);

        public static Color ButtonBorderColor { get; set; } =
            Color.FromArgb(70, 70, 70);

        public static int ButtonHeight { get; set; } = 27;
        public static int ButtonSpacing { get; set; } = 6;
        public static Color ButtonTextColor { get; set; } = Color.White;

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
        public static int ButtonWidth { get; set; } = 87;

        public static Color DefaultButtonBackgroundColor { get; set; } =
            Color.FromArgb(60, 60, 90);

        public static Color DefaultButtonBorderColor { get; set; } =
            Color.FromArgb(180, 200, 255);

        public static int DefaultButtonBorderThickness { get; set; } = 2;

        public static Color FooterBackgroundColor { get; set; } =
            Color.FromArgb(45, 45, 45);

        // Overall form and layout colors
        public static Color FormBackgroundColor { get; set; } =
            Color.FromArgb(32, 32, 32);

        public static int FormFooterHeight { get; set; } = 42;

        // Default button visual style
        public static bool HighlightDefaultButtonBackground { get; set; }

        public static int MaximumFormWidth { get; set; } = 600;

        // Optional content (body) icon override
        public static Icon MessageBodyIcon { get; set; }
        public static int MinimumFormWidthMultiButton { get; set; } = 284;
        public static int MinimumFormWidthSingleButton { get; set; } = 117;
        public static int RightMargin { get; set; } = 12;
        public static int SpacerHeight { get; set; } = 18;

        // Titlebar behavior
        public static bool TitleBarIsLight { get; set; }

        // Optional form icon
        public static Icon WindowIcon { get; set; }
    }
}