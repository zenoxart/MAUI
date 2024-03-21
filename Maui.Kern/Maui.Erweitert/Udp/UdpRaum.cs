namespace Maui.Erweitert.Udp
{
    // Stellt eine Liste an Clients von einem User Datagram Protocol-Raum
    public class UdpRaum : System.Collections.ArrayList
    {
        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private int _RaumNummer;

        /// <summary>
        /// Ruft die Raumnummer ab oder legt diese fest
        /// </summary>
        public int RaumNummer
        {
            get => this._RaumNummer;
            set => this._RaumNummer = value;
        }

    }
}

