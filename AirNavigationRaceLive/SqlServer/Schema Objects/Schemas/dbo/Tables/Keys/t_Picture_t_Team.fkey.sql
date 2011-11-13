ALTER TABLE [dbo].[t_Team]
    ADD CONSTRAINT [t_Picture_t_Team] FOREIGN KEY ([ID_Flag]) REFERENCES [dbo].[t_Picture] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

