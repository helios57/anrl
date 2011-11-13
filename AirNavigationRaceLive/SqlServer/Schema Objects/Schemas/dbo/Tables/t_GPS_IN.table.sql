CREATE TABLE [dbo].[t_GPS_IN] (
    [ID]               INT        IDENTITY (1, 1) NOT NULL,
    [IMEI]             NCHAR (20) NOT NULL,
    [Status]           INT        NOT NULL,
    [GPS_fix]          INT        NOT NULL,
    [TimestampTracker] DATETIME   NOT NULL,
    [longitude]        NCHAR (12) NOT NULL,
    [latitude]         NCHAR (12) NOT NULL,
    [altitude]         NCHAR (10) NOT NULL,
    [speed]            NCHAR (10) NOT NULL,
    [heading]          NCHAR (10) NOT NULL,
    [nr_used_sat]      INT        NOT NULL,
    [HDOP]             NCHAR (10) NOT NULL,
    [Timestamp]        DATETIME   NOT NULL,
    [Processed]        BIT        NOT NULL
);

