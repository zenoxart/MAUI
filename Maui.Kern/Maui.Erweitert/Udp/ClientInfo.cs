namespace Maui.Erweitert.Udp
{
    /// <summary>
    /// Stellt eine Datenstruktur welche User Datagram Protocol-wichtige Clientinformationen beinhaltet
    /// </summary>
    public struct ClientInfo
    {
        public System.Net.EndPoint EndPunkt;   //Socket von dem Client
        public string ClientBenutzerName;      //Benutzername mit dem der Benutzer sich im Raum angemeldet hat
    }
}
