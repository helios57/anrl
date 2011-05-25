using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AnrlDB;
using System.Drawing;

namespace TestApplikation
{
    class Program
    {
        static void Main(string[] args)
        {
            AnrlDB.AnrlDataContext db = new AnrlDB.AnrlDataContext();
            db.DatabaseExists();
            db.CreateDatabase();

            /*
            string path = @"C:\Users\Helios6x\Downloads\flags_style1_medium";
            DirectoryInfo dir = new DirectoryInfo(path);
            AnrlDB.AnrlDataContext db = new AnrlDB.AnrlDataContext();
            foreach (FileInfo fi in dir.GetFiles().Where(p=>p.Extension==".png"))
            {
                Image i = Image.FromFile(fi.FullName);
                t_Picture pic = new t_Picture();
                pic.Name = fi.Name.Replace(fi.Extension,"").Trim();
                pic.isFlag = true;
                
                MemoryStream ms = new MemoryStream();
                i.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                pic.Data = ms.ToArray();
                db.t_Pictures.InsertOnSubmit(pic);
            }
            db.SubmitChanges();*/
        }
    }
}
