﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3074
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataService
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="Database")]
	public partial class DBModelDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertt_Daten(t_Daten instance);
    partial void Updatet_Daten(t_Daten instance);
    partial void Deletet_Daten(t_Daten instance);
    partial void Insertt_Tracker(t_Tracker instance);
    partial void Updatet_Tracker(t_Tracker instance);
    partial void Deletet_Tracker(t_Tracker instance);
    partial void Insertt_Flugzeug(t_Flugzeug instance);
    partial void Updatet_Flugzeug(t_Flugzeug instance);
    partial void Deletet_Flugzeug(t_Flugzeug instance);
    partial void Insertt_GPS_IN(t_GPS_IN instance);
    partial void Updatet_GPS_IN(t_GPS_IN instance);
    partial void Deletet_GPS_IN(t_GPS_IN instance);
    #endregion
		
		public DBModelDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DBModelDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBModelDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBModelDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBModelDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<t_Daten> t_Datens
		{
			get
			{
				return this.GetTable<t_Daten>();
			}
		}
		
		public System.Data.Linq.Table<t_Tracker> t_Trackers
		{
			get
			{
				return this.GetTable<t_Tracker>();
			}
		}
		
		public System.Data.Linq.Table<t_Flugzeug> t_Flugzeugs
		{
			get
			{
				return this.GetTable<t_Flugzeug>();
			}
		}
		
		public System.Data.Linq.Table<t_GPS_IN> t_GPS_INs
		{
			get
			{
				return this.GetTable<t_GPS_IN>();
			}
		}
	}
	
	[Table(Name="dbo.t_Daten")]
	public partial class t_Daten : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _ID_Flugzeug;
		
		private System.DateTime _Timestamp;
		
		private System.Nullable<decimal> _XStart;
		
		private System.Nullable<decimal> _XEnd;
		
		private System.Nullable<decimal> _YStart;
		
		private System.Nullable<decimal> _YEnd;
		
		private System.Nullable<decimal> _ZStart;
		
		private System.Nullable<decimal> _ZEnd;
		
		private System.Nullable<System.DateTime> _TStart;
		
		private System.Nullable<System.DateTime> _TEnd;
		
		private string _Speed;
		
		private System.Nullable<int> _Penalty;
		
		private System.Nullable<int> _ID_Polygon;
		
		private EntityRef<t_Flugzeug> _t_Flugzeug;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnID_FlugzeugChanging(int value);
    partial void OnID_FlugzeugChanged();
    partial void OnTimestampChanging(System.DateTime value);
    partial void OnTimestampChanged();
    partial void OnXStartChanging(System.Nullable<decimal> value);
    partial void OnXStartChanged();
    partial void OnXEndChanging(System.Nullable<decimal> value);
    partial void OnXEndChanged();
    partial void OnYStartChanging(System.Nullable<decimal> value);
    partial void OnYStartChanged();
    partial void OnYEndChanging(System.Nullable<decimal> value);
    partial void OnYEndChanged();
    partial void OnZStartChanging(System.Nullable<decimal> value);
    partial void OnZStartChanged();
    partial void OnZEndChanging(System.Nullable<decimal> value);
    partial void OnZEndChanged();
    partial void OnTStartChanging(System.Nullable<System.DateTime> value);
    partial void OnTStartChanged();
    partial void OnTEndChanging(System.Nullable<System.DateTime> value);
    partial void OnTEndChanged();
    partial void OnSpeedChanging(string value);
    partial void OnSpeedChanged();
    partial void OnPenaltyChanging(System.Nullable<int> value);
    partial void OnPenaltyChanged();
    partial void OnID_PolygonChanging(System.Nullable<int> value);
    partial void OnID_PolygonChanged();
    #endregion
		
		public t_Daten()
		{
			this._t_Flugzeug = default(EntityRef<t_Flugzeug>);
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_ID_Flugzeug", DbType="Int NOT NULL")]
		public int ID_Flugzeug
		{
			get
			{
				return this._ID_Flugzeug;
			}
			set
			{
				if ((this._ID_Flugzeug != value))
				{
					if (this._t_Flugzeug.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnID_FlugzeugChanging(value);
					this.SendPropertyChanging();
					this._ID_Flugzeug = value;
					this.SendPropertyChanged("ID_Flugzeug");
					this.OnID_FlugzeugChanged();
				}
			}
		}
		
		[Column(Storage="_Timestamp", DbType="DateTime NOT NULL")]
		public System.DateTime Timestamp
		{
			get
			{
				return this._Timestamp;
			}
			set
			{
				if ((this._Timestamp != value))
				{
					this.OnTimestampChanging(value);
					this.SendPropertyChanging();
					this._Timestamp = value;
					this.SendPropertyChanged("Timestamp");
					this.OnTimestampChanged();
				}
			}
		}
		
		[Column(Storage="_XStart", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> XStart
		{
			get
			{
				return this._XStart;
			}
			set
			{
				if ((this._XStart != value))
				{
					this.OnXStartChanging(value);
					this.SendPropertyChanging();
					this._XStart = value;
					this.SendPropertyChanged("XStart");
					this.OnXStartChanged();
				}
			}
		}
		
		[Column(Storage="_XEnd", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> XEnd
		{
			get
			{
				return this._XEnd;
			}
			set
			{
				if ((this._XEnd != value))
				{
					this.OnXEndChanging(value);
					this.SendPropertyChanging();
					this._XEnd = value;
					this.SendPropertyChanged("XEnd");
					this.OnXEndChanged();
				}
			}
		}
		
		[Column(Storage="_YStart", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> YStart
		{
			get
			{
				return this._YStart;
			}
			set
			{
				if ((this._YStart != value))
				{
					this.OnYStartChanging(value);
					this.SendPropertyChanging();
					this._YStart = value;
					this.SendPropertyChanged("YStart");
					this.OnYStartChanged();
				}
			}
		}
		
		[Column(Storage="_YEnd", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> YEnd
		{
			get
			{
				return this._YEnd;
			}
			set
			{
				if ((this._YEnd != value))
				{
					this.OnYEndChanging(value);
					this.SendPropertyChanging();
					this._YEnd = value;
					this.SendPropertyChanged("YEnd");
					this.OnYEndChanged();
				}
			}
		}
		
		[Column(Storage="_ZStart", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> ZStart
		{
			get
			{
				return this._ZStart;
			}
			set
			{
				if ((this._ZStart != value))
				{
					this.OnZStartChanging(value);
					this.SendPropertyChanging();
					this._ZStart = value;
					this.SendPropertyChanged("ZStart");
					this.OnZStartChanged();
				}
			}
		}
		
		[Column(Storage="_ZEnd", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> ZEnd
		{
			get
			{
				return this._ZEnd;
			}
			set
			{
				if ((this._ZEnd != value))
				{
					this.OnZEndChanging(value);
					this.SendPropertyChanging();
					this._ZEnd = value;
					this.SendPropertyChanged("ZEnd");
					this.OnZEndChanged();
				}
			}
		}
		
		[Column(Storage="_TStart", DbType="DateTime")]
		public System.Nullable<System.DateTime> TStart
		{
			get
			{
				return this._TStart;
			}
			set
			{
				if ((this._TStart != value))
				{
					this.OnTStartChanging(value);
					this.SendPropertyChanging();
					this._TStart = value;
					this.SendPropertyChanged("TStart");
					this.OnTStartChanged();
				}
			}
		}
		
		[Column(Storage="_TEnd", DbType="DateTime")]
		public System.Nullable<System.DateTime> TEnd
		{
			get
			{
				return this._TEnd;
			}
			set
			{
				if ((this._TEnd != value))
				{
					this.OnTEndChanging(value);
					this.SendPropertyChanging();
					this._TEnd = value;
					this.SendPropertyChanged("TEnd");
					this.OnTEndChanged();
				}
			}
		}
		
		[Column(Storage="_Speed", DbType="NChar(10)")]
		public string Speed
		{
			get
			{
				return this._Speed;
			}
			set
			{
				if ((this._Speed != value))
				{
					this.OnSpeedChanging(value);
					this.SendPropertyChanging();
					this._Speed = value;
					this.SendPropertyChanged("Speed");
					this.OnSpeedChanged();
				}
			}
		}
		
		[Column(Storage="_Penalty", DbType="Int")]
		public System.Nullable<int> Penalty
		{
			get
			{
				return this._Penalty;
			}
			set
			{
				if ((this._Penalty != value))
				{
					this.OnPenaltyChanging(value);
					this.SendPropertyChanging();
					this._Penalty = value;
					this.SendPropertyChanged("Penalty");
					this.OnPenaltyChanged();
				}
			}
		}
		
		[Column(Storage="_ID_Polygon", DbType="Int")]
		public System.Nullable<int> ID_Polygon
		{
			get
			{
				return this._ID_Polygon;
			}
			set
			{
				if ((this._ID_Polygon != value))
				{
					this.OnID_PolygonChanging(value);
					this.SendPropertyChanging();
					this._ID_Polygon = value;
					this.SendPropertyChanged("ID_Polygon");
					this.OnID_PolygonChanged();
				}
			}
		}
		
		[Association(Name="t_Flugzeug_t_Daten", Storage="_t_Flugzeug", ThisKey="ID_Flugzeug", OtherKey="ID", IsForeignKey=true)]
		public t_Flugzeug t_Flugzeug
		{
			get
			{
				return this._t_Flugzeug.Entity;
			}
			set
			{
				t_Flugzeug previousValue = this._t_Flugzeug.Entity;
				if (((previousValue != value) 
							|| (this._t_Flugzeug.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._t_Flugzeug.Entity = null;
						previousValue.t_Datens.Remove(this);
					}
					this._t_Flugzeug.Entity = value;
					if ((value != null))
					{
						value.t_Datens.Add(this);
						this._ID_Flugzeug = value.ID;
					}
					else
					{
						this._ID_Flugzeug = default(int);
					}
					this.SendPropertyChanged("t_Flugzeug");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.t_Tracker")]
	public partial class t_Tracker : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _IMEI;
		
		private EntitySet<t_Flugzeug> _t_Flugzeugs;
		
		private EntityRef<t_GPS_IN> _t_GPS_IN;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnIMEIChanging(string value);
    partial void OnIMEIChanged();
    #endregion
		
		public t_Tracker()
		{
			this._t_Flugzeugs = new EntitySet<t_Flugzeug>(new Action<t_Flugzeug>(this.attach_t_Flugzeugs), new Action<t_Flugzeug>(this.detach_t_Flugzeugs));
			this._t_GPS_IN = default(EntityRef<t_GPS_IN>);
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_IMEI", DbType="NChar(20) NOT NULL", CanBeNull=false)]
		public string IMEI
		{
			get
			{
				return this._IMEI;
			}
			set
			{
				if ((this._IMEI != value))
				{
					if (this._t_GPS_IN.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIMEIChanging(value);
					this.SendPropertyChanging();
					this._IMEI = value;
					this.SendPropertyChanged("IMEI");
					this.OnIMEIChanged();
				}
			}
		}
		
		[Association(Name="t_Tracker_t_Flugzeug", Storage="_t_Flugzeugs", ThisKey="ID", OtherKey="ID_GPS_Tracker")]
		public EntitySet<t_Flugzeug> t_Flugzeugs
		{
			get
			{
				return this._t_Flugzeugs;
			}
			set
			{
				this._t_Flugzeugs.Assign(value);
			}
		}
		
		[Association(Name="t_GPS_IN_t_Tracker", Storage="_t_GPS_IN", ThisKey="IMEI", OtherKey="IMEI", IsForeignKey=true)]
		public t_GPS_IN t_GPS_IN
		{
			get
			{
				return this._t_GPS_IN.Entity;
			}
			set
			{
				t_GPS_IN previousValue = this._t_GPS_IN.Entity;
				if (((previousValue != value) 
							|| (this._t_GPS_IN.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._t_GPS_IN.Entity = null;
						previousValue.t_Trackers.Remove(this);
					}
					this._t_GPS_IN.Entity = value;
					if ((value != null))
					{
						value.t_Trackers.Add(this);
						this._IMEI = value.IMEI;
					}
					else
					{
						this._IMEI = default(string);
					}
					this.SendPropertyChanged("t_GPS_IN");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_t_Flugzeugs(t_Flugzeug entity)
		{
			this.SendPropertyChanging();
			entity.t_Tracker = this;
		}
		
		private void detach_t_Flugzeugs(t_Flugzeug entity)
		{
			this.SendPropertyChanging();
			entity.t_Tracker = null;
		}
	}
	
	[Table(Name="dbo.t_Flugzeug")]
	public partial class t_Flugzeug : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Flugzeug;
		
		private string _Pilot;
		
		private System.Nullable<int> _ID_GPS_Tracker;
		
		private EntitySet<t_Daten> _t_Datens;
		
		private EntityRef<t_Tracker> _t_Tracker;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnFlugzeugChanging(string value);
    partial void OnFlugzeugChanged();
    partial void OnPilotChanging(string value);
    partial void OnPilotChanged();
    partial void OnID_GPS_TrackerChanging(System.Nullable<int> value);
    partial void OnID_GPS_TrackerChanged();
    #endregion
		
		public t_Flugzeug()
		{
			this._t_Datens = new EntitySet<t_Daten>(new Action<t_Daten>(this.attach_t_Datens), new Action<t_Daten>(this.detach_t_Datens));
			this._t_Tracker = default(EntityRef<t_Tracker>);
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Flugzeug", DbType="NChar(100)")]
		public string Flugzeug
		{
			get
			{
				return this._Flugzeug;
			}
			set
			{
				if ((this._Flugzeug != value))
				{
					this.OnFlugzeugChanging(value);
					this.SendPropertyChanging();
					this._Flugzeug = value;
					this.SendPropertyChanged("Flugzeug");
					this.OnFlugzeugChanged();
				}
			}
		}
		
		[Column(Storage="_Pilot", DbType="NChar(100)")]
		public string Pilot
		{
			get
			{
				return this._Pilot;
			}
			set
			{
				if ((this._Pilot != value))
				{
					this.OnPilotChanging(value);
					this.SendPropertyChanging();
					this._Pilot = value;
					this.SendPropertyChanged("Pilot");
					this.OnPilotChanged();
				}
			}
		}
		
		[Column(Storage="_ID_GPS_Tracker", DbType="Int")]
		public System.Nullable<int> ID_GPS_Tracker
		{
			get
			{
				return this._ID_GPS_Tracker;
			}
			set
			{
				if ((this._ID_GPS_Tracker != value))
				{
					if (this._t_Tracker.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnID_GPS_TrackerChanging(value);
					this.SendPropertyChanging();
					this._ID_GPS_Tracker = value;
					this.SendPropertyChanged("ID_GPS_Tracker");
					this.OnID_GPS_TrackerChanged();
				}
			}
		}
		
		[Association(Name="t_Flugzeug_t_Daten", Storage="_t_Datens", ThisKey="ID", OtherKey="ID_Flugzeug")]
		public EntitySet<t_Daten> t_Datens
		{
			get
			{
				return this._t_Datens;
			}
			set
			{
				this._t_Datens.Assign(value);
			}
		}
		
		[Association(Name="t_Tracker_t_Flugzeug", Storage="_t_Tracker", ThisKey="ID_GPS_Tracker", OtherKey="ID", IsForeignKey=true)]
		public t_Tracker t_Tracker
		{
			get
			{
				return this._t_Tracker.Entity;
			}
			set
			{
				t_Tracker previousValue = this._t_Tracker.Entity;
				if (((previousValue != value) 
							|| (this._t_Tracker.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._t_Tracker.Entity = null;
						previousValue.t_Flugzeugs.Remove(this);
					}
					this._t_Tracker.Entity = value;
					if ((value != null))
					{
						value.t_Flugzeugs.Add(this);
						this._ID_GPS_Tracker = value.ID;
					}
					else
					{
						this._ID_GPS_Tracker = default(Nullable<int>);
					}
					this.SendPropertyChanged("t_Tracker");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_t_Datens(t_Daten entity)
		{
			this.SendPropertyChanging();
			entity.t_Flugzeug = this;
		}
		
		private void detach_t_Datens(t_Daten entity)
		{
			this.SendPropertyChanging();
			entity.t_Flugzeug = null;
		}
	}
	
	[Table(Name="dbo.t_GPS_IN")]
	public partial class t_GPS_IN : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _IMEI;
		
		private int _Status;
		
		private int _GPS_fix;
		
		private System.DateTime _TimestampTracker;
		
		private string _longitude;
		
		private string _latitude;
		
		private string _altitude;
		
		private string _speed;
		
		private string _heading;
		
		private int _nr_used_sat;
		
		private string _HDOP;
		
		private System.DateTime _Timestamp;
		
		private bool _Processed;
		
		private EntitySet<t_Tracker> _t_Trackers;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnIMEIChanging(string value);
    partial void OnIMEIChanged();
    partial void OnStatusChanging(int value);
    partial void OnStatusChanged();
    partial void OnGPS_fixChanging(int value);
    partial void OnGPS_fixChanged();
    partial void OnTimestampTrackerChanging(System.DateTime value);
    partial void OnTimestampTrackerChanged();
    partial void OnlongitudeChanging(string value);
    partial void OnlongitudeChanged();
    partial void OnlatitudeChanging(string value);
    partial void OnlatitudeChanged();
    partial void OnaltitudeChanging(string value);
    partial void OnaltitudeChanged();
    partial void OnspeedChanging(string value);
    partial void OnspeedChanged();
    partial void OnheadingChanging(string value);
    partial void OnheadingChanged();
    partial void Onnr_used_satChanging(int value);
    partial void Onnr_used_satChanged();
    partial void OnHDOPChanging(string value);
    partial void OnHDOPChanged();
    partial void OnTimestampChanging(System.DateTime value);
    partial void OnTimestampChanged();
    partial void OnProcessedChanging(bool value);
    partial void OnProcessedChanged();
    #endregion
		
		public t_GPS_IN()
		{
			this._t_Trackers = new EntitySet<t_Tracker>(new Action<t_Tracker>(this.attach_t_Trackers), new Action<t_Tracker>(this.detach_t_Trackers));
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_IMEI", DbType="NChar(20) NOT NULL", CanBeNull=false)]
		public string IMEI
		{
			get
			{
				return this._IMEI;
			}
			set
			{
				if ((this._IMEI != value))
				{
					this.OnIMEIChanging(value);
					this.SendPropertyChanging();
					this._IMEI = value;
					this.SendPropertyChanged("IMEI");
					this.OnIMEIChanged();
				}
			}
		}
		
		[Column(Storage="_Status", DbType="Int NOT NULL")]
		public int Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[Column(Storage="_GPS_fix", DbType="Int NOT NULL")]
		public int GPS_fix
		{
			get
			{
				return this._GPS_fix;
			}
			set
			{
				if ((this._GPS_fix != value))
				{
					this.OnGPS_fixChanging(value);
					this.SendPropertyChanging();
					this._GPS_fix = value;
					this.SendPropertyChanged("GPS_fix");
					this.OnGPS_fixChanged();
				}
			}
		}
		
		[Column(Storage="_TimestampTracker", DbType="DateTime NOT NULL")]
		public System.DateTime TimestampTracker
		{
			get
			{
				return this._TimestampTracker;
			}
			set
			{
				if ((this._TimestampTracker != value))
				{
					this.OnTimestampTrackerChanging(value);
					this.SendPropertyChanging();
					this._TimestampTracker = value;
					this.SendPropertyChanged("TimestampTracker");
					this.OnTimestampTrackerChanged();
				}
			}
		}
		
		[Column(Storage="_longitude", DbType="NChar(12) NOT NULL", CanBeNull=false)]
		public string longitude
		{
			get
			{
				return this._longitude;
			}
			set
			{
				if ((this._longitude != value))
				{
					this.OnlongitudeChanging(value);
					this.SendPropertyChanging();
					this._longitude = value;
					this.SendPropertyChanged("longitude");
					this.OnlongitudeChanged();
				}
			}
		}
		
		[Column(Storage="_latitude", DbType="NChar(12) NOT NULL", CanBeNull=false)]
		public string latitude
		{
			get
			{
				return this._latitude;
			}
			set
			{
				if ((this._latitude != value))
				{
					this.OnlatitudeChanging(value);
					this.SendPropertyChanging();
					this._latitude = value;
					this.SendPropertyChanged("latitude");
					this.OnlatitudeChanged();
				}
			}
		}
		
		[Column(Storage="_altitude", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string altitude
		{
			get
			{
				return this._altitude;
			}
			set
			{
				if ((this._altitude != value))
				{
					this.OnaltitudeChanging(value);
					this.SendPropertyChanging();
					this._altitude = value;
					this.SendPropertyChanged("altitude");
					this.OnaltitudeChanged();
				}
			}
		}
		
		[Column(Storage="_speed", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string speed
		{
			get
			{
				return this._speed;
			}
			set
			{
				if ((this._speed != value))
				{
					this.OnspeedChanging(value);
					this.SendPropertyChanging();
					this._speed = value;
					this.SendPropertyChanged("speed");
					this.OnspeedChanged();
				}
			}
		}
		
		[Column(Storage="_heading", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string heading
		{
			get
			{
				return this._heading;
			}
			set
			{
				if ((this._heading != value))
				{
					this.OnheadingChanging(value);
					this.SendPropertyChanging();
					this._heading = value;
					this.SendPropertyChanged("heading");
					this.OnheadingChanged();
				}
			}
		}
		
		[Column(Storage="_nr_used_sat", DbType="Int NOT NULL")]
		public int nr_used_sat
		{
			get
			{
				return this._nr_used_sat;
			}
			set
			{
				if ((this._nr_used_sat != value))
				{
					this.Onnr_used_satChanging(value);
					this.SendPropertyChanging();
					this._nr_used_sat = value;
					this.SendPropertyChanged("nr_used_sat");
					this.Onnr_used_satChanged();
				}
			}
		}
		
		[Column(Storage="_HDOP", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string HDOP
		{
			get
			{
				return this._HDOP;
			}
			set
			{
				if ((this._HDOP != value))
				{
					this.OnHDOPChanging(value);
					this.SendPropertyChanging();
					this._HDOP = value;
					this.SendPropertyChanged("HDOP");
					this.OnHDOPChanged();
				}
			}
		}
		
		[Column(Storage="_Timestamp", DbType="DateTime NOT NULL")]
		public System.DateTime Timestamp
		{
			get
			{
				return this._Timestamp;
			}
			set
			{
				if ((this._Timestamp != value))
				{
					this.OnTimestampChanging(value);
					this.SendPropertyChanging();
					this._Timestamp = value;
					this.SendPropertyChanged("Timestamp");
					this.OnTimestampChanged();
				}
			}
		}
		
		[Column(Storage="_Processed", DbType="Bit")]
		public bool Processed
		{
			get
			{
				return this._Processed;
			}
			set
			{
				if ((this._Processed != value))
				{
					this.OnProcessedChanging(value);
					this.SendPropertyChanging();
					this._Processed = value;
					this.SendPropertyChanged("Processed");
					this.OnProcessedChanged();
				}
			}
		}
		
		[Association(Name="t_GPS_IN_t_Tracker", Storage="_t_Trackers", ThisKey="IMEI", OtherKey="IMEI")]
		public EntitySet<t_Tracker> t_Trackers
		{
			get
			{
				return this._t_Trackers;
			}
			set
			{
				this._t_Trackers.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_t_Trackers(t_Tracker entity)
		{
			this.SendPropertyChanging();
			entity.t_GPS_IN = this;
		}
		
		private void detach_t_Trackers(t_Tracker entity)
		{
			this.SendPropertyChanging();
			entity.t_GPS_IN = null;
		}
	}
}
#pragma warning restore 1591
