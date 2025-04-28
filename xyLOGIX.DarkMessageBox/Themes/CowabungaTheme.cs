using System.Drawing;
using System.Windows.Forms;
using xyLOGIX.DarkMessageBox.Interfaces;

namespace xyLOGIX.DarkMessageBox.Themes
{
    /// <summary>
    /// A "Cowabunga Dude" theme for <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox" /> dialogs.
    /// </summary>
    public sealed class CowabungaTheme : IDarkMessageBoxTheme
    {
        public void Apply()
        {
            DarkMessageBoxMetrics.FormBackgroundColor =
                Color.FromArgb(20, 20, 20);
            DarkMessageBoxMetrics.FooterBackgroundColor =
                Color.FromArgb(40, 40, 40);
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
                "&No Way, Dude!";
            DarkMessageBoxMetrics.ButtonTexts[DialogResult.Yes] = "&Radical!";
            DarkMessageBoxMetrics.ButtonTexts[DialogResult.No] = "&Bogus!";
            DarkMessageBoxMetrics.ButtonTexts[DialogResult.Abort] = "&Bail!";
            DarkMessageBoxMetrics.ButtonTexts[DialogResult.Retry] =
                "&Try Again!";
            DarkMessageBoxMetrics.ButtonTexts[DialogResult.Ignore] =
                "&Shell Shock!";

            // Optional: TMNT icon
            // DarkMessageBoxMetrics.MessageBodyIcon = new Icon("tmnt.ico");
        }
    }
}