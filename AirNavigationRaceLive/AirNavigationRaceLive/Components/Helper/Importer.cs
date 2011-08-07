using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;
using System.IO;
using AirNavigationRaceLive.Components.Model;
using Facet.Combinatorics;

namespace AirNavigationRaceLive.Components.Helper
{
    static class Importer
    {
        /// <summary> 
        /// Imports a DxfFile that is in the specified Format. Any changes on the import schema may cause Errors!
        /// </summary>
        /// <param name="filepath"></param>
        public static Parcour importFromDxf(string filepath)
        {
            Parcour result = new Parcour();

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
                        if (lines[i + 9] == " 90")
                        {
                            int numberOfVertexes = int.Parse(lines[i + 10]);
                            List<Vector> input = new List<Vector>();
                            double sumX = 0;
                            double sumY = 0;
                            double count = 0;
                            for (int j = 0; j < numberOfVertexes; j++)
                            {

                                double Longitude = Converter.CHtoWGSlng(double.Parse(lines[i + (j * 4) + 16]) * 1000, double.Parse(lines[i + (j * 4) + 18]) * 1000);
                                double Latitude = Converter.CHtoWGSlat(double.Parse(lines[i + (j * 4) + 16]) * 1000, double.Parse(lines[i + (j * 4) + 18]) * 1000);
                                Vector v = new Vector(Longitude, Latitude, 0);
                                input.Add(v);
                                sumX += v.X;
                                sumY += v.Y;
                                count += 1;
                            }
                            Vector o = new Vector(sumX / count, sumY / count, 0);
                            List<Vector> ordered;
                            List<Vector> listExtended = new List<Vector>(input);
                            listExtended.Add(o);
                            if (!Vector.hasIntersections(listExtended))
                            {
                                ordered = input;
                            }
                            else
                            {
                                ordered = getOrderedList(input, o);
                            }

                            for (int j = 0; j < ordered.Count; j++)
                            {
                                Line l = new Line();
                                l.LineType = LineType.PENALTYZONE;
                                int i_a = j % ordered.Count;
                                int i_b = (j + 1) % ordered.Count;
                                Vector a = ordered[i_a];
                                Vector b = ordered[i_b];
                                l.PointA = new GPSPoint(a.X, a.Y, a.Z);
                                l.PointB = new GPSPoint(b.X, b.Y, b.Z);
                                l.PointOrientation = new GPSPoint(o.X, o.Y, o.Z);
                                result.Lines.Add(l);
                            }
                        }
                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("STARTPOINT-"))
                    {
                        Line l = new Line();
                        double Longitude1 = Converter.CHtoWGSlat(double.Parse(lines[i + 16]) * 1000, double.Parse(lines[i + 18]) * 1000);
                        double Latitude1 = Converter.CHtoWGSlat(double.Parse(lines[i + 16]) * 1000, double.Parse(lines[i + 18]) * 1000);
                        l.PointA = new GPSPoint(Longitude1, Latitude1, 0);

                        double Longitude2 = Converter.CHtoWGSlat(double.Parse(lines[i + 20]) * 1000, double.Parse(lines[i + 22]) * 1000);
                        double Latitude2 = Converter.CHtoWGSlat(double.Parse(lines[i + 20]) * 1000, double.Parse(lines[i + 22]) * 1000);
                        l.PointB = new GPSPoint(Longitude2, Latitude2, 0);
                        Vector start = new Vector(Longitude1, Latitude1, 0);
                        Vector end = new Vector(Longitude2, Latitude2, 0);
                        Vector o = Vector.Middle(start, end) + Vector.Orthogonal(end - start);
                        l.PointOrientation = new GPSPoint(o.X, o.Y, o.Z);

                        string gatename = lines[i + 6].Substring(11, 1);
                        switch (gatename)
                        {
                            case "A":
                                {
                                    l.LineType = LineType.START_A;
                                    break;
                                }
                            case "B":
                                {
                                    l.LineType = LineType.START_B;
                                    break;
                                }
                            case "C":
                                {
                                    l.LineType = LineType.START_C;
                                    break;
                                }
                            case "D":
                                {
                                    l.LineType = LineType.START_D;
                                    break;
                                }
                        }
                        result.Lines.Add(l);
                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("ENDPOINT-"))
                    {
                        Line l = new Line();
                        double Longitude1 = Converter.CHtoWGSlat(double.Parse(lines[i + 16]) * 1000, double.Parse(lines[i + 18]) * 1000);
                        double Latitude1 = Converter.CHtoWGSlat(double.Parse(lines[i + 16]) * 1000, double.Parse(lines[i + 18]) * 1000);
                        l.PointA = new GPSPoint(Longitude1, Latitude1, 0);

                        double Longitude2 = Converter.CHtoWGSlat(double.Parse(lines[i + 20]) * 1000, double.Parse(lines[i + 22]) * 1000);
                        double Latitude2 = Converter.CHtoWGSlat(double.Parse(lines[i + 20]) * 1000, double.Parse(lines[i + 22]) * 1000);
                        l.PointB = new GPSPoint(Longitude2, Latitude2, 0);
                        Vector start = new Vector(Longitude1, Latitude1, 0);
                        Vector end = new Vector(Longitude2, Latitude2, 0);
                        Vector o = Vector.Middle(start, end) + Vector.Orthogonal(end - start);
                        l.PointOrientation = new GPSPoint(o.X, o.Y, o.Z);

                        string gatename = lines[i + 6].Substring(11, 1);
                        switch (gatename)
                        {
                            case "A":
                                {
                                    l.LineType = LineType.END_A;
                                    break;
                                }
                            case "B":
                                {
                                    l.LineType = LineType.END_B;
                                    break;
                                }
                            case "C":
                                {
                                    l.LineType = LineType.END_C;
                                    break;
                                }
                            case "D":
                                {
                                    l.LineType = LineType.END_D;
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
                            double Longitude1 = Converter.CHtoWGSlat(double.Parse(lines[i + 16]) * 1000, double.Parse(lines[i + 18]) * 1000);
                            double Latitude1 = Converter.CHtoWGSlat(double.Parse(lines[i + 16]) * 1000, double.Parse(lines[i + 18]) * 1000);
                            l.PointA = new GPSPoint(Longitude1, Latitude1, 0);

                            double Longitude2 = Converter.CHtoWGSlat(double.Parse(lines[i + 20]) * 1000, double.Parse(lines[i + 22]) * 1000);
                            double Latitude2 = Converter.CHtoWGSlat(double.Parse(lines[i + 20]) * 1000, double.Parse(lines[i + 22]) * 1000);
                            l.PointB = new GPSPoint(Longitude2, Latitude2, 0);
                            Vector start = new Vector(Longitude1, Latitude1, 0);
                            Vector end = new Vector(Longitude2, Latitude2, 0);
                            Vector o = Vector.Middle(start, end) + Vector.Orthogonal(end - start);
                            l.PointOrientation = new GPSPoint(o.X, o.Y, o.Z);
                            l.LineType = LineType.LINEOFNORETURN;
                            result.Lines.Add(l);
                        }
                    }
                }
            }
            return result;
        }

        private static List<Vector> getOrderedList(List<Vector> input, Vector o)
        {
            List<int> permInput = new List<int>();
            int i = 0;
            foreach (Vector v in input)
            {
                permInput.Add(i++);
            }
            Permutations<int> permutations = new Permutations<int>(permInput);
            foreach (List<int> l in permutations)
            {
                List<Vector> extended = getPermutedList(input, l);
                extended.Add(o);
                if (!Vector.hasIntersections(extended))
                {
                    return getPermutedList(input, l);
                }
            }
            return null;
        }
        private static List<Vector> getPermutedList(List<Vector> input, List<int> permInput)
        {
            List<Vector> result = new List<Vector>();
            foreach (int i in permInput)
            {
                result.Add(input[i]);
            }
            return result;
        }
    }
}
