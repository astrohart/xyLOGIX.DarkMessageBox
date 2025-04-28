namespace xyLOGIX.DarkMessageBox.Interfaces
{
    /// <summary>
    /// Defines a contract for applying a visual theme to <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox" /> dialogs.
    /// </summary>
    public interface IDarkMessageBoxTheme
    {
        /// <summary>
        /// Applies the theme to <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBoxMetrics" />.
        /// </summary>
        void Apply();
    }
}