﻿using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using xyLOGIX.DarkMessageBox.Interfaces;
using xyLOGIX.DarkMessageBox.Properties;

namespace xyLOGIX.DarkMessageBox.Themes
{
    /// <summary>
    /// A "Cowabunga Dude" theme for
    /// <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox" /> dialogs.
    /// </summary>
    public class CowabungaTheme : IDarkMessageBoxTheme
    {
        /// <summary>
        /// Empty, <c>static</c> constructor to prohibit direct allocation of this class.
        /// </summary>
        static CowabungaTheme() { }

        /// <summary>
        /// Empty, <c>private</c> constructor to prohibit direct allocation of this class.
        /// </summary>
        private CowabungaTheme() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see cref="T:xyLOGIX.DarkMessageBox.Interfaces.IDarkMessageBoxTheme" />
        /// interface.
        /// </summary>
        public static IDarkMessageBoxTheme Instance
        {
            [DebuggerStepThrough] get;
        } = new CowabungaTheme();

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
            DarkMessageBoxMetrics.Reset();

            DarkMessageBoxMetrics.FormBackgroundColor =
                Color.FromArgb(88, 136, 245);
            DarkMessageBoxMetrics.FooterBackgroundColor =
                Color.FromArgb(213, 99, 44);
            DarkMessageBoxMetrics.ButtonBackgroundColor = Color.DarkSeaGreen;
            DarkMessageBoxMetrics.ButtonTextColor = Color.Black;
            DarkMessageBoxMetrics.ButtonBorderColor = Color.MediumSeaGreen;

            DarkMessageBoxMetrics.HighlightDefaultButtonBackground = true;
            DarkMessageBoxMetrics.DefaultButtonBackgroundColor = Color.SeaGreen;
            DarkMessageBoxMetrics.DefaultButtonBorderColor = Color.LimeGreen;
            DarkMessageBoxMetrics.DefaultButtonBorderThickness = 2;

            DarkMessageBoxMetrics.TitleBarIsLight = false;

            DarkMessageBoxMetrics.ButtonTexts[DialogResult.OK] = "&Cowabunga!";
            DarkMessageBoxMetrics.ButtonTexts[DialogResult.Cancel] =
                "&Let's quit while we're ahead!";
            DarkMessageBoxMetrics.ButtonTexts[DialogResult.Yes] = "&Radical!";
            DarkMessageBoxMetrics.ButtonTexts[DialogResult.No] = "&Bogus!";
            DarkMessageBoxMetrics.ButtonTexts[DialogResult.Abort] = "&Bail!";
            DarkMessageBoxMetrics.ButtonTexts[DialogResult.Retry] =
                "Can &we try that again?";
            DarkMessageBoxMetrics.ButtonTexts[DialogResult.Ignore] =
                "&Shell Shock!";

            DarkMessageBoxMetrics.MessageBodyIcon = Resources.michelangelo;
        }
    }
}