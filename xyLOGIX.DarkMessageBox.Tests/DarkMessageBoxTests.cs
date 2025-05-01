// ReSharper disable StringLiteralTypo

using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using xyLOGIX.DarkMessageBox.Themes;

namespace xyLOGIX.DarkMessageBox.Tests
{
    /// <summary>
    /// Provides unit tests for the
    /// <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox" /> functionality.
    /// </summary>
    [TestFixture, Apartment(ApartmentState.STA)]

    // IMPORTANT for Windows Forms!
    public class DarkMessageBoxTests
    {
        /// <summary>
        /// Provides a collection of test cases to verify different combinations of message
        /// box settings.
        /// </summary>
        private static IEnumerable<TestCaseData> MessageBoxTestCases
        {
            get
            {
                yield return new TestCaseData(
                    "This is a test OK MessageBox.", "Test OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1
                ).SetName("OK_MessageBox");

                yield return new TestCaseData(
                    "Do you want to continue?", "Test OKCancel",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2
                ).SetName("OKCancel_MessageBox_DefaultButton2");

                yield return new TestCaseData(
                    "Save changes before exiting?", "Test YesNo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1
                ).SetName("YesNo_MessageBox");

                yield return new TestCaseData(
                    "Would you like to save your progress before quitting?",
                    "Test YesNoCancel", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button3
                ).SetName("YesNoCancel_MessageBox_DefaultButton3");

                yield return new TestCaseData(
                    "The operation failed. Would you like to retry?",
                    "Test RetryCancel", MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button2
                ).SetName("RetryCancel_MessageBox");

                yield return new TestCaseData(
                    "An unrecoverable error occurred. Choose an action:",
                    "Test AbortRetryIgnore", MessageBoxButtons.AbortRetryIgnore,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1
                ).SetName("AbortRetryIgnore_MessageBox");

                yield return new TestCaseData(
                    "This is a very long message to test whether the message box resizes itself vertically and horizontally as needed to accommodate the full text without unnecessary clipping or excessive empty space. Please visually inspect the window sizing.",
                    "Test Long Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1
                ).SetName("Long_MessageBox_Sizing");

                yield return new TestCaseData(
                    "x = 5", "Math Result", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1
                ).SetName("TinyMessage_MinimumWidth_MessageBox");

                yield return new TestCaseData(
                    "Short text",
                    "This is a very very very very very very very very very very long caption that might otherwise stretch the dialog",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2
                ).SetName("LongCaption_MessageBox");

                yield return new TestCaseData(
                    "This is a super long message to ensure that the maximum width capping logic works correctly and no matter how much you type the window never grows beyond the intended limits, wrapping text neatly onto multiple lines and maintaining professional layout with no ugly gaps or runoffs.",
                    "Test Max Width Cap", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1
                ).SetName("MaxWidthCapped_MessageBox");

                yield return new TestCaseData(
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.\n\n" +
                    "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.\n\n" +
                    "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.\n\n" +
                    "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\n\n" +
                    "Curabitur pretium tincidunt lacus. Nulla gravida orci a odio. Nullam varius, turpis et commodo pharetra, est eros bibendum elit, nec luctus magna felis sollicitudin mauris.",
                    "Lorem Ipsum Test", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1
                ).SetName("MultiParagraph_MessageBox");
            }
        }

        /// <summary>
        /// Displays a <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox" /> using various
        /// configurations to
        /// validate its behavior.
        /// </summary>
        [Test, TestCaseSource(nameof(MessageBoxTestCases))]
        public void Show_DarkMessageBox_WithVariousSettings(
            string message,
            string caption,
            MessageBoxButtons buttons,
            MessageBoxIcon icon,
            MessageBoxDefaultButton defaultButton
        )
            => DarkMessageBox.Show(
                message, caption, buttons, icon, defaultButton
            );

        /// <summary>
        /// Displays a <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox" /> using the
        /// System Color theme.
        /// </summary>
        /// <remarks>
        /// This illustrates causing the appearance of the message box to exactly
        /// match that of the system-provided message boxes using the
        /// <see cref="T:xyLOGIX.DarkMessageBox.Themes.SystemColorTheme" /> class.
        /// <para />
        /// This is provided to illustrate how to make a
        /// <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox" /> look like the default.
        /// </remarks>
        [Test]
        public void Show_DarkMessageBox_ThemedAsSystem()
        {
            // Apply the system color theme
            DarkMessageBoxThemeManager.ApplyTheme(SystemColorTheme.Instance);

            // Show a message box with the system theme
            DarkMessageBox.Show(
                @"The file 'C:\foo.txt' has been modified.\n\nDid you want to save your changes?", "System Theme Test",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2
            );
        }

        /// <summary>
        /// Displays a <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox" /> that
        /// automatically closes after
        /// a delay,
        /// to verify auto-close functionality during tests.
        /// </summary>
        [Test]
        public void Show_DarkMessageBox_WithAutoClose()
            => DarkMessageBox.Show(
                "This dialog will auto-close in 2 seconds.", "Auto-Close Test",
                MessageBoxButtons.OK, MessageBoxIcon.Information,
                autoCloseAfterMilliseconds: 2000
            );

        /// <summary>
        /// Demonstrates theme switching between custom themes and default.
        /// </summary>
        [Test]
        public void Show_DarkMessageBox_ThemeSwitchingAndResetTest()
        {
            // Apply Bart Simpson Theme
            DarkMessageBoxThemeManager.ApplyTheme(BartSimpsonTheme.Instance);
            DarkMessageBox.Show(
                "Whoa, dude! That file you're lookin' for is totally MIA!",
                "My Bart Simpson Game", MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            // Apply Cowabunga Theme
            DarkMessageBoxThemeManager.ApplyTheme(CowabungaTheme.Instance);
            DarkMessageBox.Show(
                "Cowabunga, dude!", "TMNT Test", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2
            );

            // Restore Default Professional Theme
            DarkMessageBoxThemeManager.ApplyTheme(
                ProfessionalDarkTheme.Instance
            );
            DarkMessageBox.Show(
                "Theme has been reset to defaults.", "Default Theme",
                MessageBoxButtons.OK, MessageBoxIcon.Information
            );
        }
    }
}