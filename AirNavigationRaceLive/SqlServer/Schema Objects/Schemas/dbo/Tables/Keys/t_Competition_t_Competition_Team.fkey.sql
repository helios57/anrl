ALTER TABLE [dbo].[t_Competition_Team]
    ADD CONSTRAINT [t_Competition_t_Competition_Team] FOREIGN KEY ([ID_Competition]) REFERENCES [dbo].[t_Competition] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

