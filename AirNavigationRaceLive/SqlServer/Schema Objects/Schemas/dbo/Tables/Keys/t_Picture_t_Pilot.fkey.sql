ALTER TABLE [dbo].[t_Pilot]
    ADD CONSTRAINT [t_Picture_t_Pilot] FOREIGN KEY ([ID_Picture]) REFERENCES [dbo].[t_Picture] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

