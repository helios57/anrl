using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirNavigationRaceLive.Components.Model;
using AnrlInterfaces;
using System.Windows.Forms;
using System.Threading;

namespace AirNavigationRaceLive.Components.Helper
{
    public class ParcourGenerator
    {
        private const double EndLineDist = 0.9;
        private const double LineOfNoReturnDist = 1.5;
        private double best = double.MaxValue;
        private volatile ParcourModel bestModel = null;
        private Parcour parcour;
        private Converter c;
        private Comparer comparer = new Comparer();
        public volatile bool finished = false;

        public void GenerateParcour(Parcour parcour, Converter c, double lenght, double channel)
        {
            this.parcour = parcour;
            this.c = c;
            try
            {
                Line Start = parcour.Lines.Single(p => p.LineType == LineType.START) as Line;
                if (Start == null) return;
                #region StartVektoren
                Vector StartAV = new Vector(c.DegToX(Start.PointA.Longitude), c.DegToY(Start.PointA.Latitude), 0);
                Vector StartBV = new Vector(c.DegToX(Start.PointB.Longitude), c.DegToY(Start.PointB.Latitude), 0);
                Vector StartOV = new Vector(c.DegToX(Start.PointOrientation.Longitude), c.DegToY(Start.PointOrientation.Latitude), 0);
                Vector StartAB = Vector.Direction(StartAV, StartBV);
                Vector StartMV = Vector.Middle(StartAV, StartBV);
                Vector StartLotOrientation = Vector.MinDistance(StartAV, StartBV, StartOV);

                double GateRadiusKm = Converter.NMtoM(0.3);
                Vector StartABNormalized = StartAB / Vector.Abs(StartAB);
                double StartABLength = Converter.Distance(c.XtoDeg(StartAV.X), c.YtoDeg(StartAV.Y), c.XtoDeg((StartAV + StartABNormalized).X), c.YtoDeg((StartAV + StartABNormalized).Y));
                Vector StartAB1KM = StartABNormalized / StartABLength;

                StartLotOrientation = StartLotOrientation * (Vector.Abs(StartAB1KM * GateRadiusKm) / Vector.Abs(StartLotOrientation));
                StartOV = StartMV + (StartLotOrientation * 2);

                Vector Start_A_M = StartAV + (StartAB1KM * GateRadiusKm);
                Vector Start_A_A = StartAV;
                Vector Start_A_B = Start_A_M + (StartAB1KM * GateRadiusKm);
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

                Vector Start_D_M = StartBV - (StartAB1KM * GateRadiusKm);
                Vector Start_D_B = StartBV;
                Vector Start_D_A = Start_D_M - (StartAB1KM * GateRadiusKm);
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


                Vector Start_B_M = Start_A_M + (Vector.Direction(Start_A_M, Start_D_M) / 3.0);
                Vector Start_B_A = Start_B_M - (StartAB1KM * GateRadiusKm);
                Vector Start_B_B = Start_B_M + (StartAB1KM * GateRadiusKm);
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

                Vector Start_C_M = Start_A_M + ((Vector.Direction(Start_A_M, Start_D_M) * 2) / 3.0);
                Vector Start_C_B = Start_C_M - (StartAB1KM * GateRadiusKm);
                Vector Start_C_A = Start_C_M + (StartAB1KM * GateRadiusKm);
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
                #endregion

                #region EndeVektoren
                double lengthKm = Converter.NMtoM(lenght);
                Vector lotPoint = StartMV + StartLotOrientation;
                double lotLenght = Converter.Distance(c.XtoDeg(StartMV.X), c.YtoDeg(StartMV.Y), c.XtoDeg(lotPoint.X), c.YtoDeg(lotPoint.Y));
                Vector StartEnd = (StartLotOrientation / lotLenght) * lengthKm * EndLineDist; //Shorten to make linearcombinations of vectors ... factor to be definded

                Vector EndeAV = StartAV + StartEnd;
                Vector EndeBV = StartBV + StartEnd;
                Vector EndeMV = Vector.Middle(EndeAV, EndeBV);
                Vector EndeOV = EndeMV + StartLotOrientation;
                Vector EndeAB = Vector.Direction(EndeAV, EndeBV);

                Vector Ende_A_A = Start_A_A + StartEnd;
                Vector Ende_A_B = Start_A_B + StartEnd;
                Vector Ende_A_M = Start_A_M + StartEnd;
                Vector Ende_A_O = Start_A_O + StartEnd;

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

                Vector Ende_B_A = Start_B_A + StartEnd;
                Vector Ende_B_B = Start_B_B + StartEnd;
                Vector Ende_B_M = Start_B_M + StartEnd;
                Vector Ende_B_O = Start_B_O + StartEnd;

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

                Vector Ende_C_A = Start_C_A + StartEnd;
                Vector Ende_C_B = Start_C_B + StartEnd;
                Vector Ende_C_M = Start_C_M + StartEnd;
                Vector Ende_C_O = Start_C_O + StartEnd;
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

                Vector Ende_D_A = Start_D_A + StartEnd;
                Vector Ende_D_B = Start_D_B + StartEnd;
                Vector Ende_D_M = Start_D_M + StartEnd;
                Vector Ende_D_O = Start_D_O + StartEnd;
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
                #endregion

                #region LineOfNoReturn
                double lengthLONRKm = Converter.NMtoM(LineOfNoReturnDist);
                Vector StartToLONR = (StartLotOrientation / lotLenght) * ((lengthKm * EndLineDist) - lengthLONRKm);

                Vector LONR_A = StartAV + StartToLONR;
                Vector LONR_B = StartBV + StartToLONR;
                Vector LONR_O = StartOV + StartToLONR;
                Line LONR;
                if (parcour.Lines.Exists(p => p.LineType == LineType.LINEOFNORETURN))
                {
                    LONR = parcour.Lines.Single(p => p.LineType == LineType.LINEOFNORETURN) as Line;
                }
                else
                {
                    LONR = new Line();
                    LONR.LineType = LineType.LINEOFNORETURN;
                    parcour.Lines.Add(LONR);
                }
                LONR.PointA = new GPSPoint(c.XtoDeg(LONR_A.X), c.YtoDeg(LONR_A.Y), 0);
                LONR.PointB = new GPSPoint(c.XtoDeg(LONR_B.X), c.YtoDeg(LONR_B.Y), 0);
                LONR.PointOrientation = new GPSPoint(c.XtoDeg(LONR_O.X), c.YtoDeg(LONR_O.Y), 0);
                #endregion
                CalculateParcour(parcour, c);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error while generating Parcour");
            }
        }

        private void CalculateParcour(Parcour parcour, Converter c)
        {
            ParcourModel pm = new ParcourModel(parcour, c, EndLineDist);
            List<List<ParcourModel>> modelList = new List<List<ParcourModel>>();
            //System.Diagnostics.Process.GetCurrentProcess().
            for (int i = 0; i < 1; i++)
            {
                List<ParcourModel> list = new List<ParcourModel>();
                modelList.Add(list);
                list.Add(pm);
                for (int j = 0; j < 300; j++)
                {
                    list.Add(new ParcourModel(pm, 1));
                }
            }
            best = double.MaxValue;
            bestModel = null;

            foreach (List<ParcourModel> list in modelList)
            {
                Thread t = new Thread(new ParameterizedThreadStart(ProcessList));
                t.Start(list);
            }
        }

        private void ProcessList(object o)
        {
            List<ParcourModel> list = o as List<ParcourModel>;
            while (best > 2)
            {
                list.Sort(comparer);
                ParcourModel first = list[0];
                double firstWeight = first.Weight();
                if (first.Weight() < best)
                {
                    bestModel = first;
                    best = first.Weight();
                    AddBestModel();
                }
                list.Clear();
                list.Add(first);
                for (int j = 0; j < 300; j++)
                {
                    list.Add(new ParcourModel(first, 0.1));
                }
            }
            finished = true;
        }

        private void AddBestModel()
        {
            lock (parcour)
            {
                parcour.Lines.RemoveAll(p => p.LineType == LineType.Point);
                foreach (ParcourChannel pc in bestModel.getChannels())
                {
                    Vector last = null;
                    foreach (Vector v in pc.getLinearCombinations())
                    {
                        if (last != null)
                        {
                            Line l = new Line();
                            l.LineType = LineType.Point;
                            l.PointA = new GPSPoint(c.XtoDeg(last.X), c.YtoDeg(last.Y), 0);
                            l.PointB = new GPSPoint(c.XtoDeg(last.X), c.YtoDeg(last.Y), 0);
                            l.PointOrientation = new GPSPoint(c.XtoDeg(v.X), c.YtoDeg(v.Y), 0);
                            parcour.Lines.Add(l);
                        }
                        last = v;
                    }
                }
            }
        }
    }
    class Comparer : Comparer<ParcourModel>
    {
        public override int Compare(ParcourModel x, ParcourModel y)
        {
            return x.Weight().CompareTo(y.Weight());
        }
    }
}
