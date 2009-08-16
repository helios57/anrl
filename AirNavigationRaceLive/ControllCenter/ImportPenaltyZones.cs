using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using DataService;

namespace ControllCenter
{
    static class ImportPenaltyZones
    {

        /// <summary> 
        /// Imports a DxfFile that is in the specified Format. Any changes on the import schema may cause Errors!
        /// </summary>
        /// <param name="filepath"></param>
        static public void importFromDxf(string filepath, string DB_PATH)
        {

            StreamReader sr = new StreamReader(filepath);
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            foreach (t_PolygonPoint tp in dataContext.t_PolygonPoints)
            {
                dataContext.t_PolygonPoints.DeleteOnSubmit(tp);
            }
           ///dataContext.t_PolygonPoints.DeleteAllOnSubmit(dataContext.t_PolygonPoints.ToList());
            dataContext.SubmitChanges();
            dataContext.t_Polygons.DeleteAllOnSubmit(dataContext.t_Polygons);
            dataContext.SubmitChanges();
            int id = 1;

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
                            t_Polygon p = new t_Polygon();
                            p.ID = id++;

                            for (int j = 0; j < numberOfVertexes; j++)
                            {
                                t_PolygonPoint point = new t_PolygonPoint();
                                GpsPoint gp = new GpsPoint(double.Parse(lines[i + (j * 4) + 18]) * 1000, double.Parse(lines[i + (j * 4) + 16]) * 1000, GpsPointFormatImport.Swiss);
                                point.longitude = (decimal)gp.Longitude;
                                point.latitude = (decimal)gp.Latitude;
                                point.ID_Polygon = p.ID;
                                dataContext.t_PolygonPoints.InsertOnSubmit(point);
                            }
                            dataContext.t_Polygons.InsertOnSubmit(p);
                        }
                    }
                }
            }

            dataContext.SubmitChanges();
        }

        #region Enums
        public enum GpsPointComponent
        {
            Latitude,
            Longitude
        }

        public enum GpsPointFormatString
        {
            CleanWGS84String,
            DegreesOnly,
            MinutesOnly,
            SecondsOnly,
            Swiss
        }

        public enum GpsPointFormatImport
        {
            WGS84,
            Swiss
        }
        #endregion Enums
        [Serializable]
        public class GpsPoint
        {
            #region Private Members
            private double latitude;
            private double longitude;

            #region Const Members
            private const double phiSubtrahend = 169028.66;
            private const double lambdaSubtrahend = 26782.5;
            private const double dividendToCh = 10000;
            private const double yFactor1 = 600072.37;
            private const double yFactor2 = 211455.93;
            private const double yFactor3 = -10938.51;
            private const double yFactor4 = -0.36;
            private const double yFactor5 = -44.54;
            private const double xFactor1 = 200147.07;
            private const double xFactor2 = 308807.95;
            private const double xFactor3 = 3745.25;
            private const double xFactor4 = 76.63;
            private const double xFactor5 = -194.56;
            private const double xFactor6 = 119.79;

            private const double ySubtrahend = 600000;
            private const double xSubtrahend = 200000;
            private const double dividendToWgs84 = 1000000;
            private const double lambdaFactor1 = 2.6779094;
            private const double lambdaFactor2 = 4.728982;
            private const double lambdaFactor3 = 0.791484;
            private const double lambdaFactor4 = 0.1306;
            private const double lambdaFactor5 = -0.0436;
            private const double phiFactor1 = 16.9023892;
            private const double phiFactor2 = 3.238272;
            private const double phiFactor3 = -0.270978;
            private const double phiFactor4 = -0.002528;
            private const double phiFactor5 = -0.0447;
            private const double phiFactor6 = -0.014;
            #endregion Const Members
            #endregion Private Members

            #region Constructors
            GpsPoint()
                : base()
            {
            }

            public GpsPoint(double latitude, double longitude, GpsPointFormatImport format)
                : base()
            {
                switch (format)
                {
                    case GpsPointFormatImport.WGS84:
                        this.Latitude = latitude;
                        this.Longitude = longitude;
                        break;
                    case GpsPointFormatImport.Swiss:
                        this.Longitude = CHtoWGSlng(longitude, latitude);
                        this.Latitude = CHtoWGSlat(longitude, latitude);
                        break;
                    default:
                        this.Latitude = latitude;
                        this.Longitude = longitude;
                        break;
                }
            }
            #endregion Constructors

            #region Public Properties
            public double Latitude
            {
                get
                {
                    return latitude;
                }
                set
                {
                    latitude = (double)value;

                }
            }

            public double Longitude
            {
                get
                {
                    return longitude;
                }
                set
                {
                    longitude = (double)value;
                }
            }

            private double LatitudeCh
            {
                get
                {
                    return LatitudeWgs84ToCh(longitude, latitude);
                }
            }

            private double LongitudeCh
            {
                get
                {
                    return LongitudeWgs84ToCh(longitude, latitude);
                }
            }
            #endregion Public Properties

            public string ToString(GpsPointFormatString format, GpsPointComponent gpsPointComponent)
            {
                double component;
                double componentCh;
                double degrees;
                double minutes;
                double seconds;
                string sign = string.Empty;

                switch (gpsPointComponent)
                {
                    case GpsPointComponent.Latitude:
                        component = Latitude;
                        componentCh = LatitudeCh;
                        break;
                    default:
                        component = Longitude;
                        componentCh = LongitudeCh;
                        break;
                }
                if (component < 0)
                {
                    component *= (-1);
                    sign = "-";
                }

                degrees = Math.Floor(component / 3600);
                minutes = Math.Floor((component - degrees * 3600) / 60);
                seconds = Math.Floor((component - degrees * 3600 - minutes * 60));

                switch (format)
                {
                    case GpsPointFormatString.CleanWGS84String:
                        return sign + degrees.ToString() + "°" + minutes.ToString() + "'" + seconds.ToString() + "\"";
                    case GpsPointFormatString.DegreesOnly:
                        return sign + degrees.ToString();
                    case GpsPointFormatString.MinutesOnly:
                        return sign + minutes.ToString();
                    case GpsPointFormatString.SecondsOnly:
                        return sign + seconds.ToString();
                    case GpsPointFormatString.Swiss:
                        return sign + componentCh.ToString();
                    default:
                        return sign + component.ToString();
                }
            }

            // Convert CH y/x to WGS lat
            private static double CHtoWGSlat(double y, double x)
            {
                // Converts militar to civil and  to unit = 1000km
                // Axiliary values (% Bern)
                double y_aux = (y - 600000) / 1000000;
                double x_aux = (x - 200000) / 1000000;

                // Process lat
                double lat = 16.9023892
                    + 3.238272 * x_aux
                    - 0.270978 * Math.Pow(y_aux, 2)
                    - 0.002528 * Math.Pow(x_aux, 2)
                    - 0.0447 * Math.Pow(y_aux, 2) * x_aux
                    - 0.0140 * Math.Pow(x_aux, 3);

                // Unit 10000" to 1 " and converts seconds to degrees (dec)
                lat = lat * 100 / 36;

                return lat;
            }

            // Convert CH y/x to WGS long
            private static double CHtoWGSlng(double y, double x)
            {
                // Converts militar to civil and  to unit = 1000km
                // Axiliary values (% Bern)
                double y_aux = (y - 600000) / 1000000;
                double x_aux = (x - 200000) / 1000000;

                // Process long
                double lng = 2.6779094
                    + 4.728982 * y_aux
                    + 0.791484 * y_aux * x_aux
                    + 0.1306 * y_aux * Math.Pow(x_aux, 2)
                    - 0.0436 * Math.Pow(y_aux, 3);

                // Unit 10000" to 1 " and converts seconds to degrees (dec)
                lng = lng * 100 / 36;

                return lng;
            }

            static public double LongitudeChToWgs84(double y, double x)
            {
                double lambda;
                double y2 = (y - ySubtrahend) / dividendToWgs84;
                double x2 = (x - xSubtrahend) / dividendToWgs84;

                lambda = lambdaFactor1;
                lambda += lambdaFactor2 * y2;
                lambda += lambdaFactor3 * y2 * x2;
                lambda += lambdaFactor4 * y2 * Math.Pow(x2, 2);
                lambda += lambdaFactor5 * Math.Pow(y2, 3);
                lambda *= 10000;
                return lambda;
            }

            static public double LatitudeChToWgs84(double y, double x)
            {
                double phi;
                double y2 = (y - ySubtrahend) / dividendToWgs84;
                double x2 = (x - xSubtrahend) / dividendToWgs84;

                phi = phiFactor1;
                phi += phiFactor2 * x2;
                phi += phiFactor3 * Math.Pow(y2, 2);
                phi += phiFactor4 * Math.Pow(x2, 2);
                phi += phiFactor5 * Math.Pow(y2, 2) * x2;
                phi += phiFactor6 * Math.Pow(x2, 3);
                phi *= 10000;
                return phi;
            }

            static public double LongitudeWgs84ToCh(double lambda, double phi)
            {
                double y;
                double lambda2 = (lambda - lambdaSubtrahend) / dividendToCh;
                double phi2 = (phi - phiSubtrahend) / dividendToCh;

                y = yFactor1;
                y += yFactor2 * lambda2;
                y += yFactor3 * lambda2 * phi2;
                y += yFactor4 * lambda2 * Math.Pow(phi2, 2);
                y += yFactor5 * Math.Pow(lambda2, 3);
                return y;
            }

            static public double LatitudeWgs84ToCh(double lambda, double phi)
            {
                double x;
                double lambda2 = (lambda - lambdaSubtrahend) / dividendToCh;
                double phi2 = (phi - phiSubtrahend) / dividendToCh;

                x = xFactor1;
                x += xFactor2 * phi2;
                x += xFactor3 * Math.Pow(lambda2, 2);
                x += xFactor4 * Math.Pow(phi2, 2);
                x += xFactor5 * Math.Pow(lambda2, 2) * phi2;
                x += xFactor6 * Math.Pow(phi2, 3);
                return x;
            }
        }
    }
}
