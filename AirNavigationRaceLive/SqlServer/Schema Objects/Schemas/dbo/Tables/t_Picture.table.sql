CREATE TABLE [dbo].[t_Picture] (
    [ID]     INT        IDENTITY (1, 1) NOT NULL,
    [Data]   IMAGE      NOT NULL,
    [Name]   NCHAR (50) NULL,
    [isFlag] BIT        NOT NULL
);

