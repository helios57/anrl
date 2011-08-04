﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;
using System.Windows.Forms;
using AirNavigationRaceLive.Components.Model;

namespace AirNavigationRaceLive.Components.Helper
{
    public class ParcourModel
    {
        private List<ParcourChannel> Channels = new List<ParcourChannel>(4);
        private List<ParcourPolygon> Polygons = new List<ParcourPolygon>();
        private double desiredLengthFactor;
        private double weight = double.MinValue;
        private double channel;
        private Converter c;

        public ParcourModel(IParcour parcour, Converter c, double desiredLengthFactor, double channel)
        {
            this.desiredLengthFactor = desiredLengthFactor;
            this.channel = Converter.NMtoM(channel);
            this.c = c;
            List<ILine> lines = parcour.Lines;
            AddLineAsCorridor(c, lines.Single(p => p.LineType == LineType.START_A), lines.Single(p => p.LineType == LineType.END_A));
            AddLineAsCorridor(c, lines.Single(p => p.LineType == LineType.START_B), lines.Single(p => p.LineType == LineType.END_B));
            AddLineAsCorridor(c, lines.Single(p => p.LineType == LineType.START_C), lines.Single(p => p.LineType == LineType.END_C));
            AddLineAsCorridor(c, lines.Single(p => p.LineType == LineType.START_D), lines.Single(p => p.LineType == LineType.END_D));
        }

        public ParcourModel(ParcourModel pm, double firstWeight)
        {
            this.desiredLengthFactor = pm.desiredLengthFactor;
            this.channel = pm.channel;
            foreach (ParcourChannel pc in pm.Channels)
            {
                AddCorridor(pc);
            }
            Randomize(firstWeight);
        }

        private void addPolygons()
        {
            Vector ChannelRadius = Channels[3].Start - Channels[0].Start;

            GPSPoint Ende = new GPSPoint(c.XtoDeg(Channels[3].Start.X), c.YtoDeg(Channels[3].Start.Y), 0);
            GPSPoint Start = new GPSPoint(c.XtoDeg(Channels[0].Start.X), c.YtoDeg(Channels[0].Start.Y), 0);
            double origDist = Converter.Distance(Ende, Start);
            ChannelRadius = (ChannelRadius / origDist) * (channel * (-1.0/2.0));
            Vector ortho = Vector.Orthogonal(ChannelRadius) / 10;

            for (int i = 1; i <= 9; i += 2)
            {
                Vector p1 = Channels[0].LinearCombinations[i] + ChannelRadius + ortho;
                Vector p2 = Channels[0].LinearCombinations[i + 1] + ChannelRadius - ortho;
                Vector p3 = p1 + ChannelRadius * 30 + ortho;
                Vector p4 = p2 + ChannelRadius * 30 - ortho;
                Polygons.Add(new ParcourPolygon(p1, p2, p3, p4));
                Vector b1 = Channels[0].LinearCombinations[i] - ChannelRadius + ortho;
                Vector b2 = Channels[0].LinearCombinations[i+1] - ChannelRadius - ortho;
                //....

            }
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
    }
}
