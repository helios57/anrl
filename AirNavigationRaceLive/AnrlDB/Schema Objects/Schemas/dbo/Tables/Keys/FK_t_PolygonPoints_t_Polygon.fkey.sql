/****** Object:  ForeignKey [FK_t_PolygonPoints_t_Polygon]    Script Date: 08/14/2010 09:26:34 ******/
ALTER TABLE [dbo].[t_PenaltyZonePoint]  WITH CHECK ADD  CONSTRAINT [FK_t_PolygonPoints_t_Polygon] FOREIGN KEY([ID_Polygon])
REFERENCES [dbo].[t_PenaltyZonePolygon] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE


GO
ALTER TABLE [dbo].[t_PenaltyZonePoint] CHECK CONSTRAINT [FK_t_PolygonPoints_t_Polygon]

