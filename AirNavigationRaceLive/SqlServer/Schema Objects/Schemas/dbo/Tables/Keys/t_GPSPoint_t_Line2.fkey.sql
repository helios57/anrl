ALTER TABLE [dbo].[t_Line]
    ADD CONSTRAINT [t_GPSPoint_t_Line2] FOREIGN KEY ([ID_PointOrientation]) REFERENCES [dbo].[t_GPSPoint] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

