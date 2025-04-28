using xyLOGIX.DarkMessageBox.Interfaces;

namespace xyLOGIX.DarkMessageBox
{
    /// <summary>
    /// Manages the currently applied and previous themes for <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox" /> dialogs.
    /// </summary>
    public static class DarkMessageBoxThemeManager
    {
        /// <summary>
        /// Gets the currently active theme.
        /// </summary>
        public static IDarkMessageBoxTheme CurrentTheme { get; private set; }

        /// <summary>
        /// Gets the previously active theme.
        /// </summary>
        public static IDarkMessageBoxTheme PreviousTheme { get; private set; }

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
            if (PreviousTheme != null)
            {
                var temp = CurrentTheme;
                CurrentTheme = PreviousTheme;
                PreviousTheme = temp;
                CurrentTheme.Apply();
            }
        }
    }
}
