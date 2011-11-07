using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirNavigationRaceLive.Comps.Helper
{
    class GeneratePenalty
    {
        private const long tickOfSecond = 10000000;
        private const long tickOfMinute = tickOfSecond * 60;
        public static List<NetworkObjects.Penalty> CalculatePenaltyPoints(NetworkObjects.Competition competition, NetworkObjects.CompetitionTeam competitionTeam, NetworkObjects.Parcour parcour, List<NetworkObjects.GPSData> data, NetworkObjects.Route type)
        {
            List<NetworkObjects.Penalty> result = new List<NetworkObjects.Penalty>();
            NetworkObjects.GPSData last = null;
            List<LineP> PenaltyZoneLines = new List<LineP>();
            foreach (NetworkObjects.Line nl in parcour.LineList.Where(p => p.Type == (int)NetworkObjects.LineType.PENALTYZONE))
            {
                PenaltyZoneLines.Add(getLine(nl));
            }

            List<LineP> dataLines = new List<LineP>();
            foreach (NetworkObjects.GPSData g in data)
            {
                if (last != null)
                {
                    LineP l = new LineP();
                    l.end = new Vector(g.longitude, g.latitude, 0);
                    l.TimestamEnd = g.timestampGPS;
                    l.start = new Vector(last.longitude, last.latitude, 0);
                    l.TimestamStart = last.timestampGPS;
                    dataLines.Add(l);
                }
                last = g;
            }
            LineP startLine = getStartLine(parcour, type);
            LineP endLine = getEndLine(parcour, type);
            if (startLine == null || endLine == null)
            {
                return result;
            }
            LineP takeOffLine = new LineP();
            takeOffLine.start = new Vector(competition.TakeOffLine.A.longitude, competition.TakeOffLine.A.latitude, 0);
            takeOffLine.end = new Vector(competition.TakeOffLine.B.longitude, competition.TakeOffLine.B.latitude, 0);
            takeOffLine.orientation = Vector.Orthogonal(takeOffLine.end - takeOffLine.start);

            long maxTimestamp = 0;
            foreach (NetworkObjects.GPSData d in data)
            {
                maxTimestamp = Math.Max(d.timestampGPS, maxTimestamp);
            }
            bool shouldHaveCrossedTakeOff = (maxTimestamp - 2 * tickOfMinute) > competitionTeam.TimeTakeOff;
            bool shouldHaveCrossedStart = (maxTimestamp - 2 * tickOfMinute) > competitionTeam.TimeStartLine;
            bool shouldHaveCrossedEnd = (maxTimestamp - 2 * tickOfMinute) > competitionTeam.TimeEndLine;

            bool haveCrossedTakeOff = false;
            bool haveCrossedStart = false;
            bool haveCrossedEnd = false;
            bool insidePenalty = false;
            double timeSinceInsidePenalty = 0;
            foreach (LineP l in dataLines)
            {
                double intersectionTakeOff = getIntersection(l, takeOffLine);
                double intersectionStart = getIntersection(l, startLine);
                double intersectionEnd = getIntersection(l, endLine);
                if (intersectionTakeOff != -1)
                {
                    //TODO
                }
                if (intersectionStart != -1)
                {
                    haveCrossedStart = true;
                    double crossTime = (l.TimestamStart + (l.TimestamEnd - l.TimestamStart) * intersectionStart);
                    double diff = crossTime - competitionTeam.TimeStartLine;
                    if (Math.Abs(diff) > tickOfSecond)
                    {
                        NetworkObjects.Penalty penalty = new NetworkObjects.Penalty();
                        double seconds = Math.Abs(diff / tickOfSecond);
                        penalty.Points = (int)Math.Min(seconds * 3, 200);
                        penalty.Reason = "Crossed Start-Line at " + new DateTime((Int64)crossTime).ToLongTimeString() + " instead of expected " + new DateTime((Int64)competitionTeam.TimeStartLine).ToLongTimeString();
                        result.Add(penalty);
                    }
                }
                if (intersectionEnd != -1)
                {
                    haveCrossedEnd = true;
                    double crossTime = (l.TimestamStart + (l.TimestamEnd - l.TimestamStart) * intersectionEnd);
                    double diff = crossTime - competitionTeam.TimeEndLine;
                    if (Math.Abs(diff) > tickOfSecond)
                    {
                        NetworkObjects.Penalty penalty = new NetworkObjects.Penalty();
                        double seconds = Math.Abs(diff / tickOfSecond);
                        penalty.Points = Math.Min((int)seconds * 3, 200);
                        penalty.Reason = "Crossed End-Line at " + new DateTime((Int64)crossTime).ToLongTimeString() + " instead of expected " + new DateTime((Int64)competitionTeam.TimeEndLine).ToLongTimeString();
                        result.Add(penalty);
                    }
                }
                bool stateChanged = false;
                double intersectionPenalty = intersectsPenaltyPoint(PenaltyZoneLines, l, out stateChanged);
                if (intersectionPenalty != -1)
                {
                    if (stateChanged)
                    {
                        if (!insidePenalty)
                        {
                            insidePenalty = true;
                            timeSinceInsidePenalty = intersectionPenalty;
                        }
                        else
                        {
                            insidePenalty = false;
                            int sec = (int)((intersectionPenalty - timeSinceInsidePenalty) / tickOfSecond);
                            if (sec > 5)
                            {
                                NetworkObjects.Penalty penalty = new NetworkObjects.Penalty();
                                penalty.Points = Math.Min((sec-5) * 3, 300);
                                penalty.Reason = "Inside Penaltyzone for " + sec + " from " + new DateTime((Int64)timeSinceInsidePenalty).ToLongTimeString() + " to " + new DateTime((Int64)intersectionPenalty).ToLongTimeString();
                                result.Add(penalty);
                            }
                        }
                    }
                }
            }
            //bool haveCrossedTakeOff = false;
            if (shouldHaveCrossedStart && !haveCrossedStart)
            {
                NetworkObjects.Penalty penalty = new NetworkObjects.Penalty();
                penalty.Points = 200;
                penalty.Reason = "Start not passed";
                result.Add(penalty);

            };
            if (shouldHaveCrossedEnd && !haveCrossedEnd)
            {
                NetworkObjects.Penalty penalty = new NetworkObjects.Penalty();
                penalty.Points = 200;
                penalty.Reason = "End not passed";
                result.Add(penalty);
            };

            return result;
        }
        /// <summary>
        /// Return timestamp in ticks of relevant intersection
        /// </summary>
        /// <param name="penaltyZones"></param>
        /// <param name="line"></param>
        /// <param name="changedState"></param>
        /// <returns></returns>
        private static double intersectsPenaltyPoint(List<LineP> penaltyZones, LineP line, out bool changedState)
        {
            changedState = false;
            double result = -1;
            foreach (LineP nl in penaltyZones)
            {
                double intersection = getIntersection(line, nl);
                if (intersection != -1)
                {
                    changedState = !changedState;
                    result = (line.TimestamStart + (line.TimestamEnd - line.TimestamStart) * intersection);
                }
            }

            return result;
        }
        private static LineP getLine(NetworkObjects.Line nline)
        {
            LineP line = new LineP();
            line.start = new Vector(nline.A.longitude, nline.A.latitude, 0);
            line.end = new Vector(nline.B.longitude, nline.B.latitude, 0);
            line.orientation = new Vector(nline.O.longitude, nline.O.latitude, 0);
            return line;

        }
        private static double getIntersection(LineP data, LineP fix)
        {
            Vector intersection = Vector.Interception(data.start, data.end, fix.start, fix.end);
            if (intersection != null)
            {
                return Vector.Abs(intersection - data.start) / Vector.Abs(data.end - data.start);
            }
            return -1;
        }
        private static LineP getStartLine(NetworkObjects.Parcour parcour, NetworkObjects.Route type)
        {
            NetworkObjects.Line nl = null;
            try
            {
                switch (type)
                {
                    case NetworkObjects.Route.A:
                        {
                            nl = parcour.LineList.Single(p => p.Type == (int)NetworkObjects.LineType.START_A); break;
                        }
                    case NetworkObjects.Route.B:
                        {
                            nl = parcour.LineList.Single(p => p.Type == (int)NetworkObjects.LineType.START_B); break;
                        }
                    case NetworkObjects.Route.C:
                        {
                            nl = parcour.LineList.Single(p => p.Type == (int)NetworkObjects.LineType.START_C); break;
                        }
                    case NetworkObjects.Route.D:
                        {
                            nl = parcour.LineList.Single(p => p.Type == (int)NetworkObjects.LineType.START_D); break;
                        }
                }
            }
            catch { }
            LineP l=null;
            if (nl != null)
            {
                l = new LineP();
                l.start = new Vector(nl.A.longitude, nl.A.latitude, 0);
                l.end = new Vector(nl.B.longitude, nl.B.latitude, 0);
                l.orientation = new Vector(nl.O.longitude, nl.O.latitude, 0);
            }
            return l;
        }
        private static LineP getEndLine(NetworkObjects.Parcour parcour, NetworkObjects.Route type)
        {
            NetworkObjects.Line nl = null;
            try
            {
                switch (type)
                {
                    case NetworkObjects.Route.A:
                        {
                            nl = parcour.LineList.Single(p => p.Type == (int)NetworkObjects.LineType.END_A); break;
                        }
                    case NetworkObjects.Route.B:
                        {
                            nl = parcour.LineList.Single(p => p.Type == (int)NetworkObjects.LineType.END_B); break;
                        }
                    case NetworkObjects.Route.C:
                        {
                            nl = parcour.LineList.Single(p => p.Type == (int)NetworkObjects.LineType.END_C); break;
                        }
                    case NetworkObjects.Route.D:
                        {
                            nl = parcour.LineList.Single(p => p.Type == (int)NetworkObjects.LineType.END_D); break;
                        }
                }
            }
            catch { }
            LineP l=null;
            if (nl != null)
            {
                l = new LineP();
                l.start = new Vector(nl.A.longitude, nl.A.latitude, 0);
                l.end = new Vector(nl.B.longitude, nl.B.latitude, 0);
                l.orientation = new Vector(nl.O.longitude, nl.O.latitude, 0);
            }
            return l;
        }
    }
    class LineP
    {
        public Vector start;
        public Vector end;
        public Vector orientation;
        public long TimestamStart;
        public long TimestamEnd;
    }
}
