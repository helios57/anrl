ALTER TABLE [dbo].[t_Parcour_Line]
    ADD CONSTRAINT [t_Line_t_Parcour_Line] FOREIGN KEY ([ID_Line]) REFERENCES [dbo].[t_Line] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

