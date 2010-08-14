/****** Object:  ForeignKey [FK_t_Team_t_Pilot1]    Script Date: 08/14/2010 09:26:34 ******/
ALTER TABLE [dbo].[t_Team]  WITH CHECK ADD  CONSTRAINT [FK_t_Team_t_Pilot1] FOREIGN KEY([ID_Navigator])
REFERENCES [dbo].[t_Pilot] ([ID])


GO
ALTER TABLE [dbo].[t_Team] CHECK CONSTRAINT [FK_t_Team_t_Pilot1]

