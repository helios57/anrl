///////////////////////////////////////////////////////////
//  Map.cs
//  Implementation of the Class Map
//  Created on:      15-Apr-2008 21:38:40
///////////////////////////////////////////////////////////


using System.Drawing;
using System;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace PFA.ANR.BusinessLayer
{
    [Serializable]
	public class Map
    {
        private Guid mapId;
        public Guid MapId
        {
            get { return mapId; }
            set { mapId = value; }
        }

		private GpsPoint bottomRightPoint;
        private GpsPoint topLeftPoint;
        private Image image;

                
        #region constructors
		public Map()
            : base()
        {
		}
        /// <summary>
        /// Creates a Map Object. 
        /// 
        /// </summary>
        /// <param name="image">Bitmap Image of the Location, corresponding to the GPS-Points</param>
        /// <param name="topLeftPoint">GPS Point with the Coordinates of the upper Left Point on the Map Image</param>
        /// <param name="bottomRightPoint">GPS Point with the Coordinates of the lower Right Point on the Map Image</param>
        public Map(Bitmap image, GpsPoint topLeftPoint, GpsPoint bottomRightPoint)
        {
            this.Image = image;
            this.TopLeftPoint = topLeftPoint;
            this.BottomRightPoint = bottomRightPoint;
        }
        #endregion constructors

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
        public void AddMapImage(string filename)
        {
            this.image = System.Drawing.Image.FromFile(filename);

            string name = filename.Substring(filename.Length - 31, 31);

            int t1 = int.Parse(name.Substring(0, 6));
            int t2 = int.Parse(name.Substring(7, 6));
            int b1 = int.Parse(name.Substring(14, 6));
            int b2 = int.Parse(name.Substring(21, 6));

            this.topLeftPoint = new GpsPoint(t2, t1, GpsPointFormatImport.Swiss);
            this.bottomRightPoint = new GpsPoint(b2, b1, GpsPointFormatImport.Swiss);

        }

 
	}//end Map

}//end namespace PFA.ANR.BusinessLayer