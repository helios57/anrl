﻿/****** Object:  ForeignKey [FK_t_Pilot_t_Picture]    Script Date: 08/14/2010 09:26:34 ******/
ALTER TABLE [dbo].[t_Pilot]  WITH CHECK ADD  CONSTRAINT [FK_t_Pilot_t_Picture] FOREIGN KEY([ID_Picture])
REFERENCES [dbo].[t_Picture] ([ID])


GO
ALTER TABLE [dbo].[t_Pilot] CHECK CONSTRAINT [FK_t_Pilot_t_Picture]

