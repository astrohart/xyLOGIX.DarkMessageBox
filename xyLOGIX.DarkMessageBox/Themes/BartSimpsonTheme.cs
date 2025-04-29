using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using xyLOGIX.DarkMessageBox.Interfaces;
using xyLOGIX.DarkMessageBox.Properties;

namespace xyLOGIX.DarkMessageBox.Themes
{
    /// <summary>
    /// A fun "Bart Simpson" style theme for
    /// <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox" />
    /// dialogs.
    /// </summary>
    public sealed class BartSimpsonTheme : IDarkMessageBoxTheme
    {
        /// <summary>
        /// Empty, <c>static</c> constructor to prohibit direct allocation of this class.
        /// </summary>
        static BartSimpsonTheme() { }

        /// <summary>
        /// Empty, <c>private</c> constructor to prohibit direct allocation of this class.
        /// </summary>
        private BartSimpsonTheme() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see cref="T:xyLOGIX.DarkMessageBox.Interfaces.IDarkMessageBoxTheme" />
        /// interface.
        /// </summary>
        public static IDarkMessageBoxTheme Instance
        {
            [DebuggerStepThrough] get;
        } = new BartSimpsonTheme();

        /// <summary>
        /// Applies the theme to
        /// <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics" />.
        /// </summary>
        public void Apply()
        {
            DarkMessageBoxMetrics.FormBackgroundColor =
                Color.FromArgb(255, 246, 163); // #FFF6A3
            DarkMessageBoxMetrics.FooterBackgroundColor =
                Color.FromArgb(239, 220, 112); // #EFDC70
            DarkMessageBoxMetrics.ButtonBackgroundColor = Color.DarkGoldenrod;
            DarkMessageBoxMetrics.ButtonTextColor =
                Color.FromArgb(31, 31, 31); // #1F1F1F
            DarkMessageBoxMetrics.ButtonBorderColor = Color.Goldenrod;
            DarkMessageBoxMetrics.MessageTextColor =
                Color.FromArgb(31, 31, 31); // #1F1F1F

            DarkMessageBoxMetrics.HighlightDefaultButtonBackground = true;
            DarkMessageBoxMetrics.DefaultButtonBackgroundColor = Color.Gold;
            DarkMessageBoxMetrics.DefaultButtonBorderColor = Color.Orange;
            DarkMessageBoxMetrics.DefaultButtonBorderThickness = 2;

            DarkMessageBoxMetrics.TitleBarIsLight = false;

            DarkMessageBoxMetrics.ButtonTexts[DialogResult.OK] =
                "&Eat my shorts!";
            DarkMessageBoxMetrics.ButtonTexts[DialogResult.Cancel] =
                "&Don't have a cow!";
            DarkMessageBoxMetrics.ButtonTexts[DialogResult.Yes] =
                "&Ay caramba!";
            DarkMessageBoxMetrics.ButtonTexts[DialogResult.No] =
                "&No way, man!";
            DarkMessageBoxMetrics.ButtonTexts[DialogResult.Abort] = "&Drop it!";
            DarkMessageBoxMetrics.ButtonTexts[DialogResult.Retry] =
                "&Try again, dude!";
            DarkMessageBoxMetrics.ButtonTexts[DialogResult.Ignore] =
                "&Whatever!";

            // Optional: set a funny Bart icon if you want
            DarkMessageBoxMetrics.MessageBodyIcon =
                Resources.bart_simpson_logo_vector1;
        }
    }
}