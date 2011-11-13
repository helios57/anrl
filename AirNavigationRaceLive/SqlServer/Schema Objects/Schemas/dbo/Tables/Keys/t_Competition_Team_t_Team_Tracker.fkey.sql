ALTER TABLE [dbo].[t_Team_Tracker]
    ADD CONSTRAINT [t_Competition_Team_t_Team_Tracker] FOREIGN KEY ([ID_Competition_Team]) REFERENCES [dbo].[t_Competition_Team] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

