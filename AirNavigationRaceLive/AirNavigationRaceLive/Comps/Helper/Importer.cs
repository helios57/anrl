﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AirNavigationRaceLive.Comps.Model;
using Facet.Combinatorics;
using NetworkObjects;

namespace AirNavigationRaceLive.Comps.Helper
{
    static class Importer
    {
        /// <summary> 
        /// Imports a DxfFile that is in the specified Format. Any changes on the import schema may cause Errors!
        /// </summary>
        /// <param name="filepath"></param>
        public static AirNavigationRaceLive.Comps.Model.Parcour importFromDxf(string filepath)
        {
            AirNavigationRaceLive.Comps.Model.Parcour result = new AirNavigationRaceLive.Comps.Model.Parcour();

            StreamReader sr = new StreamReader(filepath);
            List<string> lineList = new List<string>();
            while (!sr.EndOfStream)
            {
                lineList.Add(sr.ReadLine());
            }
            string[] lines = lineList.ToArray();
            for (int i = 1; i < lines.Length; i++) //Looping through Array, starting with 1 (lines[0] is "0")
            {
                //Find Lines Containing a new Element Definition
                if (lines[i] == "LWPOLYLINE" && lines[i - 1] == "  0") //
                {
                    //Reading out Layer ( "8" [\n] layerName) = Type of Element
                    if (lines[i + 5] == "  8" && lines[i + 6].Contains("PROH")) // "Prohibited Zone" = ForbiddenZone
                    {
                        if (lines[i + 9 + 4] == " 90")
                        {
                            int numberOfVertexes = int.Parse(lines[i + 10 + 4]);
                            List<Vector> input = new List<Vector>();
                            for (int j = 0; j < numberOfVertexes; j++)
                            {

                                double Longitude = Converter.CHtoWGSlng(double.Parse(lines[i + (j * 4) + 16 + 4]) * 1000, double.Parse(lines[i + (j * 4) + 18 + 4]) * 1000);
                                double Latitude = Converter.CHtoWGSlat(double.Parse(lines[i + (j * 4) + 16 + 4]) * 1000, double.Parse(lines[i + (j * 4) + 18 + 4]) * 1000);
                                Vector v = new Vector(Longitude, Latitude, 0);
                                input.Add(v);

                            }
                            if (input.Count > 2)
                            {
                                List<List<Vector>> konvexLists = Vector.KonvexPolygons(input);
                                foreach (List<Vector> list in konvexLists)
                                {
                                    double sumX = 0;
                                    double sumY = 0;
                                    double count = 0;
                                    foreach (Vector v in list)
                                    {
                                        sumX += v.X;
                                        sumY += v.Y;
                                        count += 1;
                                    }
                                    Vector o = new Vector(sumX / count, sumY / count, 0);
                                    for (int j = 0; j < list.Count; j++)
                                    {
                                        Line l = new Line();
                                        l.Type = (int)LineType.PENALTYZONE;
                                        int i_a = j % list.Count;
                                        int i_b = (j + 1) % list.Count;
                                        Vector a = list[i_a];
                                        Vector b = list[i_b];
                                        l.A = new Point(a.X, a.Y, a.Z);
                                        l.B = new Point(b.X, b.Y, b.Z);
                                        l.O = new Point(o.X, o.Y, o.Z);
                                        result.Lines.Add(l);
                                    }
                                }
                            }                    
                        }
                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("STARTPOINT-"))
                    {
                        Line l = new Line();
                        double Longitude1 = Converter.CHtoWGSlng(double.Parse(lines[i + 20]) * 1000, double.Parse(lines[i + 22]) * 1000);
                        double Latitude1 = Converter.CHtoWGSlat(double.Parse(lines[i + 20]) * 1000, double.Parse(lines[i + 22]) * 1000);
                        l.A = new Point(Longitude1, Latitude1, 0);

                        double Longitude2 = Converter.CHtoWGSlng(double.Parse(lines[i + 24]) * 1000, double.Parse(lines[i + 26]) * 1000);
                        double Latitude2 = Converter.CHtoWGSlat(double.Parse(lines[i + 24]) * 1000, double.Parse(lines[i + 26]) * 1000);
                        l.B = new Point(Longitude2, Latitude2, 0);
                        Vector start = new Vector(Longitude1, Latitude1, 0);
                        Vector end = new Vector(Longitude2, Latitude2, 0);
                        Vector o = Vector.Middle(start, end) - Vector.Orthogonal(end - start);
                        l.O = new Point(o.X, o.Y, o.Z);

                        string gatename = lines[i + 6].Substring(11, 1);
                        switch (gatename)
                        {
                            case "A":
                                {
                                    l.Type = (int)LineType.START_A;
                                    break;
                                }
                            case "B":
                                {
                                    l.Type = (int)LineType.START_B;
                                    break;
                                }
                            case "C":
                                {
                                    l.Type = (int)LineType.START_C;
                                    break;
                                }
                            case "D":
                                {
                                    l.Type = (int)LineType.START_D;
                                    break;
                                }
                        }
                        result.Lines.Add(l);
                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("ENDPOINT-"))
                    {
                        Line l = new Line();
                        double Longitude1 = Converter.CHtoWGSlng(double.Parse(lines[i + 20]) * 1000, double.Parse(lines[i + 22]) * 1000);
                        double Latitude1 = Converter.CHtoWGSlat(double.Parse(lines[i + 20]) * 1000, double.Parse(lines[i + 22]) * 1000);
                        l.A = new Point(Longitude1, Latitude1, 0);

                        double Longitude2 = Converter.CHtoWGSlng(double.Parse(lines[i + 24]) * 1000, double.Parse(lines[i + 26]) * 1000);
                        double Latitude2 = Converter.CHtoWGSlat(double.Parse(lines[i + 24]) * 1000, double.Parse(lines[i + 26]) * 1000);
                        l.B = new Point(Longitude2, Latitude2, 0);
                        Vector start = new Vector(Longitude1, Latitude1, 0);
                        Vector end = new Vector(Longitude2, Latitude2, 0);
                        Vector o = Vector.Middle(start, end) - Vector.Orthogonal(end - start);
                        l.O = new Point(o.X, o.Y, o.Z);

                        string gatename = lines[i + 6].Substring(9, 1);
                        switch (gatename)
                        {
                            case "A":
                                {
                                    l.Type = (int)LineType.END_A;
                                    break;
                                }
                            case "B":
                                {
                                    l.Type = (int)LineType.END_B;
                                    break;
                                }
                            case "C":
                                {
                                    l.Type = (int)LineType.END_C;
                                    break;
                                }
                            case "D":
                                {
                                    l.Type = (int)LineType.END_D;
                                    break;
                                }
                        }
                        result.Lines.Add(l);

                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("NBLINE"))
                    {
                        if (lines[i + 9] == " 90" && double.Parse(lines[10]) == 2)
                        {
                            Line l = new Line();
                            double Longitude1 = Converter.CHtoWGSlng(double.Parse(lines[i + 16]) * 1000, double.Parse(lines[i + 18]) * 1000);
                            double Latitude1 = Converter.CHtoWGSlat(double.Parse(lines[i + 16]) * 1000, double.Parse(lines[i + 18]) * 1000);
                            l.A = new Point(Longitude1, Latitude1, 0);

                            double Longitude2 = Converter.CHtoWGSlng(double.Parse(lines[i + 20]) * 1000, double.Parse(lines[i + 22]) * 1000);
                            double Latitude2 = Converter.CHtoWGSlat(double.Parse(lines[i + 20]) * 1000, double.Parse(lines[i + 22]) * 1000);
                            l.B = new Point(Longitude2, Latitude2, 0);
                            Vector start = new Vector(Longitude1, Latitude1, 0);
                            Vector end = new Vector(Longitude2, Latitude2, 0);
                            Vector o = Vector.Middle(start, end) - Vector.Orthogonal(end - start);
                            l.O = new Point(o.X, o.Y, o.Z);
                            l.Type = (int)LineType.LINEOFNORETURN;
                            result.Lines.Add(l);
                        }
                    }
                }
            }
            return result;
        }
    }
}