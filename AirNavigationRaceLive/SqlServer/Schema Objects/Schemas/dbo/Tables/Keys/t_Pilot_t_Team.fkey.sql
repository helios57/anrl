﻿ALTER TABLE [dbo].[t_Team]
    ADD CONSTRAINT [t_Pilot_t_Team] FOREIGN KEY ([ID_Pilot]) REFERENCES [dbo].[t_Pilot] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

