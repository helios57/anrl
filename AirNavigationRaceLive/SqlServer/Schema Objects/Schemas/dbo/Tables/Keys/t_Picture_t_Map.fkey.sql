ALTER TABLE [dbo].[t_Map]
    ADD CONSTRAINT [t_Picture_t_Map] FOREIGN KEY ([ID_Picture]) REFERENCES [dbo].[t_Picture] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

