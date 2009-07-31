using System.Windows.Forms;
using System;

namespace DataService
{
    /// <summary>
    /// Class to bee Added to an ListView-Controll, contains information about a Tracker
    /// </summary>
    [Serializable]
    public class TrackerListEntry : ListViewItem
    {
        /// <summary>
        /// ID of the Tracker
        /// </summary>
        public int ID_Tracker;
        /// <summary>
        /// IMEI if the Tracker
        /// </summary>
        public string IMEI;
        /// <summary>
        /// ID of the Airplane (if any attaches, else 0 or null)
        /// </summary>
        public int ID_Flugzeug;
        /// <summary>
        /// Name/Type of the Airplane
        /// </summary>
        public String Flugzeug;
        /// <summary>
        /// Name of the Pilot
        /// </summary>
        public String Pilot;

        /// <summary>
        /// Create a new TrackerListEntry for adding to a ListView
        /// </summary>
        /// <param name="ID_Tracker">ID if the Tracker</param>
        /// <param name="IMEI">IMEI of the Tracker</param>
        public TrackerListEntry(int ID_Tracker, string IMEI)
        {
            this.ID_Tracker = ID_Tracker;
            this.IMEI = IMEI;
        }
        /// <summary>
        /// Applies all Data to the ListViewItem and make it ready for Displaying
        /// </summary>
        public void Set()
        {
            this.SubItems.Clear();
            this.Text = ID_Tracker.ToString();
            this.SubItems.Add(IMEI.Trim());
            if (Flugzeug != null && Pilot != null && ID_Flugzeug != 0)
            {
                this.SubItems.Add(Flugzeug.Trim());
                this.SubItems.Add(Pilot.Trim());
                this.SubItems.Add(ID_Flugzeug.ToString());
            }
        }
    }
    /// <summary>
    /// Class for Displaying an Airplane with Pilot in a Line
    /// </summary>
    [Serializable]
    public class AirplaneListEntry
    {
        /// <summary>
        /// Create a new AirplaneListEntry
        /// </summary>
        /// <param name="f">The Airplane to be displayed</param>
        public AirplaneListEntry(t_Flugzeug f)
        {
            ID = f.ID;
            Flugzeug = f.Flugzeug;
            Pilot = f.Pilot;
        }
        /// <summary>
        /// The ID of the Airplane
        /// </summary>
        public int ID;
        /// <summary>
        /// The Name/Type of the Airplane
        /// </summary>
        public string Flugzeug;
        /// <summary>
        /// The Name of the Pilot
        /// </summary>
        public string Pilot;
        /// <summary>
        /// Generating a String showing all important properties of an Airplane
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ID.ToString() + " " + Flugzeug.Trim() + " " + Pilot.Trim();
        }
    }
}
