using System.Diagnostics;
using xyLOGIX.DarkMessageBox.Interfaces;

namespace xyLOGIX.DarkMessageBox.Themes
{
    /// <summary>
    /// A standard default theme for
    /// <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox" /> dialogs.
    /// </summary>
    public class ProfessionalDarkTheme : IDarkMessageBoxTheme
    {
        /// <summary>
        /// Empty, <c>static</c> constructor to prohibit direct allocation of this class.
        /// </summary>
        static ProfessionalDarkTheme() { }

        /// <summary>
        /// Empty, <c>private</c> constructor to prohibit direct allocation of this class.
        /// </summary>
        private ProfessionalDarkTheme() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see cref="T:xyLOGIX.DarkMessageBox.Interfaces.IDarkMessageBoxTheme" />
        /// interface.
        /// </summary>
        public static IDarkMessageBoxTheme Instance
        {
            [DebuggerStepThrough] get;
        } = new ProfessionalDarkTheme();

        /// <summary>
        /// Applies the theme to <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics" />.
        /// </summary>
        /// <remarks>
        /// If this method is overriden, the base-class version must be called
        /// first.
        /// </remarks>
        public virtual void Apply()
            => DarkMessageBoxMetrics.Reset();
    }
}