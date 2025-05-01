using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace xyLOGIX.DarkMessageBox
{
    /// <summary>
    /// Supplies every tunable visual or layout parameter that a
    /// <see cref="DarkMessageBox" /> consumes at run-time.
    /// </summary>
    /// <remarks>
    /// All members are <c>static</c> so callers can tweak a single, global
    /// “theme profile” before showing a dialog.
    /// <para>
    /// Unless stated otherwise, integral values must be greater than or equal to
    /// <c>1</c>; colors cannot be <see cref="Color.Empty" />.
    /// </para>
    /// </remarks>
    public static class DarkMessageBoxMetrics
    {
        /// <summary>
        /// Gets or sets the vertical gap, in pixels, between the bottom edge of the
        /// dialog’s buttons and the bottom edge of the dialog’s client area.
        /// </summary>
        /// <remarks>
        /// • Default = 12 px.
        /// <para />
        /// • Set this to <c>&gt;= 1</c> to keep buttons visually separated from the
        /// form’s border.
        /// <para />
        /// • A value that is too small can make the UI feel cramped; a value that is
        /// too large wastes space and pushes the buttons uncomfortably upward.
        /// </remarks>
        public static int BottomMargin
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = 12;

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Color" /> value that specifies the
        /// background color of every button displayed in the dialog.
        /// </summary>
        /// <remarks>
        /// • Default = <c>#323232</c> (RGB 50, 50, 50).
        /// <para />
        /// • Cannot be <see cref="Color.Empty" />.
        /// <para />
        /// • Choose a color that provides sufficient contrast with
        /// <see cref="ButtonTextColor" />.
        /// </remarks>
        public static Color ButtonBackgroundColor
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = Color.FromArgb(50, 50, 50);

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Color" /> value that specifies the
        /// border color drawn around buttons.
        /// </summary>
        /// <remarks>
        /// • Default = <c>#464646</c> (RGB 70, 70, 70).
        /// <para />
        /// • Cannot be <see cref="Color.Empty" />.
        /// <para />
        /// • When <see cref="HighlightDefaultButtonBackground" /> is
        /// <see langword="false" />,
        /// this color is also used for the emphasis rectangle of the default button.
        /// </remarks>
        public static Color ButtonBorderColor
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = Color.FromArgb(70, 70, 70);

        /// <summary>
        /// Gets or sets the height, in pixels, of every button.
        /// </summary>
        /// <remarks>
        /// • Default = 27 px — close to the 26 px guideline for 9-pt Segoe UI.
        /// <para />
        /// • Must be <c>&gt;= 1</c>.
        /// <para />
        /// • Values smaller than 23 px may clip the glyph on high-DPI displays.
        /// </remarks>
        public static int ButtonHeight
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = 27;

        /// <summary>
        /// Gets or sets the horizontal space, in pixels, left between adjacent buttons.
        /// </summary>
        /// <remarks>
        /// • Default = 6 px.
        /// <para />
        /// • Must be <c>&gt;= 1</c>.
        /// <para />
        /// • A value below 4 px can make buttons appear glued together; a value above
        /// 12 px unnecessarily widens the window.
        /// </remarks>
        public static int ButtonSpacing
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = 6;

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Color" /> value that specifies the
        /// default foreground color of button captions.
        /// </summary>
        /// <remarks>
        /// • Default = <c>#F1F1F1</c>.
        /// <para />
        /// • Cannot be <see cref="Color.Empty" />.
        /// <para />
        /// • Insufficient contrast against <see cref="ButtonBackgroundColor" /> harms
        /// readability and fails accessibility checks.
        /// </remarks>
        public static Color ButtonTextColor
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = Color.FromArgb(241, 241, 241);

        /// <summary>
        /// Gets a modifiable map that overrides the caption shown for each
        /// <see cref="DialogResult" /> value.
        /// </summary>
        /// <remarks>
        /// • Keys correspond to results produced by the button.
        /// <para />
        /// • Values may include an ampersand (<c>&amp;</c>) to define a keyboard
        /// mnemonic; e.g., <c>&amp;Yes</c>.
        /// <para />
        /// • Empty or whitespace captions are invalid and rejected by the
        /// validator.
        /// </remarks>
        public static FixedSizeDictionary<DialogResult, string>
            ButtonTexts { [DebuggerStepThrough] get; } =
            new FixedSizeDictionary<DialogResult, string>(
                new Dictionary<DialogResult, string>
                {
                    { DialogResult.OK, "OK" },
                    { DialogResult.Cancel, "Cancel" },
                    { DialogResult.Yes, "&Yes" },
                    { DialogResult.No, "&No" },
                    { DialogResult.Abort, "&Abort" },
                    { DialogResult.Retry, "&Retry" },
                    { DialogResult.Ignore, "&Ignore" }
                }
            );

        /// <summary>
        /// Gets or sets the minimum width of a button.  Wider captions automatically
        /// expand the button beyond this value.
        /// </summary>
        /// <remarks>
        /// • Default = 87 px, matching Windows-classic button metrics.
        /// <para />
        /// • Must be <c>&gt;= 1</c>.
        /// <para />
        /// • If you localize captions into languages with longer words, you can keep
        /// this value but the dialog will still widen to fit.
        /// </remarks>
        public static int ButtonWidth
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = 87;

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Color" /> value that specifies the
        /// fill color applied to the default button when the
        /// <see
        ///     cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.HighlightDefaultButtonBackground" />
        /// property is set to <see langword="true" />.
        /// </summary>
        /// <remarks>
        /// • Default = <c>#3C3C5A</c>.
        /// <para />
        /// • Cannot be <see cref="Color.Empty" />.
        /// <para />
        /// • Use a hue that contrasts against <see cref="ButtonTextColor" /> while
        /// standing out from <see cref="ButtonBackgroundColor" />.
        /// </remarks>
        public static Color DefaultButtonBackgroundColor
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = Color.FromArgb(60, 60, 90);

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Color" /> value that specifies the
        /// border color drawn around the default button when the
        /// <see
        ///     cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.HighlightDefaultButtonBackground" />
        /// property is set to is <see langword="false" />.
        /// </summary>
        /// <remarks>
        /// • Default is the value of the
        /// <see cref="P:System.Drawing.SystemColors.Highlight" /> property.
        /// <para />
        /// • Cannot be <see cref="Color.Empty" />.
        /// <para />
        /// • Choose a vivid accent to help users locate the recommended action quickly.
        /// </remarks>
        public static Color DefaultButtonBorderColor
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = SystemColors.Highlight;

        /// <summary>
        /// Gets or sets the stroke thickness, in whole pixels, used to draw the default
        /// button’s emphasis rectangle when the background-highlight mode is disabled.
        /// </summary>
        /// <remarks>
        /// • Default = 2 px.
        /// <para />
        /// • Must be <c>&gt;= 1</c>.
        /// <para />
        /// • A value that is too thick can crowd the button text; a value that is too
        /// thin may be hard to notice on high-DPI displays.
        /// </remarks>
        public static int DefaultButtonBorderThickness
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = 2;

        /// <summary>
        /// Gets or sets a value indicating whether the buttons are to be rendered as
        /// <c>Flat</c> (true) or <c>System</c> (false).
        /// </summary>
        public static bool FlatButtons
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = true;

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Color" /> value that
        /// specifies the background color of the footer strip that holds the buttons.
        /// </summary>
        /// <remarks>
        /// • Default = <c>#2D2D2D</c>.
        /// <para />
        /// • Cannot be <see cref="Color.Empty" />.
        /// <para />
        /// It is recommended that a color which is slightly lighter or darker than that
        /// which is the value of the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.FormBackgroundColor" />
        /// property be used, to create a clear separation.
        /// </remarks>
        public static Color FooterBackgroundColor
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = Color.FromArgb(45, 45, 45);

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Color" /> value that is to
        /// be used for the background color of the dialog’s main client area.
        /// </summary>
        /// <remarks>
        /// • Default = <c>#1F1F1F</c>.
        /// <para />
        /// • Cannot be <see cref="Color.Empty" />.
        /// <para />
        /// • Pick a tone that provides comfortable contrast with both
        /// <see cref="MessageTextColor" /> and any <see cref="MessageBodyIcon" /> you
        /// plan to use.
        /// </remarks>
        public static Color FormBackgroundColor
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = Color.FromArgb(31, 31, 31);

        /// <summary>
        /// Gets or sets the height, in pixels, of the footer strip that houses the
        /// buttons.
        /// </summary>
        /// <remarks>
        /// • Default = 42 px.
        /// <para />
        /// • Must be at least <c>ButtonHeight + 6</c> so buttons never clip vertically.
        /// <para />
        /// • The validator enforces this lower bound automatically.
        /// </remarks>
        public static int FormFooterHeight
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = 42;

        /// <summary>
        /// Gets or sets a value indicating whether the default button is indicated by
        /// filling its background (<see langword="true" />) or by drawing a thick border
        /// (<see langword="false" />).
        /// </summary>
        /// <remarks>
        /// • Default = <see langword="false" /> (border style).
        /// <para />
        /// • Toggling this to <see langword="true" /> uses
        /// <see cref="DefaultButtonBackgroundColor" /> to flood-fill the button’s
        /// client area.
        /// <para />
        /// • Prior to changing this flag at run-time, make sure your fill color still
        /// meets contrast requirements for legibility.
        /// </remarks>
        public static bool HighlightDefaultButtonBackground
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }

        /// <summary>
        /// Gets or sets the maximum width, in pixels, the dialog may grow to while
        /// accommodating long captions, long messages, or many buttons.
        /// </summary>
        /// <remarks>
        /// • Default = 600 px.
        /// <para />
        /// • Must be <c>&gt;= MinimumFormWidthMultiButton</c>.
        /// <para />
        /// • If a message is wider than this limit, it will wrap onto multiple lines
        /// instead of expanding the window further.
        /// </remarks>
        public static int MaximumFormWidth
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = 600;

        /// <summary>
        /// Gets or sets a reference to an instance of <see cref="T:System.Drawing.Icon" />
        /// that specifies a custom icon that is to replace the stock
        /// <see cref="T:System.Windows.Forms.MessageBoxIcon" /> glyph shown beside the
        /// message text.
        /// <para />
        /// If this property is set to <see langword="null" />, then whichever system icon
        /// that corresponds to the <see cref="T:System.Windows.Forms.MessageBoxIcon" />
        /// enumeration value that is supplied to the
        /// <see
        ///     cref="xyLOGIX.DarkMessageBox.DarkMessageBox.Show(string, string, MessageBoxButtons, MessageBoxIcon, MessageBoxDefaultButton, int)" />
        /// method, or its other overload, is used.
        /// </summary>
        /// <remarks>
        /// • Default = <see langword="null" /> (use system icon).
        /// <para />
        /// • Supply <see langword="null" /> again to revert.
        /// <para />
        /// • Icons should be 32 × 32 px for optimal scaling.
        /// </remarks>
        public static Icon MessageBodyIcon
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Color" /> value that is to
        /// be used for the color of the main message text.
        /// </summary>
        /// <remarks>
        /// • Default = <c>#F1F1F1</c>.
        /// <para />
        /// • Cannot be <see cref="Color.Empty" />.
        /// <para />
        /// • Select a tone that remains legible on
        /// <see cref="FormBackgroundColor" /> and that meets WCAG contrast guidelines.
        /// </remarks>
        public static Color MessageTextColor
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = Color.FromArgb(241, 241, 241);

        /// <summary>
        /// Gets or sets the minimum width of a dialog that contains three or more
        /// buttons.
        /// </summary>
        /// <remarks>
        /// • Default = 284 px.
        /// <para />
        /// • Must be at least large enough to hold three
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.ButtonWidth" />
        /// buttons plus two
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.ButtonSpacing" />
        /// gaps and margins.
        /// </remarks>
        public static int MinimumFormWidthMultiButton
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = 284;

        /// <summary>
        /// Gets or sets the minimum width of a dialog that contains exactly one or two
        /// buttons.
        /// </summary>
        /// <remarks>
        /// • Default = 117 px.
        /// <para />
        /// • Must be <c>&gt;= 1</c>.
        /// <para />
        /// • The runtime layout algorithm always ensures that buttons fit, so raising
        /// this value is purely cosmetic.
        /// </remarks>
        public static int MinimumFormWidthSingleButton
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = 117;

        /// <summary>
        /// Gets or sets the horizontal gap, in pixels, between the rightmost edge of the
        /// rightmost button and the right edge of the dialog’s client area.
        /// </summary>
        /// <remarks>
        /// • Default = 12 px.
        /// <para />
        /// • Must be <c>&gt;= 1</c>.
        /// <para />
        /// • Reducing this value below 6 px may make the layout feel misaligned; raising
        /// it above 24 px can feel wasteful on small screens.
        /// </remarks>
        public static int RightMargin
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = 12;

        /// <summary>
        /// Gets or sets the height, in pixels, of the spacer strip that appears between
        /// the message content and the footer.
        /// </summary>
        /// <remarks>
        /// • Default = 18 px.
        /// <para />
        /// • Must be <c>&gt;= 1</c>.
        /// <para />
        /// • Lower values tighten the layout; higher values produce an airier look that
        /// may or may not suit your visual language.
        /// </remarks>
        public static int SpacerHeight
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        } = 18;

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="InternalDarkMessageBox" />
        /// should automatically restore the professional theme when it closes.
        /// </summary>
        /// <remarks>
        /// • Default = <see langword="false" />.
        /// <para />
        /// • Setting this to <see langword="true" /> leaves caller-defined theme changes
        /// in place after the dialog is dismissed.
        /// </remarks>
        public static bool SuppressAutoReset
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the title bar should be rendered in
        /// light mode (<see langword="true" />) or dark mode
        /// (<see langword="false" />) when the host OS supports immersive
        /// title-bar theming.
        /// </summary>
        /// <remarks>
        /// • Default = <see langword="false" /> (dark title bar).
        /// <para />
        /// • Changing this property has no effect on operating systems that do not
        /// expose the DWM dark-title-bar API.
        /// </remarks>
        public static bool TitleBarIsLight
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }

        /// <summary>
        /// Gets or sets a reference to an instance of <see cref="T:System.Drawing.Icon" />
        /// that specifies the custom window icon that is displayed in the title bar and
        /// Taskbar for the message box.
        /// <para />
        /// Setting this value to <see langword="null" /> (the default) removes the icon
        /// and does not display the message box in the Taskbar.
        /// </summary>
        /// <remarks>
        /// • Default = <see langword="null" /> (the dialog shows no icon).
        /// <para />
        /// • Supply <see langword="null" /> again to remove a previously assigned icon.
        /// <para />
        /// • Recommended size is 32 pixels × 32 pixels with a 256-color palette or PNG
        /// compressed alpha.
        /// </remarks>
        public static Icon WindowIcon
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }

        /// <summary>
        /// Restores every metric in this class to its library-default value.
        /// </summary>
        /// <remarks>
        /// Call this before displaying a dialog if you want to guarantee that no
        /// changes from earlier code affect the look-and-feel.  The method is also
        /// invoked internally by the professional dark theme implementation.
        /// </remarks>
        public static void Reset()
        {
            BottomMargin = 12;
            ButtonHeight = 27;
            ButtonSpacing = 6;
            ButtonWidth = 87;
            DefaultButtonBorderThickness = 2;
            FlatButtons = true;
            FormFooterHeight = 42;
            MaximumFormWidth = 600;
            MinimumFormWidthMultiButton = 284;
            MinimumFormWidthSingleButton = 117;
            RightMargin = 12;
            SpacerHeight = 18;

            HighlightDefaultButtonBackground = false;
            SuppressAutoReset = false;
            TitleBarIsLight = false;

            ButtonBackgroundColor = Color.FromArgb(50, 50, 50);
            ButtonBorderColor = Color.FromArgb(70, 70, 70);
            ButtonTextColor = Color.FromArgb(241, 241, 241);
            DefaultButtonBackgroundColor = Color.FromArgb(60, 60, 90);
            DefaultButtonBorderColor = Color.FromArgb(180, 200, 255);
            FooterBackgroundColor = Color.FromArgb(45, 45, 45);
            FormBackgroundColor = Color.FromArgb(31, 31, 31);
            MessageTextColor = Color.FromArgb(241, 241, 241);

            MessageBodyIcon = null;
            WindowIcon = null;

            ButtonTexts[DialogResult.OK] = "OK";
            ButtonTexts[DialogResult.Cancel] = "Cancel";
            ButtonTexts[DialogResult.Yes] = "&Yes";
            ButtonTexts[DialogResult.No] = "&No";
            ButtonTexts[DialogResult.Abort] = "&Abort";
            ButtonTexts[DialogResult.Retry] = "&Retry";
            ButtonTexts[DialogResult.Ignore] = "&Ignore";
        }
    }
}