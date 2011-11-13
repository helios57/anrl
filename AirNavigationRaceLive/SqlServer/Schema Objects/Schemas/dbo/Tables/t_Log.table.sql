CREATE TABLE [dbo].[t_Log] (
    [id]        INT      IDENTITY (1, 1) NOT NULL,
    [timestamp] DATETIME NOT NULL,
    [level]     INT      NOT NULL,
    [project]   TEXT     NULL,
    [Text]      TEXT     NULL
);

