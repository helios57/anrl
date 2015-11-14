using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AirNavigationRaceLive.Comps.Model;
using Facet.Combinatorics;
using NetworkObjects;
using System.Xml.Linq;
using System.Globalization;

namespace AirNavigationRaceLive.Comps.Helper
{
    static class Importer
    {
        /// <summary> 
        /// Imports a DxfFile that is in the specified Format. Any changes on the import schema may cause Errors!
        /// </summary>
        /// <param name="filepath"></param>
        public static Parcour importFromDxfCH(string filepath)
        {
            Parcour result = new Parcour();

            StreamReader sr = new StreamReader(filepath);
            List<string> Line = new List<string>();
            while (!sr.EndOfStream)
            {
                Line.Add(sr.ReadLine());
            }
            string[] lines = Line.ToArray();
            for (int i = 1; i < lines.Length; i++) //Looping through Array, starting with 1 (lines[0] is "0")
            {
                //Find Lines Containing a new Element Definition
                if (lines[i] == "LWPOLYLINE" && lines[i - 1] == "  0") //
                {
                    //Reading out Layer ( "8" [\n] layerName) = Type of Element
                    if (lines[i + 5] == "  8" && lines[i + 6].Contains("PROH")) // "Prohibited Zone" = ForbiddenZone
                    {
                        if (lines[i + 9 + 4] == " 90" || lines[i + 9] == " 90")
                        {
                            int correctur = lines[i + 9 + 4] == " 90" ? 4 : 0;
                            int numberOfVertexes = int.Parse(lines[i + 10 + correctur]);
                            List<Vector> input = new List<Vector>();
                            for (int j = 0; j < numberOfVertexes; j++)
                            {

                                double Longitude = Converter.CHtoWGSlng(double.Parse(lines[i + (j * 4) + 16 + correctur], NumberFormatInfo.InvariantInfo) * 1000, double.Parse(lines[i + (j * 4) + 18 + correctur], NumberFormatInfo.InvariantInfo) * 1000);
                                double Latitude = Converter.CHtoWGSlat(double.Parse(lines[i + (j * 4) + 16 + correctur], NumberFormatInfo.InvariantInfo) * 1000, double.Parse(lines[i + (j * 4) + 18 + correctur], NumberFormatInfo.InvariantInfo) * 1000);
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
                                        l.A = a.toGPSPoint();
                                        l.B = b.toGPSPoint();
                                        l.O = o.toGPSPoint();
                                        result.Line.Add(l);
                                    }
                                }
                            }
                        }
                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("STARTPOINT-"))
                    {
                        double[] res = new double[4];
                        res[3] = 0.0f;
                        int resCount = 0;
                        for (int j = 0; resCount < 4; j++)
                        {
                            try
                            {
                                double parsed = double.Parse(lines[i + 6 + 8 + j], NumberFormatInfo.InvariantInfo);
                                int dummy;
                                if (parsed != 0.0f && !Int32.TryParse(lines[i + 6 + 8 + j], out dummy))
                                {
                                    res[resCount++] = parsed;
                                }
                            }
                            catch { }
                        }

                        Line l = new Line();
                        double Longitude1 = Converter.CHtoWGSlng(res[0] * 1000, res[1] * 1000);
                        double Latitude1 = Converter.CHtoWGSlat(res[0] * 1000, res[1] * 1000);
                        l.A = new Point();
                        l.A.longitude = Longitude1;
                        l.A.latitude = Latitude1;

                        double Longitude2 = Converter.CHtoWGSlng(res[2] * 1000, res[3] * 1000);
                        double Latitude2 = Converter.CHtoWGSlat(res[2] * 1000, res[3] * 1000);
                        l.B = new Point();
                        l.B.longitude = Longitude2;
                        l.B.latitude = Latitude2;

                        Vector start = new Vector(Longitude1, Latitude1, 0);
                        Vector end = new Vector(Longitude2, Latitude2, 0);
                        Vector o = Vector.Middle(start, end) - Vector.Orthogonal(end - start);
                        l.O = o.toGPSPoint();

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
                        result.Line.Add(l);
                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("ENDPOINT-"))
                    {
                        double[] res = new double[4];
                        res[3] = 0.0f;
                        int resCount = 0;
                        for (int j = 0; resCount < 4; j++)
                        {
                            try
                            {
                                double parsed = double.Parse(lines[i + 6 + 8 + j], NumberFormatInfo.InvariantInfo);
                                int dummy;
                                if (parsed != 0.0f && !Int32.TryParse(lines[i + 6 + 8 + j], out dummy))
                                {
                                    res[resCount++] = parsed;
                                }
                            }
                            catch { }
                        }

                        Line l = new Line();
                        double Longitude1 = Converter.CHtoWGSlng(res[0] * 1000, res[1] * 1000);
                        double Latitude1 = Converter.CHtoWGSlat(res[0] * 1000, res[1] * 1000);
                        l.A = new Point();
                        l.A.longitude = Longitude1;
                        l.A.latitude = Latitude1;

                        double Longitude2 = Converter.CHtoWGSlng(res[2] * 1000, res[3] * 1000);
                        double Latitude2 = Converter.CHtoWGSlat(res[2] * 1000, res[3] * 1000);
                        l.B = new Point();
                        l.B.longitude = Longitude2;
                        l.B.latitude = Latitude2;

                        Vector start = new Vector(Longitude1, Latitude1, 0);
                        Vector end = new Vector(Longitude2, Latitude2, 0);
                        Vector o = Vector.Middle(start, end) - Vector.Orthogonal(end - start);
                        l.O = o.toGPSPoint();

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
                        result.Line.Add(l);

                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("NBLINE"))
                    {
                        if ((lines[i + 9 + 4] == " 90" || lines[i + 9] == " 90") && double.Parse(lines[10], NumberFormatInfo.InvariantInfo) == 2)
                        {
                            int correctur = lines[i + 9 + 4] == " 90" ? 4 : 0;
                            Line l = new Line();
                            double Longitude1 = Converter.CHtoWGSlng(double.Parse(lines[i + 16 + correctur], NumberFormatInfo.InvariantInfo) * 1000, double.Parse(lines[i + 18 + correctur], NumberFormatInfo.InvariantInfo) * 1000);
                            double Latitude1 = Converter.CHtoWGSlat(double.Parse(lines[i + 16 + correctur], NumberFormatInfo.InvariantInfo) * 1000, double.Parse(lines[i + 18 + correctur], NumberFormatInfo.InvariantInfo) * 1000);
                            l.A = new Point();
                            l.A.longitude = Longitude1;
                            l.A.latitude = Latitude1;

                            double Longitude2 = Converter.CHtoWGSlng(double.Parse(lines[i + 20 + correctur], NumberFormatInfo.InvariantInfo) * 1000, double.Parse(lines[i + 22 + correctur], NumberFormatInfo.InvariantInfo) * 1000);
                            double Latitude2 = Converter.CHtoWGSlat(double.Parse(lines[i + 20 + correctur], NumberFormatInfo.InvariantInfo) * 1000, double.Parse(lines[i + 22 + correctur], NumberFormatInfo.InvariantInfo) * 1000);
                            l.B = new Point();
                            l.B.longitude = Longitude2;
                            l.B.latitude = Latitude2;


                            Vector start = new Vector(Longitude1, Latitude1, 0);
                            Vector end = new Vector(Longitude2, Latitude2, 0);
                            Vector o = Vector.Middle(start, end) - Vector.Orthogonal(end - start);
                            l.O = o.toGPSPoint();
                            l.Type = (int)LineType.LINEOFNORETURN;
                            result.Line.Add(l);
                        }
                    }
                }
            }
            return result;
        }/// <summary> 
        /// Imports a DxfFile that is in the specified Format. Any changes on the import schema may cause Errors!
        /// </summary>
        /// <param name="filepath"></param>
        public static Parcour importFromDxfWGS(string filepath)
        {
            Parcour result = new Parcour();

            StreamReader sr = new StreamReader(filepath);
            List<string> Line = new List<string>();
            while (!sr.EndOfStream)
            {
                Line.Add(sr.ReadLine());
            }
            string[] lines = Line.ToArray();
            for (int i = 1; i < lines.Length; i++) //Looping through Array, starting with 1 (lines[0] is "0")
            {
                //Find Lines Containing a new Element Definition
                if (lines[i] == "LWPOLYLINE" && lines[i - 1] == "  0") //
                {
                    //Reading out Layer ( "8" [\n] layerName) = Type of Element
                    if (lines[i + 5] == "  8" && lines[i + 6].Contains("PROH")) // "Prohibited Zone" = ForbiddenZone
                    {
                        if (lines[i + 9 + 4] == " 90" || lines[i + 9] == " 90")
                        {
                            int correctur = lines[i + 9 + 4] == " 90" ? 4 : 0;
                            int numberOfVertexes = int.Parse(lines[i + 10 + correctur]);
                            List<Vector> input = new List<Vector>();
                            for (int j = 0; j < numberOfVertexes; j++)
                            {

                                double Longitude = double.Parse(lines[i + (j * 4) + 18 + correctur], NumberFormatInfo.InvariantInfo);
                                double Latitude = double.Parse(lines[i + (j * 4) + 16 + correctur], NumberFormatInfo.InvariantInfo);
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
                                        l.A = a.toGPSPoint();
                                        l.B = b.toGPSPoint();
                                        l.O = o.toGPSPoint();
                                        result.Line.Add(l);
                                    }
                                }
                            }
                        }
                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("STARTPOINT-"))
                    {
                        double[] res = new double[4];
                        res[3] = 0.0f;
                        int resCount = 0;
                        for (int j = 0; resCount < 4; j++)
                        {
                            try
                            {
                                double parsed = double.Parse(lines[i + 6 + 8 + j], NumberFormatInfo.InvariantInfo);
                                int dummy;
                                if (parsed != 0.0f && !Int32.TryParse(lines[i + 6 + 8 + j], out dummy))
                                {
                                    res[resCount++] = parsed;
                                }
                            }
                            catch { }
                        }

                        Line l = new Line();
                        double Longitude1 = res[1];
                        double Latitude1 = res[0];
                        l.A = new Point();
                        l.A.longitude = Longitude1;
                        l.A.latitude = Latitude1;

                        double Longitude2 = res[3];
                        double Latitude2 = res[2];
                        l.B = new Point();
                        l.B.longitude = Longitude2;
                        l.B.latitude = Latitude2;

                        Vector start = new Vector(Longitude1, Latitude1, 0);
                        Vector end = new Vector(Longitude2, Latitude2, 0);
                        Vector o = Vector.Middle(start, end) - Vector.Orthogonal(end - start);
                        l.O = o.toGPSPoint();

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
                        result.Line.Add(l);
                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("ENDPOINT-"))
                    {
                        double[] res = new double[4];
                        res[3] = 0.0f;
                        int resCount = 0;
                        for (int j = 0; resCount < 4; j++)
                        {
                            try
                            {
                                double parsed = double.Parse(lines[i + 6 + 8 + j], NumberFormatInfo.InvariantInfo);
                                int dummy;
                                if (parsed != 0.0f && !Int32.TryParse(lines[i + 6 + 8 + j], out dummy))
                                {
                                    res[resCount++] = parsed;
                                }
                            }
                            catch { }
                        }

                        Line l = new Line();
                        double Longitude1 = res[1];
                        double Latitude1 = res[0];
                        l.A = new Point();
                        l.A.longitude = Longitude1;
                        l.A.latitude = Latitude1;

                        double Longitude2 = res[3];
                        double Latitude2 = res[2];
                        l.B = new Point();
                        l.B.longitude = Longitude2;
                        l.B.latitude = Latitude2;

                        Vector start = new Vector(Longitude1, Latitude1, 0);
                        Vector end = new Vector(Longitude2, Latitude2, 0);
                        Vector o = Vector.Middle(start, end) - Vector.Orthogonal(end - start);
                        l.O = o.toGPSPoint();

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
                        result.Line.Add(l);

                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("NBLINE"))
                    {
                        if ((lines[i + 9 + 4] == " 90" || lines[i + 9] == " 90") && double.Parse(lines[10], NumberFormatInfo.InvariantInfo) == 2)
                        {
                            int correctur = lines[i + 9 + 4] == " 90" ? 4 : 0;
                            Line l = new Line();
                            double Longitude1 = double.Parse(lines[i + 18 + correctur], NumberFormatInfo.InvariantInfo);
                            double Latitude1 = double.Parse(lines[i + 16 + correctur], NumberFormatInfo.InvariantInfo);
                            l.A = new Point();
                            l.A.longitude = Longitude1;
                            l.A.latitude = Latitude1;

                            double Longitude2 = double.Parse(lines[i + 22 + correctur], NumberFormatInfo.InvariantInfo);
                            double Latitude2 = double.Parse(lines[i + 20 + correctur], NumberFormatInfo.InvariantInfo);
                            l.B = new Point();
                            l.B.longitude = Longitude2;
                            l.B.latitude = Latitude2;

                            Vector start = new Vector(Longitude1, Latitude1, 0);
                            Vector end = new Vector(Longitude2, Latitude2, 0);
                            Vector o = Vector.Middle(start, end) - Vector.Orthogonal(end - start);
                            l.O = o.toGPSPoint();
                            l.Type = (int)LineType.LINEOFNORETURN;
                            result.Line.Add(l);
                        }
                    }
                }
            }
            return result;
        }
        /// <summary> 
        /// Imports a DxfFile that is in the specified Format. Any changes on the import schema may cause Errors!
        /// </summary>
        /// <param name="filepath"></param>
        public static Parcour importFromDxfWGSSwitched(string filepath)
        {
            Parcour result = new Parcour();

            StreamReader sr = new StreamReader(filepath);
            List<string> Line = new List<string>();
            while (!sr.EndOfStream)
            {
                Line.Add(sr.ReadLine());
            }
            string[] lines = Line.ToArray();
            for (int i = 1; i < lines.Length; i++) //Looping through Array, starting with 1 (lines[0] is "0")
            {
                //Find Lines Containing a new Element Definition
                if (lines[i] == "LWPOLYLINE" && lines[i - 1] == "  0") //
                {
                    //Reading out Layer ( "8" [\n] layerName) = Type of Element
                    if (lines[i + 5] == "  8" && lines[i + 6].Contains("PROH")) // "Prohibited Zone" = ForbiddenZone
                    {
                        if (lines[i + 9 + 4] == " 90" || lines[i + 9] == " 90")
                        {
                            int correctur = lines[i + 9 + 4] == " 90" ? 4 : 0;
                            int numberOfVertexes = int.Parse(lines[i + 10 + correctur]);
                            List<Vector> input = new List<Vector>();
                            for (int j = 0; j < numberOfVertexes; j++)
                            {

                                double Latitude = double.Parse(lines[i + (j * 4) + 18 + correctur], NumberFormatInfo.InvariantInfo);
                                double Longitude = double.Parse(lines[i + (j * 4) + 16 + correctur], NumberFormatInfo.InvariantInfo);
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
                                        l.A = a.toGPSPoint();
                                        l.B = b.toGPSPoint();
                                        l.O = o.toGPSPoint();
                                        result.Line.Add(l);
                                    }
                                }
                            }
                        }
                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("STARTPOINT-"))
                    {
                        double[] res = new double[4];
                        res[3] = 0.0f;
                        int resCount = 0;
                        for (int j = 0; resCount < 4; j++)
                        {
                            try
                            {
                                double parsed = double.Parse(lines[i + 6 + 8 + j], NumberFormatInfo.InvariantInfo);
                                int dummy;
                                if (parsed != 0.0f && !Int32.TryParse(lines[i + 6 + 8 + j], out dummy))
                                {
                                    res[resCount++] = parsed;
                                }
                            }
                            catch { }
                        }

                        Line l = new Line();
                        double Latitude1 = res[1];
                        double Longitude1 = res[0];
                        l.A = new Point();
                        l.A.longitude = Longitude1;
                        l.A.latitude = Latitude1;

                        double Latitude2 = res[3];
                        double Longitude2 = res[2];
                        l.B = new Point();
                        l.B.longitude = Longitude2;
                        l.B.latitude = Latitude2;

                        Vector start = new Vector(Longitude1, Latitude1, 0);
                        Vector end = new Vector(Longitude2, Latitude2, 0);
                        Vector o = Vector.Middle(start, end) - Vector.Orthogonal(end - start);
                        l.O = o.toGPSPoint();

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
                        result.Line.Add(l);
                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("ENDPOINT-"))
                    {
                        double[] res = new double[4];
                        res[3] = 0.0f;
                        int resCount = 0;
                        for (int j = 0; resCount < 4; j++)
                        {
                            try
                            {
                                double parsed = double.Parse(lines[i + 6 + 8 + j], NumberFormatInfo.InvariantInfo);
                                int dummy;
                                if (parsed != 0.0f && !Int32.TryParse(lines[i + 6 + 8 + j], out dummy))
                                {
                                    res[resCount++] = parsed;
                                }
                            }
                            catch { }
                        }

                        Line l = new Line();
                        double Latitude1 = res[1];
                        double Longitude1 = res[0];
                        l.A = new Point();
                        l.A.longitude = Longitude1;
                        l.A.latitude = Latitude1;

                        double Latitude2 = res[3];
                        double Longitude2 = res[2];
                        l.B = new Point();
                        l.B.longitude = Longitude2;
                        l.B.latitude = Latitude2;

                        Vector start = new Vector(Longitude1, Latitude1, 0);
                        Vector end = new Vector(Longitude2, Latitude2, 0);
                        Vector o = Vector.Middle(start, end) - Vector.Orthogonal(end - start);
                        l.O = o.toGPSPoint();

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
                        result.Line.Add(l);

                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("NBLINE"))
                    {
                        if ((lines[i + 9 + 4] == " 90" || lines[i + 9] == " 90") && double.Parse(lines[10], NumberFormatInfo.InvariantInfo) == 2)
                        {
                            int correctur = lines[i + 9 + 4] == " 90" ? 4 : 0;
                            Line l = new Line();
                            double Latitude1 = double.Parse(lines[i + 18 + correctur], NumberFormatInfo.InvariantInfo);
                            double Longitude1 = double.Parse(lines[i + 16 + correctur], NumberFormatInfo.InvariantInfo);
                            l.A = new Point();
                            l.A.longitude = Longitude1;
                            l.A.latitude = Latitude1;

                            double Latitude2 = double.Parse(lines[i + 22 + correctur], NumberFormatInfo.InvariantInfo);
                            double Longitude2 = double.Parse(lines[i + 20 + correctur], NumberFormatInfo.InvariantInfo);
                            l.B = new Point();
                            l.B.longitude = Longitude2;
                            l.B.latitude = Latitude2;

                            Vector start = new Vector(Longitude1, Latitude1, 0);
                            Vector end = new Vector(Longitude2, Latitude2, 0);
                            Vector o = Vector.Middle(start, end) - Vector.Orthogonal(end - start);
                            l.O = o.toGPSPoint();
                            l.Type = (int)LineType.LINEOFNORETURN;
                            result.Line.Add(l);
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Imports a GAC File of a Flight.
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns>The created Flight object</returns>
        public static List<Point> GPSdataFromGAC(int year, int month, int day, string filename)
        {
            List<Point> result = new List<Point>();
            StreamReader gacFileStreamReader = new StreamReader(filename);
            string line = string.Empty;
            line = gacFileStreamReader.ReadLine();
            while (!line.Substring(0, 1).Equals("I") && !gacFileStreamReader.EndOfStream)
            {
                line = gacFileStreamReader.ReadLine();
            }
            {
                while (!gacFileStreamReader.EndOfStream)
                {
                    line = gacFileStreamReader.ReadLine();
                    if (line.Substring(0, 1).Equals("B"))
                    {
                        //B082337 4758489N 008 30 945 E A99999 0224901011680001
                        //B1601114816962N00700724EA003100037007532330012
                        // timestamp
                        DateTime newPointTimeStamp = new DateTime(year, month, day, Convert.ToInt32(line.Substring(1, 2)), Convert.ToInt32(line.Substring(3, 2)), Convert.ToInt32(line.Substring(5, 2)));
                        // latitude
                        double newPointLatitude = Convert.ToDouble(line.Substring(7, 2)) + Convert.ToDouble(line.Substring(9, 2) + "." + line.Substring(11, 3)) / 60;
                        switch (line.Substring(14, 1))
                        {
                            case "N":
                                break;
                            case "S":
                                newPointLatitude *= (-1);
                                break;
                            default:
                                // TODO: Error
                                break;
                        }
                        // longitude
                        double newPointLongitude = Convert.ToDouble(line.Substring(15, 3)) + Convert.ToDouble(line.Substring(18, 2) + "." + line.Substring(20, 3)) / 60;
                        switch (line.Substring(23, 1))
                        {
                            case "E":
                                break;
                            case "W":
                                newPointLongitude *= (-1);
                                break;
                            default:
                                // ToDo: Error
                                break;
                        }
                        double altitude = double.Parse(line.Substring(30, 5), NumberFormatInfo.InvariantInfo) * 0.3048f; //Feet to Meter
                        double speed = (double.Parse(line.Substring(35, 4), NumberFormatInfo.InvariantInfo) / 10) / 0.514444444f; //Knot to m/s
                        double bearing = double.Parse(line.Substring(39, 3), NumberFormatInfo.InvariantInfo);
                        double acc = double.Parse(line.Substring(42, 4), NumberFormatInfo.InvariantInfo);

                        Point data = new Point();
                        data.Timestamp = newPointTimeStamp.Ticks;
                        data.latitude = newPointLatitude;
                        data.longitude = newPointLongitude;
                        data.altitude = altitude;
                        result.Add(data);
                    }
                }
            }
            return result;
        }

        internal static List<Point> GPSdataFromGPX(string filename)
        {
            List<Point> result = new List<Point>();
            XNamespace gpx = XNamespace.Get("http://www.topografix.com/GPX/1/1");
            XDocument gpxDoc = XDocument.Load(filename);
            var tracks = from track in gpxDoc.Descendants(gpx + "trk")
                         select new
                         {
                             Name = track.Element(gpx + "name") != null ?
                                 track.Element(gpx + "name").Value : null,
                             Segs = (
                                  from trackpoint in track.Descendants(gpx + "trkpt")
                                  select new
                                  {
                                      Latitude = trackpoint.Attribute("lat").Value,
                                      Longitude = trackpoint.Attribute("lon").Value,
                                      Elevation = trackpoint.Element(gpx + "ele") != null ?
                                        trackpoint.Element(gpx + "ele").Value : null,
                                      Time = trackpoint.Element(gpx + "time") != null ?
                                        trackpoint.Element(gpx + "time").Value : null
                                  }
                                )
                         };
            foreach (var trk in tracks)
            {
                foreach (var trkSeg in trk.Segs)
                {
                    Point data = new Point();
                    data.Timestamp = DateTime.Parse(trkSeg.Time).Ticks;
                    data.latitude = Double.Parse(trkSeg.Latitude, NumberFormatInfo.InvariantInfo);
                    data.longitude = Double.Parse(trkSeg.Longitude, NumberFormatInfo.InvariantInfo);
                    data.altitude = Double.Parse(trkSeg.Elevation, NumberFormatInfo.InvariantInfo);
                    result.Add(data);
                }
            }
            return result;
        }
    }
}
