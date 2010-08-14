/****** Object:  ForeignKey [FK_t_Race_t_PenaltyZone]    Script Date: 08/14/2010 09:26:34 ******/
ALTER TABLE [dbo].[t_Race]  WITH CHECK ADD  CONSTRAINT [FK_t_Race_t_PenaltyZone] FOREIGN KEY([ID_PenaltyZone])
REFERENCES [dbo].[t_PenaltyZone] ([ID])


GO
ALTER TABLE [dbo].[t_Race] CHECK CONSTRAINT [FK_t_Race_t_PenaltyZone]

