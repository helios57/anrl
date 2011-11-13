CREATE TABLE [dbo].[t_Competition] (
    [ID]             INT          IDENTITY (1, 1) NOT NULL,
    [TimeTakeOff]    BIGINT       NOT NULL,
    [TimeStartLine]  BIGINT       NOT NULL,
    [TimeEndLine]    BIGINT       NOT NULL,
    [ID_TakeOffLine] INT          NOT NULL,
    [Name]           VARCHAR (50) NOT NULL,
    [ID_Parcour]     INT          NOT NULL
);

