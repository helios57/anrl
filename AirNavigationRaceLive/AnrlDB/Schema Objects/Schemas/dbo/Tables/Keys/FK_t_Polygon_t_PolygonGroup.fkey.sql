/****** Object:  ForeignKey [FK_t_Polygon_t_PolygonGroup]    Script Date: 08/14/2010 09:26:34 ******/
ALTER TABLE [dbo].[t_PenaltyZonePolygon]  WITH CHECK ADD  CONSTRAINT [FK_t_Polygon_t_PolygonGroup] FOREIGN KEY([ID_PolygonGroup])
REFERENCES [dbo].[t_PenaltyZone] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE


GO
ALTER TABLE [dbo].[t_PenaltyZonePolygon] CHECK CONSTRAINT [FK_t_Polygon_t_PolygonGroup]

