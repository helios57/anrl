///////////////////////////////////////////////////////////
//  Map.cs
//  Implementation of the Class Map
//  Created on:      15-Apr-2008 21:38:40
///////////////////////////////////////////////////////////

using System.Drawing;
using System;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace ANR.Core
{
    [Serializable]
	public class Map : AnrObject
    {
        #region Private Members
        private GpsPoint bottomRightPoint;
        private GpsPoint topLeftPoint;
        private Image image;
        private string mapName;
        private ParcoursCollection parcoursCollection;
        private Competition parentCompetition;

        #endregion Private Members

        #region Constructors
        public Map()
            : base()
        {
            this.parcoursCollection = new ParcoursCollection();
		}
        public Map(string filename, Competition parentCompetition)
            : base()
        {
            Bitmap image = new Bitmap(filename);
            GpsPoint topLeftPoint;
            GpsPoint bottomRightPoint;
            double topLeftLatitude;
            double topLeftLongitude;
            double bottomRightLatitude;
            double bottomRightLongitude;
            string[] coordinatesFromPath = filename.Remove(filename.LastIndexOf(".")).Substring(filename.LastIndexOf(@"\") + 1).Split("_".ToCharArray());
            foreach (string coordinate in coordinatesFromPath)
            {
                if (coordinate.Length != 6 || coordinate == null || coordinate == string.Empty)
                {
                    throw (new FormatException("Coordinates in image name not in correct format!"));
                }
            }
            topLeftLongitude = Convert.ToDouble(coordinatesFromPath[0]);
            topLeftLatitude = Convert.ToDouble(coordinatesFromPath[1]);
            bottomRightLongitude = Convert.ToDouble(coordinatesFromPath[2]);
            bottomRightLatitude = Convert.ToDouble(coordinatesFromPath[3]);
            topLeftPoint = new GpsPoint(topLeftLatitude, topLeftLongitude, GpsPointFormatImport.Swiss);
            bottomRightPoint = new GpsPoint(bottomRightLatitude, bottomRightLongitude, GpsPointFormatImport.Swiss);

            this.image = image;
            this.mapName = filename;
            this.topLeftPoint = topLeftPoint;
            this.bottomRightPoint = bottomRightPoint;
            this.parcoursCollection = new ParcoursCollection();
            this.parentCompetition = parentCompetition;

        }
        /// <summary>
        /// Creates a Map Object. 
        /// 
        /// </summary>
        /// <param name="image">Bitmap Image of the Location, corresponding to the GPS-Points</param>
        /// <param name="topLeftPoint">GPS Point with the Coordinates of the upper Left Point on the Map Image</param>
        /// <param name="bottomRightPoint">GPS Point with the Coordinates of the lower Right Point on the Map Image</param>
        public Map(Bitmap image, GpsPoint topLeftPoint, GpsPoint bottomRightPoint, Competition parentCompetition)
        {
            this.Image = image;
            this.TopLeftPoint = topLeftPoint;
            this.BottomRightPoint = bottomRightPoint;
            this.parcoursCollection = new ParcoursCollection();
            this.parentCompetition = parentCompetition;
        }
        #endregion Constructors

       #region Public Properties
        public GpsPoint TopLeftPoint
        {
			get
            {
				return topLeftPoint;
			}
			set
            {
				topLeftPoint = value;
			}
		}

		public GpsPoint BottomRightPoint
        {
			get
            {
				return bottomRightPoint;
            }
            set
            {
                bottomRightPoint = value;
            }
		}

		public Image Image
        {
			get
            {
				return image;
			}
            set
            {
                image = value;
            }
        }
        public string MapName
        {
            get 
            { 
                return mapName; 
            }
            set 
            { 
                mapName = value; 
            }
        }
        public ParcoursCollection ParcoursCollection
        {
            get 
            { 
                return parcoursCollection; 
            }
            set 
            { 
                parcoursCollection = value; 
            }
        }

        public Competition ParentCompetition
        {
            get { return parentCompetition; }
            set { parentCompetition = value; }
        }
        #endregion Public Properties
    }
}