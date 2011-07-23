///////////////////////////////////////////////////////////
//  BO.cs
//  Implementation of the Class BO
//  Created on:      15-Apr-2008 21:38:39
///////////////////////////////////////////////////////////



using System;
using System.Drawing;
using System.Collections;
using System.Xml;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Data;

namespace PFA.ANR.BusinessLayer {
	public static class BO
    {
        public static void savePdf(Competitor competitor, CompetitorGroup group, string filename)
        {
            // ToDo: get flight
            //Common.savePdf(competitor, competitor.getFlight(group), race, group.Parcours, filename);
        }

        //private static void initDataTables()
        //{
        //    competitorTable = new DataTable();
        //    competitorTable.Columns.AddRange(new DataColumn[]{
        //            new DataColumn("Competition Number"),
        //            new DataColumn("AcCallsign"), 
        //            new DataColumn("Country"), 
        //            new DataColumn("Navigator: First Name"),
        //            new DataColumn("Navigator: Name"),
        //            new DataColumn("Pilot: FirstName"),
        //            new DataColumn("Pilot: Name")});

        //    groupTable = new DataTable();
        //    groupTable.Columns.AddRange(new DataColumn[]{
        //        new DataColumn("Competitor 1"), 
        //        new DataColumn("Competitor 2"),
        //        new DataColumn("Competitor 3"),
        //        new DataColumn("Competitor 4")});
        //}
	}
}