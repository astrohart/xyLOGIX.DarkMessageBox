using System.Windows.Forms;

namespace xyLOGIX.DarkMessageBox
{
    /// <summary>
    /// Provides a dark-themed equivalent to the standard
    /// <see cref="T:System.Windows.Forms.MessageBox" />.
    /// </summary>
    public static class DarkMessageBox
    {
        /// <summary>
        /// Displays a <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox" /> to the user
        /// and blocks the calling thread until the message box is dismissed.
        /// </summary>
        /// <param name="text">
        /// (Required.) A <see cref="T:System.String" /> containing the
        /// text of the message itself.
        /// <para />
        /// Use the <c>\n</c> character to create a newline (no <c>\r</c> character is
        /// necessary).
        /// </param>
        /// <param name="caption">
        /// (Required.) A <see cref="T:System.String" /> containing
        /// the caption that is to be displayed on the titlebar of the message box.
        /// </param>
        /// <param name="buttons">
        /// (Optional.) One of the
        /// <see cref="T:System.Windows.Forms.MessageBoxButtons" /> enumeration value(s)
        /// that describes the button(s) that are to be displayed on the message box.
        /// <para />
        /// The default value of this parameter is
        /// <see cref="F:System.Windows.Forms.MessageBoxButtons.OK" />, which displays only
        /// an <b>OK</b> button to the user.
        /// </param>
        /// <param name="icon">
        /// (Optional.) One of the
        /// <see cref="T:System.Windows.Forms.MessageBoxIcon" /> enumeration value(s) that
        /// specifies which standard system icon is to be displayed in the message box.
        /// <para />
        /// The value of the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.WindowIcon" />
        /// property overrides this parameter, if that property is set to a non-
        /// <see langword="null" /> value.
        /// <para />
        /// The default value of this parameter is
        /// <see cref="F:System.Windows.Forms.MessageBoxIcon.None" />, which displays no
        /// icon.
        /// </param>
        /// <param name="defaultButton">
        /// (Optional.) One of the
        /// <see cref="T:System.Windows.Forms.MessageBoxDefaultButton" /> enumeration
        /// value(s) that specifies which of the button(s) that are displayed is to be the
        /// default; i.e., which is "clicked" if the user presses the <c>ENTER</c> key on
        /// the keyboard while the message box is active.
        /// <para />
        /// The default value of this parameter is
        /// <see cref="F:System.Windows.Forms.MessageBoxDefaultButton.Button1" />, which
        /// means the leftmost button is the default.
        /// </param>
        /// <param name="autoCloseAfterMilliseconds">
        /// (Optional.) If set to greater than
        /// zero, the number of milliseconds the message box is to be displayed on the
        /// screen, without user interaction, before it is automatically dismissed.
        /// <para />
        /// The value of this parameter should only be set to zero or greater.
        /// <para />
        /// A value of zero, or less, means no automatic dismissal of the message box is to
        /// take place.
        /// <para/>
        /// The default value of this parameter is zero.
        /// </param>
        /// <remarks>
        /// This method displays a modal message box.
        /// <para />
        /// Unless the <paramref name="autoCloseAfterMilliseconds" /> parameter is set to a
        /// value greater than zero milliseconds, otherwise, the message box will remain on
        /// the screen and block the calling thread until the user selects an option to
        /// close it.
        /// </remarks>
        /// <returns>
        /// One of the <see cref="T:System.Windows.Forms.DialogResult" />
        /// enumeration value(s), that identifies the means by which the user dismissed the
        /// message box.
        /// </returns>
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

        /// <summary>
        /// Displays a <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox" /> to the user
        /// and blocks the calling thread until the message box is dismissed.
        /// </summary>
        /// <param name="owner">
        /// (Required.) Reference to an instance of an object that implements the
        /// <see cref="T:System.Windows.Forms.IWin32Window" /> interface that identifies
        /// the parent window of the message box.
        /// </param>
        /// <param name="text">
        /// (Required.) A <see cref="T:System.String" /> containing the
        /// text of the message itself.
        /// <para />
        /// Use the <c>\n</c> character to create a newline (no <c>\r</c> character is
        /// necessary).
        /// </param>
        /// <param name="caption">
        /// (Required.) A <see cref="T:System.String" /> containing
        /// the caption that is to be displayed on the titlebar of the message box.
        /// </param>
        /// <param name="buttons">
        /// (Optional.) One of the
        /// <see cref="T:System.Windows.Forms.MessageBoxButtons" /> enumeration value(s)
        /// that describes the button(s) that are to be displayed on the message box.
        /// <para />
        /// The default value of this parameter is
        /// <see cref="F:System.Windows.Forms.MessageBoxButtons.OK" />, which displays only
        /// an <b>OK</b> button to the user.
        /// </param>
        /// <param name="icon">
        /// (Optional.) One of the
        /// <see cref="T:System.Windows.Forms.MessageBoxIcon" /> enumeration value(s) that
        /// specifies which standard system icon is to be displayed in the message box.
        /// <para />
        /// The value of the
        /// <see cref="P:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics.WindowIcon" />
        /// property overrides this parameter, if that property is set to a non-
        /// <see langword="null" /> value.
        /// <para />
        /// The default value of this parameter is
        /// <see cref="F:System.Windows.Forms.MessageBoxIcon.None" />, which displays no
        /// icon.
        /// </param>
        /// <param name="defaultButton">
        /// (Optional.) One of the
        /// <see cref="T:System.Windows.Forms.MessageBoxDefaultButton" /> enumeration
        /// value(s) that specifies which of the button(s) that are displayed is to be the
        /// default; i.e., which is "clicked" if the user presses the <c>ENTER</c> key on
        /// the keyboard while the message box is active.
        /// <para />
        /// The default value of this parameter is
        /// <see cref="F:System.Windows.Forms.MessageBoxDefaultButton.Button1" />, which
        /// means the leftmost button is the default.
        /// </param>
        /// <param name="autoCloseAfterMilliseconds">
        /// (Optional.) If set to greater than
        /// zero, the number of milliseconds the message box is to be displayed on the
        /// screen, without user interaction, before it is automatically dismissed.
        /// <para />
        /// The value of this parameter should only be set to zero or greater.
        /// <para />
        /// A value of zero, or less, means no automatic dismissal of the message box is to
        /// take place.
        /// <para/>
        /// The default value of this parameter is zero.
        /// </param>
        /// <remarks>
        /// This method displays a modal message box.
        /// <para />
        /// Unless the <paramref name="autoCloseAfterMilliseconds" /> parameter is set to a
        /// value greater than zero milliseconds, otherwise, the message box will remain on
        /// the screen and block the calling thread until the user selects an option to
        /// close it.
        /// </remarks>
        /// <returns>
        /// One of the <see cref="T:System.Windows.Forms.DialogResult" />
        /// enumeration value(s), that identifies the means by which the user dismissed the
        /// message box.
        /// </returns>
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
    }
}