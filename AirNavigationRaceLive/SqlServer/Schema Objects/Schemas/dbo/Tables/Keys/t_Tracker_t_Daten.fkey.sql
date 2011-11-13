ALTER TABLE [dbo].[t_Daten]
    ADD CONSTRAINT [t_Tracker_t_Daten] FOREIGN KEY ([ID_Tracker]) REFERENCES [dbo].[t_Tracker] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

