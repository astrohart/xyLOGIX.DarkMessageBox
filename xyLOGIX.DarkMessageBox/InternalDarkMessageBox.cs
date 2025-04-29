using Dark.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xyLOGIX.DarkMessageBox.Properties;
using xyLOGIX.DarkMessageBox.Themes;
using xyLOGIX.DarkMessageBox.Validators;

namespace xyLOGIX.DarkMessageBox
{
    /// <summary>
    /// This is a custom implementation of a dark-themed message box, based on
    /// a Windows <see cref="T:System.Windows.Forms.Form" /> that is customized at
    /// runtime.
    /// </summary>
    /// <remarks>
    /// Users of this NuGet package must not call this class directly.  This
    /// class is reserved to actually implement the dark-message-box functionality.
    /// The methods of the <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox" /> class
    /// are to be used to display message boxes.
    /// <para />
    /// Before calling the methods of the
    /// <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox" /> class, the user can set
    /// various properties of the
    /// <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics" /> class to
    /// customize the look, feel, appearance, and behavior of the message  box.
    /// <para />
    /// In order for the customizations to take effect, the property(ies) of the
    /// <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics" /> class must be set
    /// in advance of calling the method(s) of the
    /// <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox" /> class.
    /// <para />
    /// In addition, user(s) of this NuGet package can also implement the
    /// <see cref="T:xyLOGIX.DarkMessageBox.Interfaces.IDarkMessageBoxTheme" />
    /// interface and then call the
    /// <see cref="xyLOGIX.DarkMessageBox.Interfaces.IDarkMessageBoxTheme.Apply" />
    /// method of that interface to customize
    /// the message box.
    /// <para />
    /// The <see cref="xyLOGIX.DarkMessageBox.Interfaces.IDarkMessageBoxTheme.Apply" />
    /// method must be called prior to the display of the message box.
    /// <para />
    /// Implementers of the
    /// <see cref="xyLOGIX.DarkMessageBox.Interfaces.IDarkMessageBoxTheme.Apply" />
    /// method must set the properties of the
    /// <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics" /> class to a
    /// customized set of values that correspond to that particular theme.
    /// <para />
    /// This form automatically reapplies the default theme when it is closed.  Setting
    /// the
    /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.SuppressAutoReset" />
    /// property to <see langword="true" /> suppresses this behavior.
    /// </remarks>
    internal sealed class InternalDarkMessageBox : Form
    {
        /// <summary>
        /// The number of milliseconds the message box is to be displayed on the screen,
        /// without user interaction, before it is automatically dismissed.
        /// </summary>
        /// <remarks>
        /// If this value is zero or negative, then the message box will remain on
        /// the screen until the user clicks one of its button(s) to close it.
        /// </remarks>
        private readonly int _autoCloseAfterMilliseconds;

        /// <summary>
        /// A collection of instances of <see cref="T:System.Windows.Forms.Button" />, each
        /// of which represents one of the control(s) that are to be made available to the
        /// interactive user.
        /// </summary>
        /// <remarks>The contents of this collection are configured at runtime.</remarks>
        private readonly List<Button> _buttons = new List<Button>();

        /// <summary>
        /// Reference to an instance of <see cref="T:System.Windows.Forms.Panel" /> that
        /// refers to the footer panel that surrounds the buttons (a la the Vista-style
        /// message box that is used by convention.)
        /// </summary>
        private Panel _footerPanel;

        /// <summary>
        /// Reference to an instance of <see cref="T:System.Windows.Forms.PictureBox" />
        /// that displays the icon in the body of the message box.
        /// </summary>
        /// <remarks>
        /// The icon should be symbolic of the action being requested, or the
        /// notification being presented, and/or the particular application that is
        /// notifying the user.
        /// </remarks>
        private PictureBox _iconBox;

        /// <summary>
        /// Reference to an instance of <see cref="T:System.Windows.Forms.Label" /> that
        /// displays the message content.
        /// </summary>
        private Label _messageLabel;

        /// <summary>
        /// Reference to an instance of <see cref="T:System.Windows.Forms.Panel" /> that
        /// displays a small spacer panel between the message content and the footer.
        /// </summary>
        private Panel _spacerPanel;

        /// <summary>
        /// Reference to an instance of <see cref="T:System.Windows.Forms.Timer" /> that,
        /// if applicable, governs the automatic closure of the message box after a
        /// specified interval in milliseconds.
        /// </summary>
        private Timer _timer;

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.DarkMessageBox.InternalDarkMessageBox" /> and returns a
        /// reference to it.
        /// </summary>
        /// <param name="text">
        /// (Required.) A <see cref="T:System.String" /> containing the message content.
        /// </param>
        /// <param name="caption">
        /// (Required.) A <see cref="T:System.String" /> containing the text to be
        /// displayed on the titlebar of the message.
        /// </param>
        /// <param name="buttons">
        /// (Required.) One of the <see cref="T:System.Windows.Forms.MessageBoxButtons" />
        /// enumeration value(s) that identifies the sort of button(s) that are to be made
        /// available to the user.
        /// </param>
        /// <param name="icon">
        /// (Required.) One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" />
        /// enumeration value(s) that identifies the standardized system icon to be
        /// displayed next to the message content, or
        /// <see cref="F:System.Windows.Forms.MessageBoxIcon.None" /> to display no icon.
        /// <para />
        /// This parameter is ignored if the value of the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.MessageBodyIcon" />
        /// property is not a <see langword="null" /> reference when this constructor is
        /// called.
        /// </param>
        /// <param name="defaultButton">
        /// (Required.) One of the
        /// <see cref="T:System.Windows.Forms.MessageBoxDefaultButton" /> enumeration
        /// value(s) that identifies, in order from left to right, which button is to be
        /// "pressed" if the user presses the <c>ENTER</c> key on the keyboard.
        /// </param>
        /// <param name="autoCloseAfterMilliseconds">
        /// (Required.) If greater than zero, the number of milliseconds to wait before
        /// automatically dismissing the message box.
        /// </param>
        /// <remarks>
        /// If the current theme settings have invalid values, it will be ignored,
        /// and the <see cref="T:xyLOGIX.DarkMessageBox.Themes.ProfessionalDarkTheme" />
        /// theme will be used by default.
        /// </remarks>
        public InternalDarkMessageBox(
            string text,
            string caption,
            MessageBoxButtons buttons,
            MessageBoxIcon icon,
            MessageBoxDefaultButton defaultButton,
            int autoCloseAfterMilliseconds
        )
        {
            EnsureValidTheme(); // ← new validation / fallback

            _autoCloseAfterMilliseconds = autoCloseAfterMilliseconds;

            InitializeComponents();
            SetCaption(caption);
            SetMessage(text);
            SetIcon(icon);
            SetButtons(buttons, defaultButton);
            AutoSizeForm();
            ConfigureWindowIcon();
            InitializeAutoCloseTimer();
        }

        /// <summary>
        /// Adds a <see cref="T:System.Windows.Forms.Button" /> control to the footer panel
        /// of this message box having the specified dialog <paramref name="result" />.
        /// </summary>
        /// <param name="result">
        /// (Required.) One of the <see cref="T:System.Windows.Forms.DialogResult" />
        /// enumeration value(s) that indicates the result of the button when the message
        /// box is dismissed from the user clicking it.
        /// </param>
        /// <remarks>
        /// If <see cref="F:System.Windows.Forms.DialogResult.None" /> is passed
        /// as the argument of the <paramref name="result" /> parameter, then this method
        /// takes no action.
        /// <para />
        /// A reminder message will be emitted to the Debug output window in the event that
        /// <see cref="F:System.Windows.Forms.DialogResult.None" /> is passed for the value
        /// of the <paramref name="result" /> parameter.
        /// </remarks>
        private void AddButton(DialogResult result)
        {
            if (DialogResult.None.Equals(result))
            {
                Debug.WriteLine(Resources.Error_Invalid_DialogResult);
                return;
            }

            var text = FormatDialogResultAsButtonText(result);
            if (string.IsNullOrWhiteSpace(text))
            {
                Debug.WriteLine(
                    Resources.Error_UnableToDetermineButtonText, result
                );
                return;
            }

            var textWidth = TextRenderer.MeasureText(text, Font)
                                        .Width;
            var width = Math.Max(
                DarkMessageBoxMetrics.ButtonWidth, textWidth + 20
            );

            var btn = new Button
            {
                Text = text,
                DialogResult = result,
                BackColor = DarkMessageBoxMetrics.ButtonBackgroundColor,
                ForeColor = DarkMessageBoxMetrics.ButtonTextColor,
                FlatStyle = FlatStyle.Flat,
                Width = width,
                Height = DarkMessageBoxMetrics.ButtonHeight
            };

            btn.FlatAppearance.BorderColor =
                DarkMessageBoxMetrics.ButtonBorderColor;
            btn.FlatAppearance.BorderSize = 1;
            btn.Paint += OnPaintButton;
            btn.Click += (s, e) => OnClickButton(result);

            _buttons.Add(btn);
            _footerPanel.Controls.Add(btn);
        }

        /// <summary>
        /// Dynamically sizes the message box to fit the caption, message, and buttons
        /// according to the design guidelines in the book,
        /// <c>The Windows User Interface Guidelines for Software Design</c>, Microsoft
        /// Press, 1995.
        /// </summary>
        private void AutoSizeForm()
        {
            var captionWidth = TextRenderer.MeasureText(Text, Font)
                                           .Width + 40;
            var messageWidth =
                _messageLabel.PreferredWidth + _iconBox.Width + 36;

            var buttonRowWidth = _buttons.Sum(b => b.Width) +
                                 (_buttons.Count - 1) * DarkMessageBoxMetrics
                                     .ButtonSpacing + 2 * DarkMessageBoxMetrics
                                     .RightMargin;

            var contentWidth = Math.Max(captionWidth, messageWidth);

            var minWidth = _buttons.Count >= 3
                ? DarkMessageBoxMetrics.MinimumFormWidthMultiButton
                : DarkMessageBoxMetrics.MinimumFormWidthSingleButton;

            var formWidth = Math.Max(
                minWidth,
                Math.Min(
                    Math.Max(contentWidth, buttonRowWidth),
                    DarkMessageBoxMetrics.MaximumFormWidth
                )
            );

            _messageLabel.MaximumSize = new Size(
                formWidth - _iconBox.Width - 36, 0
            );
            _messageLabel.PerformLayout();

            var contentBottom = Math.Max(_messageLabel.Bottom, _iconBox.Bottom);

            _spacerPanel.Location = new Point(0, contentBottom);
            _spacerPanel.Width = formWidth;

            var clientHeight = contentBottom + _spacerPanel.Height +
                               _footerPanel.Height +
                               DarkMessageBoxMetrics.BottomMargin;

            ClientSize = new Size(formWidth, clientHeight);

            var startX = ClientSize.Width - DarkMessageBoxMetrics.RightMargin -
                         _buttons.Sum(b => b.Width) - (_buttons.Count - 1) *
                         DarkMessageBoxMetrics.ButtonSpacing;

            var buttonTop =
                (_footerPanel.Height - DarkMessageBoxMetrics.ButtonHeight) / 2;

            var x = startX;
            foreach (var btn in _buttons)
            {
                btn.Location = new Point(x, buttonTop);
                x += btn.Width + DarkMessageBoxMetrics.ButtonSpacing;
            }
        }

        /// <summary>
        /// Configures the window icon of this message box, if applicable.
        /// </summary>
        /// <remarks>
        /// This method also configures, if applicable, the display of the window icon on
        /// the system Taskbar.
        /// <para />
        /// This method relies upon the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.WindowIcon" />
        /// property to provide the value to be set.
        /// <para />
        /// If the value of the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.WindowIcon" />
        /// property is <see langword="null" />, then no icon is set and the message box is
        /// set to not appear in the system Taskbar.
        /// </remarks>
        private void ConfigureWindowIcon()
        {
            if (DarkMessageBoxMetrics.WindowIcon != null)
            {
                Icon = DarkMessageBoxMetrics.WindowIcon;
                ShowIcon = true;
                ShowInTaskbar = true;
            }
            else
            {
                ShowIcon = false;
                ShowInTaskbar = false;
            }
        }

        /// <summary>
        /// Examines the button(s), in the event that this message box is set to
        /// automatically be closed, and ascertains the
        /// <see cref="T:System.Windows.Forms.DialogResult" /> value of the leftmost
        /// button.
        /// </summary>
        /// <remarks>
        /// If the proper <see cref="T:System.Windows.Forms.DialogResult" /> value cannot
        /// be ascertained by this method, then
        /// <see cref="F:System.Windows.Forms.DialogResult.OK" /> is returned by default,
        /// unless the
        /// <see
        ///     cref="F:xyLOGIX.DarkMessageBox.InternalDarkMessageBox._autoCloseAfterMilliseconds" />
        /// is set to zero or a negative number; in which case,
        /// <see cref="F:System.Windows.Forms.DialogResult.None" /> is returned.
        /// </remarks>
        /// <returns>
        /// The <see cref="T:System.Windows.Forms.DialogResult" /> value of the leftmost
        /// button, or <see cref="F:System.Windows.Forms.DialogResult.OK" /> by default,
        /// or, if the
        /// <see
        ///     cref="F:xyLOGIX.DarkMessageBox.InternalDarkMessageBox._autoCloseAfterMilliseconds" />
        /// field is set to zero or less, then
        /// <see cref="F:System.Windows.Forms.DialogResult.None" /> is returned.
        /// </returns>
        private DialogResult DetermineAutoCloseDialogResult()
        {
            if (_autoCloseAfterMilliseconds <= 0) return DialogResult.None;

            // Determine the correct DialogResult value to utilize if the
            // message box is to be closed automatically.  The default
            // value is DialogResult.OK.  But, if different buttons are
            // displayed, we must utilize the DialogResult value of the
            // leftmost button.
            if (_buttons == null) return DialogResult.OK;
            if (_buttons.Count <= 0) return DialogResult.OK;

            var leftmostButton = _buttons[0];
            if (leftmostButton == null) return DialogResult.OK;
            if (leftmostButton.IsDisposed) return DialogResult.OK;

            return leftmostButton.DialogResult == DialogResult.None
                ? DialogResult.OK
                : leftmostButton.DialogResult;
        }

        /// <summary>
        /// Ensures the current theme is valid; if not, falls back to the professional
        /// dark theme so we never render with broken metrics.
        /// </summary>
        private static void EnsureValidTheme()
        {
            if (DarkMessageBoxThemeValidator.IsValid(
                    DarkMessageBoxThemeManager.CurrentTheme
                )) return;

            // If we are here, then the current theme is invalid.  Revert to
            // the default theme.
            DarkMessageBoxThemeManager.ApplyTheme(
                ProfessionalDarkTheme.Instance
            );
        }

        private string FormatDialogResultAsButtonText(DialogResult result)
        {
            /*
             * If DialogResult.None is passed as the argument of the result
             * parameter, we do not know how to handle this case.
             */
            if (DialogResult.None.Equals(result)) return string.Empty;

            /*
             * If customized text is available that corresponds to the specified
             * DialogResult, then fetch it from the ButtonTexts dictionary and
             * return it.
             */

            if (DarkMessageBoxMetrics.ButtonTexts.TryGetValue(
                    result, out var customText
                ))
                return customText;

            /*
             * If we are here, then custom button text was not available in the
             * ButtonTexts dictionary for the specified DialogResult.  This is not
             * an issue; we'll just use the name of the specified DialogResult value
             * as the text of the button, prepending an ampersand character except
             * if the value is 'OK' or 'Cancel'.
             *
             * By Win32 UI/UX convention, the 'OK' and 'Cancel' buttons are not
             * * prepended with an ampersand character (to underline that character
             * in the UI).  This is because the 'OK' and 'Cancel' buttons are, by
             * convention, always activated by the pressing of the ENTER and/or
             * ESC key(s) on the keyboard, respectively; therefore, it is not
             * necessary to provide a keyboard mnemonic shortcut for these buttons
             * (which is what an '&' character does).
             */

            return DialogResult.OK.Equals(result) ||
                   DialogResult.Cancel.Equals(result)
                ? result.ToString()
                : "&" + result;
        }

        /// <summary>
        /// This method is called to configure the timer that governs the automatic closure
        /// of this message box after a time interval, in milliseconds, that is specified
        /// by the user.
        /// </summary>
        /// <remarks>
        /// If the value of the
        /// <see
        ///     cref="F:xyLOGIX.DarkMessageBox.InternalDarkMessageBox._autoCloseAfterMilliseconds" />
        /// field is zero or less, then this method does nothing.
        /// </remarks>
        private void InitializeAutoCloseTimer()
        {
            // If the _autoCloseAfterMilliseconds field is less than or
            // equal to zero, then do nothing.
            if (_autoCloseAfterMilliseconds <= 0) return;

            // Otherwise, create a timer and set its interval to the value
            // of the _autoCloseAfterMilliseconds field.
            _timer = new Timer();
            _timer.Interval = _autoCloseAfterMilliseconds;
            _timer.Tick += OnTimerTick;
            _timer.Enabled = false;
        }

        /// <summary>
        /// Called to initialize the interactive user-interface components of the message
        /// box.
        /// </summary>
        private void InitializeComponents()
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            BackColor = DarkMessageBoxMetrics.FormBackgroundColor;
            ForeColor = DarkMessageBoxMetrics.ButtonTextColor;
            Font = new Font(
                "Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point
            );
            KeyPreview = true;
            MinimizeBox = false;
            MaximizeBox = false;
            ControlBox = true;

            _iconBox = new PictureBox
            {
                Location = new Point(15, 15),
                Size = new Size(32, 32),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            Controls.Add(_iconBox);

            _messageLabel = new Label
            {
                Location     = new Point(60, 15),
                MaximumSize  = new Size(400, 0),
                AutoSize     = true,
                ForeColor    = DarkMessageBoxMetrics.MessageTextColor // ← here
            };
            Controls.Add(_messageLabel);

            _footerPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = DarkMessageBoxMetrics.FormFooterHeight,
                BackColor = DarkMessageBoxMetrics.FooterBackgroundColor
            };
            Controls.Add(_footerPanel);

            _spacerPanel = new Panel
            {
                Size = new Size(0, DarkMessageBoxMetrics.SpacerHeight),
                BackColor = DarkMessageBoxMetrics.FormBackgroundColor
            };
            Controls.Add(_spacerPanel);

            DialogResult = DialogResult.None;

            Visible = false;
        }

        /// <summary>
        /// Handles a <see cref="E:System.Windows.Forms.Control.Click" /> event raised by
        /// one of the buttons.
        /// </summary>
        /// <param name="result">
        /// (Required.) One of the <see cref="T:System.Windows.Forms.DialogResult" />
        /// enumeration value(s) that indicates what the
        /// <see cref="P:System.Windows.Forms.Form.DialogResult" /> property of this
        /// <see cref="T:System.Windows.Forms.Form" /> is to be set before it is then
        /// closed.
        /// </param>
        /// <remarks>
        /// This method takes no action if
        /// <see cref="F:System.Windows.Forms.DialogResult.None" /> is passed as the
        /// argument of the <paramref name="result" /> parameter.
        /// <para />
        /// This method responds by setting the value of the
        /// <see cref="P:System.Windows.Forms.Form.DialogResult" /> property to the
        /// specified <paramref name="result" />, and then closing the
        /// <see cref="T:System.Windows.Forms.Form" />.
        /// </remarks>
        private void OnClickButton(DialogResult result)
        {
            if (DialogResult.None.Equals(result)) return;

            DialogResult = result;
            Close();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.FormClosed" />
        /// event.
        /// </summary>
        /// <param name="e">
        /// A <see cref="T:System.Windows.Forms.FormClosedEventArgs" />
        /// that contains the event data.
        /// </param>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (_timer == null) return;

            _timer.Enabled = false;
            _timer.Stop();
            _timer.Dispose();

            // Auto–reset metrics unless the user has suppressed it.
            // (In case the user forgot.)
            if (DarkMessageBoxMetrics.SuppressAutoReset) return;

            // Write a helpful message to the Debug output, in case this is not what
            // the user of this NuGet package intended.
            Debug.WriteLine(Resources.Reminder_SuppressAutoReset);

            DarkMessageBoxThemeManager.ApplyTheme(
                ProfessionalDarkTheme.Instance
            );
        }

        /// <summary>
        /// Called when the underlying Win32 handle has been created.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            DarkNet.Instance.SetWindowThemeForms(
                this,
                DarkMessageBoxMetrics.TitleBarIsLight ? Theme.Light : Theme.Dark
            );
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyDown" />
        /// event.
        /// </summary>
        /// <param name="e">
        /// A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that
        /// contains the event data.
        /// </param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            /*
             * Mimic the functionality of Win32 MessageBox, which allows
             * the user to copy the message text to the clipboard by
             * simply pressing CTRL+C while the MessageBox is active.
             *
             * This generates a text version of the MessageBox, which is
             * then placed on the Clipboard.
             */

            if (!e.Control || e.KeyCode != Keys.C) return;

            var sb = new StringBuilder();
            sb.AppendLine("---------------------------");
            sb.AppendLine(Text);
            sb.AppendLine("---------------------------");
            sb.AppendLine(_messageLabel.Text);
            sb.AppendLine("---------------------------");

            foreach (var btn in _buttons)
                sb.Append(btn.Text.Replace("&", "") + "   ");

            sb.AppendLine();
            sb.AppendLine("---------------------------");

            Clipboard.SetText(sb.ToString());
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Form.Load" /> event.</summary>
        /// <param name="e">
        /// An <see cref="T:System.EventArgs" /> that contains the event
        /// data.
        /// </param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            DialogResult = DialogResult.None;

            if (_autoCloseAfterMilliseconds <= 0) return;
        }

        /// <summary>
        /// Handles the <see cref="E:System.Windows.Forms.Control.Paint" /> event raised by
        /// one of the button controls in the footer panel of the message box when the
        /// operating system needs to repaint it.
        /// </summary>
        /// <param name="sender">
        /// (Required.) Reference to an instance of the object that
        /// raised this event.
        /// </param>
        /// <param name="e">
        /// (Required.) A
        /// <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event
        /// data.
        /// </param>
        /// <remarks>
        /// This method controls the painting of an individual button in the
        /// footer panel.
        /// </remarks>
        private void OnPaintButton(object sender, PaintEventArgs e)
        {
            if (!(sender is Button btn) || AcceptButton != btn) return;

            var g      = e.Graphics;
            var bounds = btn.ClientRectangle;

            if (DarkMessageBoxMetrics.HighlightDefaultButtonBackground)
            {
                using (var brush = new SolidBrush(
                           DarkMessageBoxMetrics.DefaultButtonBackgroundColor
                       ))
                {
                    e.Graphics.FillRectangle(brush, btn.ClientRectangle);
                }

                using (var borderPen = new Pen(
                           DarkMessageBoxMetrics.DefaultButtonBorderColor, 1))
                {
                    g.DrawRectangle(borderPen, 0, 0, bounds.Width - 1, bounds.Height - 1);
                }

                TextRenderer.DrawText(
                    g,
                    btn.Text,
                    btn.Font,
                    bounds,
                    DarkMessageBoxMetrics.ButtonTextColor,
                    TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter   |
                    TextFormatFlags.SingleLine);
            }
            else
            {
                var rect = btn.ClientRectangle;
                rect.Inflate(-2, -2);
                using (var pen = new Pen(
                           DarkMessageBoxMetrics.DefaultButtonBorderColor,
                           DarkMessageBoxMetrics.DefaultButtonBorderThickness
                       ))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }

        /// <summary>
        /// Given the values of the <paramref name="buttons" /> and
        /// <paramref name="defaultButton" /> parameters, respectively, dynamically
        /// configures the buttons that are to be displayed on the message box, along with
        /// their layout and appearance.
        /// <para />
        /// The results are then stored in the
        /// <see cref="F:xyLOGIX.DarkMessageBox.InternalDarkMessageBox._buttons" />
        /// collection, and then are displayed on this form.
        /// </summary>
        /// <param name="buttons">
        /// (Required.) One of the <see cref="T:System.Windows.Forms.MessageBoxButtons" />
        /// enumeration value(s) that identifies the button(s) that are to be displayed to
        /// the user to offer the user their choices.
        /// </param>
        /// <param name="defaultButton">
        /// (Required.) One of the
        /// <see cref="T:System.Windows.Forms.MessageBoxDefaultButton" /> enumeration
        /// value(s) that identifies which button is to be made the default; i.e., its
        /// <c>Click</c> event is raised if the user presses the <c>ENTER</c> key on the
        /// keyboard.
        /// </param>
        /// <remarks>
        /// The text of the buttons can be configured by setting the values in the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.ButtonTexts" />
        /// dictionary prior to the display of this message box.
        /// </remarks>
        private void OnSetButtons(
            MessageBoxButtons buttons,
            MessageBoxDefaultButton defaultButton
        )
        {
            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    AddButton(DialogResult.OK);
                    AcceptButton = _buttons[0];
                    break;

                case MessageBoxButtons.OKCancel:
                    AddButton(DialogResult.OK);
                    AddButton(DialogResult.Cancel);
                    AcceptButton = _buttons[0];
                    CancelButton = _buttons[1];
                    break;

                case MessageBoxButtons.YesNo:
                    AddButton(DialogResult.Yes);
                    AddButton(DialogResult.No);
                    AcceptButton = _buttons[0];
                    CancelButton = _buttons[1];
                    break;

                case MessageBoxButtons.YesNoCancel:
                    AddButton(DialogResult.Yes);
                    AddButton(DialogResult.No);
                    AddButton(DialogResult.Cancel);
                    AcceptButton = _buttons[0];
                    CancelButton = _buttons[2];
                    break;

                case MessageBoxButtons.RetryCancel:
                    AddButton(DialogResult.Retry);
                    AddButton(DialogResult.Cancel);
                    AcceptButton = _buttons[0];
                    CancelButton = _buttons[1];
                    break;

                case MessageBoxButtons.AbortRetryIgnore:
                    AddButton(DialogResult.Abort);
                    AddButton(DialogResult.Retry);
                    AddButton(DialogResult.Ignore);
                    AcceptButton = _buttons[1];
                    CancelButton = _buttons[2];
                    break;
            }

            switch (defaultButton)
            {
                case MessageBoxDefaultButton.Button1:
                    if (_buttons.Count > 0)
                        _buttons[0]
                            .Focus(); // ✅ NOT .Select()
                    break;

                case MessageBoxDefaultButton.Button2:
                    if (_buttons.Count > 1)
                        _buttons[1]
                            .Focus();
                    break;

                case MessageBoxDefaultButton.Button3:
                    if (_buttons.Count > 2)
                        _buttons[2]
                            .Focus();
                    break;
            }
        }

        /// <summary>
        /// Sets the text that is to be displayed in the titlebar of the message box.
        /// </summary>
        /// <param name="caption">
        /// (Required.) A <see cref="T:System.String" /> that
        /// contains the text that is to be displayed in the titlebar of the message box.
        /// </param>
        /// <remarks>
        /// This method does nothing if a <see langword="null" />, blank, or
        /// <see cref="F:System.String.Empty" /> value is passed as the argument of the
        /// <paramref name="caption" /> parameter.
        /// </remarks>
        private void OnSetCaption(string caption)
        {
            if (string.IsNullOrWhiteSpace(caption))
                return;

            Text = caption;
        }

        /// <summary>
        /// Sets the icon that is to be displayed in the body of the message box next to
        /// the message content.
        /// </summary>
        /// <param name="icon">
        /// (Required.) One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" />
        /// enumeration value(s) that identifies the standardized system icon to be
        /// displayed next to the message content, or
        /// <see cref="F:System.Windows.Forms.MessageBoxIcon.None" /> to display no icon.
        /// <para />
        /// This parameter is ignored if the value of the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.MessageBodyIcon" />
        /// property is not a <see langword="null" /> reference when this constructor is
        /// called.
        /// </param>
        /// <remarks>
        /// If the <see cref="F:System.Windows.Forms.MessageBoxIcon.None" /> value
        /// is passed for the <paramref name="icon" /> parameter, then no image is
        /// displayed.
        /// <para />
        /// This value can be overriden with a custom icon by setting the value of the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.MessageBodyIcon" />
        /// property to something other than a <see langword="null" /> reference.
        /// </remarks>
        private void OnSetIcon(MessageBoxIcon icon)
        {
            if (_iconBox == null) return;
            if (_iconBox.IsDisposed) return;

            if (DarkMessageBoxMetrics.MessageBodyIcon != null)
            {
                /*
                 * Override the default system icon with a custom icon
                 * supplied by the user via the DarkMessageBoxMetrics
                 * class.
                 */

                _iconBox.Image =
                    DarkMessageBoxMetrics.MessageBodyIcon.ToBitmap();
                return;
            }

            switch (icon)
            {
                case MessageBoxIcon.Error:
                    _iconBox.Image = SystemIcons.Error.ToBitmap();
                    break;

                case MessageBoxIcon.Warning:
                    _iconBox.Image = SystemIcons.Warning.ToBitmap();
                    break;

                case MessageBoxIcon.Information:
                    _iconBox.Image = SystemIcons.Information.ToBitmap();
                    break;

                case MessageBoxIcon.Question:
                    _iconBox.Image = SystemIcons.Question.ToBitmap();
                    break;

                default:
                    _iconBox.Visible = false;
                    _messageLabel.Location = new Point(15, 15);
                    break;
            }
        }

        /// <summary>
        /// Sets the content of the message label to the specified
        /// <paramref name="message" />.
        /// </summary>
        /// <param name="message">
        /// (Required.) A <see cref="T:System.String" /> that contains the message content.
        /// <para />
        /// To create a newline, simply use the ASCII <c>LF</c> character; i.e., <c>\n</c>.
        /// <para />
        /// The ASCII <c>CR</c> character is not necessary.
        /// </param>
        /// <remarks>
        /// This method takes no action if the
        /// <see cref="F:xyLOGIX.DarkMessageBox.InternalDarkMessageBox._messageLabel" />
        /// field is set to a <see langword="null" /> reference, or if its
        /// <see cref="P:System.Windows.Forms.Control.IsDisposed" /> property is set to
        /// <see langword="true" />, or if the <paramref name="message" /> is
        /// <see langword="null" />, blank, or the <see cref="F:System.String.Empty" />
        /// value.
        /// </remarks>
        private void OnSetMessage(string message)
        {
            if (_messageLabel == null) return;
            if (_messageLabel.IsDisposed)
                return; // This should never happen, but just in case...
            if (string.IsNullOrWhiteSpace(message)) return;


            _messageLabel.Text = message;
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Form.Shown" /> event.</summary>
        /// <param name="e">
        /// A <see cref="T:System.EventArgs" /> that contains the event
        /// data.
        /// </param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // If the _autoCloseAfterMilliseconds field is less than or
            // equal to zero, then do nothing.
            if (_autoCloseAfterMilliseconds <= 0) return;

            if (_timer == null) return;

            // Enable and start the auto-close timer here.
            _timer.Enabled = true;
            _timer.Start();
        }

        /// <summary>
        /// Handles the <see cref="E:System.Windows.Forms.Timer.Tick" /> event raised by
        /// the <see cref="T:System.Windows.Forms.Timer" /> component that controls the
        /// automatic dismissal of this message box, when the configured time interval (in
        /// milliseconds) has elapsed.
        /// </summary>
        /// <param name="sender">
        /// Reference to an instance of the object that raised the
        /// event.
        /// </param>
        /// <param name="e">
        /// A <see cref="T:System.EventArgs" /> that contains the event
        /// data.
        /// </param>
        /// <remarks>
        /// This method responds by disabling the
        /// <see cref="T:System.Windows.Forms.Timer" /> component, stopping it, and then
        /// closing this message box.
        /// </remarks>
        private void OnTimerTick(object sender, EventArgs e)
        {
            // Stop the timer.
            if (_timer == null) return;

            _timer.Enabled = false;
            _timer.Stop();

            // Set the dialog result to the proper value (that of the
            // leftmost button by default) and close the form.
            DialogResult = DetermineAutoCloseDialogResult();
            Close();
        }

        /// <summary>
        /// Given the values of the <paramref name="buttons" /> and
        /// <paramref name="defaultButton" /> parameters, respectively, dynamically
        /// configures the buttons that are to be displayed on the message box, along with
        /// their layout and appearance.
        /// <para />
        /// The results are then stored in the
        /// <see cref="F:xyLOGIX.DarkMessageBox.InternalDarkMessageBox._buttons" />
        /// collection, and then are displayed on this form.
        /// </summary>
        /// <param name="buttons">
        /// (Required.) One of the <see cref="T:System.Windows.Forms.MessageBoxButtons" />
        /// enumeration value(s) that identifies the button(s) that are to be displayed to
        /// the user to offer the user their choices.
        /// </param>
        /// <param name="defaultButton">
        /// (Required.) One of the
        /// <see cref="T:System.Windows.Forms.MessageBoxDefaultButton" /> enumeration
        /// value(s) that identifies which button is to be made the default; i.e., its
        /// <c>Click</c> event is raised if the user presses the <c>ENTER</c> key on the
        /// keyboard.
        /// </param>
        /// <remarks>
        /// The text of the buttons can be configured by setting the values in the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.ButtonTexts" />
        /// dictionary prior to the display of this message box.
        /// </remarks>
        private void SetButtons(
            MessageBoxButtons buttons,
            MessageBoxDefaultButton defaultButton
        )
        {
            /*
             * Just in case, ensure that the call is properly marshalled
             * across thread boundaries to the UI thread.
             */

            if (InvokeRequired)
                BeginInvoke(
                    new Action<MessageBoxButtons, MessageBoxDefaultButton>(
                        OnSetButtons
                    ), buttons, defaultButton
                );
            else
                OnSetButtons(buttons, defaultButton);
        }

        /// <summary>
        /// Sets the text that is to be displayed in the titlebar of the message box.
        /// </summary>
        /// <param name="caption">
        /// (Required.) A <see cref="T:System.String" /> that
        /// contains the text that is to be displayed in the titlebar of the message box.
        /// </param>
        /// <remarks>
        /// This method does nothing if a <see langword="null" />, blank, or
        /// <see cref="F:System.String.Empty" /> value is passed as the argument of the
        /// <paramref name="caption" /> parameter.
        /// </remarks>
        private void SetCaption(string caption)
        {
            /*
             * Just in case, ensure that the call is properly marshalled
             * across thread boundaries to the UI thread.
             */

            if (InvokeRequired)
                BeginInvoke(new Action<string>(OnSetCaption), caption);
            else
                OnSetCaption(caption);
        }

        /// <summary>
        /// Sets the icon that is to be displayed in the body of the message box next to
        /// the message content.
        /// </summary>
        /// <param name="icon">
        /// (Required.) One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" />
        /// enumeration value(s) that identifies the standardized system icon to be
        /// displayed next to the message content, or
        /// <see cref="F:System.Windows.Forms.MessageBoxIcon.None" /> to display no icon.
        /// <para />
        /// This parameter is ignored if the value of the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.MessageBodyIcon" />
        /// property is not a <see langword="null" /> reference when this constructor is
        /// called.
        /// </param>
        /// <remarks>
        /// If the <see cref="F:System.Windows.Forms.MessageBoxIcon.None" /> value
        /// is passed for the <paramref name="icon" /> parameter, then no image is
        /// displayed.
        /// <para />
        /// This value can be overriden with a custom icon by setting the value of the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.MessageBodyIcon" />
        /// property to something other than a <see langword="null" /> reference.
        /// </remarks>
        private void SetIcon(MessageBoxIcon icon)
        {
            /*
             * Just in case, ensure that the call is properly marshalled
             * across thread boundaries to the UI thread.
             */

            if (InvokeRequired)
                BeginInvoke(new Action<MessageBoxIcon>(OnSetIcon), icon);
            else
                OnSetIcon(icon);
        }

        /// <summary>
        /// Sets the content of the message label to the specified
        /// <paramref name="message" />.
        /// </summary>
        /// <param name="message">
        /// (Required.) A <see cref="T:System.String" /> that contains the message content.
        /// <para />
        /// To create a newline, simply use the ASCII <c>LF</c> character; i.e., <c>\n</c>.
        /// <para />
        /// The ASCII <c>CR</c> character is not necessary.
        /// </param>
        /// <remarks>
        /// This method takes no action if the
        /// <see cref="F:xyLOGIX.DarkMessageBox.InternalDarkMessageBox._messageLabel" />
        /// field is set to a <see langword="null" /> reference, or if its
        /// <see cref="P:System.Windows.Forms.Control.IsDisposed" /> property is set to
        /// <see langword="true" />, or if the <paramref name="message" /> is
        /// <see langword="null" />, blank, or the <see cref="F:System.String.Empty" />
        /// value.
        /// </remarks>
        private void SetMessage(string message)
        {
            /*
             * Just in case, ensure that the call is properly marshalled
             * across thread boundaries to the UI thread.
             */

            if (InvokeRequired)
                BeginInvoke(new Action<string>(OnSetMessage), message);
            else
                OnSetMessage(message);
        }
    }
}