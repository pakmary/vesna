﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vesna.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool Klimat_usloviya {
            get {
                return ((bool)(this["Klimat_usloviya"]));
            }
            set {
                this["Klimat_usloviya"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\database_inspector.m" +
            "db;Persist Security Info=True;Jet OLEDB:Database Password=hfpdbnbt")]
        public string database_inspectorConnectionString {
            get {
                return ((string)(this["database_inspectorConnectionString"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1.9749")]
        public float YearIndex {
            get {
                return ((float)(this["YearIndex"]));
            }
            set {
                this["YearIndex"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("COM3")]
        public string COMPortName {
            get {
                return ((string)(this["COMPortName"]));
            }
            set {
                this["COMPortName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2.07")]
        public float ConstDorojhnoKlimatZon {
            get {
                return ((float)(this["ConstDorojhnoKlimatZon"]));
            }
            set {
                this["ConstDorojhnoKlimatZon"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public float ConstKapitalniyRemont {
            get {
                return ((float)(this["ConstKapitalniyRemont"]));
            }
            set {
                this["ConstKapitalniyRemont"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2.9")]
        public float ConstKlimatAxisMult {
            get {
                return ((float)(this["ConstKlimatAxisMult"]));
            }
            set {
                this["ConstKlimatAxisMult"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("7365")]
        public float ConstIshodnoeZnacheieDlyaMassi {
            get {
                return ((float)(this["ConstIshodnoeZnacheieDlyaMassi"]));
            }
            set {
                this["ConstIshodnoeZnacheieDlyaMassi"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.01675")]
        public float ConstUchotPrevisheniyaMassi {
            get {
                return ((float)(this["ConstUchotPrevisheniyaMassi"]));
            }
            set {
                this["ConstUchotPrevisheniyaMassi"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.04")]
        public float InaccuracyRoulette {
            get {
                return ((float)(this["InaccuracyRoulette"]));
            }
            set {
                this["InaccuracyRoulette"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.05")]
        public float InaccuracyScales {
            get {
                return ((float)(this["InaccuracyScales"]));
            }
            set {
                this["InaccuracyScales"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public float DopustimiyProcentAxis {
            get {
                return ((float)(this["DopustimiyProcentAxis"]));
            }
            set {
                this["DopustimiyProcentAxis"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public float DopustimiyProcentFullMass {
            get {
                return ((float)(this["DopustimiyProcentFullMass"]));
            }
            set {
                this["DopustimiyProcentFullMass"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public float ConstKpmFederalRoad {
            get {
                return ((float)(this["ConstKpmFederalRoad"]));
            }
            set {
                this["ConstKpmFederalRoad"] = value;
            }
        }
    }
}
