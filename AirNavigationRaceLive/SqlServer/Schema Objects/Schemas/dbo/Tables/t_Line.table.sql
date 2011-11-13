CREATE TABLE [dbo].[t_Line] (
    [ID]                  INT IDENTITY (1, 1) NOT NULL,
    [Type]                INT NOT NULL,
    [ID_PointA]           INT NOT NULL,
    [ID_PointB]           INT NOT NULL,
    [ID_PointOrientation] INT NOT NULL
);

