﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrybeSDK {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TrybeSDK.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to The TrybeAPI did not return a successful response, but it also did not provide an error message..
        /// </summary>
        internal static string ApiClient_NoErrorMessage {
            get {
                return ResourceManager.GetString("ApiClient_NoErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An unexpected response was returned from the Trybe API, and we could not determine the actual error in this case..
        /// </summary>
        internal static string ApiClient_UnknownResponse {
            get {
                return ResourceManager.GetString("ApiClient_UnknownResponse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A Trybe API key must be provided..
        /// </summary>
        internal static string TrybeSettingsValidator_ApiKey_ValidationMessage {
            get {
                return ResourceManager.GetString("TrybeSettingsValidator_ApiKey_ValidationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A Trybe API base URL must be provided..
        /// </summary>
        internal static string TrybeSettingsValidator_ApiUrl_ValidationMessage {
            get {
                return ResourceManager.GetString("TrybeSettingsValidator_ApiUrl_ValidationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A Trybe Shop base URL must be provided..
        /// </summary>
        internal static string TrybeSettingsValidator_ShopUrl_ValidationMessage {
            get {
                return ResourceManager.GetString("TrybeSettingsValidator_ShopUrl_ValidationMessage", resourceCulture);
            }
        }
    }
}
