﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4016
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
    [System.Runtime.Serialization.DataContractAttribute(Name="t_Daten", Namespace="http://schemas.datacontract.org/2004/07/DataService")]
    [System.SerializableAttribute()]
    public partial class t_Daten : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> AltitudeEndField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> AltitudeStartField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ID_FlugzeugField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> ID_PolygonField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> LatitudeEndField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> LatitudeStartField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> LongitudeEndField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> LongitudeStartField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PenaltyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SpeedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> TEndField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> TStartField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimestampField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private GELive.ANRLDataService.t_Flugzeug t_FlugzeugField;
        
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
        public System.Nullable<decimal> AltitudeEnd {
            get {
                return this.AltitudeEndField;
            }
            set {
                if ((this.AltitudeEndField.Equals(value) != true)) {
                    this.AltitudeEndField = value;
                    this.RaisePropertyChanged("AltitudeEnd");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> AltitudeStart {
            get {
                return this.AltitudeStartField;
            }
            set {
                if ((this.AltitudeStartField.Equals(value) != true)) {
                    this.AltitudeStartField = value;
                    this.RaisePropertyChanged("AltitudeStart");
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
        public int ID_Flugzeug {
            get {
                return this.ID_FlugzeugField;
            }
            set {
                if ((this.ID_FlugzeugField.Equals(value) != true)) {
                    this.ID_FlugzeugField = value;
                    this.RaisePropertyChanged("ID_Flugzeug");
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
        public System.Nullable<decimal> LatitudeEnd {
            get {
                return this.LatitudeEndField;
            }
            set {
                if ((this.LatitudeEndField.Equals(value) != true)) {
                    this.LatitudeEndField = value;
                    this.RaisePropertyChanged("LatitudeEnd");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> LatitudeStart {
            get {
                return this.LatitudeStartField;
            }
            set {
                if ((this.LatitudeStartField.Equals(value) != true)) {
                    this.LatitudeStartField = value;
                    this.RaisePropertyChanged("LatitudeStart");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> LongitudeEnd {
            get {
                return this.LongitudeEndField;
            }
            set {
                if ((this.LongitudeEndField.Equals(value) != true)) {
                    this.LongitudeEndField = value;
                    this.RaisePropertyChanged("LongitudeEnd");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> LongitudeStart {
            get {
                return this.LongitudeStartField;
            }
            set {
                if ((this.LongitudeStartField.Equals(value) != true)) {
                    this.LongitudeStartField = value;
                    this.RaisePropertyChanged("LongitudeStart");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Penalty {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="t_Flugzeug", Namespace="http://schemas.datacontract.org/2004/07/DataService")]
    [System.SerializableAttribute()]
    public partial class t_Flugzeug : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FlugzeugField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> ID_GPS_TrackerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PilotField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<GELive.ANRLDataService.t_Daten> t_DatensField;
        
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
        public System.Nullable<int> ID_GPS_Tracker {
            get {
                return this.ID_GPS_TrackerField;
            }
            set {
                if ((this.ID_GPS_TrackerField.Equals(value) != true)) {
                    this.ID_GPS_TrackerField = value;
                    this.RaisePropertyChanged("ID_GPS_Tracker");
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
        public System.Collections.Generic.List<GELive.ANRLDataService.t_Daten> t_Datens {
            get {
                return this.t_DatensField;
            }
            set {
                if ((object.ReferenceEquals(this.t_DatensField, value) != true)) {
                    this.t_DatensField = value;
                    this.RaisePropertyChanged("t_Datens");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="t_PolygonPoint", Namespace="http://schemas.datacontract.org/2004/07/DataService")]
    [System.SerializableAttribute()]
    public partial class t_PolygonPoint : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ID_PolygonField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal altitudeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal latitudeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal longitudeField;
        
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
        public int ID_Polygon {
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
        public decimal altitude {
            get {
                return this.altitudeField;
            }
            set {
                if ((this.altitudeField.Equals(value) != true)) {
                    this.altitudeField = value;
                    this.RaisePropertyChanged("altitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal latitude {
            get {
                return this.latitudeField;
            }
            set {
                if ((this.latitudeField.Equals(value) != true)) {
                    this.latitudeField = value;
                    this.RaisePropertyChanged("latitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal longitude {
            get {
                return this.longitudeField;
            }
            set {
                if ((this.longitudeField.Equals(value) != true)) {
                    this.longitudeField = value;
                    this.RaisePropertyChanged("longitude");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ANRLDataService.IANRLDataService")]
    public interface IANRLDataService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IANRLDataService/GetPathData", ReplyAction="http://tempuri.org/IANRLDataService/GetPathDataResponse")]
        System.Collections.Generic.List<GELive.ANRLDataService.t_Daten> GetPathData(System.DateTime timestamp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IANRLDataService/GetTimestamps", ReplyAction="http://tempuri.org/IANRLDataService/GetTimestampsResponse")]
        System.Collections.Generic.List<System.DateTime> GetTimestamps();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IANRLDataService/GetPolygons", ReplyAction="http://tempuri.org/IANRLDataService/GetPolygonsResponse")]
        System.Collections.Generic.List<GELive.ANRLDataService.t_PolygonPoint> GetPolygons();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IANRLDataService/GetTrackers", ReplyAction="http://tempuri.org/IANRLDataService/GetTrackersResponse")]
        System.Collections.Generic.List<System.Collections.Generic.List<string>> GetTrackers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IANRLDataService/GetAirplanes", ReplyAction="http://tempuri.org/IANRLDataService/GetAirplanesResponse")]
        System.Collections.Generic.List<System.Collections.Generic.List<string>> GetAirplanes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IANRLDataService/CleanTracker", ReplyAction="http://tempuri.org/IANRLDataService/CleanTrackerResponse")]
        void CleanTracker(int TrackerID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IANRLDataService/AddNewAirplane", ReplyAction="http://tempuri.org/IANRLDataService/AddNewAirplaneResponse")]
        void AddNewAirplane(string Flugzeug, string Pilot, int TrackerID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IANRLDataService/AddAirplane", ReplyAction="http://tempuri.org/IANRLDataService/AddAirplaneResponse")]
        void AddAirplane(int FlugzeugID, int TrackerID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IANRLDataService/AddPolygons", ReplyAction="http://tempuri.org/IANRLDataService/AddPolygonsResponse")]
        void AddPolygons(System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<double>>> PolygonList);
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
        
        public System.Collections.Generic.List<System.DateTime> GetTimestamps() {
            return base.Channel.GetTimestamps();
        }
        
        public System.Collections.Generic.List<GELive.ANRLDataService.t_PolygonPoint> GetPolygons() {
            return base.Channel.GetPolygons();
        }
        
        public System.Collections.Generic.List<System.Collections.Generic.List<string>> GetTrackers() {
            return base.Channel.GetTrackers();
        }
        
        public System.Collections.Generic.List<System.Collections.Generic.List<string>> GetAirplanes() {
            return base.Channel.GetAirplanes();
        }
        
        public void CleanTracker(int TrackerID) {
            base.Channel.CleanTracker(TrackerID);
        }
        
        public void AddNewAirplane(string Flugzeug, string Pilot, int TrackerID) {
            base.Channel.AddNewAirplane(Flugzeug, Pilot, TrackerID);
        }
        
        public void AddAirplane(int FlugzeugID, int TrackerID) {
            base.Channel.AddAirplane(FlugzeugID, TrackerID);
        }
        
        public void AddPolygons(System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<double>>> PolygonList) {
            base.Channel.AddPolygons(PolygonList);
        }
    }
}
