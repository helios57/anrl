CREATE TABLE [dbo].[t_Map] (
    [ID]         INT          IDENTITY (1, 1) NOT NULL,
    [ID_Picture] INT          NOT NULL,
    [Name]       VARCHAR (50) NOT NULL,
    [XSize]      FLOAT        NOT NULL,
    [YSize]      FLOAT        NOT NULL,
    [XRot]       FLOAT        NOT NULL,
    [YRot]       FLOAT        NOT NULL,
    [XTopLeft]   FLOAT        NOT NULL,
    [YTopLeft]   FLOAT        NOT NULL
);

