﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DSCInterface.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int PIDPeltierPSUPort {
            get {
                return ((int)(this["PIDPeltierPSUPort"]));
            }
            set {
                this["PIDPeltierPSUPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public int PIDPeltierReadingsPort {
            get {
                return ((int)(this["PIDPeltierReadingsPort"]));
            }
            set {
                this["PIDPeltierReadingsPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("14.8")]
        public double PIDPeltierMaxVoltage {
            get {
                return ((double)(this["PIDPeltierMaxVoltage"]));
            }
            set {
                this["PIDPeltierMaxVoltage"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("14")]
        public double PIDPeltierMaxCurrent {
            get {
                return ((double)(this["PIDPeltierMaxCurrent"]));
            }
            set {
                this["PIDPeltierMaxCurrent"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Parallel")]
        public global::EFMExperimentsLibrary.AbstractPSUTrackingMode IsoTechPSUDefaultTrackMode {
            get {
                return ((global::EFMExperimentsLibrary.AbstractPSUTrackingMode)(this["IsoTechPSUDefaultTrackMode"]));
            }
            set {
                this["IsoTechPSUDefaultTrackMode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("340")]
        public double MaxTemperature {
            get {
                return ((double)(this["MaxTemperature"]));
            }
            set {
                this["MaxTemperature"] = value;
            }
        }
    }
}
