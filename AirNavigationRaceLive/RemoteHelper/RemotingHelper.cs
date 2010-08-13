//..begin "File Description"
/*--------------------------------------------------------------------------------*
   Filename:  RemotingHelper.cs
   Tool:      objectiF, CSharpSSvr V7.0.272
 *--------------------------------------------------------------------------------*/
//..end "File Description"

using System;
using System.Text;

// NICHT VERGESSEN: System.Runtime.Remoting.dll ALS VERWEIS ZUF�GEN!


namespace RemoteHelper
{	
	/// <summary>
	/// Enth�lt eine Sammlung von statischen Funktionen, die einfaches
	/// Remoting erm�glichen.
	/// </summary>
	public class RemotingHelper
	{
		/// <summary>
		/// Ver�ffentlicht ein beliebiges von MarshalByRef abgeleitetes Objekt �ber einen TCP-Kanal f�r entfernten Zugriff.
		///
		/// Bei aktivierung der Sicherheit �ber den Parameter "enableSecurity", wird die Kommunikation 
		/// vom Absender signiert, um die Integrit�t sicherzustellen und zus�tzlich verschl�sselt. 
		/// �ber den Parameter "impersonate" kann Impersonierung eingeschaltet werden. Bei eingeschalteter
		/// Impersonierung, wird der Remoteaufruf im Kontext des Client-Benutzers ausgef�hrt.
		/// </summary>
		/// <remarks>
		/// Der TCP-Kanal wird automatisch konfiguriert und registriert. Die Kanal-Registrierung bleibt 
		/// �ber diesen Prozeduraufruf hinaus g�ltig. Wenn sie die selbe TCP-Anschlussnummer mehrmals an
		/// diese Methode �bergeben, wird der bestehene Kanal verwendet. Die Sicherheitskonfiguration des 
		/// ersten Aufrufs ist deshalb entscheidend. Wenn sie f�r sp�tere Aufrufe andere Werte f�r die
		/// Parameter "enableSecurity" oder "impersonate" angeben, werden diese nicht ber�cksichtigt, 
		/// da der bestehende Kanal verwendet wird!
		/// </remarks>
		/// <param name="instance">Zu ver�ffentlichendes Objekt</param>
		/// <param name="publicName">�ffentlicher Name (�ber diesen Namen greifen Clients entfernt auf das Objekt zu!)</param>
		/// <param name="tcpPort">TCP-Anschlussnummer</param>
		/// <param name="enableSecurity">Schalter f�r Sicherheit</param>
		/// <param name="impersonate">Schalter f�r Impersonierung</param>
		public static void PublishObjectOverTCP(MarshalByRefObject instance,string publicName,int tcpPort, bool enableSecurity,bool impersonate)
		{
		    // Kanal einrichten (Falls dies noch nicht geschehen ist!)
		    SetupServerChannel(tcpPort, enableSecurity, impersonate);
		
		    // Objektinstanz �ber den TCP-Kanal f�r entfernten Zugriff ver�ffentlichen
		    System.Runtime.Remoting.RemotingServices.Marshal(instance, publicName);            
		}
		
		/// <summary>
		/// Ver�ffentlicht einen beliebigen von MarshalByRef abgeleiteten Typ als Singleton �ber einen 
		/// TCP-Kanal f�r entfernten Zugriff.
		///
		/// Bei aktivierung der Sicherheit �ber den Parameter "enableSecurity", wird die Kommunikation 
		/// vom Absender signiert, um die Integrit�t sicherzustellen und zus�tzlich verschl�sselt. 
		/// �ber den Parameter "impersonate" kann Impersonierung eingeschaltet werden. Bei eingeschalteter
		/// Impersonierung, wird der Remoteaufruf im Kontext des Client-Benutzers ausgef�hrt.
		/// </summary>
		/// <remarks>
		/// Der TCP-Kanal wird automatisch konfiguriert und registriert. Die Kanal-Registrierung bleibt 
		/// �ber diesen Prozeduraufruf hinaus g�ltig. Wenn sie die selbe TCP-Anschlussnummer mehrmals an
		/// diese Methode �bergeben, wird der bestehene Kanal verwendet. Die Sicherheitskonfiguration des 
		/// ersten Aufrufs ist deshalb entscheidend. Wenn sie f�r sp�tere Aufrufe andere Werte f�r die
		/// Parameter "enableSecurity" oder "impersonate" angeben, werden diese nicht ber�cksichtigt, 
		/// da der bestehende Kanal verwendet wird!
		/// </remarks>
		/// <param name="type">Zu ver�ffentlichender Typ</param>
		/// <param name="publicName">�ffentlicher Name (�ber diesen Namen greifen Clients entfernt auf das Objekt zu!)</param>
		/// <param name="tcpPort">TCP-Anschlussnummer</param>
		/// <param name="enableSecurity">Schalter f�r Sicherheit</param>
		/// <param name="impersonate">Schalter f�r Impersonierung</param>
		public static void PublishSingletonTypeOverTCP(Type type, string publicName, int tcpPort, bool enableSecurity, bool impersonate)
		{
		    // Kanal einrichten (Falls dies noch nicht geschehen ist!)
		    SetupServerChannel(tcpPort, enableSecurity, impersonate);
		
		    // Typ Singleton-Aktiviert ver�ffentlichen
		    System.Runtime.Remoting.RemotingConfiguration.RegisterWellKnownServiceType(type, publicName, System.Runtime.Remoting.WellKnownObjectMode.Singleton);
		}
		
		/// <summary>
		/// Ver�ffentlicht einen beliebigen von MarshalByRef abgeleiteten Typ als SingleCall �ber einen 
		/// TCP-Kanal f�r entfernten Zugriff.
		///
		/// Bei aktivierung der Sicherheit �ber den Parameter "enableSecurity", wird die Kommunikation 
		/// vom Absender signiert, um die Integrit�t sicherzustellen und zus�tzlich verschl�sselt. 
		/// �ber den Parameter "impersonate" kann Impersonierung eingeschaltet werden. Bei eingeschalteter
		/// Impersonierung, wird der Remoteaufruf im Kontext des Client-Benutzers ausgef�hrt.
		/// </summary>
		/// <remarks>
		/// Der TCP-Kanal wird automatisch konfiguriert und registriert. Die Kanal-Registrierung bleibt 
		/// �ber diesen Prozeduraufruf hinaus g�ltig. Wenn sie die selbe TCP-Anschlussnummer mehrmals an
		/// diese Methode �bergeben, wird der bestehene Kanal verwendet. Die Sicherheitskonfiguration des 
		/// ersten Aufrufs ist deshalb entscheidend. Wenn sie f�r sp�tere Aufrufe andere Werte f�r die
		/// Parameter "enableSecurity" oder "impersonate" angeben, werden diese nicht ber�cksichtigt, 
		/// da der bestehende Kanal verwendet wird!
		/// </remarks>
		/// <param name="type">Zu ver�ffentlichender Typ</param>
		/// <param name="publicName">�ffentlicher Name (�ber diesen Namen greifen Clients entfernt auf das Objekt zu!)</param>
		/// <param name="tcpPort">TCP-Anschlussnummer</param>
		/// <param name="enableSecurity">Schalter f�r Sicherheit</param>
		/// <param name="impersonate">Schalter f�r Impersonierung</param>
		public static void PublishSingleCallTypeOverTCP(Type type, string publicName, int tcpPort, bool enableSecurity, bool impersonate)
		{
		    // Kanal einrichten (Falls dies noch nicht geschehen ist!)
		    SetupServerChannel(tcpPort, enableSecurity, impersonate);
		
		    // Typ SingleCall-Aktiviert ver�ffentlichen
		    System.Runtime.Remoting.RemotingConfiguration.RegisterWellKnownServiceType(type, publicName, System.Runtime.Remoting.WellKnownObjectMode.SingleCall);
		}
		
		/// <summary>
		/// Gibt einen Proxy auf ein entferntes Objekt zur�ck. 
		/// 
		/// Das entfernte Objekt wird �ber eine TCP-Verbindung ferngesteuert. 
		/// Der Proxy vermittelt lokale Methodenaufrufe an das entfernte Objekt.
		/// R�ckgabe-Werte k�nnen lokal �ber den proxy entgegen genommen werden.
		/// 
		/// Bei aktivierung der Sicherheit �ber den Parameter "enableSecurity", wird die Kommunikation 
		/// vom Absender signiert, um die Integrit�t sicherzustellen und zus�tzlich verschl�sselt. 
		/// �ber den Parameter "impersonate" kann Impersonierung eingeschaltet werden. Bei eingeschalteter
		/// Impersonierung, wird der Remoteaufruf im Kontext des Client-Benutzers ausgef�hrt.
		/// </summary>
		/// <param name="remoteType">Typ-Informationen des entfernten Objekts (�bergeben Sie entweder den Typ der Klasse oder den typ einer, vom entfernten Objekt, implementierten Schnittstelle an!)</param>
		/// <param name="publicName">�ffentlicher Name des entfernten Objekts</param>
		/// <param name="serverName">DNS-Computername des Servers oder dessen IP-Adresse</param>
		/// <param name="tcpPort">TCP-Anschlussnummer des Servers</param>
		/// <param name="enableSecurity">Schalter f�r Sicherheit</param>
		/// <param name="impersonate">Schalter f�r Impersonierung</param>
		/// <returns>Transparentes Proxy-Objekt</returns>
		public static object GetRemoteObjectOverTCP(Type remoteType, string publicName, string serverName, int tcpPort, bool enableSecurity, bool impersonate)
		{
		    // Kanal einrichten (Falls dies noch nicht geschehen ist!)
		    SetupClientChannel(enableSecurity, impersonate);
		
		    // URI f�r die Adressierung des entfernten Objekts generieren
		    StringBuilder uriBuilder = new StringBuilder(@"tcp://");
		    uriBuilder.Append(serverName);
		    uriBuilder.Append(':');
		    uriBuilder.Append(tcpPort);
		    uriBuilder.Append('/');
		    uriBuilder.Append(publicName);
		
		    // Verbindung zum entfernten Objekt herstellen und einen Proxy erzeugen
		    return Activator.GetObject(remoteType, uriBuilder.ToString());
		}
		
		/// <summary>
		/// Richtet einen TCP-Serverkanal ein. Serverkan�le nehmen Anfragen von Clients entgegen.
		/// 
		/// Bei aktivierung der Sicherheit �ber den Parameter "enableSecurity", wird die Kommunikation 
		/// vom Absender signiert, um die Integrit�t sicherzustellen und zus�tzlich verschl�sselt. 
		/// �ber den Parameter "impersonate" kann Impersonierung eingeschaltet werden. Bei eingeschalteter
		/// Impersonierung, wird der Remoteaufruf im Kontext des Client-Benutzers ausgef�hrt.
		/// </summary>
		/// <param name="tcpPort">TCP-Anschlussnummer</param>
		/// <param name="enableSecurity">Schalter f�r Sicherheit</param>
		/// <param name="impersonate">Schalter f�r Impersonierung</param>
		public static void SetupServerChannel(int tcpPort, bool enableSecurity,bool impersonate)
		{
		    // Kanalnamen erzeugen
		    string channelName = "RainbirdEasyRemotingServer" + Convert.ToString(tcpPort);
		
		    // Kanal suchen
		    System.Runtime.Remoting.Channels.IChannel channel = System.Runtime.Remoting.Channels.ChannelServices.GetChannel(channelName);
		
		    // Wenn der Kanal nicht gefunden wurde ...
		    if (channel == null)
		    {
		        // Konfiguration f�r den TCP-Kanal erstellen
		        System.Collections.IDictionary channelSettings = new System.Collections.Hashtable();
		        channelSettings["name"] = channelName;
		        channelSettings["port"] = tcpPort;
		        channelSettings["secure"] = enableSecurity;
		
		        // Wenn Sicherheit aktiviert ist ...
		        if (enableSecurity)
		        {
		            // Impersonierung entsprechend der Einstellung aktivieren oder deaktivieren
		            channelSettings["tokenImpersonationLevel"] = impersonate ? System.Security.Principal.TokenImpersonationLevel.Impersonation : System.Security.Principal.TokenImpersonationLevel.Identification;
		
		            // Signatur und Verschl�ssung explizit aktivieren
		            channelSettings["protectionLevel"] = System.Net.Security.ProtectionLevel.EncryptAndSign;
		        }
		        // Bin�re Serialisierung von komplexen Objekten aktivieren
		        System.Runtime.Remoting.Channels.BinaryServerFormatterSinkProvider provider = new System.Runtime.Remoting.Channels.BinaryServerFormatterSinkProvider();
		        provider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
		
		        // Neuen TCP-Kanal erzeugen
		        channel = new System.Runtime.Remoting.Channels.Tcp.TcpChannel(channelSettings, null, provider);
		
		        // Kanal registrieren
		        System.Runtime.Remoting.Channels.ChannelServices.RegisterChannel(channel, enableSecurity);
		    }
		}
		
		/// <summary>
		/// Richtet einen TCP-Clientkanal ein. Clientkan�le senden Anfragen an Serverkan�le.
		/// 
		/// Bei aktivierung der Sicherheit �ber den Parameter "enableSecurity", wird die Kommunikation 
		/// vom Absender signiert, um die Integrit�t sicherzustellen und zus�tzlich verschl�sselt. 
		/// �ber den Parameter "impersonate" kann Impersonierung eingeschaltet werden. Bei eingeschalteter
		/// Impersonierung, wird der Remoteaufruf im Kontext des Client-Benutzers ausgef�hrt.
		/// <remarks>
		/// Achtung!
		/// 
		/// Die Sicherheitseinstellungen des Client-Kanals m�ssen mit denen des Server-Kanals genau 
		/// �bereinstimmen. Ansonsten werden Sicherheitsprobleme auftreten.
		/// </remarks>
		/// </summary>      
		/// <param name="enableSecurity">Schalter f�r Sicherheit</param>
		/// <param name="impersonate">Schalter f�r Impersonierung</param>
		public static void SetupClientChannel(bool enableSecurity, bool impersonate)
		{
		    // Kanalnamen erzeugen
		    string channelName = "RainbirdEasyRemotingClient"; 
		
		    // Kanal suchen
		    System.Runtime.Remoting.Channels.IChannel channel = System.Runtime.Remoting.Channels.ChannelServices.GetChannel(channelName);
		
		    // Wenn der Kanal nicht gefunden wurde ...
		    if (channel == null)
		    {
		        // Konfiguration f�r den TCP-Kanal erstellen
		        System.Collections.IDictionary channelSettings = new System.Collections.Hashtable();
		        channelSettings["port"] = 0;
		        channelSettings["name"] = channelName;                
		        channelSettings["secure"] = enableSecurity;
		
		        // Wenn Sicherheit aktiviert ist ...
		        if (enableSecurity)
		        {
		            // Impersonierung entsprechend der Einstellung aktivieren oder deaktivieren
		            channelSettings["tokenImpersonationLevel"] = impersonate ? System.Security.Principal.TokenImpersonationLevel.Impersonation : System.Security.Principal.TokenImpersonationLevel.Identification;
		
		            // Signatur und Verschl�ssung explizit aktivieren
		            channelSettings["protectionLevel"] = System.Net.Security.ProtectionLevel.EncryptAndSign;
		        }
		        // Bin�re Serialisierung von komplexen Objekten aktivieren
		        System.Runtime.Remoting.Channels.BinaryServerFormatterSinkProvider provider = new System.Runtime.Remoting.Channels.BinaryServerFormatterSinkProvider();
		        provider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
		
		        // Neuen TCP-Kanal erzeugen
		        channel = new System.Runtime.Remoting.Channels.Tcp.TcpChannel(channelSettings, null, provider);
		
		        // Kanal registrieren
		        System.Runtime.Remoting.Channels.ChannelServices.RegisterChannel(channel, enableSecurity);
		    }
		}
	}
}