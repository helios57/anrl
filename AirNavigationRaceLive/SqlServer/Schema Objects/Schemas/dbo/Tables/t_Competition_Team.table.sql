CREATE TABLE [dbo].[t_Competition_Team] (
    [ID]             INT    IDENTITY (1, 1) NOT NULL,
    [StartID]        INT    NOT NULL,
    [Route]          INT    NOT NULL,
    [ID_Team]        INT    NOT NULL,
    [ID_Competition] INT    NOT NULL,
    [TimeTakeOff]    BIGINT NOT NULL,
    [TimeStart]      BIGINT NOT NULL,
    [TimeEnd]        BIGINT NOT NULL
);

