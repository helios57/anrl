using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using AnrlDB;

namespace AnrlService.Server.Processors
{
    class ParcourProcessor : AnrlService.Server.Processors.AProcessor
    {
        private readonly List<Parcour> cached = new List<Parcour>();

        protected override void reloadCacheThreated()
        {
            AnrlDataContext db = getDB();
            lock (cached)
            {
                cached.Clear();
                foreach (t_Parcour m in db.t_Parcours)
                {
                    cached.Add(getParcour(m));
                }
            }
            db.Dispose();
        }

        public override Root proccess(Root request)
        {
            Root r = new Root();
            r.ResponseParameters = new ResponseParameters();
            switch ((ERequestType)request.RequestType)
            {
                case ERequestType.Delete:
                    {
                        Delete(request);
                        break;
                    }
                case ERequestType.Get:
                    {
                        Get(request, r);
                        break;
                    }
                case ERequestType.GetAll:
                    {
                        GetAll(request, r);
                        break;
                    }
                case ERequestType.Save:
                    {
                        Save(request, r);
                        break;
                    }
            }
            return r;
        }

        private void Get(Root request, Root r)
        {
            if (request.RequestParameters != null && request.RequestParameters.ID != 0)
            {
                lock (cached)
                {
                    foreach (Parcour parcour in cached.Where(p => p.ID == request.RequestParameters.ID))
                    {
                        r.ResponseParameters.ParcourList.Add(parcour);
                    }
                }
            }
        }

        private void GetAll(Root request, Root r)
        {
            List<int> ids = new List<int>(request.RequestParameters.IDS);
            lock (cached)
            {
                foreach (Parcour parcour in cached)
                {
                    if (!ids.Contains(parcour.ID))
                    {
                        r.ResponseParameters.ParcourList.Add(parcour);
                    }
                    else
                    {
                        ids.Remove(parcour.ID);
                    }
                }
            }
            r.ResponseParameters.DeletedIDList.AddRange(ids);
        }

        private void Save(Root request, Root r)
        {
            Parcour p = request.RequestParameters.Parcour;
            t_Parcour dbParcour = new t_Parcour();
            dbParcour.Name = p.Name;
            dbParcour.ID_Map = p.ID_Map;

            AnrlDataContext db = getDB();
            db.t_Parcours.InsertOnSubmit(dbParcour);
            db.SubmitChanges();
            foreach (Line l in p.LineList)
            {
                t_Line line = new t_Line();
                t_GPSPoint a = new t_GPSPoint();
                CopyAttributes(l.A, a);
                db.t_GPSPoints.InsertOnSubmit(a);

                t_GPSPoint b = new t_GPSPoint();
                CopyAttributes(l.B, b);
                db.t_GPSPoints.InsertOnSubmit(b);

                t_GPSPoint o = new t_GPSPoint();
                CopyAttributes(l.O, o);
                db.t_GPSPoints.InsertOnSubmit(o);
                db.SubmitChanges();

                line.ID_PointA = a.ID;
                line.ID_PointB = b.ID;
                line.ID_PointOrientation = o.ID;
                line.Type = l.Type;
                db.t_Lines.InsertOnSubmit(line);
                db.SubmitChanges();
                t_Parcour_Line pl = new t_Parcour_Line();
                pl.ID_Line = line.ID;
                pl.ID_Parcour = dbParcour.ID;
                db.t_Parcour_Lines.InsertOnSubmit(pl);
                db.SubmitChanges();
            }
            db.Dispose();
            lock (cached)
            {
                cached.Add(getParcour(dbParcour));
            }
            r.ResponseParameters = new ResponseParameters();
            r.ResponseParameters.ID = dbParcour.ID;
        }

        private void Delete(Root request)
        {
            AnrlDataContext db = getDB();
            foreach (t_Parcour dbParcour in db.t_Parcours.Where(p => p.ID == request.RequestParameters.ID))
            {
                foreach (t_Parcour_Line t_p_l in dbParcour.t_Parcour_Lines)
                {
                    t_Line t_l = t_p_l.t_Line;
                    db.t_GPSPoints.DeleteOnSubmit(t_l.t_GPSPoint);
                    db.t_GPSPoints.DeleteOnSubmit(t_l.t_GPSPoint1);
                    db.t_GPSPoints.DeleteOnSubmit(t_l.t_GPSPoint2);
                    db.t_Lines.DeleteOnSubmit(t_l);
                    db.t_Parcour_Lines.DeleteOnSubmit(t_p_l);
                }
                db.t_Parcours.DeleteOnSubmit(dbParcour);
            }
            db.SubmitChanges();
            db.Dispose();
            lock (cached)
            {
                cached.RemoveAll(p => p.ID == request.RequestParameters.ID);
            }
        }

        private Parcour getParcour(t_Parcour input)
        {
            Parcour result = new Parcour();
            result.ID = input.ID;
            result.Name = input.Name;
            result.ID_Map = input.ID_Map;
            foreach (t_Parcour_Line t_p_l in input.t_Parcour_Lines)
            {
                t_Line t_l = t_p_l.t_Line;
                Line l = new Line();
                l.A = new Point();
                CopyAttributes(t_l.t_GPSPoint, l.A);
                l.B = new Point();
                CopyAttributes(t_l.t_GPSPoint1, l.B);
                l.O = new Point();
                CopyAttributes(t_l.t_GPSPoint2, l.O);
                l.Type = t_l.Type;
                result.LineList.Add(l);
            }
            return result;
        }

        private static void CopyAttributes(t_GPSPoint gp, Point p)
        {
            p.ID = gp.ID;
            p.altitude = gp.altitude;
            p.latitude = gp.latitude;
            p.longitude = gp.longitude;
        }
        private static void CopyAttributes(Point gp, t_GPSPoint p)
        {
            p.ID = gp.ID;
            p.altitude = gp.altitude;
            p.latitude = gp.latitude;
            p.longitude = gp.longitude;
        }
        private static void CopyAttributesWithoutId(t_GPSPoint gp, Point p)
        {
            p.altitude = gp.altitude;
            p.latitude = gp.latitude;
            p.longitude = gp.longitude;
        }
        private static void CopyAttributesWithoutId(Point gp, t_GPSPoint p)
        {
            p.altitude = gp.altitude;
            p.latitude = gp.latitude;
            p.longitude = gp.longitude;
        }
    }
}
