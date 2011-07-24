using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirNavigationRaceLive.Components.Model;
using AnrlInterfaces;
using System.Windows.Forms;

namespace AirNavigationRaceLive.Components.Helper
{
    public static class ParcourGenerator
    {
        public static void GenerateParcour(Parcour parcour, Converter c, double lenght, int amount, double channel, double zoneSize)
        {
            try
            {
                Line Start = parcour.Lines.Single(p => p.LineType == LineType.START) as Line;
                Line Ende = parcour.Lines.Single(p => p.LineType == LineType.END) as Line;
                Line LineOfNoReturn = parcour.Lines.Single(p => p.LineType == LineType.LINEOFNORETURN) as Line;
                double dist = Converter.Distance(Start.PointA, Ende.PointA);
                double dist2 = Converter.Distance(Start.PointB, Ende.PointB);
                if (dist < lenght - 1 && dist2 < lenght - 1)
                {

                }
                else
                {
                    MessageBox.Show("Minimal Distancen bewteen Start and End bigger than configured Parcour length-1", "Error while generating Parcour");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error while generating Parcour");
            }
        }
    }
}
