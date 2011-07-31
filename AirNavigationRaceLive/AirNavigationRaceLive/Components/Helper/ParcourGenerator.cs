﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirNavigationRaceLive.Components.Model;
using AnrlInterfaces;
using System.Windows.Forms;

namespace AirNavigationRaceLive.Components.Helper
{
    public static class ParcourGenerator
    {
        public static void GenerateParcour(Parcour parcour, Converter c, double lenght, double channel)
        {
            try
            {
                Line Start = parcour.Lines.Single(p => p.LineType == LineType.START) as Line;
                Line Ende = parcour.Lines.Single(p => p.LineType == LineType.END) as Line;
                Line LineOfNoReturn = parcour.Lines.Single(p => p.LineType == LineType.LINEOFNORETURN) as Line;
                double dist = Converter.Distance(Start.PointA, Ende.PointA);
                double dist2 = Converter.Distance(Start.PointB, Ende.PointB);
                if (dist < lenght - 1 && dist2 < lenght - 1)
                {
                    #region StartVektoren
                    Vector StartAV = new Vector(c.DegToX(Start.PointA.Longitude), c.DegToY(Start.PointA.Latitude), 0);
                    Vector StartBV = new Vector(c.DegToX(Start.PointB.Longitude), c.DegToY(Start.PointB.Latitude), 0);
                    Vector StartOV = new Vector(c.DegToX(Start.PointOrientation.Longitude), c.DegToY(Start.PointOrientation.Latitude), 0);
                    Vector StartAB = Vector.Direction(StartAV, StartBV);
                    Vector StartMV = Vector.Middle(StartAV, StartBV);
                    Vector StartLotOrientation = Vector.MinDistance(StartAV, StartBV, StartOV);
                    StartLotOrientation = StartLotOrientation * (0.5 * Vector.Abs(StartAB*( 1.0 / 7)) / Vector.Abs(StartLotOrientation));

                    Vector Start_A_A = StartAV;
                    Vector Start_A_B = StartAV + (StartAB* (1.0 / 7));
                    Vector Start_A_M = Vector.Middle(Start_A_A, Start_A_B);
                    Vector Start_A_O = Start_A_M + StartLotOrientation;

                    Line Start_A;
                    if (parcour.Lines.Exists(p => p.LineType == LineType.START_A))
                    {
                        Start_A = parcour.Lines.Single(p => p.LineType == LineType.START_A) as Line;
                    }
                    else
                    {
                        Start_A = new Line();
                        Start_A.LineType = LineType.START_A;
                        parcour.Lines.Add(Start_A);
                    }
                    Start_A.PointA = new GPSPoint(c.XtoDeg(Start_A_A.X), c.YtoDeg(Start_A_A.Y), 0);
                    Start_A.PointB = new GPSPoint(c.XtoDeg(Start_A_B.X), c.YtoDeg(Start_A_B.Y), 0);
                    Start_A.PointOrientation = new GPSPoint(c.XtoDeg(Start_A_O.X), c.YtoDeg(Start_A_O.Y), 0);

                    Vector Start_B_A = StartAV + (StartAB*(2.0 / 7));
                    Vector Start_B_B = StartAV + (StartAB*( 3.0 / 7));
                    Vector Start_B_M = Vector.Middle(Start_B_A, Start_B_B);
                    Vector Start_B_O = Start_B_M + StartLotOrientation;

                    Line Start_B;
                    if (parcour.Lines.Exists(p => p.LineType == LineType.START_B))
                    {
                        Start_B = parcour.Lines.Single(p => p.LineType == LineType.START_B) as Line;
                    }
                    else
                    {
                        Start_B = new Line();
                        Start_B.LineType = LineType.START_B;
                        parcour.Lines.Add(Start_B);
                    }
                    Start_B.PointA = new GPSPoint(c.XtoDeg(Start_B_A.X), c.YtoDeg(Start_B_A.Y), 0);
                    Start_B.PointB = new GPSPoint(c.XtoDeg(Start_B_B.X), c.YtoDeg(Start_B_B.Y), 0);
                    Start_B.PointOrientation = new GPSPoint(c.XtoDeg(Start_B_O.X), c.YtoDeg(Start_B_O.Y), 0);

                    Vector Start_C_A = StartAV + (StartAB *(4.0 / 7));
                    Vector Start_C_B = StartAV + (StartAB*( 5.0 / 7));
                    Vector Start_C_M = Vector.Middle(Start_C_A, Start_C_B);
                    Vector Start_C_O = Start_C_M + StartLotOrientation;
                    Line Start_C;
                    if (parcour.Lines.Exists(p => p.LineType == LineType.START_C))
                    {
                        Start_C = parcour.Lines.Single(p => p.LineType == LineType.START_C) as Line;
                    }
                    else
                    {
                        Start_C = new Line();
                        Start_C.LineType = LineType.START_C;
                        parcour.Lines.Add(Start_C);
                    }
                    Start_C.PointA = new GPSPoint(c.XtoDeg(Start_C_A.X), c.YtoDeg(Start_C_A.Y), 0);
                    Start_C.PointB = new GPSPoint(c.XtoDeg(Start_C_B.X), c.YtoDeg(Start_C_B.Y), 0);
                    Start_C.PointOrientation = new GPSPoint(c.XtoDeg(Start_C_O.X), c.YtoDeg(Start_C_O.Y), 0);

                    Vector Start_D_A = StartAV +(StartAB *(6.0 / 7));
                    Vector Start_D_B = StartAV + StartAB;
                    Vector Start_D_M = Vector.Middle(Start_D_A, Start_D_B);
                    Vector Start_D_O = Start_D_M + StartLotOrientation;
                    Line Start_D;
                    if (parcour.Lines.Exists(p => p.LineType == LineType.START_D))
                    {
                        Start_D = parcour.Lines.Single(p => p.LineType == LineType.START_D) as Line;
                    }
                    else
                    {
                        Start_D = new Line();
                        Start_D.LineType = LineType.START_D;
                        parcour.Lines.Add(Start_D);
                    }
                    Start_D.PointA = new GPSPoint(c.XtoDeg(Start_D_A.X), c.YtoDeg(Start_D_A.Y), 0);
                    Start_D.PointB = new GPSPoint(c.XtoDeg(Start_D_B.X), c.YtoDeg(Start_D_B.Y), 0);
                    Start_D.PointOrientation = new GPSPoint(c.XtoDeg(Start_D_O.X), c.YtoDeg(Start_D_O.Y), 0);
                    double lenghtStartLine = Converter.Distance(Start.PointA, Start.PointB);
                    #endregion



                    #region EndeVektoren
                    Vector EndeAV = new Vector(c.DegToX(Ende.PointA.Longitude), c.DegToY(Ende.PointA.Latitude), 0);
                    Vector EndeBV = new Vector(c.DegToX(Ende.PointB.Longitude), c.DegToY(Ende.PointB.Latitude), 0);
                    Vector EndeOV = new Vector(c.DegToX(Ende.PointOrientation.Longitude), c.DegToY(Ende.PointOrientation.Latitude), 0);
                    Vector EndeAB = Vector.Direction(EndeAV, EndeBV);
                    Vector EndeMV = Vector.Middle(EndeAV, EndeBV);
                    Vector EndeLotOrientation = Vector.MinDistance(EndeAV, EndeBV, EndeOV);
                    EndeLotOrientation = EndeLotOrientation *( 0.5 * Vector.Abs(EndeAB*( 1.0 / 7)) / Vector.Abs(EndeLotOrientation));

                    Vector Ende_A_A = EndeAV;
                    Vector Ende_A_B = EndeAV +(EndeAB*( 1.0 / 7));
                    Vector Ende_A_M = Vector.Middle(Ende_A_A, Ende_A_B);
                    Vector Ende_A_O = Ende_A_M+ EndeLotOrientation;

                    Line END_A;
                    if (parcour.Lines.Exists(p => p.LineType == LineType.END_A))
                    {
                        END_A = parcour.Lines.Single(p => p.LineType == LineType.END_A) as Line;
                    }
                    else
                    {
                        END_A = new Line();
                        END_A.LineType = LineType.END_A;
                        parcour.Lines.Add(END_A);
                    }
                    END_A.PointA = new GPSPoint(c.XtoDeg(Ende_A_A.X), c.YtoDeg(Ende_A_A.Y), 0);
                    END_A.PointB = new GPSPoint(c.XtoDeg(Ende_A_B.X), c.YtoDeg(Ende_A_B.Y), 0);
                    END_A.PointOrientation = new GPSPoint(c.XtoDeg(Ende_A_O.X), c.YtoDeg(Ende_A_O.Y), 0);

                    Vector Ende_B_A = EndeAV +(EndeAB* (2.0 / 7));
                    Vector Ende_B_B = EndeAV +(EndeAB* (3.0 / 7));
                    Vector Ende_B_M = Vector.Middle(Ende_B_A, Ende_B_B);
                    Vector Ende_B_O = Ende_B_M + EndeLotOrientation;

                    Line END_B;
                    if (parcour.Lines.Exists(p => p.LineType == LineType.END_B))
                    {
                        END_B = parcour.Lines.Single(p => p.LineType == LineType.END_B) as Line;
                    }
                    else
                    {
                        END_B = new Line();
                        END_B.LineType = LineType.END_B;
                        parcour.Lines.Add(END_B);
                    }
                    END_B.PointA = new GPSPoint(c.XtoDeg(Ende_B_A.X), c.YtoDeg(Ende_B_A.Y), 0);
                    END_B.PointB = new GPSPoint(c.XtoDeg(Ende_B_B.X), c.YtoDeg(Ende_B_B.Y), 0);
                    END_B.PointOrientation = new GPSPoint(c.XtoDeg(Ende_B_O.X), c.YtoDeg(Ende_B_O.Y), 0);

                    Vector Ende_C_A = EndeAV + (EndeAB *( 4.0 / 7));
                    Vector Ende_C_B = EndeAV + (EndeAB *( 5.0 / 7));
                    Vector Ende_C_M = Vector.Middle(Ende_C_A, Ende_C_B);
                    Vector Ende_C_O = Ende_C_M + EndeLotOrientation;
                    Line END_C;
                    if (parcour.Lines.Exists(p => p.LineType == LineType.END_C))
                    {
                        END_C = parcour.Lines.Single(p => p.LineType == LineType.END_C) as Line;
                    }
                    else
                    {
                        END_C = new Line();
                        END_C.LineType = LineType.END_C;
                        parcour.Lines.Add(END_C);
                    }
                    END_C.PointA = new GPSPoint(c.XtoDeg(Ende_C_A.X), c.YtoDeg(Ende_C_A.Y), 0);
                    END_C.PointB = new GPSPoint(c.XtoDeg(Ende_C_B.X), c.YtoDeg(Ende_C_B.Y), 0);
                    END_C.PointOrientation = new GPSPoint(c.XtoDeg(Ende_C_O.X), c.YtoDeg(Ende_C_O.Y), 0);

                    Vector Ende_D_A = EndeAV +(EndeAB*(6.0 / 7));
                    Vector Ende_D_B = EndeAV+ EndeAB;
                    Vector Ende_D_M = Vector.Middle(Ende_D_A, Ende_D_B);
                    Vector Ende_D_O = Ende_D_M + EndeLotOrientation;
                    Line END_D;
                    if (parcour.Lines.Exists(p => p.LineType == LineType.END_D))
                    {
                        END_D = parcour.Lines.Single(p => p.LineType == LineType.END_D) as Line;
                    }
                    else
                    {
                        END_D = new Line();
                        END_D.LineType = LineType.END_D;
                        parcour.Lines.Add(END_D);
                    }
                    END_D.PointA = new GPSPoint(c.XtoDeg(Ende_D_A.X), c.YtoDeg(Ende_D_A.Y), 0);
                    END_D.PointB = new GPSPoint(c.XtoDeg(Ende_D_B.X), c.YtoDeg(Ende_D_B.Y), 0);
                    END_D.PointOrientation = new GPSPoint(c.XtoDeg(Ende_D_O.X), c.YtoDeg(Ende_D_O.Y), 0);
                    double lenghtEndeLine = Converter.Distance(Ende.PointA, Ende.PointB);
                    #endregion

                }
                else
                {
                    MessageBox.Show("Minimal Distancen bewteen Start and End bigger than configured Parcour length-1", "Error while generating Parcour");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error while generating Parcour");
            }
        }
    }
}
