using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;
using System.Windows.Forms;

namespace AirNavigationRaceLive.Components.Helper
{
    public class ParcourModel
    {
        private List<ParcourChannel> Channels = new List<ParcourChannel>(4);
        private List<ParcourPolygon> Polygons = new List<ParcourPolygon>();
        private double desiredLengthFactor;
        private double weight = double.MinValue;
        public ParcourModel(IParcour parcour, Converter c, double desiredLengthFactor)
        {
            this.desiredLengthFactor = desiredLengthFactor;
            List<ILine> lines = parcour.Lines;
            AddLineAsCorridor(c, lines.Single(p => p.LineType == LineType.START_A), lines.Single(p => p.LineType == LineType.END_A));
            AddLineAsCorridor(c, lines.Single(p => p.LineType == LineType.START_B), lines.Single(p => p.LineType == LineType.END_B));
            AddLineAsCorridor(c, lines.Single(p => p.LineType == LineType.START_C), lines.Single(p => p.LineType == LineType.END_C));
            AddLineAsCorridor(c, lines.Single(p => p.LineType == LineType.START_D), lines.Single(p => p.LineType == LineType.END_D));
        }

        public ParcourModel(ParcourModel pm, double firstWeight)
        {
            this.desiredLengthFactor = pm.desiredLengthFactor;
            foreach (ParcourChannel pc in pm.Channels)
            {
                AddCorridor(pc);
            }
            Randomize(firstWeight);
        }
        public List<ParcourChannel> getChannels()
        {
            return Channels;
        }
        public double Weight()
        {
            if (weight == double.MinValue)
            {
                double[] lenght = new double[4];
                double diffSum = 0;
                double min = Double.MaxValue;
                double max = Double.MinValue;
                //double minDist = 0;
                for (int i = 0; i < 4; i++)
                {
                    lenght[i] = Channels[i].getDistance();
                    min = Math.Min(min, lenght[i]);
                    max = Math.Max(max, lenght[i]);
                   diffSum += Math.Abs(lenght[i] - (Channels[i].getDistanceStraight() / desiredLengthFactor));
                    /*   for (int j = 0; j < 4; j++)
                      {
                          if (i != j)
                          {
                              minDist += Channels[i].getMinDistance(Channels[j]);
                          }
                      }*/
                }
                double result = 0;
                result += max - min;
                result += diffSum;
                //result += (10000.0 / (minDist / 9));
                weight = result;
            }
               
            return weight;
        }

        private void Randomize(double factor)
        {
            foreach (ParcourChannel pc in Channels)
            {
                pc.Randomize(factor);
            }
        }

        private void AddLineAsCorridor(Converter c, ILine start, ILine end)
        {
            Vector MiddleStart = Vector.Middle(getVector(c, start.PointA), getVector(c, start.PointB));
            Vector MiddleEnd = Vector.Middle(getVector(c, end.PointA), getVector(c, end.PointB));
            Channels.Add(new ParcourChannel(MiddleStart, MiddleEnd));
        }

        private void AddCorridor(ParcourChannel c)
        {
            Channels.Add(new ParcourChannel(c));
        }

        private static Vector getVector(Converter c, IGPSPoint point)
        {

            Vector startA = new Vector(c.DegToX(point.Longitude), c.DegToY(point.Latitude), 0);
            return startA;
        }
    }

    public class ParcourChannel
    {
        Vector Start;
        Vector End;
        List<Vector> LinearCombinations = new List<Vector>(10);

        public List<Vector> getLinearCombinations()
        {
            return LinearCombinations;
        }

        public ParcourChannel(Vector Start, Vector End)
        {
            this.Start = Start;
            this.End = End;
            Vector StartEnd = Vector.Direction(Start, End);
            for (int i = 0; i < 10; i++)
            {
                Vector linComb = Start + (StartEnd * (i / 9.0));
                LinearCombinations.Add(linComb);
            }
            double dist = getDistance();
            double straightDist = getDistanceStraight();
            if (dist - straightDist > 0.1)
            {
                System.Console.Out.WriteLine("ERROR");
            }
        }
        public ParcourChannel(ParcourChannel pc)
        {
            this.Start = pc.Start;
            this.End = pc.End;
            foreach (Vector v in pc.LinearCombinations)
            {
                LinearCombinations.Add(new Vector(v));
            }
        }
        internal void Randomize(double factor)
        {
            for (int i = 2; i < 8; i++)
            {
                Vector v = LinearCombinations.ElementAt(i);
                int sign = (i%2==1)?1:-1;
                Vector orth = Vector.Orthogonal(End - Start);
                orth = (orth / Vector.Abs(orth)) * (Utils.getNextDouble() * factor * sign);
                v.X += orth.X;
                v.Y += orth.Y;
               // v.X += Utils.getNextDouble() * factor * sign;
                //v.Y += Utils.getNextDouble() * factor * sign;
            }
        }
        public double getDistance()
        {
            double result = 0;
            Vector last = Start;
            foreach (Vector v in LinearCombinations)
            {
                result += Vector.Abs(last - v);
                last = v;
            }
            return result;
        }
        public double getDistanceStraight()
        {
            return Vector.Abs(Start - End);
        }
        //Optimize
        public double getMinDistance(ParcourChannel pc)
        {
            double result = Double.MaxValue;
            foreach (Vector v1 in LinearCombinations)
            {
                foreach (Vector v2 in pc.LinearCombinations)
                {
                    double dist = Vector.Abs(v1 - v2);
                    result = Math.Min(result, dist);
                }
            }

            return result;
        }
    }

    public class ParcourPolygon
    {
        List<Vector> Edges = new List<Vector>();
    }
}
