CREATE TABLE [dbo].[t_Penalty] (
    [ID]                  INT           IDENTITY (1, 1) NOT NULL,
    [Points]              INT           NOT NULL,
    [Reason]              VARCHAR (500) NOT NULL,
    [ID_Competition_Team] INT           NOT NULL
);

