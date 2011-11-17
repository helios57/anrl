using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Drawing;

namespace AirNavigationRaceLive.Comps.Helper
{
    public class PDFCreator
    {
        public static void test()
        {
                        // Create a new PDF document
            PdfDocument document = new PdfDocument();

            // Create an empty page
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);
            
            // Create a font
            XFont font = new XFont("Verdana", 14, XFontStyle.Bold);
            XFont font2 = new XFont("Verdana", 10, XFontStyle.Regular);
            XFont font3 = new XFont("Verdana", 10, XFontStyle.Regular);

            // Draw the text
            /*string headingText = "Results for " + race.Name + ", " + competition.Date.ToString("dd.MM.yyyy") + " in " + competition.Location;
            gfx.DrawString(headingText, font, XBrushes.DarkMagenta, new XPoint(50, 50), XStringFormat.TopLeft);

            string pilotLine = "Pilot: " + competitor.PilotName + ", " + competitor.PilotFirstName;
            gfx.DrawString(pilotLine, font2, XBrushes.Black, new XPoint(50, 90), XStringFormat.TopLeft);

            string copilotLine = "Navigator: " + competitor.NavigatorName + ", " + competitor.NavigatorFirstName;
            gfx.DrawString(copilotLine, font2, XBrushes.Black, new XPoint(50, 110), XStringFormat.TopLeft);

            string takeoffTime = "Takeoff time: " + flight.TakeOffTime.ToString("HH.mm.ss");
            gfx.DrawString(takeoffTime, font2, XBrushes.Black, new XPoint(50, 130), XStringFormat.TopLeft);

            string startTime = "Start Time: " + flight.StartGateTime.ToString("HH.mm.ss");
            gfx.DrawString(startTime, font2, XBrushes.Black, new XPoint(50, 150), XStringFormat.TopLeft);
            
            string finishTime = "Finish Time: " + flight.FinishGateTime.ToString("HH.mm.ss");
            gfx.DrawString(finishTime, font2, XBrushes.Black, new XPoint(250, 150), XStringFormat.TopLeft);

            Image image = Common.drawFlight(parcours.ParentMap, parcours, flight);
            int originalHeight = image.Height;
            int originalWidth = image.Width;
            XImage xImage = XImage.FromGdiPlusImage(image);
            double ratio = (double)image.Height / (double)image.Width;
            int height = (int)Math.Ceiling((page.Width.Point - 100) * ratio);
            gfx.DrawImage(xImage, 50, 180, page.Width.Point - 100, height);

            gfx.DrawString("Penalties", font2, XBrushes.Black, 50, height + 200);
            int position = height + 220;
            int i = 0;

            foreach (Penalty penalty in flight.AutomaticPenalties)
            {
                if ((position + i * 20) <= page.Height.Point - 50)
                {
                    gfx.DrawString(penalty.PenaltyPoints.ToString(), font3, XBrushes.Gray, 60, (position + i * 20));
                    gfx.DrawString(penalty.PenaltyType.ToString() + ", " + penalty.Comment, font2, XBrushes.Gray, 120, (position + i * 20));
                    i++;
                }
                else
                {
                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    i = 0;
                    position = 50;
                }
            }


/*                 Process p = new Process();
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
                 */
        }
    }
}
