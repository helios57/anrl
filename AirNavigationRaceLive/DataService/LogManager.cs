using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace DataService
{
    /// <summary>
    /// Adds Log Entries
    /// </summary>
    static public class LogManager
    {
        /// <summary>
        /// Add a Log entry
        /// </summary>
        /// <param name="DB_Path">Path of the DB to add the Log</param>
        /// <param name="Level">Level of the Log 0 = Error, 4 = information</param>
        /// <param name="Project">Project which throw this log entry</param>
        /// <param name="Text">Description / Data of this Log</param>
        static public void AddLog(string DB_Path,int Level, string Project, string Text)
        {
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_Path);
            t_Log LogEntry = new t_Log();
            LogEntry.level = Level;
            LogEntry.project = Project;
            LogEntry.Text = Text;
            LogEntry.timestamp = DateTime.Now;
            dataContext.t_Logs.InsertOnSubmit(LogEntry);
            dataContext.SubmitChanges();
        }
    }
}
