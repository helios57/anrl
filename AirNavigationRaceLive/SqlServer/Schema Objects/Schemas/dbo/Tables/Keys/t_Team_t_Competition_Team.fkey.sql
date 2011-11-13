ALTER TABLE [dbo].[t_Competition_Team]
    ADD CONSTRAINT [t_Team_t_Competition_Team] FOREIGN KEY ([ID_Team]) REFERENCES [dbo].[t_Team] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

