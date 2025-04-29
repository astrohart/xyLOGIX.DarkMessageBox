using System;
using System.Diagnostics;
using xyLOGIX.DarkMessageBox.Interfaces;
using xyLOGIX.DarkMessageBox.Themes;

namespace xyLOGIX.DarkMessageBox.Validators
{
    /// <summary>
    /// Validates concrete
    /// <see cref="T:xyLOGIX.DarkMessageBox.Interfaces.IDarkMessageBoxTheme" />
    /// implementations.
    /// </summary>
    public static class DarkMessageBoxThemeValidator
    {
        /// <summary>
        /// Determines whether the theme’s settings are logically valid.
        /// </summary>
        /// <remarks>
        /// The theme is applied to <see cref="DarkMessageBoxMetrics" />; metrics are
        /// snapshotted first and restored afterwards, so the caller’s environment is
        /// unchanged.
        /// </remarks>
        public static bool IsValid(IDarkMessageBoxTheme theme)
        {
            if (theme == null) return false;

            DarkMessageBoxThemeManager.ApplyTheme(
                MetricsSnapshotTheme.Instance
            ); // make snapshot “current”

            try
            {
                DarkMessageBoxThemeManager.WithTemporaryTheme(
                    theme, ValidateCurrentMetrics // throws if anything is wrong
                );
                return true; // reached only when no exception
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        /// <summary>
        /// Requires that the specified Boolean <paramref name="condition" /> evaluate to
        /// <see langword="true" />, or else
        /// <see cref="T:System.InvalidOperationException" /> is thrown with the specified
        /// <paramref name="message" />.
        /// </summary>
        /// <param name="condition">
        /// (Required.) Boolean condition that, if it evaluates to
        /// <see langword="false" />, throws
        /// <see cref="T:System.InvalidOperationException" />.
        /// </param>
        /// <param name="message">
        /// (Required.) A <see cref="T:System.String" /> containing
        /// the message that is to be used for the
        /// <see cref="T:System.InvalidOperationException" /> that is thrown if the
        /// specified <paramref name="condition" /> evaluates to <see langword="false" />.
        /// </param>
        /// <exception cref="T:System.InvalidOperationException">
        /// Thrown in the event that
        /// the specified Boolean <paramref name="condition" /> evaluates to
        /// <see langword="false" />.
        /// </exception>
        private static void Require(bool condition, string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return;

            if (!condition)
                throw new InvalidOperationException(message);
        }

        /// <summary>
        /// Throws when any metric violates its allowed range / relationship.
        /// </summary>
        private static void ValidateCurrentMetrics()
        {
            /* BASIC NUMERIC BOUNDS */
            Require(
                DarkMessageBoxMetrics.ButtonWidth >= 1,
                "ButtonWidth must be ≥ 1."
            );
            Require(
                DarkMessageBoxMetrics.ButtonHeight >= 1,
                "ButtonHeight must be ≥ 1."
            );
            Require(
                DarkMessageBoxMetrics.ButtonSpacing >= 1,
                "ButtonSpacing must be ≥ 1."
            );
            Require(
                DarkMessageBoxMetrics.RightMargin >= 1,
                "RightMargin must be ≥ 1."
            );
            Require(
                DarkMessageBoxMetrics.BottomMargin >= 1,
                "BottomMargin must be ≥ 1."
            );
            Require(
                DarkMessageBoxMetrics.SpacerHeight >= 1,
                "SpacerHeight must be ≥ 1."
            );
            Require(
                DarkMessageBoxMetrics.DefaultButtonBorderThickness >= 1,
                "DefaultButtonBorderThickness must be ≥ 1."
            );

            /* WINDOW WIDTH RELATIONSHIPS */
            Require(
                DarkMessageBoxMetrics.MinimumFormWidthSingleButton >= 1,
                "MinimumFormWidthSingleButton must be ≥ 1."
            );
            Require(
                DarkMessageBoxMetrics.MinimumFormWidthMultiButton >=
                DarkMessageBoxMetrics.MinimumFormWidthSingleButton,
                "MinimumFormWidthMultiButton must be ≥ MinimumFormWidthSingleButton."
            );
            Require(
                DarkMessageBoxMetrics.MaximumFormWidth >= DarkMessageBoxMetrics
                    .MinimumFormWidthMultiButton,
                "MaximumFormWidth must be ≥ MinimumFormWidthMultiButton."
            );

            /* FOOTER HEIGHT  (button-height + 6 px padding) */
            var minFooter = DarkMessageBoxMetrics.ButtonHeight + 6;
            Require(
                DarkMessageBoxMetrics.FormFooterHeight >= minFooter,
                $"FormFooterHeight must be ≥ ButtonHeight + 6 (≥ {minFooter})."
            );

            /* NON-BLANK BUTTON CAPTIONS */
            foreach (var kv in DarkMessageBoxMetrics.ButtonTexts)
                Require(
                    !string.IsNullOrWhiteSpace(kv.Value),
                    $"ButtonTexts entry for {kv.Key} is blank."
                );
        }
    }
}