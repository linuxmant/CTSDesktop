﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fiehnlab.CTSRest.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Fiehnlab.CTSRest.Properties.Resources", typeof(Resources).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to convert.
        /// </summary>
        public static string CTS_REST_CONVERSION_PATH {
            get {
                return ResourceManager.GetString("CTS_REST_CONVERSION_PATH", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /service/conversion/fromValues.
        /// </summary>
        public static string CTS_REST_FROMNAMES_PATH {
            get {
                return ResourceManager.GetString("CTS_REST_FROMNAMES_PATH", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /service/conversion/toValues.
        /// </summary>
        public static string CTS_REST_TONAMES_PATH {
            get {
                return ResourceManager.GetString("CTS_REST_TONAMES_PATH", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to http://cts.fiehnlab.ucdavis.edu.
        /// </summary>
        public static string CTS_URL {
            get {
                return ResourceManager.GetString("CTS_URL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to application/x-www-form-urlencoded.
        /// </summary>
        public static string HEADERS_FORM_URLENCODED {
            get {
                return ResourceManager.GetString("HEADERS_FORM_URLENCODED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to application/x-www-form-urlencoded;charset=UTF-8.
        /// </summary>
        public static string HEADERS_FORM_URLENCODED_CHARSET {
            get {
                return ResourceManager.GetString("HEADERS_FORM_URLENCODED_CHARSET", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to application/json.
        /// </summary>
        public static string HEADERS_JSON {
            get {
                return ResourceManager.GetString("HEADERS_JSON", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to application/json;charset=UTF-8.
        /// </summary>
        public static string HEADERS_JSON_CHARSET {
            get {
                return ResourceManager.GetString("HEADERS_JSON_CHARSET", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to InChI Code.
        /// </summary>
        public static string INCHI_CODE {
            get {
                return ResourceManager.GetString("INCHI_CODE", resourceCulture);
            }
        }
    }
}
