CREATE TABLE [dbo].[t_GPS_IN](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IMEI] [nchar](20) NOT NULL,
	[Status] [int] NOT NULL,
	[GPS_fix] [int] NOT NULL,
	[TimestampTracker] [datetime] NOT NULL,
	[longitude] [nchar](12) NOT NULL,
	[latitude] [nchar](12) NOT NULL,
	[altitude] [nchar](10) NOT NULL,
	[speed] [nchar](10) NOT NULL,
	[heading] [nchar](10) NOT NULL,
	[nr_used_sat] [int] NOT NULL,
	[HDOP] [nchar](10) NOT NULL,
	[Timestamp] [datetime] NOT NULL,
	[Processed] [bit] NOT NULL,
 CONSTRAINT [PK_t_GPS_IN_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


