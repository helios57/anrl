using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;

namespace ANR.ErrorLog
{
    public static class Log
    {
        public static void WriteToLog(Exception ex)
        {
            string filename = Environment.CurrentDirectory + "\\Error.xml";
            if (!System.IO.File.Exists(filename))
            {
                CreateLogDocument();
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(Environment.CurrentDirectory + "\\Error.xml");
            XmlNode rootNode = doc.GetElementsByTagName("Exceptions")[0];
            XmlNode exNode = doc.CreateElement("Exception");
                
            List<XmlNode> nodes = new List<XmlNode>();
            XmlNode n0 = doc.CreateElement("ErrorMessage");
            n0.InnerText = ex.Message;

            XmlNode n1 = doc.CreateElement("Source");
            n1.InnerText = ex.Source;

            XmlNode n2 = doc.CreateElement("Stacktrace");
            n2.InnerText = ex.StackTrace;

            exNode.AppendChild(n0);
            exNode.AppendChild(n1);
            exNode.AppendChild(n2);
            rootNode.AppendChild(exNode);
            doc.Save(filename);
        }

        private static void CreateLogDocument()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode rootNode = doc.CreateElement("Exceptions");
            doc.AppendChild(rootNode);
            doc.Save(Environment.CurrentDirectory + "\\Error.xml");
        }
    }
}
