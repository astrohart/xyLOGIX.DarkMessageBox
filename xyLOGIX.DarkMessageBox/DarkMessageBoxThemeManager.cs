using System;
using System.Diagnostics;
using xyLOGIX.DarkMessageBox.Interfaces;
using xyLOGIX.DarkMessageBox.Themes;

namespace xyLOGIX.DarkMessageBox
{
    /// <summary>
    /// Manages the currently applied and previous themes for
    /// <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox" /> dialogs.
    /// </summary>
    public static class DarkMessageBoxThemeManager
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBoxThemeManager" />
        /// class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        static DarkMessageBoxThemeManager()

            // Apply the default theme always
            => CurrentTheme.Apply();

        /// <summary>
        /// Gets the currently active theme.
        /// </summary>
        public static IDarkMessageBoxTheme CurrentTheme
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] private set;
        } = ProfessionalDarkTheme.Instance;

        /// <summary>
        /// Gets the previously active theme.
        /// </summary>
        public static IDarkMessageBoxTheme PreviousTheme
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] private set;
        }

        /// <summary>
        /// Applies the specified theme, remembering the previously active one.
        /// </summary>
        /// <param name="theme">The new theme to apply.</param>
        public static void ApplyTheme(IDarkMessageBoxTheme theme)
        {
            if (theme == null)
                return;

            PreviousTheme = CurrentTheme;
            CurrentTheme = theme;
            theme.Apply();
        }

        /// <summary>
        /// Reapplies the previously active theme, if one exists.
        /// </summary>
        public static void RevertToPreviousTheme()
        {
            if (PreviousTheme == null) return;

            (CurrentTheme, PreviousTheme) = (PreviousTheme, CurrentTheme);
            CurrentTheme.Apply();
        }

        /// <summary>
        /// Applies <paramref name="theme" />, runs <paramref name="action" />,
        /// then reverts to the previous theme ? even if an exception is thrown.
        /// </summary>
        public static void WithTemporaryTheme(
            IDarkMessageBoxTheme theme,
            Action action
        )
        {
            ApplyTheme(theme);
            try
            {
                action();
            }
            finally
            {
                RevertToPreviousTheme();
            }
        }
    }
}