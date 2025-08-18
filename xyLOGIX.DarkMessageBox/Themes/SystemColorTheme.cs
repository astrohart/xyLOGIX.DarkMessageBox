using System.Diagnostics;
using System.Drawing;
using xyLOGIX.DarkMessageBox.Interfaces;

namespace xyLOGIX.DarkMessageBox.Themes
{
    /// <summary>
    /// A theme that styles <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox" />
    /// according to the value(s) in the <see cref="T:System.Drawing.SystemColors" />
    /// class.
    /// </summary>
    public class SystemColorTheme : IDarkMessageBoxTheme
    {
        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of this class.
        /// </summary>
        static SystemColorTheme() { }

        /// <summary>
        /// Empty, private constructor to prohibit direct allocation of this class.
        /// </summary>
        private SystemColorTheme() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see cref="T:xyLOGIX.DarkMessageBox.Interfaces.IDarkMessageBoxTheme" />
        /// interface.
        /// </summary>
        public static IDarkMessageBoxTheme Instance
        {
            [DebuggerStepThrough] get;
        } = new SystemColorTheme();

        /// <summary>
        /// Applies the theme to
        /// <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics" />.
        /// </summary>
        /// <remarks>
        /// If this method is overriden, the base-class version must be called
        /// first.
        /// </remarks>
        public virtual void Apply()
        {
            DarkMessageBoxMetrics.FormBackgroundColor =
                SystemColors.Window; // typical window background
            DarkMessageBoxMetrics.FooterBackgroundColor =
                SystemColors.ControlLight; // one shade lighter than ButtonFace
            DarkMessageBoxMetrics.FlatButtons = false;

            DarkMessageBoxMetrics.ButtonBackgroundColor =
                SystemColors.ButtonFace;
            DarkMessageBoxMetrics.ButtonBorderColor = SystemColors.ButtonShadow;
            DarkMessageBoxMetrics.ButtonTextColor = SystemColors.ControlText;

            DarkMessageBoxMetrics.HighlightDefaultButtonBackground = false;
            DarkMessageBoxMetrics.DefaultButtonBorderColor =
                SystemColors.Highlight;
            DarkMessageBoxMetrics.DefaultButtonBorderThickness = 2;

            DarkMessageBoxMetrics.MessageTextColor = SystemColors.ControlText;

            DarkMessageBoxMetrics.TitleBarIsLight = true;
        }
    }
}