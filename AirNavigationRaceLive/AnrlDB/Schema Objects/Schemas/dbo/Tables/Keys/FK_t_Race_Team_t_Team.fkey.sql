/****** Object:  ForeignKey [FK_t_Race_Team_t_Team]    Script Date: 08/14/2010 09:26:34 ******/
ALTER TABLE [dbo].[t_Race_Team]  WITH CHECK ADD  CONSTRAINT [FK_t_Race_Team_t_Team] FOREIGN KEY([ID_Team])
REFERENCES [dbo].[t_Team] ([ID])


GO
ALTER TABLE [dbo].[t_Race_Team] CHECK CONSTRAINT [FK_t_Race_Team_t_Team]

