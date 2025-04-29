using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using xyLOGIX.DarkMessageBox.Interfaces;

namespace xyLOGIX.DarkMessageBox.Themes
{
    /// <summary>
    /// A standard default theme for
    /// <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox" /> dialogs.
    /// </summary>
    public sealed class ProfessionalDarkTheme : IDarkMessageBoxTheme
    {
        /// <summary>
        /// Empty, <c>static</c> constructor to prohibit direct allocation of this class.
        /// </summary>
        static ProfessionalDarkTheme() { }

        /// <summary>
        /// Empty, <c>private</c> constructor to prohibit direct allocation of this class.
        /// </summary>
        private ProfessionalDarkTheme() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see cref="T:xyLOGIX.DarkMessageBox.Interfaces.IDarkMessageBoxTheme" />
        /// interface.
        /// </summary>
        public static IDarkMessageBoxTheme Instance
        {
            [DebuggerStepThrough] get;
        } = new ProfessionalDarkTheme();

        public void Apply()
        {
            DarkMessageBoxMetrics.FormBackgroundColor =
                Color.FromArgb(32, 32, 32);
            DarkMessageBoxMetrics.FooterBackgroundColor =
                Color.FromArgb(45, 45, 45);
            DarkMessageBoxMetrics.ButtonBackgroundColor =
                Color.FromArgb(50, 50, 50);
            DarkMessageBoxMetrics.ButtonTextColor = Color.White;
            DarkMessageBoxMetrics.ButtonBorderColor =
                Color.FromArgb(70, 70, 70);

            DarkMessageBoxMetrics.HighlightDefaultButtonBackground = false;
            DarkMessageBoxMetrics.DefaultButtonBackgroundColor =
                Color.FromArgb(60, 60, 90);
            DarkMessageBoxMetrics.DefaultButtonBorderColor =
                Color.FromArgb(180, 200, 255);
            DarkMessageBoxMetrics.DefaultButtonBorderThickness = 2;

            DarkMessageBoxMetrics.TitleBarIsLight = false;

            DarkMessageBoxMetrics.ButtonTexts[DialogResult.OK] = "OK";
            DarkMessageBoxMetrics.ButtonTexts[DialogResult.Cancel] = "Cancel";
            DarkMessageBoxMetrics.ButtonTexts[DialogResult.Yes] = "&Yes";
            DarkMessageBoxMetrics.ButtonTexts[DialogResult.No] = "&No";
            DarkMessageBoxMetrics.ButtonTexts[DialogResult.Abort] = "&Abort";
            DarkMessageBoxMetrics.ButtonTexts[DialogResult.Retry] = "&Retry";
            DarkMessageBoxMetrics.ButtonTexts[DialogResult.Ignore] = "&Ignore";

            DarkMessageBoxMetrics.WindowIcon = null;
            DarkMessageBoxMetrics.MessageBodyIcon = null;
        }
    }
}