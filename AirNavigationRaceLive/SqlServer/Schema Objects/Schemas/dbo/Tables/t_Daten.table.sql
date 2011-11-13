CREATE TABLE [dbo].[t_Daten] (
    [ID]         INT    IDENTITY (1, 1) NOT NULL,
    [ID_Tracker] INT    NOT NULL,
    [Timestamp]  BIGINT NOT NULL,
    [Longitude]  FLOAT  NOT NULL,
    [Latitude]   FLOAT  NOT NULL,
    [Altitude]   FLOAT  NOT NULL,
    [Speed]      FLOAT  NOT NULL,
    [Accuracy]   FLOAT  NULL,
    [Bearing]    FLOAT  NULL
);

