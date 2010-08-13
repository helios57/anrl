//..begin "File Description"
/*--------------------------------------------------------------------------------*
   Filename:  RemotingHelper.cs
   Tool:      objectiF, CSharpSSvr V7.0.272
 *--------------------------------------------------------------------------------*/
//..end "File Description"

using System;
using System.Text;

// NICHT VERGESSEN: System.Runtime.Remoting.dll ALS VERWEIS ZUFÜGEN!


namespace RemoteHelper
{	
	/// <summary>
	/// Enthält eine Sammlung von statischen Funktionen, die einfaches
	/// Remoting ermöglichen.
	/// </summary>
	public class RemotingHelper
	{
		/// <summary>
		/// Veröffentlicht ein beliebiges von MarshalByRef abgeleitetes Objekt über einen TCP-Kanal für entfernten Zugriff.
		///
		/// Bei aktivierung der Sicherheit über den Parameter "enableSecurity", wird die Kommunikation 
		/// vom Absender signiert, um die Integrität sicherzustellen und zusätzlich verschlüsselt. 
		/// Über den Parameter "impersonate" kann Impersonierung eingeschaltet werden. Bei eingeschalteter
		/// Impersonierung, wird der Remoteaufruf im Kontext des Client-Benutzers ausgeführt.
		/// </summary>
		/// <remarks>
		/// Der TCP-Kanal wird automatisch konfiguriert und registriert. Die Kanal-Registrierung bleibt 
		/// über diesen Prozeduraufruf hinaus gültig. Wenn sie die selbe TCP-Anschlussnummer mehrmals an
		/// diese Methode übergeben, wird der bestehene Kanal verwendet. Die Sicherheitskonfiguration des 
		/// ersten Aufrufs ist deshalb entscheidend. Wenn sie für spätere Aufrufe andere Werte für die
		/// Parameter "enableSecurity" oder "impersonate" angeben, werden diese nicht berücksichtigt, 
		/// da der bestehende Kanal verwendet wird!
		/// </remarks>
		/// <param name="instance">Zu veröffentlichendes Objekt</param>
		/// <param name="publicName">Öffentlicher Name (Über diesen Namen greifen Clients entfernt auf das Objekt zu!)</param>
		/// <param name="tcpPort">TCP-Anschlussnummer</param>
		/// <param name="enableSecurity">Schalter für Sicherheit</param>
		/// <param name="impersonate">Schalter für Impersonierung</param>
		public static void PublishObjectOverTCP(MarshalByRefObject instance,string publicName,int tcpPort, bool enableSecurity,bool impersonate)
		{
		    // Kanal einrichten (Falls dies noch nicht geschehen ist!)
		    SetupServerChannel(tcpPort, enableSecurity, impersonate);
		
		    // Objektinstanz über den TCP-Kanal für entfernten Zugriff veröffentlichen
		    System.Runtime.Remoting.RemotingServices.Marshal(instance, publicName);            
		}
		
		/// <summary>
		/// Veröffentlicht einen beliebigen von MarshalByRef abgeleiteten Typ als Singleton über einen 
		/// TCP-Kanal für entfernten Zugriff.
		///
		/// Bei aktivierung der Sicherheit über den Parameter "enableSecurity", wird die Kommunikation 
		/// vom Absender signiert, um die Integrität sicherzustellen und zusätzlich verschlüsselt. 
		/// Über den Parameter "impersonate" kann Impersonierung eingeschaltet werden. Bei eingeschalteter
		/// Impersonierung, wird der Remoteaufruf im Kontext des Client-Benutzers ausgeführt.
		/// </summary>
		/// <remarks>
		/// Der TCP-Kanal wird automatisch konfiguriert und registriert. Die Kanal-Registrierung bleibt 
		/// über diesen Prozeduraufruf hinaus gültig. Wenn sie die selbe TCP-Anschlussnummer mehrmals an
		/// diese Methode übergeben, wird der bestehene Kanal verwendet. Die Sicherheitskonfiguration des 
		/// ersten Aufrufs ist deshalb entscheidend. Wenn sie für spätere Aufrufe andere Werte für die
		/// Parameter "enableSecurity" oder "impersonate" angeben, werden diese nicht berücksichtigt, 
		/// da der bestehende Kanal verwendet wird!
		/// </remarks>
		/// <param name="type">Zu veröffentlichender Typ</param>
		/// <param name="publicName">Öffentlicher Name (Über diesen Namen greifen Clients entfernt auf das Objekt zu!)</param>
		/// <param name="tcpPort">TCP-Anschlussnummer</param>
		/// <param name="enableSecurity">Schalter für Sicherheit</param>
		/// <param name="impersonate">Schalter für Impersonierung</param>
		public static void PublishSingletonTypeOverTCP(Type type, string publicName, int tcpPort, bool enableSecurity, bool impersonate)
		{
		    // Kanal einrichten (Falls dies noch nicht geschehen ist!)
		    SetupServerChannel(tcpPort, enableSecurity, impersonate);
		
		    // Typ Singleton-Aktiviert veröffentlichen
		    System.Runtime.Remoting.RemotingConfiguration.RegisterWellKnownServiceType(type, publicName, System.Runtime.Remoting.WellKnownObjectMode.Singleton);
		}
		
		/// <summary>
		/// Veröffentlicht einen beliebigen von MarshalByRef abgeleiteten Typ als SingleCall über einen 
		/// TCP-Kanal für entfernten Zugriff.
		///
		/// Bei aktivierung der Sicherheit über den Parameter "enableSecurity", wird die Kommunikation 
		/// vom Absender signiert, um die Integrität sicherzustellen und zusätzlich verschlüsselt. 
		/// Über den Parameter "impersonate" kann Impersonierung eingeschaltet werden. Bei eingeschalteter
		/// Impersonierung, wird der Remoteaufruf im Kontext des Client-Benutzers ausgeführt.
		/// </summary>
		/// <remarks>
		/// Der TCP-Kanal wird automatisch konfiguriert und registriert. Die Kanal-Registrierung bleibt 
		/// über diesen Prozeduraufruf hinaus gültig. Wenn sie die selbe TCP-Anschlussnummer mehrmals an
		/// diese Methode übergeben, wird der bestehene Kanal verwendet. Die Sicherheitskonfiguration des 
		/// ersten Aufrufs ist deshalb entscheidend. Wenn sie für spätere Aufrufe andere Werte für die
		/// Parameter "enableSecurity" oder "impersonate" angeben, werden diese nicht berücksichtigt, 
		/// da der bestehende Kanal verwendet wird!
		/// </remarks>
		/// <param name="type">Zu veröffentlichender Typ</param>
		/// <param name="publicName">Öffentlicher Name (Über diesen Namen greifen Clients entfernt auf das Objekt zu!)</param>
		/// <param name="tcpPort">TCP-Anschlussnummer</param>
		/// <param name="enableSecurity">Schalter für Sicherheit</param>
		/// <param name="impersonate">Schalter für Impersonierung</param>
		public static void PublishSingleCallTypeOverTCP(Type type, string publicName, int tcpPort, bool enableSecurity, bool impersonate)
		{
		    // Kanal einrichten (Falls dies noch nicht geschehen ist!)
		    SetupServerChannel(tcpPort, enableSecurity, impersonate);
		
		    // Typ SingleCall-Aktiviert veröffentlichen
		    System.Runtime.Remoting.RemotingConfiguration.RegisterWellKnownServiceType(type, publicName, System.Runtime.Remoting.WellKnownObjectMode.SingleCall);
		}
		
		/// <summary>
		/// Gibt einen Proxy auf ein entferntes Objekt zurück. 
		/// 
		/// Das entfernte Objekt wird über eine TCP-Verbindung ferngesteuert. 
		/// Der Proxy vermittelt lokale Methodenaufrufe an das entfernte Objekt.
		/// Rückgabe-Werte können lokal über den proxy entgegen genommen werden.
		/// 
		/// Bei aktivierung der Sicherheit über den Parameter "enableSecurity", wird die Kommunikation 
		/// vom Absender signiert, um die Integrität sicherzustellen und zusätzlich verschlüsselt. 
		/// Über den Parameter "impersonate" kann Impersonierung eingeschaltet werden. Bei eingeschalteter
		/// Impersonierung, wird der Remoteaufruf im Kontext des Client-Benutzers ausgeführt.
		/// </summary>
		/// <param name="remoteType">Typ-Informationen des entfernten Objekts (übergeben Sie entweder den Typ der Klasse oder den typ einer, vom entfernten Objekt, implementierten Schnittstelle an!)</param>
		/// <param name="publicName">Öffentlicher Name des entfernten Objekts</param>
		/// <param name="serverName">DNS-Computername des Servers oder dessen IP-Adresse</param>
		/// <param name="tcpPort">TCP-Anschlussnummer des Servers</param>
		/// <param name="enableSecurity">Schalter für Sicherheit</param>
		/// <param name="impersonate">Schalter für Impersonierung</param>
		/// <returns>Transparentes Proxy-Objekt</returns>
		public static object GetRemoteObjectOverTCP(Type remoteType, string publicName, string serverName, int tcpPort, bool enableSecurity, bool impersonate)
		{
		    // Kanal einrichten (Falls dies noch nicht geschehen ist!)
		    SetupClientChannel(enableSecurity, impersonate);
		
		    // URI für die Adressierung des entfernten Objekts generieren
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
		/// Richtet einen TCP-Serverkanal ein. Serverkanäle nehmen Anfragen von Clients entgegen.
		/// 
		/// Bei aktivierung der Sicherheit über den Parameter "enableSecurity", wird die Kommunikation 
		/// vom Absender signiert, um die Integrität sicherzustellen und zusätzlich verschlüsselt. 
		/// Über den Parameter "impersonate" kann Impersonierung eingeschaltet werden. Bei eingeschalteter
		/// Impersonierung, wird der Remoteaufruf im Kontext des Client-Benutzers ausgeführt.
		/// </summary>
		/// <param name="tcpPort">TCP-Anschlussnummer</param>
		/// <param name="enableSecurity">Schalter für Sicherheit</param>
		/// <param name="impersonate">Schalter für Impersonierung</param>
		public static void SetupServerChannel(int tcpPort, bool enableSecurity,bool impersonate)
		{
		    // Kanalnamen erzeugen
		    string channelName = "RainbirdEasyRemotingServer" + Convert.ToString(tcpPort);
		
		    // Kanal suchen
		    System.Runtime.Remoting.Channels.IChannel channel = System.Runtime.Remoting.Channels.ChannelServices.GetChannel(channelName);
		
		    // Wenn der Kanal nicht gefunden wurde ...
		    if (channel == null)
		    {
		        // Konfiguration für den TCP-Kanal erstellen
		        System.Collections.IDictionary channelSettings = new System.Collections.Hashtable();
		        channelSettings["name"] = channelName;
		        channelSettings["port"] = tcpPort;
		        channelSettings["secure"] = enableSecurity;
		
		        // Wenn Sicherheit aktiviert ist ...
		        if (enableSecurity)
		        {
		            // Impersonierung entsprechend der Einstellung aktivieren oder deaktivieren
		            channelSettings["tokenImpersonationLevel"] = impersonate ? System.Security.Principal.TokenImpersonationLevel.Impersonation : System.Security.Principal.TokenImpersonationLevel.Identification;
		
		            // Signatur und Verschlüssung explizit aktivieren
		            channelSettings["protectionLevel"] = System.Net.Security.ProtectionLevel.EncryptAndSign;
		        }
		        // Binäre Serialisierung von komplexen Objekten aktivieren
		        System.Runtime.Remoting.Channels.BinaryServerFormatterSinkProvider provider = new System.Runtime.Remoting.Channels.BinaryServerFormatterSinkProvider();
		        provider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
		
		        // Neuen TCP-Kanal erzeugen
		        channel = new System.Runtime.Remoting.Channels.Tcp.TcpChannel(channelSettings, null, provider);
		
		        // Kanal registrieren
		        System.Runtime.Remoting.Channels.ChannelServices.RegisterChannel(channel, enableSecurity);
		    }
		}
		
		/// <summary>
		/// Richtet einen TCP-Clientkanal ein. Clientkanäle senden Anfragen an Serverkanäle.
		/// 
		/// Bei aktivierung der Sicherheit über den Parameter "enableSecurity", wird die Kommunikation 
		/// vom Absender signiert, um die Integrität sicherzustellen und zusätzlich verschlüsselt. 
		/// Über den Parameter "impersonate" kann Impersonierung eingeschaltet werden. Bei eingeschalteter
		/// Impersonierung, wird der Remoteaufruf im Kontext des Client-Benutzers ausgeführt.
		/// <remarks>
		/// Achtung!
		/// 
		/// Die Sicherheitseinstellungen des Client-Kanals müssen mit denen des Server-Kanals genau 
		/// übereinstimmen. Ansonsten werden Sicherheitsprobleme auftreten.
		/// </remarks>
		/// </summary>      
		/// <param name="enableSecurity">Schalter für Sicherheit</param>
		/// <param name="impersonate">Schalter für Impersonierung</param>
		public static void SetupClientChannel(bool enableSecurity, bool impersonate)
		{
		    // Kanalnamen erzeugen
		    string channelName = "RainbirdEasyRemotingClient"; 
		
		    // Kanal suchen
		    System.Runtime.Remoting.Channels.IChannel channel = System.Runtime.Remoting.Channels.ChannelServices.GetChannel(channelName);
		
		    // Wenn der Kanal nicht gefunden wurde ...
		    if (channel == null)
		    {
		        // Konfiguration für den TCP-Kanal erstellen
		        System.Collections.IDictionary channelSettings = new System.Collections.Hashtable();
		        channelSettings["port"] = 0;
		        channelSettings["name"] = channelName;                
		        channelSettings["secure"] = enableSecurity;
		
		        // Wenn Sicherheit aktiviert ist ...
		        if (enableSecurity)
		        {
		            // Impersonierung entsprechend der Einstellung aktivieren oder deaktivieren
		            channelSettings["tokenImpersonationLevel"] = impersonate ? System.Security.Principal.TokenImpersonationLevel.Impersonation : System.Security.Principal.TokenImpersonationLevel.Identification;
		
		            // Signatur und Verschlüssung explizit aktivieren
		            channelSettings["protectionLevel"] = System.Net.Security.ProtectionLevel.EncryptAndSign;
		        }
		        // Binäre Serialisierung von komplexen Objekten aktivieren
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