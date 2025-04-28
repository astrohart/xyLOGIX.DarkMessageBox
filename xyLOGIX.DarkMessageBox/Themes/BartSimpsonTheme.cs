using System.Drawing;
using System.Windows.Forms;
using xyLOGIX.DarkMessageBox.Interfaces;

namespace xyLOGIX.DarkMessageBox.Themes
{
    /// <summary>
    /// A fun "Bart Simpson" style theme for <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox" />
    /// dialogs.
    /// </summary>
    public sealed class BartSimpsonTheme : IDarkMessageBoxTheme
    {
        public void Apply()
        {
            DarkMessageBoxMetrics.FormBackgroundColor =
                Color.FromArgb(30, 30, 30);
            DarkMessageBoxMetrics.FooterBackgroundColor =
                Color.FromArgb(50, 50, 50);
            DarkMessageBoxMetrics.ButtonBackgroundColor = Color.DarkGoldenrod;
            DarkMessageBoxMetrics.ButtonTextColor = Color.Black;
            DarkMessageBoxMetrics.ButtonBorderColor = Color.Goldenrod;

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
            // DarkMessageBoxMetrics.MessageBodyIcon = new Icon("bart.ico");
        }
    }
}