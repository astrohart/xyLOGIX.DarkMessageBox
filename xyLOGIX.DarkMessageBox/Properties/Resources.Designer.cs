﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace xyLOGIX.DarkMessageBox.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("xyLOGIX.DarkMessageBox.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon bart_simpson_logo_vector1 {
            get {
                object obj = ResourceManager.GetObject("bart_simpson_logo_vector1", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DialogResult.None passed to AddButton().  We do not know what to do with this value..
        /// </summary>
        internal static string Error_Invalid_DialogResult {
            get {
                return ResourceManager.GetString("Error_Invalid_DialogResult", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to AddButton: Unable to determine the appropriate text for the button that corresponds to a DialogResult value of &apos;{0}&apos;.  Stopping....
        /// </summary>
        internal static string Error_UnableToDetermineButtonText {
            get {
                return ResourceManager.GetString("Error_UnableToDetermineButtonText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon michelangelo {
            get {
                object obj = ResourceManager.GetObject("michelangelo", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to InternalDarkMessageBox.OnFormClosed: The default message box theme is to be re-applied, because DarkMessageBoxMetrics.SuppressAutoReset is set to FALSE..
        /// </summary>
        internal static string Reminder_SuppressAutoReset {
            get {
                return ResourceManager.GetString("Reminder_SuppressAutoReset", resourceCulture);
            }
        }
    }
}
