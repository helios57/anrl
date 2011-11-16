using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using iTextSharp.text;
using System.Diagnostics;

namespace AirNavigationRaceLive.Comps.Helper
{
    public class PDFCreator
    {
        public static void test()
        {
            try
            {
                string assyName = Path.GetFileName(Assembly.GetExecutingAssembly().GetName().CodeBase.ToString());
                string assyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                Random rnd = new Random();

                // step 1: create a document
                Document document = new Document();
                // step 2: we set the ContentType and create an instance of the Writer
                int pid = Process.GetCurrentProcess().Id;
                string Filename = String.Format(@"C:\temp\pdf\{0}-{1}-{2}.pdf", assyName, pid, rnd.Next(1000));
                iTextSharp.text.pdf.PdfWriter.GetInstance(document,
                                new FileStream(Filename, FileMode.Create));

                // step 3:  add metadata (before document.Open())
                document.AddTitle("Sample Document");
                document.AddSubject("Csharp PDF creation example");
                document.AddKeywords("csharp dotnet examples");
                document.AddCreator(".NET Assembly: " + assyName);
                document.AddAuthor("Dino Chiesa");
                document.AddProducer();

                // step 4: open the doc
                document.Open();

                // step 5: Add content to the document
                Font font24 = FontFactory.GetFont(FontFactory.HELVETICA, 24);
                Font font18 = FontFactory.GetFont(FontFactory.HELVETICA, 18);
                Font fontAnchor = FontFactory.GetFont(FontFactory.HELVETICA, 10,
                                                 Font.UNDERLINE,
                                                 iTextSharp.text.BaseColor.RED);
                Chunk bullet = new Chunk("\u2022", font18);

     
                iTextSharp.text.pdf.PdfPTable bigtable = new iTextSharp.text.pdf.PdfPTable(3);
                bigtable.WidthPercentage = 60;
                int i, j, n, m, x = 0;
                for (i = 0; i < 3; i++)
                {
                    for (j = 0; j < 3; j++)
                    {
                        iTextSharp.text.pdf.PdfPTable nested = new iTextSharp.text.pdf.PdfPTable(3);
                        nested.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        nested.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        nested.DefaultCell.MinimumHeight = 24;
                        for (n = 0; n < 3; n++)
                        {
                            for (m = 0; m < 3; m++)
                            {
                                nested.AddCell(new String((char)(65 + x), 1) + (n + 1) + "," + (m + 1));
                            }
                        }
                        bigtable.AddCell(nested);
                        x++;
                    }
                }

                document.Add(bigtable);

                document.Add(new Paragraph("\n"));
                document.Add(new Paragraph("This PDF document was generated dynamically: "));
                List list = new List(false, 20);  // true= ordered, false= unordered
                list.ListSymbol = bullet;       // use "bullet" as list symbol
                list.Add(new ListItem("on " + DateTime.Now.ToString("dddd, MMM d, yyyy")));
                list.Add(new ListItem("at " + DateTime.Now.ToString("hh:mm:ss tt zzzz")));
                list.Add(new ListItem("on machine " + Environment.MachineName));
                list.Add(new ListItem("by .NET assembly: " + assyName + " " + assyVersion));
                list.Add(new ListItem("on a machine running " + Environment.OSVersion.ToString()));
                list.Add(new ListItem("and .NET CLR " + Environment.Version));

                string v1 = "(none)";
                string v2 = "(none)";
                try
                {
                    v1 = list.GetType().Assembly.GetName().Version.ToString();
                    v2 = list.GetType().Assembly.ImageRuntimeVersion;
                }
                catch (Exception e1) { v1 = e1.ToString(); }

                ListItem li = new ListItem(String.Format("iTextSharp v{0} (compiled with .NET {1}) see ", v1, v2));
                Anchor anchor =
              new Anchor("http://itextsharp.sourceforge.net/", fontAnchor);
                anchor.Reference = "http://itextsharp.sourceforge.net";
                //anchor.Name = "website"; 

                li.Add(anchor);
                list.Add(li);

                document.Add(list);


                // step 6: Close document
                document.Close();


                Process p = new Process();
                p.StartInfo.FileName = Filename;
                //p.StartInfo.WindowStyle = Diagnostics.ProcessWindowStyle.Hidden;
                p.StartInfo.RedirectStandardOutput = false;
                p.StartInfo.UseShellExecute = true;

                p.Start();

            }
            catch (DocumentException ex)
            {
                Console.Error.WriteLine(ex.StackTrace);
                Console.Error.WriteLine(ex.Message);
            }

        }
    }
}
