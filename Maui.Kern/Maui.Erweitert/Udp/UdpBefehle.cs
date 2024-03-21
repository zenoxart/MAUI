namespace Maui.Erweitert.Udp
{
    /// <summary>
    /// Stellt eine Auflistung an User Datagram Protocol-Protokoll-Befehlen
    /// </summary>
    public enum UdpBefehle
    {
        Login,      //Anmelden am Server
        Logout,     //Abmelden vom Server
        Message,    //Sendet eine Nachricht an alle Clients
        List,       //Holt eine Liste an Benutzern in einem Raum
        Null        //Kein Befehl
    }
}
