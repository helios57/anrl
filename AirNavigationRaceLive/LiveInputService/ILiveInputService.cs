using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LiveInputService
{
    //netsh http add urlacl url=http://+:80/gps user=domain\user

    [ServiceContract]
    public interface ILiveInputService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "json",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json)]
        Root PostData(Root root);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "xml",
           RequestFormat = WebMessageFormat.Xml,
           ResponseFormat = WebMessageFormat.Xml)]
        Root PostDataXML(Root root);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "/*")]
        void Options();
    }

    [DataContract]
    public class Root
    {
        [DataMember]
        public List<GPSData> gpsdata = new List<GPSData>();
        [DataMember]
        public Response response = null;
        [DataMember]
        public string exception = "";
    }

    [DataContract]
    public class GPSData
    {
        [DataMember]
        public long timestampSender;
        [DataMember]
        public long timestampGPS;
        [DataMember]
        public double altitude;
        [DataMember]
        public double latitude;
        [DataMember]
        public double longitude;
        [DataMember]
        public double accuracy;
        [DataMember]
        public double speed;
        [DataMember]
        public double bearing;
        [DataMember]
        public string identifier;
        [DataMember]
        public string trackerName;
        [DataMember]
        public int trackerID;
        [DataMember]
        public int ID;
    }

    [DataContract]
    public class Response
    {
        [DataMember]
        public int countAdded = 0;
    }
    /*  <bwiredtravel>
     <model>iPhone</model>
     <devId>21622f43420a5590f327fcd78efb753c55189bff</devId>
     <username>pk</username>
     <password>testing</password>
     <travel>
        <id>1</id> 
        <description>23-03-12 bike</description> 
        <length>2954.76</length>
        <time>1014</time>
        <tpoints>129</tpoints>
        <uplpoints>100</uplpoints> 
        <point>
           <id>104</id>
           <date>1332524797.424494</date>
           <lat>+51.724043</lat>
           <lon>+5.300559</lon>
           <speed>3.911873</speed> 
           <course>72.584372</course>
           <haccu>10.000000</haccu>
           <bat>0.40</bat>
           <vaccu>9.000000</vaccu>
           <altitude>1.645592</altitude>
           <continous>0</continous>
           <tdist>2559.39</tdist>
           <rdist>97.17</rdist>
           <ttime>811</ttime>
        </point>
        <point>
           <id>105</id>
           <date>1332524800.426888</date>
           <lat>+51.724118</lat>
           <lon>+5.300701</lon>
           <speed>3.941704</speed>
           <course>41.977433</course>
           <haccu>10.000000</haccu>
           <bat>0.40</bat>
           <vaccu>9.373876</vaccu>
           <altitude>2.436264</altitude>
           <continous>1</continous>
           <tdist>2572.19</tdist>
           <rdist>12.80</rdist>
           <ttime>814</ttime>
        </point>
     </travel>
  </bwiredtravel>*/
}
