using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using xyLOGIX.DarkMessageBox.Interfaces;

namespace xyLOGIX.DarkMessageBox.Themes
{
    // -----------------------------------------------------------------------------
    // Helper “theme” that simply remembers the current metrics and restores them
    // when its Apply() is called.  This lets us use ThemeManager.WithTemporaryTheme
    // to handle push / pop without any manual snapshot code.
    // -----------------------------------------------------------------------------
    internal sealed class MetricsSnapshotTheme : IDarkMessageBoxTheme
    {
        private readonly Icon _bodyIcon = DarkMessageBoxMetrics.MessageBodyIcon;

        // ---- numeric values ----
        private readonly int _bottomMargin = DarkMessageBoxMetrics.BottomMargin;

        // ---- colours ----
        private readonly Color _btnBack =
            DarkMessageBoxMetrics.ButtonBackgroundColor;

        private readonly Color _btnBorder =
            DarkMessageBoxMetrics.ButtonBorderColor;

        private readonly Color _btnText = DarkMessageBoxMetrics.ButtonTextColor;
        private readonly int _buttonHeight = DarkMessageBoxMetrics.ButtonHeight;

        private readonly int _buttonSpacing =
            DarkMessageBoxMetrics.ButtonSpacing;

        private readonly int _buttonWidth = DarkMessageBoxMetrics.ButtonWidth;

        private readonly FixedSizeDictionary<DialogResult, string> _captions =
            new FixedSizeDictionary<DialogResult, string>(
                DarkMessageBoxMetrics.ButtonTexts
            );

        private readonly int _defaultBtnBorderThickness =
            DarkMessageBoxMetrics.DefaultButtonBorderThickness;

        private readonly Color _defBtnBack =
            DarkMessageBoxMetrics.DefaultButtonBackgroundColor;

        private readonly Color _defBtnBorder =
            DarkMessageBoxMetrics.DefaultButtonBorderColor;

        private readonly Color _footerBack =
            DarkMessageBoxMetrics.FooterBackgroundColor;

        private readonly Color _formBack =
            DarkMessageBoxMetrics.FormBackgroundColor;

        private readonly int _formFooterHeight =
            DarkMessageBoxMetrics.FormFooterHeight;

        // ---- bools ----
        private readonly bool _highlightDefault =
            DarkMessageBoxMetrics.HighlightDefaultButtonBackground;

        private readonly int _maximumFormWidth =
            DarkMessageBoxMetrics.MaximumFormWidth;

        private readonly int _minFormWidthMulti =
            DarkMessageBoxMetrics.MinimumFormWidthMultiButton;

        private readonly int _minFormWidthSingle =
            DarkMessageBoxMetrics.MinimumFormWidthSingleButton;

        private readonly int _rightMargin = DarkMessageBoxMetrics.RightMargin;
        private readonly int _spacerHeight = DarkMessageBoxMetrics.SpacerHeight;

        private readonly bool _titleBarIsLight =
            DarkMessageBoxMetrics.TitleBarIsLight;

        // ---- icons ----
        private readonly Icon _windowIcon = DarkMessageBoxMetrics.WindowIcon;

        /// <summary>
        /// Empty, <c>static</c> constructor to prohibit direct allocation of this class.
        /// </summary>
        static MetricsSnapshotTheme() { }

        /// <summary>
        /// Empty, <c>private</c> constructor to prohibit direct allocation of this class.
        /// </summary>
        private MetricsSnapshotTheme() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see cref="T:xyLOGIX.DarkMessageBox.Interfaces.IDarkMessageBoxTheme" />
        /// interface.
        /// </summary>
        public static IDarkMessageBoxTheme Instance
        {
            [DebuggerStepThrough] get;
        } = new MetricsSnapshotTheme();

        /// <summary>
        /// Restores every captured value back to
        /// <see cref="DarkMessageBoxMetrics" />.
        /// </summary>
        public void Apply()
        {
            DarkMessageBoxMetrics.BottomMargin = _bottomMargin;
            DarkMessageBoxMetrics.ButtonHeight = _buttonHeight;
            DarkMessageBoxMetrics.ButtonSpacing = _buttonSpacing;
            DarkMessageBoxMetrics.ButtonWidth = _buttonWidth;
            DarkMessageBoxMetrics.MaximumFormWidth = _maximumFormWidth;
            DarkMessageBoxMetrics.MinimumFormWidthMultiButton =
                _minFormWidthMulti;
            DarkMessageBoxMetrics.MinimumFormWidthSingleButton =
                _minFormWidthSingle;
            DarkMessageBoxMetrics.RightMargin = _rightMargin;
            DarkMessageBoxMetrics.DefaultButtonBorderThickness =
                _defaultBtnBorderThickness;
            DarkMessageBoxMetrics.FormFooterHeight = _formFooterHeight;
            DarkMessageBoxMetrics.SpacerHeight = _spacerHeight;

            DarkMessageBoxMetrics.HighlightDefaultButtonBackground =
                _highlightDefault;
            DarkMessageBoxMetrics.TitleBarIsLight = _titleBarIsLight;

            DarkMessageBoxMetrics.ButtonBackgroundColor = _btnBack;
            DarkMessageBoxMetrics.ButtonBorderColor = _btnBorder;
            DarkMessageBoxMetrics.ButtonTextColor = _btnText;
            DarkMessageBoxMetrics.DefaultButtonBackgroundColor = _defBtnBack;
            DarkMessageBoxMetrics.DefaultButtonBorderColor = _defBtnBorder;
            DarkMessageBoxMetrics.FooterBackgroundColor = _footerBack;
            DarkMessageBoxMetrics.FormBackgroundColor = _formBack;

            DarkMessageBoxMetrics.WindowIcon = _windowIcon;
            DarkMessageBoxMetrics.MessageBodyIcon = _bodyIcon;

            foreach (var kv in _captions.ToArray())
                DarkMessageBoxMetrics.ButtonTexts[kv.Key] = kv.Value;
        }
    }
}