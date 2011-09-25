using System;
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
        public static AirNavigationRaceLive.Comps.Model.Parcour importFromDxfCH(string filepath)
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
                        if (lines[i + 9 + 4] == " 90" || lines[i + 9] == " 90")
                        {
                            int correctur = lines[i + 9 + 4] == " 90" ? 4 : 0;
                            int numberOfVertexes = int.Parse(lines[i + 10 + correctur]);
                            List<Vector> input = new List<Vector>();
                            for (int j = 0; j < numberOfVertexes; j++)
                            {

                                double Longitude = Converter.CHtoWGSlng(double.Parse(lines[i + (j * 4) + 16 + correctur]) * 1000, double.Parse(lines[i + (j * 4) + 18 + correctur]) * 1000);
                                double Latitude = Converter.CHtoWGSlat(double.Parse(lines[i + (j * 4) + 16 + correctur]) * 1000, double.Parse(lines[i + (j * 4) + 18 + correctur]) * 1000);
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
                                        l.A = NetworkObjects.Helper.Point(a.X, a.Y, a.Z);
                                        l.B = NetworkObjects.Helper.Point(b.X, b.Y, b.Z);
                                        l.O = NetworkObjects.Helper.Point(o.X, o.Y, o.Z);
                                        result.LineList.Add(l);
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
                                double parsed = double.Parse(lines[i + 6 + 8 + j]);
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
                        l.A = NetworkObjects.Helper.Point(Longitude1, Latitude1, 0);

                        double Longitude2 = Converter.CHtoWGSlng(res[2] * 1000, res[3] * 1000);
                        double Latitude2 = Converter.CHtoWGSlat(res[2] * 1000, res[3] * 1000);
                        l.B = NetworkObjects.Helper.Point(Longitude2, Latitude2, 0);

                        Vector start = new Vector(Longitude1, Latitude1, 0);
                        Vector end = new Vector(Longitude2, Latitude2, 0);
                        Vector o = Vector.Middle(start, end) - Vector.Orthogonal(end - start);
                        l.O = NetworkObjects.Helper.Point(o.X, o.Y, o.Z);

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
                        result.LineList.Add(l);
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
                                double parsed = double.Parse(lines[i + 6 + 8 + j]);
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
                        l.A = NetworkObjects.Helper.Point(Longitude1, Latitude1, 0);

                        double Longitude2 = Converter.CHtoWGSlng(res[2] * 1000, res[3] * 1000);
                        double Latitude2 = Converter.CHtoWGSlat(res[2] * 1000, res[3] * 1000);
                        l.B = NetworkObjects.Helper.Point(Longitude2, Latitude2, 0);
                        Vector start = new Vector(Longitude1, Latitude1, 0);
                        Vector end = new Vector(Longitude2, Latitude2, 0);
                        Vector o = Vector.Middle(start, end) - Vector.Orthogonal(end - start);
                        l.O = NetworkObjects.Helper.Point(o.X, o.Y, o.Z);

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
                        result.LineList.Add(l);

                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("NBLINE"))
                    {
                        if ((lines[i + 9 + 4] == " 90" || lines[i + 9] == " 90") && double.Parse(lines[10]) == 2)
                        {
                            int correctur = lines[i + 9 + 4] == " 90" ? 4 : 0;
                            Line l = new Line();
                            double Longitude1 = Converter.CHtoWGSlng(double.Parse(lines[i + 16 + correctur]) * 1000, double.Parse(lines[i + 18 + correctur]) * 1000);
                            double Latitude1 = Converter.CHtoWGSlat(double.Parse(lines[i + 16 + correctur]) * 1000, double.Parse(lines[i + 18 + correctur]) * 1000);
                            l.A = NetworkObjects.Helper.Point(Longitude1, Latitude1, 0);

                            double Longitude2 = Converter.CHtoWGSlng(double.Parse(lines[i + 20 + correctur]) * 1000, double.Parse(lines[i + 22 + correctur]) * 1000);
                            double Latitude2 = Converter.CHtoWGSlat(double.Parse(lines[i + 20 + correctur]) * 1000, double.Parse(lines[i + 22 + correctur]) * 1000);
                            l.B = NetworkObjects.Helper.Point(Longitude2, Latitude2, 0);
                            Vector start = new Vector(Longitude1, Latitude1, 0);
                            Vector end = new Vector(Longitude2, Latitude2, 0);
                            Vector o = Vector.Middle(start, end) - Vector.Orthogonal(end - start);
                            l.O = NetworkObjects.Helper.Point(o.X, o.Y, o.Z);
                            l.Type = (int)LineType.LINEOFNORETURN;
                            result.LineList.Add(l);
                        }
                    }
                }
            }
            return result;
        }/// <summary> 
        /// Imports a DxfFile that is in the specified Format. Any changes on the import schema may cause Errors!
        /// </summary>
        /// <param name="filepath"></param>
        public static AirNavigationRaceLive.Comps.Model.Parcour importFromDxfWGS(string filepath)
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
                        if (lines[i + 9 + 4] == " 90" || lines[i + 9] == " 90")
                        {
                            int correctur = lines[i + 9 + 4] == " 90" ? 4 : 0;
                            int numberOfVertexes = int.Parse(lines[i + 10 + correctur]);
                            List<Vector> input = new List<Vector>();
                            for (int j = 0; j < numberOfVertexes; j++)
                            {

                                double Longitude = double.Parse(lines[i + (j * 4) + 18 + correctur]);
                                double Latitude =double.Parse(lines[i + (j * 4) + 16 + correctur]);
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
                                        l.A = NetworkObjects.Helper.Point(a.X, a.Y, a.Z);
                                        l.B = NetworkObjects.Helper.Point(b.X, b.Y, b.Z);
                                        l.O = NetworkObjects.Helper.Point(o.X, o.Y, o.Z);
                                        result.LineList.Add(l);
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
                                double parsed = double.Parse(lines[i + 6 + 8 + j]);
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
                        l.A = NetworkObjects.Helper.Point(Longitude1, Latitude1, 0);

                        double Longitude2 = res[3];
                        double Latitude2 = res[2];
                        l.B = NetworkObjects.Helper.Point(Longitude2, Latitude2, 0);

                        Vector start = new Vector(Longitude1, Latitude1, 0);
                        Vector end = new Vector(Longitude2, Latitude2, 0);
                        Vector o = Vector.Middle(start, end) - Vector.Orthogonal(end - start);
                        l.O = NetworkObjects.Helper.Point(o.X, o.Y, o.Z);

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
                        result.LineList.Add(l);
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
                                double parsed = double.Parse(lines[i + 6 + 8 + j]);
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
                        l.A = NetworkObjects.Helper.Point(Longitude1, Latitude1, 0);

                        double Longitude2 = res[3];
                        double Latitude2 = res[2];
                        l.B = NetworkObjects.Helper.Point(Longitude2, Latitude2, 0);
                        Vector start = new Vector(Longitude1, Latitude1, 0);
                        Vector end = new Vector(Longitude2, Latitude2, 0);
                        Vector o = Vector.Middle(start, end) - Vector.Orthogonal(end - start);
                        l.O = NetworkObjects.Helper.Point(o.X, o.Y, o.Z);

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
                        result.LineList.Add(l);

                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("NBLINE"))
                    {
                        if ((lines[i + 9 + 4] == " 90" || lines[i + 9] == " 90") && double.Parse(lines[10]) == 2)
                        {
                            int correctur = lines[i + 9 + 4] == " 90" ? 4 : 0;
                            Line l = new Line();
                            double Longitude1 =double.Parse(lines[i + 18 + correctur]);
                            double Latitude1 =double.Parse(lines[i + 16 + correctur]);
                            l.A = NetworkObjects.Helper.Point(Longitude1, Latitude1, 0);

                            double Longitude2 =double.Parse(lines[i + 22 + correctur]) ;
                            double Latitude2 = double.Parse(lines[i + 20 + correctur]);
                            l.B = NetworkObjects.Helper.Point(Longitude2, Latitude2, 0);
                            Vector start = new Vector(Longitude1, Latitude1, 0);
                            Vector end = new Vector(Longitude2, Latitude2, 0);
                            Vector o = Vector.Middle(start, end) - Vector.Orthogonal(end - start);
                            l.O = NetworkObjects.Helper.Point(o.X, o.Y, o.Z);
                            l.Type = (int)LineType.LINEOFNORETURN;
                            result.LineList.Add(l);
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
        public static List<GPSData> GPSdataFromGAC(int year, int month, int day, string IdentifierTracker, string filename)
        {
            List<GPSData> result = new List<GPSData>();
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
                        // timestamp
                        DateTime newPointTimeStamp = new DateTime(year, month, day, Convert.ToInt32(line.Substring(1, 2)), Convert.ToInt32(line.Substring(3, 2)), Convert.ToInt32(line.Substring(5, 2)));
                        // latitude
                        double newPointLatitude = Convert.ToDouble(line.Substring(7, 2)) * 3600 + Convert.ToDouble(line.Substring(9, 2)) * 60 + Convert.ToDouble(line.Substring(11, 3)) * 60 / 1000;
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
                        double newPointLongitude = Convert.ToDouble(line.Substring(15, 3)) * 3600 + Convert.ToDouble(line.Substring(18, 2)) * 60 + Convert.ToDouble(line.Substring(20, 3)) * 60 / 1000;
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
                        double altitude = double.Parse(line.Substring(30, 5)) * 0.3048f; //Feet to Meter
                        double speed = (double.Parse(line.Substring(35, 4)) * 10) / 0.514444444f; //Knot to m/s
                        double bearing = double.Parse(line.Substring(39,3));
                        double acc = double.Parse(line.Substring(42,4));

                        GPSData data = new GPSData();
                        data.timestampGPS = newPointTimeStamp.Ticks;
                        data.latitude = newPointLatitude;
                        data.longitude = newPointLongitude;
                        data.altitude = altitude;
                        data.speed = speed;
                        data.bearing = bearing;
                        data.accuracy = acc;
                        data.identifier = IdentifierTracker;
                        data.timestampSender = new DateTime().Ticks;
                        result.Add(data);
                    }
                }
            }
            return result;
        }
    }
}
