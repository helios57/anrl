ALTER TABLE [dbo].[t_Parcour_Line]
    ADD CONSTRAINT [t_Parcour_t_Parcour_Line] FOREIGN KEY ([ID_Parcour]) REFERENCES [dbo].[t_Parcour] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

