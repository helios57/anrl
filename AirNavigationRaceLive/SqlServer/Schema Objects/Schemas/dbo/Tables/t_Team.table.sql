CREATE TABLE [dbo].[t_Team] (
    [ID]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (50)  NULL,
    [ID_Pilot]     INT           NOT NULL,
    [ID_Navigator] INT           NULL,
    [Color]        VARCHAR (10)  NULL,
    [ID_Flag]      INT           NULL,
    [Description]  VARCHAR (500) NULL
);

