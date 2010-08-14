/****** Object:  ForeignKey [FK_t_Team_t_Tracker]    Script Date: 08/14/2010 09:26:34 ******/
ALTER TABLE [dbo].[t_Team]  WITH CHECK ADD  CONSTRAINT [FK_t_Team_t_Tracker] FOREIGN KEY([ID_Tracker])
REFERENCES [dbo].[t_Tracker] ([ID])


GO
ALTER TABLE [dbo].[t_Team] CHECK CONSTRAINT [FK_t_Team_t_Tracker]

