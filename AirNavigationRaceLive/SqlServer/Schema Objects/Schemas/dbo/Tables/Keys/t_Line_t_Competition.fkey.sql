ALTER TABLE [dbo].[t_Competition]
    ADD CONSTRAINT [t_Line_t_Competition] FOREIGN KEY ([ID_TakeOffLine]) REFERENCES [dbo].[t_Line] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

