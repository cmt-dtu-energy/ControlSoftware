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
    internal sealed partial class IsoTechPSUSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static IsoTechPSUSettings defaultInstance = ((IsoTechPSUSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new IsoTechPSUSettings())));
        
        public static IsoTechPSUSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("14.4")]
        public double Chan1Voltage {
            get {
                return ((double)(this["Chan1Voltage"]));
            }
            set {
                this["Chan1Voltage"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public double Chan1Current {
            get {
                return ((double)(this["Chan1Current"]));
            }
            set {
                this["Chan1Current"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool Chan1Enabled {
            get {
                return ((bool)(this["Chan1Enabled"]));
            }
            set {
                this["Chan1Enabled"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("14.4")]
        public double Chan2Voltage {
            get {
                return ((double)(this["Chan2Voltage"]));
            }
            set {
                this["Chan2Voltage"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public double Chan2Current {
            get {
                return ((double)(this["Chan2Current"]));
            }
            set {
                this["Chan2Current"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool Chan2Enabled {
            get {
                return ((bool)(this["Chan2Enabled"]));
            }
            set {
                this["Chan2Enabled"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("COM4")]
        public string IsoTechPSUComPort {
            get {
                return ((string)(this["IsoTechPSUComPort"]));
            }
            set {
                this["IsoTechPSUComPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("8")]
        public int IsoTechPSUDataBits {
            get {
                return ((int)(this["IsoTechPSUDataBits"]));
            }
            set {
                this["IsoTechPSUDataBits"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("9600")]
        public int IsoTechPSUBaudRate {
            get {
                return ((int)(this["IsoTechPSUBaudRate"]));
            }
            set {
                this["IsoTechPSUBaudRate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("One")]
        public global::System.IO.Ports.StopBits IsoTechPSUStopBits {
            get {
                return ((global::System.IO.Ports.StopBits)(this["IsoTechPSUStopBits"]));
            }
            set {
                this["IsoTechPSUStopBits"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("None")]
        public global::System.IO.Ports.Parity IsoTechPSUParity {
            get {
                return ((global::System.IO.Ports.Parity)(this["IsoTechPSUParity"]));
            }
            set {
                this["IsoTechPSUParity"] = value;
            }
        }
    }
}