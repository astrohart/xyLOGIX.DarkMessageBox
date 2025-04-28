using Dark.Net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace xyLOGIX.DarkMessageBox
{
    /// <summary>
    /// Provides a dark-themed equivalent to the standard
    /// <see cref="T:System.Windows.Forms.MessageBox" />.
    /// </summary>
    public static class DarkMessageBox
    {
        public static DialogResult Show(
            string text,
            string caption,
            MessageBoxButtons buttons = MessageBoxButtons.OK,
            MessageBoxIcon icon = MessageBoxIcon.None,
            MessageBoxDefaultButton defaultButton =
                MessageBoxDefaultButton.Button1,
            int autoCloseAfterMilliseconds = 0
        )
        {
            using (var form = new InternalDarkMessageBox(
                       text, caption, buttons, icon, defaultButton,
                       autoCloseAfterMilliseconds
                   ))
            {
                form.StartPosition = FormStartPosition.CenterScreen;
                return form.ShowDialog();
            }
        }

        public static DialogResult Show(
            IWin32Window owner,
            string text,
            string caption,
            MessageBoxButtons buttons = MessageBoxButtons.OK,
            MessageBoxIcon icon = MessageBoxIcon.None,
            MessageBoxDefaultButton defaultButton =
                MessageBoxDefaultButton.Button1,
            int autoCloseAfterMilliseconds = 0
        )
        {
            using (var form = new InternalDarkMessageBox(
                       text, caption, buttons, icon, defaultButton,
                       autoCloseAfterMilliseconds
                   ))
            {
                form.StartPosition = FormStartPosition.CenterParent;
                return form.ShowDialog(owner);
            }
        }

        private sealed class InternalDarkMessageBox : Form
        {
            private readonly int _autoCloseAfterMilliseconds;
            private readonly List<Button> _buttons = new List<Button>();
            private readonly string _captionText;
            private Panel _footerPanel;
            private PictureBox _iconBox;
            private Label _messageLabel;
            private Panel _spacerPanel;

            public InternalDarkMessageBox(
                string text,
                string caption,
                MessageBoxButtons buttons,
                MessageBoxIcon icon,
                MessageBoxDefaultButton defaultButton,
                int autoCloseAfterMilliseconds
            )
            {
                _captionText = caption;
                _autoCloseAfterMilliseconds = autoCloseAfterMilliseconds;
                InitializeComponents();
                Text = caption;
                SetMessage(text);
                SetIcon(icon);
                SetButtons(buttons, defaultButton);
                AutoSizeForm();
            }

            private void AutoSizeForm()
            {
                var buttonAreaWidth =
                    _buttons.Count * DarkMessageBoxMetrics.ButtonWidth +
                    (_buttons.Count - 1) * DarkMessageBoxMetrics.ButtonSpacing;

                var captionWidth = TextRenderer.MeasureText(_captionText, Font)
                                               .Width + 40;
                var messageWidth =
                    _messageLabel.PreferredWidth + _iconBox.Width + 36;

                var rawContentWidth = Math.Max(
                    Math.Max(captionWidth, messageWidth),
                    buttonAreaWidth + 2 * DarkMessageBoxMetrics.RightMargin
                );

                var minWidth = _buttons.Count >= 3
                    ? DarkMessageBoxMetrics.MinimumFormWidthMultiButton
                    : DarkMessageBoxMetrics.MinimumFormWidthSingleButton;

                var formWidth = Math.Max(
                    minWidth,
                    Math.Min(
                        rawContentWidth, DarkMessageBoxMetrics.MaximumFormWidth
                    )
                );

                _messageLabel.MaximumSize = new Size(
                    formWidth - _iconBox.Width - 36, 0
                );
                _messageLabel.PerformLayout();
                _messageLabel.AutoSize = true;

                var contentBottom = Math.Max(
                    _messageLabel.Bottom, _iconBox.Bottom
                );

                _spacerPanel.Location = new Point(0, contentBottom);
                _spacerPanel.Width = formWidth;

                ClientSize = new Size(
                    formWidth,
                    contentBottom + _spacerPanel.Height + _footerPanel.Height
                );

                var totalButtonWidth =
                    _buttons.Count * DarkMessageBoxMetrics.ButtonWidth +
                    (_buttons.Count - 1) * DarkMessageBoxMetrics.ButtonSpacing;

                var startX = ClientSize.Width -
                             DarkMessageBoxMetrics.RightMargin -
                             totalButtonWidth;
                var buttonTop = (_footerPanel.Height -
                                 DarkMessageBoxMetrics.ButtonHeight) / 2;

                for (var i = 0; i < _buttons.Count; i++)
                {
                    _buttons[i].Location = new Point(
                        startX + i * (DarkMessageBoxMetrics.ButtonWidth +
                                      DarkMessageBoxMetrics.ButtonSpacing),
                        buttonTop
                    );
                }
            }

            private void Button_Paint(object sender, PaintEventArgs e)
            {
                if (sender is Button btn && AcceptButton == btn)
                {
                    if (DarkMessageBoxMetrics.HighlightDefaultButtonBackground)
                    {
                        using (var brush = new SolidBrush(
                                   DarkMessageBoxMetrics
                                       .DefaultButtonBackgroundColor
                               ))
                            e.Graphics.FillRectangle(
                                brush, btn.ClientRectangle
                            );
                    }
                    else
                    {
                        var rect = btn.ClientRectangle;
                        rect.Inflate(-2, -2);
                        using (var pen = new Pen(
                                   DarkMessageBoxMetrics
                                       .DefaultButtonBorderColor,
                                   DarkMessageBoxMetrics
                                       .DefaultButtonBorderThickness
                               ))
                        {
                            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            e.Graphics.DrawRectangle(pen, rect);
                        }
                    }
                }
            }

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
                    Location = new Point(60, 15),
                    MaximumSize = new Size(400, 0),
                    AutoSize = true
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

                KeyDown += OnKeyDown;
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
                    DarkMessageBoxMetrics.TitleBarIsLight
                        ? Theme.Light
                        : Theme.Dark
                );
            }

            private void OnKeyDown(object sender, KeyEventArgs e)
            {
                if (e.Control && e.KeyCode == Keys.C)
                {
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
            }

            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);

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

                if (_autoCloseAfterMilliseconds <= 0) return;

                var timer = new Timer();
                timer.Interval = _autoCloseAfterMilliseconds;
                timer.Tick += (s, ev) =>
                {
                    timer.Stop();
                    DialogResult = DialogResult.OK;
                    Close();
                };
                timer.Start();
            }

            private void SetButtons(
                MessageBoxButtons buttons,
                MessageBoxDefaultButton defaultButton
            )
            {
                void AddButton(DialogResult result)
                {
                    var text =
                        DarkMessageBoxMetrics.ButtonTexts.ContainsKey(result)
                            ? DarkMessageBoxMetrics.ButtonTexts[result]
                            : result.ToString();

                    var btn = new Button
                    {
                        Text = text,
                        DialogResult = result,
                        BackColor =
                            DarkMessageBoxMetrics.ButtonBackgroundColor,
                        ForeColor = DarkMessageBoxMetrics.ButtonTextColor,
                        FlatStyle = FlatStyle.Flat,
                        Width = DarkMessageBoxMetrics.ButtonWidth,
                        Height = DarkMessageBoxMetrics.ButtonHeight
                    };
                    btn.FlatAppearance.BorderColor =
                        DarkMessageBoxMetrics.ButtonBorderColor;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.Paint += Button_Paint;
                    _buttons.Add(btn);
                    _footerPanel.Controls.Add(btn);
                }

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
                                .Select();
                        break;
                    case MessageBoxDefaultButton.Button2:
                        if (_buttons.Count > 1)
                            _buttons[1]
                                .Select();
                        break;
                    case MessageBoxDefaultButton.Button3:
                        if (_buttons.Count > 2)
                            _buttons[2]
                                .Select();
                        break;
                }
            }

            private void SetIcon(MessageBoxIcon icon)
            {
                if (DarkMessageBoxMetrics.MessageBodyIcon != null)
                {
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

            private void SetMessage(string message)
                => _messageLabel.Text = message;
        }
    }
}