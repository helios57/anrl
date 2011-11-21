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
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.Tables;

namespace AirNavigationRaceLive.Comps.Helper
{
    public class PDFCreator
    {
        public static void CreateTeamsPDF(List<NetworkObjects.Team> teams, Client.Client c, String pathToPDF)
        {
            Document doc = new Document();
            doc.Info.Author = "Luc.Baumann@sharpsoft.ch";
            doc.Info.Comment = "Generated from ANRL Client on " + DateTime.Now.ToString();
            doc.Info.Keywords = "ANRL Crewlist";
            doc.Info.Subject = "Crewlist";
            doc.Info.Title = "Crewlist";
            doc.UseCmykColor = true;
            doc.DefaultPageSetup.PageFormat = PageFormat.A4;
            doc.DefaultPageSetup.Orientation = Orientation.Landscape;

            Section sec = doc.AddSection();
            Table table = sec.AddTable();
            table.Borders.Visible = true;

            table.AddColumn(Unit.FromCentimeter(0.7));
            table.AddColumn(Unit.FromCentimeter(2.5));
            table.AddColumn();
            table.AddColumn();
            table.AddColumn();
            table.AddColumn();
            table.AddColumn();
            table.AddColumn();

            Row row = table.AddRow();
            row.Shading.Color = Colors.Gray;
            row.Cells[0].AddParagraph("ID");
            row.Cells[1].AddParagraph("Nationality");
            row.Cells[2].AddParagraph("Pilot Lastname");
            row.Cells[3].AddParagraph("Pilot Surename");
            row.Cells[4].AddParagraph("Navigator Lastname");
            row.Cells[5].AddParagraph("Navigator Surename");
            row.Cells[6].AddParagraph("CNumber");
            row.Cells[7].AddParagraph("AC");

            foreach (NetworkObjects.Team t in teams)
            {
                Row r = table.AddRow();
                r.Cells[0].AddParagraph(t.ID.ToString());
                r.Cells[1].AddParagraph(t.Name);
                NetworkObjects.Pilot pilot = c.getPilot(t.ID_Pilot);
                r.Cells[2].AddParagraph(pilot.Name);
                r.Cells[3].AddParagraph(pilot.Surename);
                if (t.ID_Navigator > 0)
                {
                    NetworkObjects.Pilot navigator = c.getPilot(t.ID_Navigator);
                    r.Cells[4].AddParagraph(navigator.Name);
                    r.Cells[5].AddParagraph(navigator.Surename);
                }
                r.Cells[6].AddParagraph(t.StartID);
                r.Cells[7].AddParagraph(t.Description);
            }

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            renderer.Document = doc;
            renderer.RenderDocument();
            renderer.PdfDocument.Save(pathToPDF);

            Process.Start(pathToPDF);
        }

        public static void CreateParcourPDF(ParcourPictureBox picBox, Client.Client c, String pathToPDF)
        {
            PdfDocument doc = new PdfDocument();
            doc.Info.Author = "Luc.Baumann@sharpsoft.ch";
            doc.Info.Keywords = "ANRL Parcour Printout";
            doc.Info.Subject = "Parcour Printout generated from ANRL Client on " + DateTime.Now.ToString();
            doc.Info.Title = "Parcour Printout";
            doc.Options.ColorMode = PdfColorMode.Cmyk;
            doc.Language = "EN";
            doc.PageLayout = PdfPageLayout.SinglePage;

            PdfPage page = doc.AddPage();
            page.Orientation = PdfSharp.PageOrientation.Landscape;
            page.Size = PdfSharp.PageSize.A4;

            XGraphics gfx = XGraphics.FromPdfPage(page);
            XImage image = XImage.FromGdiPlusImage(picBox.PrintOutImage);

            double distX = picBox.GetXDistanceKM()/2;//1:200 000 in cm
            double distY = picBox.GetYDistanceKM()/2;//1:200 000 in cm

            gfx.DrawImage(image, 100, 100, page.Width.Point * (distX/page.Width.Centimeter), page.Height.Point*(distY/page.Height.Centimeter));
            doc.Save(pathToPDF);
            Process.Start(pathToPDF);

        }
        public static void test()
        {
            DateTime now = DateTime.Now;
            string filename = "MixMigraDocAndPdfSharp.pdf";
            filename = Guid.NewGuid().ToString("D").ToUpper() + ".pdf";
            PdfDocument document = new PdfDocument();
            document.Info.Title = "PDFsharp XGraphic Sample";
            document.Info.Author = "Stefan Lange";
            document.Info.Subject = "Created with code snippets that show the use of graphical functions";
            document.Info.Keywords = "PDFsharp, XGraphics";


            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            gfx.MUH = PdfFontEncoding.Unicode;
            gfx.MFEH = PdfFontEmbedding.Default;
            XFont font = new XFont("Verdana", 13, XFontStyle.Bold);
            gfx.DrawString("The following paragraph was rendered using MigraDoc:", font, XBrushes.Black,
            new XRect(100, 100, page.Width - 200, 300), XStringFormats.Center);
            Document doc = new Document();
            Section sec = doc.AddSection();
            Paragraph para = sec.AddParagraph();
            para.Format.Alignment = ParagraphAlignment.Justify;
            para.Format.Font.Name = "Times New Roman";
            para.Format.Font.Size = 12;
            para.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.DarkGray;
            para.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.DarkGray;
            para.AddText("Duisism odigna acipsum delesenisl ");
            para.AddFormattedText("ullum in velenit", TextFormat.Bold);
            para.AddText(" ipit iurero dolum zzriliquisis nit wis dolore vel et nonsequipit, velendigna " +
            "auguercilit lor se dipisl duismod tatem zzrit at laore magna feummod oloborting ea con vel " +
            "essit augiati onsequat luptat nos diatum vel ullum illummy nonsent nit ipis et nonsequis " +
            "niation utpat. Odolobor augait et non etueril landre min ut ulla feugiam commodo lortie ex " +
            "essent augait el ing eumsan hendre feugait prat augiatem amconul laoreet. ≤≥≈≠");
            para.Format.Borders.Distance = "5pt";
            para.Format.Borders.Color = Colors.Gold;
            MigraDoc.Rendering.DocumentRenderer docRenderer = new DocumentRenderer(doc);
            docRenderer.PrepareDocument();
            docRenderer.RenderObject(gfx, XUnit.FromCentimeter(5), XUnit.FromCentimeter(10), "12cm", para);

            document.Save(filename);

            Process.Start(filename);
        }

        internal static void CreateStartListPDF(NetworkObjects.Competition competition, Client.Client Client, string pathToPDF)
        {
            Document doc = new Document();
            doc.Info.Author = "Luc.Baumann@sharpsoft.ch";
            doc.Info.Comment = "Generated from ANRL Client on " + DateTime.Now.ToString();
            doc.Info.Keywords = "ANRL StartList";
            doc.Info.Subject = "StartList";
            doc.Info.Title = "StartList";
            doc.UseCmykColor = true;
            doc.DefaultPageSetup.PageFormat = PageFormat.A4;
            doc.DefaultPageSetup.Orientation = Orientation.Landscape;

            Section sec = doc.AddSection();
            Table table = sec.AddTable();
            table.Borders.Visible = true;

            table.AddColumn(Unit.FromCentimeter(0.7));
            table.AddColumn(Unit.FromCentimeter(2.5));
            table.AddColumn();
            table.AddColumn();
            table.AddColumn();
            table.AddColumn();
            table.AddColumn();
            table.AddColumn();
            table.AddColumn();
            table.AddColumn();
            table.AddColumn();

            Row row = table.AddRow();
            row.Shading.Color = Colors.Gray;
            row.Cells[0].AddParagraph("Start ID");
            row.Cells[1].AddParagraph("Crew Number");
            row.Cells[2].AddParagraph("AC");
            row.Cells[3].AddParagraph("Pilot Lastname");
            row.Cells[4].AddParagraph("Pilot Surename");
            row.Cells[5].AddParagraph("Navigator Lastname");
            row.Cells[6].AddParagraph("Navigator Surename");
            row.Cells[7].AddParagraph("Take Off");
            row.Cells[8].AddParagraph("Start Gate");
            row.Cells[9].AddParagraph("End Gate");
            row.Cells[10].AddParagraph("Route");

            foreach (NetworkObjects.CompetitionTeam ct in competition.CompetitionTeamList)
            {
                Row r = table.AddRow();
                r.Cells[0].AddParagraph(ct.StartID.ToString());
                NetworkObjects.Team teams = Client.getTeam(ct.ID_Team);
                r.Cells[1].AddParagraph(teams.StartID);
                r.Cells[2].AddParagraph(teams.Description);
                NetworkObjects.Pilot pilot = Client.getPilot(teams.ID_Pilot);
                r.Cells[3].AddParagraph(pilot.Name);
                r.Cells[4].AddParagraph(pilot.Surename);
                if (teams.ID_Navigator > 0)
                {
                    NetworkObjects.Pilot navigator = Client.getPilot(teams.ID_Navigator);
                    r.Cells[5].AddParagraph(navigator.Name);
                    r.Cells[6].AddParagraph(navigator.Surename);
                }
                r.Cells[7].AddParagraph(new DateTime(ct.TimeTakeOff).ToString("HH:mm"));
                r.Cells[8].AddParagraph(new DateTime(ct.TimeStartLine).ToString("HH:mm"));
                r.Cells[9].AddParagraph(new DateTime(ct.TimeEndLine).ToString("HH:mm"));
                r.Cells[10].AddParagraph(Enum.GetName(NetworkObjects.Route.A.GetType(),ct.Route));
            }

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            renderer.Document = doc;
            renderer.RenderDocument();
            renderer.PdfDocument.Save(pathToPDF);

            Process.Start(pathToPDF);
        }
    }
}
