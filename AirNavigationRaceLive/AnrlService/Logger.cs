using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlDB;

namespace AnrlService
{
    public class Logger
    {
        public static void Log(String text, int level)
        {
            try
            {
                AnrlDB.AnrlDataContext db = new AnrlDB.AnrlDataContext();
                t_Log l = new t_Log();
                l.level = level;
                l.timestamp = new DateTime();
                l.Text = text;
                db.t_Logs.InsertOnSubmit(l);
                db.SubmitChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                System.Console.Out.WriteLine(ex.ToString());
            }
        }

        internal static void Log(AnrlDataContext db, string text, int level)
        {
            try
            {
                t_Log l = new t_Log();
                l.level = level;
                l.timestamp = new DateTime();
                l.Text = text;
                db.t_Logs.InsertOnSubmit(l);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                System.Console.Out.WriteLine(ex.ToString());
            }
        }
    }
}
