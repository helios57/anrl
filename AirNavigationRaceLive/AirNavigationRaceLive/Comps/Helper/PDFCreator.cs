using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.DocumentObjectModel.Shapes;
using NetworkObjects;

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
            doc.DefaultPageSetup.BottomMargin = Unit.FromCentimeter(1);
            doc.DefaultPageSetup.TopMargin = Unit.FromCentimeter(1);
            doc.DefaultPageSetup.LeftMargin = Unit.FromCentimeter(1.5);
            doc.DefaultPageSetup.RightMargin = Unit.FromCentimeter(1);


            Section sec = doc.AddSection();

            AddCompetitionAndLogo(c, sec);
            sec.AddParagraph("");
            sec.AddParagraph("Participants list");

            Table table = sec.AddTable();
            table.Borders.Visible = true;

            //table.AddColumn(Unit.FromCentimeter(0.7));
            table.AddColumn(Unit.FromCentimeter(2.5));
            table.AddColumn();
            table.AddColumn(Unit.FromCentimeter(4));
            table.AddColumn(Unit.FromCentimeter(4));
            table.AddColumn(Unit.FromCentimeter(4));
            table.AddColumn(Unit.FromCentimeter(4));
            table.AddColumn();

            Row row = table.AddRow();
            row.Shading.Color = Colors.Gray;
            //row.Cells[0].AddParagraph("ID");
            row.Cells[0].AddParagraph("CNumber");
            row.Cells[1].AddParagraph("Nationality");
            row.Cells[2].AddParagraph("Pilot Lastname");
            row.Cells[3].AddParagraph("Pilot Surename");
            row.Cells[4].AddParagraph("Navigator Lastname");
            row.Cells[5].AddParagraph("Navigator Surename");
            row.Cells[6].AddParagraph("AC");

            foreach (NetworkObjects.Team t in teams)
            {
                Row r = table.AddRow();
                //r.Cells[0].AddParagraph(t.ID.ToString());
                r.Cells[0].AddParagraph(t.StartID);
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
                r.Cells[6].AddParagraph(t.Description);
            }

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            renderer.Document = doc;
            renderer.RenderDocument();
            renderer.PdfDocument.Save(pathToPDF);

            Process.Start(pathToPDF);
        }

        private static void AddCompetitionAndLogo(Client.Client c, Section sec)
        {
            String competitionName = "Competition: " + c.getCompetitionSet().Name;
            Paragraph pg = sec.AddParagraph();
            pg.Format.Alignment = ParagraphAlignment.Left;
            pg.Format.KeepTogether = false;
            pg.Format.KeepWithNext = false;
            pg.Format.AddTabStop(Unit.FromCentimeter(24));

            FormattedText ft = pg.AddFormattedText(competitionName);
            ft.Bold = true;
            ft.Size = Unit.FromPoint(16);
            pg.AddTab();


            Image logo = pg.AddImage(@"Resources\ANR_LOGO.jpg");
            logo.Height = Unit.FromCentimeter(2);
            logo.Width = Unit.FromCentimeter(2);
            logo.LockAspectRatio = true;
            logo.Left = Unit.FromCentimeter(23);
            logo.Top = Unit.FromCentimeter(0);
        }

        public static void CreateParcourPDF(ParcourPictureBox picBox, Client.Client c, String parcourName, String pathToPDF)
        {
            //PdfDocument doc = new PdfDocument(@"Resources\PDFTemplates\Competition_Map.pdf");
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
            XImage logo = XImage.FromFile(@"Resources\ANR_LOGO.jpg");
            XRect rect = new XRect(XUnit.FromCentimeter(25), XUnit.FromCentimeter(1), XUnit.FromCentimeter(2), XUnit.FromCentimeter(2));
            gfx.DrawImage(logo, rect);

            gfx.DrawString("Competition: " + c.getCompetitionSet().Name,
                new XFont("Verdana", 16, XFontStyle.Bold), XBrushes.Black,
                new XPoint(XUnit.FromCentimeter(2), XUnit.FromCentimeter(2)));

            gfx.DrawString("Parcour: " + parcourName,
                new XFont("Verdana", 14, XFontStyle.Bold), XBrushes.Black,
                new XPoint(XUnit.FromCentimeter(2), XUnit.FromCentimeter(3)));

            XImage image = XImage.FromGdiPlusImage(picBox.PrintOutImage);

            double distX = picBox.GetXDistanceKM() / 2;//1:200 000 in cm
            double distY = picBox.GetYDistanceKM() / 2;//1:200 000 in cm

            gfx.DrawImage(image, XUnit.FromCentimeter(1), XUnit.FromCentimeter(4), page.Width.Point * (distX / page.Width.Centimeter), page.Height.Point * (distY / page.Height.Centimeter));

            double startX = 190;

            List<XPoint> points = new List<XPoint>();
            points.Add(new XPoint(Unit.FromMillimeter(startX), Unit.FromMillimeter(40)));
            points.Add(new XPoint(Unit.FromMillimeter(startX + 18 * 5), Unit.FromMillimeter(40)));
            points.Add(new XPoint(Unit.FromMillimeter(startX + 18 * 5), Unit.FromMillimeter(40 + 9)));
            points.Add(new XPoint(Unit.FromMillimeter(startX), Unit.FromMillimeter(40 + 9)));
            points.Add(new XPoint(Unit.FromMillimeter(startX), Unit.FromMillimeter(40)));
            gfx.DrawLines(XPens.Black, points.ToArray());
            for (int i = 0; i < 5; i++)
            {
                if (i == 1) continue;
                points = new List<XPoint>();
                points.Add(new XPoint(Unit.FromMillimeter(startX + 18 * i), Unit.FromMillimeter(40)));
                points.Add(new XPoint(Unit.FromMillimeter(startX + 18 * i), Unit.FromMillimeter(40 + 9)));
                gfx.DrawLines(XPens.Black, points.ToArray());
            }

            gfx.DrawString("Comp. Nr:",
                new XFont("Verdana", 14, XFontStyle.Bold), XBrushes.Black,
                new XPoint(Unit.FromMillimeter(startX + 1), Unit.FromMillimeter(40 + 7)));

            gfx.DrawString("Track:",
                new XFont("Verdana", 14, XFontStyle.Bold), XBrushes.Black,
                new XPoint(Unit.FromMillimeter(startX + 18 * 3 + 1), Unit.FromMillimeter(40 + 7)));

            double startY = 40 + 9 + 5;

            double colWidth = 18;
            double rowHeight = 9;


            for (int i = 0; i < 16; i++)
            {
                points = new List<XPoint>();
                points.Add(new XPoint(Unit.FromMillimeter(startX), Unit.FromMillimeter(startY + i * rowHeight)));
                points.Add(new XPoint(Unit.FromMillimeter(startX + colWidth * 5), Unit.FromMillimeter(startY + i * rowHeight)));
                gfx.DrawLines(XPens.Black, points.ToArray());
            }

            for (int i = 0; i < 6; i++)
            {
                points = new List<XPoint>();
                points.Add(new XPoint(Unit.FromMillimeter(startX + i * colWidth), Unit.FromMillimeter(startY)));
                points.Add(new XPoint(Unit.FromMillimeter(startX + i * colWidth), Unit.FromMillimeter(startY + 15 * rowHeight)));
                gfx.DrawLines(XPens.Black, points.ToArray());
            }

            gfx.DrawString("Dist.",
                new XFont("Verdana", 14, XFontStyle.Bold), XBrushes.Black,
                new XPoint(Unit.FromMillimeter(startX + colWidth * 1 + 1), Unit.FromMillimeter(startY + 7)));

            gfx.DrawString("TT",
                new XFont("Verdana", 14, XFontStyle.Bold), XBrushes.Black,
                new XPoint(Unit.FromMillimeter(startX + colWidth * 2 + 1), Unit.FromMillimeter(startY + 7)));

            gfx.DrawString("EET",
                new XFont("Verdana", 14, XFontStyle.Bold), XBrushes.Black,
                new XPoint(Unit.FromMillimeter(startX + colWidth * 3 + 1), Unit.FromMillimeter(startY + 7)));

            gfx.DrawString("ETO",
                new XFont("Verdana", 14, XFontStyle.Bold), XBrushes.Black,
                new XPoint(Unit.FromMillimeter(startX + colWidth * 4 + 1), Unit.FromMillimeter(startY + 7)));

            gfx.DrawString("T/O",
                new XFont("Verdana", 14, XFontStyle.Bold), XBrushes.Black,
                new XPoint(Unit.FromMillimeter(startX + 1), Unit.FromMillimeter(startY + rowHeight * 1 + 7)));

            gfx.DrawString("SP",
                new XFont("Verdana", 14, XFontStyle.Bold), XBrushes.Black,
                new XPoint(Unit.FromMillimeter(startX + 1), Unit.FromMillimeter(startY + rowHeight * 2 + 7)));

            for (int i = 3; i < 13; i++)
            {
                gfx.DrawString("TP" + (i - 3),
                    new XFont("Verdana", 14, XFontStyle.Bold), XBrushes.Black,
                    new XPoint(Unit.FromMillimeter(startX + 1), Unit.FromMillimeter(startY + rowHeight * i + 7)));
            }
            gfx.DrawString("FP",
                new XFont("Verdana", 14, XFontStyle.Bold), XBrushes.Black,
                new XPoint(Unit.FromMillimeter(startX + 1), Unit.FromMillimeter(startY + rowHeight * 13 + 7)));

            gfx.DrawImage(XImage.FromFile(@"Resources\Summe.png"),
                new XPoint(Unit.FromMillimeter(startX + 1), Unit.FromMillimeter(startY + rowHeight * 14 + 2)));

            doc.Save(pathToPDF);
            doc.Close();
            Process.Start(pathToPDF);
        }

        public static void CreateResultPDF(VisualisationPictureBox picBox, Client.Client c, NetworkObjects.Competition competition, List<ComboBoxCompetitionTeam> competitionTeam, String pathToPDF)
        {
            int counter = 0;
            List<NetworkObjects.CompetitionTeam> tempList = new List<NetworkObjects.CompetitionTeam>();
            foreach (ComboBoxCompetitionTeam cbct in competitionTeam)
            {
                GC.Collect();
                PdfDocument doc = new PdfDocument();
                doc.Info.Author = "Luc.Baumann@sharpsoft.ch";
                doc.Info.Keywords = "ANRL Results Printout";
                doc.Info.Subject = "Results Printout generated from ANRL Client on " + DateTime.Now.ToString();
                doc.Info.Title = "Results Printout";
                doc.Options.ColorMode = PdfColorMode.Cmyk;
                doc.Language = "EN";
                doc.PageLayout = PdfPageLayout.SinglePage;

                tempList.Clear();
                tempList.Add(cbct.competitionTeam);
                picBox.SetData(cbct.data, c.getTeams(), tempList);

                PdfPage page = doc.AddPage();
                page.Orientation = PdfSharp.PageOrientation.Landscape;
                page.Size = PdfSharp.PageSize.A4;

                XGraphics gfx = XGraphics.FromPdfPage(page);


                XImage image = XImage.FromGdiPlusImage(picBox.PrintOutImage);

                double distX = picBox.GetXDistanceKM() / 2;//1:200 000 in cm
                double distY = picBox.GetYDistanceKM() / 2;//1:200 000 in cm

                gfx.DrawImage(image, XUnit.FromCentimeter(2).Point, XUnit.FromCentimeter(3).Point, page.Width.Point * (distX / page.Width.Centimeter), page.Height.Point * (distY / page.Height.Centimeter));


                XImage logo = XImage.FromFile(@"Resources\ANR_LOGO.jpg");
                XRect rect = new XRect(XUnit.FromCentimeter(23), XUnit.FromCentimeter(1), XUnit.FromCentimeter(2), XUnit.FromCentimeter(2));
                gfx.DrawImage(logo, rect);

                gfx.DrawString("Competition: " + c.getCompetitionSet().Name,
                    new XFont("Verdana", 13, XFontStyle.Bold), XBrushes.Black,
                    new XPoint(XUnit.FromCentimeter(2), XUnit.FromCentimeter(1.5)));

                gfx.DrawString("Q-Round: " + competition.Name,
                    new XFont("Verdana", 11, XFontStyle.Bold), XBrushes.Black,
                    new XPoint(XUnit.FromCentimeter(2), XUnit.FromCentimeter(2.1)));

                gfx.DrawString("Crew: " + getTeamDsc(c, cbct.competitionTeam.ID_Team),
                    new XFont("Verdana", 11, XFontStyle.Bold), XBrushes.Black,
                    new XPoint(XUnit.FromCentimeter(2), XUnit.FromCentimeter(2.7)));

                int sum = 0;
                int line = 0;
                int offsetLine = 20;
                //gfx.DrawString("ID", new XFont("Verdana", 11, XFontStyle.Bold), XBrushes.Black, new XPoint(XUnit.FromCentimeter(18), XUnit.FromCentimeter(3)));
                gfx.DrawString("Points ", new XFont("Verdana", 11, XFontStyle.Bold), XBrushes.Black, new XPoint(XUnit.FromCentimeter(offsetLine), XUnit.FromCentimeter(3)));
                gfx.DrawString("Reason ", new XFont("Verdana", 11, XFontStyle.Bold), XBrushes.Black, new XPoint(XUnit.FromCentimeter(offsetLine+2), XUnit.FromCentimeter(3)));

                foreach (Penalty penalty in cbct.penalty)
                {
                    sum += penalty.Points;
                    line++;
                    //gfx.DrawString(penalty.ID.ToString(), new XFont("Verdana", 9, XFontStyle.Regular), XBrushes.Black, new XPoint(XUnit.FromCentimeter(18), XUnit.FromCentimeter(3 + line * 0.4)));
                    gfx.DrawString(penalty.Points.ToString(), new XFont("Verdana", 9, XFontStyle.Regular), XBrushes.Black, new XPoint(XUnit.FromCentimeter(offsetLine), XUnit.FromCentimeter(3 + line * 0.4)));

                    List<String> reason = getWrapped(penalty.Reason);
                    bool loop = false;
                    foreach (String s in reason)
                    {
                        gfx.DrawString(s, new XFont("Verdana", 9, XFontStyle.Regular), XBrushes.Black, new XPoint(XUnit.FromCentimeter(offsetLine+2), XUnit.FromCentimeter(3 + line * 0.4)));
                        line++;
                        loop = true;
                    }
                    if (loop)
                    {
                        line--;
                    }
                }
                line++;
                //gfx.DrawString("-", new XFont("Verdana", 9, XFontStyle.Regular), XBrushes.Black, new XPoint(XUnit.FromCentimeter(18), XUnit.FromCentimeter(3 + line * 0.4)));
                gfx.DrawString(sum.ToString(), new XFont("Verdana", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(XUnit.FromCentimeter(offsetLine), XUnit.FromCentimeter(3 + line * 0.4)));
                gfx.DrawString("Total Points", new XFont("Verdana", 10, XFontStyle.Bold), XBrushes.Black, new XPoint(XUnit.FromCentimeter(offsetLine+2), XUnit.FromCentimeter(3 + line * 0.4)));


                String path = pathToPDF.Replace(".pdf",(counter++ + "_"+ getTeamDsc(c, cbct.competitionTeam.ID_Team)+".pdf"));
                doc.Save(path);
                doc.Close();
                Process.Start(path);
            }    
        }

        private static List<String> getWrapped(String s)
        {
            List<String> result = new List<String>();
            string[] splitted = s.Split(new char[] { ' ' });
            int currentLenght = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < splitted.Length; i++)
            {
                if (currentLenght + splitted[i].Length < 45)
                {
                    currentLenght += splitted.Length;
                    sb.Append(splitted[i]);
                    sb.Append(" ");
                }
                else
                {
                    currentLenght = 0;
                    result.Add(sb.ToString());
                    sb = new StringBuilder();
                    i--;
                }
            }
            result.Add(sb.ToString());
            return result;
        }

        private static string getTeamDsc(Client.Client c, int ID_Team)
        {
            NetworkObjects.Team team = c.getTeam(ID_Team);
            NetworkObjects.Pilot pilot = c.getPilot(team.ID_Pilot);
            StringBuilder sb = new StringBuilder();
            sb.Append(team.StartID).Append(" ");
            sb.Append(pilot.Name).Append(" ").Append(pilot.Surename);
            if (team.ID_Navigator > 0)
            {
                NetworkObjects.Pilot navi = c.getPilot(team.ID_Navigator);
                sb.Append(" - ").Append(navi.Name).Append(" ").Append(navi.Surename);
            }
            return sb.ToString();
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

            AddCompetitionAndLogo(Client, sec);

            sec.AddParagraph("Qualification Round: " + competition.Name);
            sec.AddParagraph("Startlist");

            Table table = sec.AddTable();
            table.Borders.Visible = true;

            table.AddColumn(Unit.FromCentimeter(1.5));
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
            row.Cells[7].AddParagraph("Take Off (UTC)");
            row.Cells[8].AddParagraph("Start Gate (UTC)");
            row.Cells[9].AddParagraph("End Gate (UTC)");
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
                r.Cells[10].AddParagraph(Enum.GetName(NetworkObjects.Route.A.GetType(), ct.Route));
            }

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            renderer.Document = doc;
            renderer.RenderDocument();
            renderer.PdfDocument.Save(pathToPDF);

            Process.Start(pathToPDF);
        }
    }
}
