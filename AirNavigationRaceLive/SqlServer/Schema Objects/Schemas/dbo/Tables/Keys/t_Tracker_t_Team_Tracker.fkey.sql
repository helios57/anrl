ALTER TABLE [dbo].[t_Team_Tracker]
    ADD CONSTRAINT [t_Tracker_t_Team_Tracker] FOREIGN KEY ([ID_Tracker]) REFERENCES [dbo].[t_Tracker] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

