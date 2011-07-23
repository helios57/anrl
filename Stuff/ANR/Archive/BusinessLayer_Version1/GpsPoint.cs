///////////////////////////////////////////////////////////
//  GpsPoint.cs
//  Implementation of the Class GpsPoint
//  Created on:      15-Apr-2008 21:38:40
///////////////////////////////////////////////////////////




using System;
namespace PFA.ANR.BusinessLayer
{
    #region enums
    public enum GpsPointComponent
    {
        Latitude,
        Longitude
    }

    public enum GpsPointFormatString
    {
        Degrees,
        DegreesAndMinutes,
        DegreesDecimal,
        DegreesOnly,
        MinutesOnly,
        Swiss
    }

    public enum GpsPointFormatImport
    {
        WGS84,
        Swiss
    }
    #endregion enums

    [Serializable]
    public class GpsPoint
    {
        #region private fields
        private double latitude;
		private double longitude;

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
        #endregion private fields

        public GpsPoint(double latitude, double longitude, GpsPointFormatImport format)
        {
            switch (format)
            {
                case GpsPointFormatImport.WGS84:
                    this.Latitude = latitude;
                    this.Longitude = longitude;
                    break;
                case GpsPointFormatImport.Swiss:
                    this.Longitude = longitudeChToWgs84(longitude, latitude);
                    this.Latitude = latitudeChToWgs84(longitude, latitude);
                    break;
                default:
                    this.Latitude = latitude;
                    this.Longitude = longitude;
                    break;
            }
        }

        #region properties
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
                return latitudeWgs84ToCh(longitude, latitude);
            }
        }

        private double LongitudeCh
        {
            get
            {
                return longitudeWgs84ToCh(longitude, latitude);
            }
        }
        #endregion properties

        #region methods
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
            switch (format)
            {
                case GpsPointFormatString.Degrees:
                    degrees = component/3600;
                    minutes = (degrees - Math.Floor(degrees)) * 60;
                    seconds = (minutes - Math.Floor(minutes)) * 60;
                    return sign + Math.Floor(degrees).ToString() + "°" + Math.Floor(minutes).ToString() + "'" + Math.Round(seconds, 2).ToString() + "\"";
                case GpsPointFormatString.DegreesAndMinutes:
                    degrees = component / 3600;
                    minutes = (degrees - Math.Floor(degrees)) * 60;
                    return sign + Math.Floor(degrees).ToString() + "°" + Math.Round(minutes, 2).ToString() + "\"";
                case GpsPointFormatString.DegreesDecimal:
                    return sign + (component / 3600).ToString();
                case GpsPointFormatString.DegreesOnly:
                    degrees = component / 3600;
                    return sign + Math.Floor(degrees).ToString();
                case GpsPointFormatString.MinutesOnly:
                    degrees = component / 3600;
                    minutes = Math.Round((degrees - Math.Floor(degrees)) * 60, 4);
                    return sign + minutes.ToString();
                case GpsPointFormatString.Swiss:
                    return sign + componentCh.ToString();
                default:
                    return sign + component.ToString();
            }
        }

        private static double longitudeChToWgs84(double y, double x)
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

        private static double latitudeChToWgs84(double y, double x)
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

        private static double longitudeWgs84ToCh(double lambda, double phi)
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

        private static double latitudeWgs84ToCh(double lambda, double phi)
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
        #endregion methods
    }//end GpsPoint

}//end namespace PFA.ANR.BusinessLayer