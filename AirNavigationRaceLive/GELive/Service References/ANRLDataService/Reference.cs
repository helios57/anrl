﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3074
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GELive.ANRLDataService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="t_Daten", Namespace="http://schemas.datacontract.org/2004/07/DataService", IsReference=true)]
    [System.SerializableAttribute()]
    public partial class t_Daten : GELive.ANRLDataService.EntityObject {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> ID_PolygonField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> PenaltyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SpeedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> TEndField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> TStartField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimestampField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> XEndField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> XStartField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> YEndField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> YStartField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> ZEndField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> ZStartField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private GELive.ANRLDataService.t_Flugzeug t_FlugzeugField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private GELive.ANRLDataService.EntityReferenceOft_Flugzeug1U8vXZAD t_FlugzeugReferenceField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> ID_Polygon {
            get {
                return this.ID_PolygonField;
            }
            set {
                if ((this.ID_PolygonField.Equals(value) != true)) {
                    this.ID_PolygonField = value;
                    this.RaisePropertyChanged("ID_Polygon");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Penalty {
            get {
                return this.PenaltyField;
            }
            set {
                if ((this.PenaltyField.Equals(value) != true)) {
                    this.PenaltyField = value;
                    this.RaisePropertyChanged("Penalty");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Speed {
            get {
                return this.SpeedField;
            }
            set {
                if ((object.ReferenceEquals(this.SpeedField, value) != true)) {
                    this.SpeedField = value;
                    this.RaisePropertyChanged("Speed");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> TEnd {
            get {
                return this.TEndField;
            }
            set {
                if ((this.TEndField.Equals(value) != true)) {
                    this.TEndField = value;
                    this.RaisePropertyChanged("TEnd");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> TStart {
            get {
                return this.TStartField;
            }
            set {
                if ((this.TStartField.Equals(value) != true)) {
                    this.TStartField = value;
                    this.RaisePropertyChanged("TStart");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Timestamp {
            get {
                return this.TimestampField;
            }
            set {
                if ((this.TimestampField.Equals(value) != true)) {
                    this.TimestampField = value;
                    this.RaisePropertyChanged("Timestamp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> XEnd {
            get {
                return this.XEndField;
            }
            set {
                if ((this.XEndField.Equals(value) != true)) {
                    this.XEndField = value;
                    this.RaisePropertyChanged("XEnd");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> XStart {
            get {
                return this.XStartField;
            }
            set {
                if ((this.XStartField.Equals(value) != true)) {
                    this.XStartField = value;
                    this.RaisePropertyChanged("XStart");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> YEnd {
            get {
                return this.YEndField;
            }
            set {
                if ((this.YEndField.Equals(value) != true)) {
                    this.YEndField = value;
                    this.RaisePropertyChanged("YEnd");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> YStart {
            get {
                return this.YStartField;
            }
            set {
                if ((this.YStartField.Equals(value) != true)) {
                    this.YStartField = value;
                    this.RaisePropertyChanged("YStart");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> ZEnd {
            get {
                return this.ZEndField;
            }
            set {
                if ((this.ZEndField.Equals(value) != true)) {
                    this.ZEndField = value;
                    this.RaisePropertyChanged("ZEnd");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> ZStart {
            get {
                return this.ZStartField;
            }
            set {
                if ((this.ZStartField.Equals(value) != true)) {
                    this.ZStartField = value;
                    this.RaisePropertyChanged("ZStart");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public GELive.ANRLDataService.t_Flugzeug t_Flugzeug {
            get {
                return this.t_FlugzeugField;
            }
            set {
                if ((object.ReferenceEquals(this.t_FlugzeugField, value) != true)) {
                    this.t_FlugzeugField = value;
                    this.RaisePropertyChanged("t_Flugzeug");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public GELive.ANRLDataService.EntityReferenceOft_Flugzeug1U8vXZAD t_FlugzeugReference {
            get {
                return this.t_FlugzeugReferenceField;
            }
            set {
                if ((object.ReferenceEquals(this.t_FlugzeugReferenceField, value) != true)) {
                    this.t_FlugzeugReferenceField = value;
                    this.RaisePropertyChanged("t_FlugzeugReference");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StructuralObject", Namespace="http://schemas.datacontract.org/2004/07/System.Data.Objects.DataClasses", IsReference=true)]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GELive.ANRLDataService.EntityObject))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GELive.ANRLDataService.t_Flugzeug))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GELive.ANRLDataService.t_Tracker))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GELive.ANRLDataService.t_Daten))]
    public partial class StructuralObject : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EntityObject", Namespace="http://schemas.datacontract.org/2004/07/System.Data.Objects.DataClasses", IsReference=true)]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GELive.ANRLDataService.t_Flugzeug))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GELive.ANRLDataService.t_Tracker))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GELive.ANRLDataService.t_Daten))]
    public partial class EntityObject : GELive.ANRLDataService.StructuralObject {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private GELive.ANRLDataService.EntityKey EntityKeyField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public GELive.ANRLDataService.EntityKey EntityKey {
            get {
                return this.EntityKeyField;
            }
            set {
                if ((object.ReferenceEquals(this.EntityKeyField, value) != true)) {
                    this.EntityKeyField = value;
                    this.RaisePropertyChanged("EntityKey");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="t_Flugzeug", Namespace="http://schemas.datacontract.org/2004/07/DataService", IsReference=true)]
    [System.SerializableAttribute()]
    public partial class t_Flugzeug : GELive.ANRLDataService.EntityObject {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FlugzeugField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PilotField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<GELive.ANRLDataService.t_Daten> t_DatenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private GELive.ANRLDataService.t_Tracker t_TrackerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private GELive.ANRLDataService.EntityReferenceOft_Tracker1U8vXZAD t_TrackerReferenceField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Flugzeug {
            get {
                return this.FlugzeugField;
            }
            set {
                if ((object.ReferenceEquals(this.FlugzeugField, value) != true)) {
                    this.FlugzeugField = value;
                    this.RaisePropertyChanged("Flugzeug");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Pilot {
            get {
                return this.PilotField;
            }
            set {
                if ((object.ReferenceEquals(this.PilotField, value) != true)) {
                    this.PilotField = value;
                    this.RaisePropertyChanged("Pilot");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<GELive.ANRLDataService.t_Daten> t_Daten {
            get {
                return this.t_DatenField;
            }
            set {
                if ((object.ReferenceEquals(this.t_DatenField, value) != true)) {
                    this.t_DatenField = value;
                    this.RaisePropertyChanged("t_Daten");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public GELive.ANRLDataService.t_Tracker t_Tracker {
            get {
                return this.t_TrackerField;
            }
            set {
                if ((object.ReferenceEquals(this.t_TrackerField, value) != true)) {
                    this.t_TrackerField = value;
                    this.RaisePropertyChanged("t_Tracker");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public GELive.ANRLDataService.EntityReferenceOft_Tracker1U8vXZAD t_TrackerReference {
            get {
                return this.t_TrackerReferenceField;
            }
            set {
                if ((object.ReferenceEquals(this.t_TrackerReferenceField, value) != true)) {
                    this.t_TrackerReferenceField = value;
                    this.RaisePropertyChanged("t_TrackerReference");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="t_Tracker", Namespace="http://schemas.datacontract.org/2004/07/DataService", IsReference=true)]
    [System.SerializableAttribute()]
    public partial class t_Tracker : GELive.ANRLDataService.EntityObject {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IMEIField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<GELive.ANRLDataService.t_Flugzeug> t_FlugzeugField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IMEI {
            get {
                return this.IMEIField;
            }
            set {
                if ((object.ReferenceEquals(this.IMEIField, value) != true)) {
                    this.IMEIField = value;
                    this.RaisePropertyChanged("IMEI");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<GELive.ANRLDataService.t_Flugzeug> t_Flugzeug {
            get {
                return this.t_FlugzeugField;
            }
            set {
                if ((object.ReferenceEquals(this.t_FlugzeugField, value) != true)) {
                    this.t_FlugzeugField = value;
                    this.RaisePropertyChanged("t_Flugzeug");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EntityKey", Namespace="http://schemas.datacontract.org/2004/07/System.Data", IsReference=true)]
    [System.SerializableAttribute()]
    public partial class EntityKey : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EntityContainerNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<GELive.ANRLDataService.EntityKeyMember> EntityKeyValuesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EntitySetNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EntityContainerName {
            get {
                return this.EntityContainerNameField;
            }
            set {
                if ((object.ReferenceEquals(this.EntityContainerNameField, value) != true)) {
                    this.EntityContainerNameField = value;
                    this.RaisePropertyChanged("EntityContainerName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<GELive.ANRLDataService.EntityKeyMember> EntityKeyValues {
            get {
                return this.EntityKeyValuesField;
            }
            set {
                if ((object.ReferenceEquals(this.EntityKeyValuesField, value) != true)) {
                    this.EntityKeyValuesField = value;
                    this.RaisePropertyChanged("EntityKeyValues");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EntitySetName {
            get {
                return this.EntitySetNameField;
            }
            set {
                if ((object.ReferenceEquals(this.EntitySetNameField, value) != true)) {
                    this.EntitySetNameField = value;
                    this.RaisePropertyChanged("EntitySetName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EntityReferenceOft_Flugzeug1U8vXZAD", Namespace="http://schemas.datacontract.org/2004/07/System.Data.Objects.DataClasses")]
    [System.SerializableAttribute()]
    public partial class EntityReferenceOft_Flugzeug1U8vXZAD : GELive.ANRLDataService.EntityReference {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EntityKeyMember", Namespace="http://schemas.datacontract.org/2004/07/System.Data")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GELive.ANRLDataService.EntityKey))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Collections.Generic.List<GELive.ANRLDataService.EntityKeyMember>))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GELive.ANRLDataService.EntityObject))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GELive.ANRLDataService.StructuralObject))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GELive.ANRLDataService.EntityReferenceOft_Tracker1U8vXZAD))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GELive.ANRLDataService.EntityReference))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GELive.ANRLDataService.RelatedEnd))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GELive.ANRLDataService.EntityReferenceOft_Flugzeug1U8vXZAD))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Collections.Generic.List<GELive.ANRLDataService.t_Daten>))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GELive.ANRLDataService.t_Daten))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GELive.ANRLDataService.t_Flugzeug))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GELive.ANRLDataService.t_Tracker))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Collections.Generic.List<GELive.ANRLDataService.t_Flugzeug>))]
    public partial class EntityKeyMember : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string KeyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object ValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Key {
            get {
                return this.KeyField;
            }
            set {
                if ((object.ReferenceEquals(this.KeyField, value) != true)) {
                    this.KeyField = value;
                    this.RaisePropertyChanged("Key");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object Value {
            get {
                return this.ValueField;
            }
            set {
                if ((object.ReferenceEquals(this.ValueField, value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EntityReferenceOft_Tracker1U8vXZAD", Namespace="http://schemas.datacontract.org/2004/07/System.Data.Objects.DataClasses")]
    [System.SerializableAttribute()]
    public partial class EntityReferenceOft_Tracker1U8vXZAD : GELive.ANRLDataService.EntityReference {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EntityReference", Namespace="http://schemas.datacontract.org/2004/07/System.Data.Objects.DataClasses")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GELive.ANRLDataService.EntityReferenceOft_Flugzeug1U8vXZAD))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GELive.ANRLDataService.EntityReferenceOft_Tracker1U8vXZAD))]
    public partial class EntityReference : GELive.ANRLDataService.RelatedEnd {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private GELive.ANRLDataService.EntityKey EntityKeyField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public GELive.ANRLDataService.EntityKey EntityKey {
            get {
                return this.EntityKeyField;
            }
            set {
                if ((object.ReferenceEquals(this.EntityKeyField, value) != true)) {
                    this.EntityKeyField = value;
                    this.RaisePropertyChanged("EntityKey");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RelatedEnd", Namespace="http://schemas.datacontract.org/2004/07/System.Data.Objects.DataClasses")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GELive.ANRLDataService.EntityReference))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GELive.ANRLDataService.EntityReferenceOft_Flugzeug1U8vXZAD))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GELive.ANRLDataService.EntityReferenceOft_Tracker1U8vXZAD))]
    public partial class RelatedEnd : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ANRLDataService.IANRLDataService")]
    public interface IANRLDataService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IANRLDataService/GetPathData", ReplyAction="http://tempuri.org/IANRLDataService/GetPathDataResponse")]
        System.Collections.Generic.List<GELive.ANRLDataService.t_Daten> GetPathData(System.DateTime timestamp);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IANRLDataServiceChannel : GELive.ANRLDataService.IANRLDataService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class ANRLDataServiceClient : System.ServiceModel.ClientBase<GELive.ANRLDataService.IANRLDataService>, GELive.ANRLDataService.IANRLDataService {
        
        public ANRLDataServiceClient() {
        }
        
        public ANRLDataServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ANRLDataServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ANRLDataServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ANRLDataServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<GELive.ANRLDataService.t_Daten> GetPathData(System.DateTime timestamp) {
            return base.Channel.GetPathData(timestamp);
        }
    }
}