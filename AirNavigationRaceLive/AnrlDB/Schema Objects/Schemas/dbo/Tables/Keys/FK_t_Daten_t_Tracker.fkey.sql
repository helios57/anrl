/****** Object:  ForeignKey [FK_t_Daten_t_Tracker]    Script Date: 08/14/2010 09:26:34 ******/
ALTER TABLE [dbo].[t_Daten]  WITH CHECK ADD  CONSTRAINT [FK_t_Daten_t_Tracker] FOREIGN KEY([ID_Tracker])
REFERENCES [dbo].[t_Tracker] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE


GO
ALTER TABLE [dbo].[t_Daten] CHECK CONSTRAINT [FK_t_Daten_t_Tracker]

