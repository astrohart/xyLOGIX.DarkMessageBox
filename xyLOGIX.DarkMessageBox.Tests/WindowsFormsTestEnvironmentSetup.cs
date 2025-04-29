// ReSharper disable InconsistentNaming

using NUnit.Framework;
using System.Threading;
using System.Windows.Forms;

namespace xyLOGIX.DarkMessageBox.Tests
{
    /// <summary>
    /// Ensures that Windows Forms is correctly initialized
    /// for unit tests, with visual styles and compatible text rendering.
    /// </summary>
    [SetUpFixture]
    [Apartment(ApartmentState.STA)] // Very important for WinForms apps
    public sealed class WindowsFormsTestEnvironmentSetup
    {
        private static bool _initialized;

        /// <summary>
        /// One-time setup to prepare Windows Forms environment before any tests run.
        /// </summary>
        [OneTimeSetUp]
        public void InitializeWindowsForms()
        {
            if (_initialized)
                return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _initialized = true;
        }
    }
}