ALTER TABLE [dbo].[t_Penalty]
    ADD CONSTRAINT [t_Competition_Team_t_Penalty] FOREIGN KEY ([ID_Competition_Team]) REFERENCES [dbo].[t_Competition_Team] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

