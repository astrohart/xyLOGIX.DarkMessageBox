using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using xyLOGIX.DarkMessageBox.Interfaces;

namespace xyLOGIX.DarkMessageBox.Themes
{
    /// <summary>
    /// Helper “theme” that simply remembers the current metrics and restores them
    /// when its Apply() is called.  This lets us use ThemeManager.WithTemporaryTheme
    /// to handle push / pop without any manual snapshot code.
    /// </summary>
    /// s
    internal sealed class MetricsSnapshotTheme : IDarkMessageBoxTheme
    {
        /// <summary>
        /// Reference to an instance of <see cref="T:System.Drawing.Icon" /> that saves the
        /// current value of the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.MessageBodyIcon" />
        /// property.
        /// </summary>
        private readonly Icon _bodyIcon = DarkMessageBoxMetrics.MessageBodyIcon;

        /// <summary>
        /// An <see cref="T:System.Int32" /> value that saves the current value of the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.BottomMargin" />
        /// property.
        /// </summary>
        private readonly int _bottomMargin = DarkMessageBoxMetrics.BottomMargin;

        /// <summary>
        /// A <see cref="T:System.Drawing.Color" /> value that saves the current value of
        /// the
        /// <see
        ///     cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.ButtonBackgroundColor" />
        /// property.
        /// </summary>
        private readonly Color _btnBack =
            DarkMessageBoxMetrics.ButtonBackgroundColor;

        /// <summary>
        /// A <see cref="T:System.Drawing.Color" /> value that saves the current value of
        /// the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.ButtonBorderColor" />
        /// property.
        /// </summary>
        private readonly Color _btnBorder =
            DarkMessageBoxMetrics.ButtonBorderColor;

        /// <summary>
        /// A <see cref="T:System.Drawing.Color" /> value that saves the current value of
        /// the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.ButtonTextColor" />
        /// property.
        /// </summary>
        private readonly Color _btnText = DarkMessageBoxMetrics.ButtonTextColor;

        /// <summary>
        /// A <see cref="T:System.Int32" /> value that saves the current value of the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.ButtonHeight" />
        /// property.
        /// </summary>
        private readonly int _buttonHeight = DarkMessageBoxMetrics.ButtonHeight;

        /// <summary>
        /// A <see cref="T:System.Int32" /> value that saves the current value of the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.ButtonSpacing" />
        /// property.
        /// </summary>
        private readonly int _buttonSpacing =
            DarkMessageBoxMetrics.ButtonSpacing;

        /// <summary>
        /// A <see cref="T:System.Int32" /> value that saves the current value of the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.ButtonWidth" />
        /// property.
        /// </summary>
        private readonly int _buttonWidth = DarkMessageBoxMetrics.ButtonWidth;

        /// <summary>
        /// A <see cref="T:xyLOGIX.DarkMessageBox.FixedSizeDictionary`2" /> that saves the
        /// current value of the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.ButtonTexts" />
        /// property.
        /// </summary>
        private readonly FixedSizeDictionary<DialogResult, string> _captions =
            new FixedSizeDictionary<DialogResult, string>(
                DarkMessageBoxMetrics.ButtonTexts
            );

        /// <summary>
        /// A <see cref="T:System.Int32" /> value that saves the current value of the
        /// <see
        ///     cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.DefaultButtonBorderThickness" />
        /// property.
        /// </summary>
        private readonly int _defaultBtnBorderThickness =
            DarkMessageBoxMetrics.DefaultButtonBorderThickness;

        /// <summary>
        /// A <see cref="T:System.Drawing.Color" /> value that saves the current value of
        /// the
        /// <see
        ///     cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.DefaultButtonBackgroundColor" />
        /// property.
        /// </summary>
        private readonly Color _defBtnBack =
            DarkMessageBoxMetrics.DefaultButtonBackgroundColor;

        /// <summary>
        /// A <see cref="T:System.Drawing.Color" /> value that saves the current value of
        /// the
        /// <see
        ///     cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.DefaultButtonBorderColor" />
        /// property.
        /// </summary>
        private readonly Color _defBtnBorder =
            DarkMessageBoxMetrics.DefaultButtonBorderColor;

        /// <summary>
        /// A <see cref="T:System.Boolean" /> value that saves the current value of the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.FlatButtons" />
        /// property.
        /// </summary>
        private readonly bool _flatButtons = DarkMessageBoxMetrics.FlatButtons;

        /// <summary>
        /// A <see cref="T:System.Drawing.Color" /> value that saves the current value of
        /// the
        /// <see
        ///     cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.FooterBackgroundColor" />
        /// property.
        /// </summary>
        private readonly Color _footerBackgroundColor =
            DarkMessageBoxMetrics.FooterBackgroundColor;

        /// <summary>
        /// A <see cref="T:System.Drawing.Color" /> value that saves the current value of
        /// the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.FormBackgroundColor" />
        /// property.
        /// </summary>
        private readonly Color _formBackgroundColor =
            DarkMessageBoxMetrics.FormBackgroundColor;

        /// <summary>
        /// A <see cref="T:System.Int32" /> value that saves the current value of the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.FormFooterHeight" />
        /// property.
        /// </summary>
        private readonly int _formFooterHeight =
            DarkMessageBoxMetrics.FormFooterHeight;

        /// <summary>
        /// A <see cref="T:System.Boolean" /> value that saves current value of the
        /// <see
        ///     cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.HighlightDefaultButtonBackground" />
        /// property.
        /// </summary>
        private readonly bool _highlightDefault =
            DarkMessageBoxMetrics.HighlightDefaultButtonBackground;

        /// <summary>
        /// A <see cref="T:System.Int32" /> value that saves the current value of the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.MaximumFormWidth" />
        /// property.
        /// </summary>
        private readonly int _maximumFormWidth =
            DarkMessageBoxMetrics.MaximumFormWidth;

        /// <summary>
        /// A <see cref="T:System.Int32" /> value that saves the current value of the
        /// <see
        ///     cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.MinimumFormWidthMultiButton" />
        /// property.
        /// </summary>
        private readonly int _minFormWidthMultiButton =
            DarkMessageBoxMetrics.MinimumFormWidthMultiButton;

        /// <summary>
        /// A <see cref="T:System.Int32" /> value that saves the current value of the
        /// <see
        ///     cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.MinimumFormWidthSingleButton" />
        /// property.
        /// </summary>
        private readonly int _minFormWidthSingleButton =
            DarkMessageBoxMetrics.MinimumFormWidthSingleButton;

        /// <summary>
        /// An <see cref="T:System.Int32" /> value that saves the current value of the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.RightMargin" />
        /// property.
        /// </summary>
        private readonly int _rightMargin = DarkMessageBoxMetrics.RightMargin;

        /// <summary>
        /// An <see cref="T:System.Int32" /> value that saves the current value of the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.SpacerHeight" />
        /// property.
        /// </summary>
        private readonly int _spacerHeight = DarkMessageBoxMetrics.SpacerHeight;

        /// <summary>
        /// A <see cref="T:System.Boolean" /> value that saves the current value of the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.TitleBarIsLight" />
        /// property.
        /// </summary>
        private readonly bool _titleBarIsLight =
            DarkMessageBoxMetrics.TitleBarIsLight;

        /// <summary>
        /// Reference to an instance of <see cref="T:System.Drawing.Icon" /> that saves the
        /// current value of the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.WindowIcon" />
        /// property.
        /// </summary>
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
        /// Restores every captured value back to the property(ies) of the
        /// <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics" /> class.
        /// </summary>
        public void Apply()
        {
            DarkMessageBoxMetrics.Reset();

            DarkMessageBoxMetrics.BottomMargin = _bottomMargin;
            DarkMessageBoxMetrics.ButtonHeight = _buttonHeight;
            DarkMessageBoxMetrics.ButtonSpacing = _buttonSpacing;
            DarkMessageBoxMetrics.ButtonWidth = _buttonWidth;
            DarkMessageBoxMetrics.MaximumFormWidth = _maximumFormWidth;
            DarkMessageBoxMetrics.MinimumFormWidthMultiButton =
                _minFormWidthMultiButton;
            DarkMessageBoxMetrics.FlatButtons = _flatButtons;
            DarkMessageBoxMetrics.MinimumFormWidthSingleButton =
                _minFormWidthSingleButton;
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
            DarkMessageBoxMetrics.FooterBackgroundColor =
                _footerBackgroundColor;
            DarkMessageBoxMetrics.FormBackgroundColor = _formBackgroundColor;

            DarkMessageBoxMetrics.WindowIcon = _windowIcon;
            DarkMessageBoxMetrics.MessageBodyIcon = _bodyIcon;

            foreach (var kv in _captions.ToArray())
                DarkMessageBoxMetrics.ButtonTexts[kv.Key] = kv.Value;
        }
    }
}