using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AirNavigationRaceLive.Comps.Model;
using NetworkObjects;

namespace AirNavigationRaceLive.Comps.Helper
{
    public class ParcourModel
    {
        private List<ParcourChannel> Channels = new List<ParcourChannel>(4);
        private List<ParcourPolygon> Polygons = new List<ParcourPolygon>();
        private double desiredLengthFactor;
        private double weight = double.MinValue;
        private double channel;
        private Converter c;

        public ParcourModel(AirNavigationRaceLive.Comps.Model.Parcour parcour, Converter c, double desiredLengthFactor, double channel)
        {
            this.desiredLengthFactor = desiredLengthFactor;
            this.channel = Converter.NMtoM(channel);
            this.c = c;
            List<Line> lines = parcour.Lines;
            AddLineAsCorridor(c, lines.Single(p => p.Type == (int)LineType.START_A), lines.Single(p => p.Type == (int)LineType.END_A));
            AddLineAsCorridor(c, lines.Single(p => p.Type == (int)LineType.START_B), lines.Single(p => p.Type == (int)LineType.END_B));
            AddLineAsCorridor(c, lines.Single(p => p.Type == (int)LineType.START_C), lines.Single(p => p.Type == (int)LineType.END_C));
            AddLineAsCorridor(c, lines.Single(p => p.Type == (int)LineType.START_D), lines.Single(p => p.Type == (int)LineType.END_D));
        }

        public ParcourModel(ParcourModel pm, double firstWeight)
        {
            this.desiredLengthFactor = pm.desiredLengthFactor;
            this.channel = pm.channel;
            this.c = pm.c;
            foreach (ParcourChannel pc in pm.Channels)
            {
                AddCorridor(pc);
            }
            Randomize(firstWeight);
        }

        public void addPolygons()
        {
            Vector ChannelRadius = Channels[3].Start - Channels[0].Start;

            Point Ende = new Point(c.XtoDeg(Channels[3].Start.X), c.YtoDeg(Channels[3].Start.Y), 0);
            Point Start = new Point(c.XtoDeg(Channels[0].Start.X), c.YtoDeg(Channels[0].Start.Y), 0);
            double origDist = Converter.Distance(Ende, Start);
            ChannelRadius = (ChannelRadius / origDist) * (channel * (-1.0/2.0));
            Vector ortho = Vector.Orthogonal(ChannelRadius)/10.0;
            double factorLengthSides = 20.0;

            for (int i = 1; i < 8; i += 1)
            {
                Vector a1 = Channels[0].LinearCombinations[i] + ChannelRadius + ortho;
                Vector a2 = Channels[0].LinearCombinations[i + 1] + ChannelRadius - ortho;
                Vector a3 = a1 + ChannelRadius * factorLengthSides + ortho;
                Vector a4 = a2 + ChannelRadius * factorLengthSides - ortho;
                Polygons.Add(new ParcourPolygon(a1, a2, a4, a3));

                Vector b1 = Channels[0].LinearCombinations[i] - ChannelRadius + ortho;
                Vector b2 = Channels[0].LinearCombinations[i + 1] - ChannelRadius - ortho;
                Vector b3 = Channels[1].LinearCombinations[i] + ChannelRadius + ortho;
                Vector b4 = Channels[1].LinearCombinations[i + 1] + ChannelRadius - ortho;
                Polygons.Add(new ParcourPolygon(b1, b2, b4, b3));

                Vector c1 = Channels[1].LinearCombinations[i] - ChannelRadius + ortho;
                Vector c2 = Channels[1].LinearCombinations[i + 1] - ChannelRadius - ortho;
                Vector c3 = Channels[2].LinearCombinations[i] + ChannelRadius + ortho;
                Vector c4 = Channels[2].LinearCombinations[i + 1] + ChannelRadius - ortho;
                Polygons.Add(new ParcourPolygon(c1, c2, c4, c3)); 
                
                Vector d1 = Channels[2].LinearCombinations[i] - ChannelRadius + ortho;
                Vector d2 = Channels[2].LinearCombinations[i + 1] - ChannelRadius - ortho;
                Vector d3 = Channels[3].LinearCombinations[i] + ChannelRadius + ortho;
                Vector d4 = Channels[3].LinearCombinations[i + 1] + ChannelRadius - ortho;
                Polygons.Add(new ParcourPolygon(d1, d2, d4, d3));


                Vector e1 = Channels[3].LinearCombinations[i] - ChannelRadius + ortho;
                Vector e2 = Channels[3].LinearCombinations[i + 1] - ChannelRadius - ortho;
                Vector e3 = e1 - ChannelRadius * factorLengthSides + ortho;
                Vector e4 = e2 - ChannelRadius * factorLengthSides - ortho;
                Polygons.Add(new ParcourPolygon(e1, e2, e4, e3));
            }
        }

        public List<ParcourChannel> getChannels()
        {
            return Channels;
        }
        public List<ParcourPolygon> getPolygons()
        {
            return Polygons;
        }
        public double Weight()
        {
            if (weight == double.MinValue)
            {
                double[] lenght = new double[4];
                double diffSum = 0;
                double min = Double.MaxValue;
                double max = Double.MinValue;
                for (int i = 0; i < 4; i++)
                {
                    lenght[i] = Channels[i].getDistance();
                    min = Math.Min(min, lenght[i]);
                    max = Math.Max(max, lenght[i]);
                    diffSum += Math.Abs(lenght[i] - (Channels[i].getDistanceStraight() / desiredLengthFactor));
                }
                double result = 0;
                result += max - min;
                result += diffSum;
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

        private void AddLineAsCorridor(Converter c, Line start, Line end)
        {
            Vector MiddleStart = Vector.Middle(getVector(c, start.A), getVector(c, start.B));
            Vector MiddleEnd = Vector.Middle(getVector(c, end.A), getVector(c, end.B));
            Channels.Add(new ParcourChannel(MiddleStart, MiddleEnd));
        }

        private void AddCorridor(ParcourChannel c)
        {
            Channels.Add(new ParcourChannel(c));
        }

        private static Vector getVector(Converter c, Point point)
        {

            Vector startA = new Vector(c.DegToX(point.longitude), c.DegToY(point.latitude), 0);
            return startA;
        }
    }

    public class ParcourChannel
    {
        internal Vector Start;
        internal Vector End;
        internal List<Vector> LinearCombinations = new List<Vector>(10);

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
                int sign = (i % 2 == 1) ? 1 : -1;
                Vector orth = Vector.Orthogonal(End - Start);
                orth = (orth / Vector.Abs(orth)) * (Utils.getNextDouble() * factor * sign);
                v.X += orth.X;
                v.Y += orth.Y;
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
    }

    public class ParcourPolygon
    {
        List<Vector> Edges = new List<Vector>();
        public ParcourPolygon(Vector p1, Vector p2, Vector p3, Vector p4)
        {
            Edges.Add(p1);
            Edges.Add(p2);
            Edges.Add(p3);
            Edges.Add(p4);
        }
        public List<Vector> getEdges()
        {
            return Edges;
        }
    }
}
