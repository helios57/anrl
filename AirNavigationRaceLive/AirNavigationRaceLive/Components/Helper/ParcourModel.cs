using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;

namespace AirNavigationRaceLive.Components.Helper
{
    public class ParcourModel
    {
        Vector LineOfNoReturnStart;
        Vector LineOfNoReturnEnd;

        public ParcourModel(IParcour parcour, Converter c)
        {
            List<ILine> lines = parcour.Lines;
            AddLineAsChannel(c, lines.Single(p => p.LineType == LineType.START_A), lines.Single(p => p.LineType == LineType.END_A));
            AddLineAsChannel(c, lines.Single(p => p.LineType == LineType.START_B), lines.Single(p => p.LineType == LineType.END_B));
            AddLineAsChannel(c, lines.Single(p => p.LineType == LineType.START_C), lines.Single(p => p.LineType == LineType.END_C));
            AddLineAsChannel(c, lines.Single(p => p.LineType == LineType.START_D), lines.Single(p => p.LineType == LineType.END_D));

            ILine lonr = lines.Single(p => p.LineType == LineType.LINEOFNORETURN);
            LineOfNoReturnStart = getVector(c, lonr.PointA);
            LineOfNoReturnEnd = getVector(c, lonr.PointA);
        }

        private void AddLineAsChannel(Converter c, ILine start, ILine end)
        {
            Vector MiddleStart = VectorUtil.getMiddle(getVector(c, start.PointA), getVector(c, start.PointB));
            Vector MiddleEnd = VectorUtil.getMiddle(getVector(c, end.PointA), getVector(c, end.PointB));
            Channels.Add(new ParcourChannel(MiddleStart, MiddleEnd));
        }

        private static Vector getVector(Converter c, IGPSPoint point)
        {

            Vector startA = new Vector(c.DegToX(point.Longitude), c.DegToY(point.Latitude), 0);
            return startA;
        }
        List<ParcourChannel> Channels = new List<ParcourChannel>();
        List<ParcourPolygon> Polygons = new List<ParcourPolygon>();
    }

    public class ParcourChannel
    {
        public ParcourChannel(Vector Start, Vector End)
        {
            this.Start = Start;
            this.End = End;
        }
        Vector Start;
        Vector End;
        Vector CutLONR;
        List<Vector> LinearCombinations = new List<Vector>();
    }
    public class ParcourPolygon
    {
        List<Vector> Edges = new List<Vector>();
    }
}
