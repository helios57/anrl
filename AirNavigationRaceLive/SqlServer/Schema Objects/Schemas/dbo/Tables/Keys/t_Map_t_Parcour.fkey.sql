﻿ALTER TABLE [dbo].[t_Parcour]
    ADD CONSTRAINT [t_Map_t_Parcour] FOREIGN KEY ([ID_Map]) REFERENCES [dbo].[t_Map] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

