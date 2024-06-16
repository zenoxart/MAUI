using Maui.Kern.Manager.Logging;

namespace Maui.Erweitert.Udp
{
    /// <summary>
    /// Stellt einen Client zum Verwalten von User Datagram Protocol-Verbindungen
    /// </summary>
    public class UdpClient : ViewModelAppObjekt
    {

        public UdpClient(string ZielServer, int Port, string BenutzerName)
        {
            this.ZielServerAdresse = ZielServer;
            this.UdpServerPort = Port;
            this.BenutzerName = BenutzerName;
        }

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private System.Net.Sockets.Socket _ServerSocket;

        /// <summary>
        /// Ruft den Web-Socket für UDP-Request und Responses ab oder legt diesen fest
        /// </summary>
        public System.Net.Sockets.Socket ServerSocket
        {
            get
            {
                this._ServerSocket ??=
                        new System.Net.Sockets.Socket(
                            System.Net.Sockets.AddressFamily.InterNetwork,
                            System.Net.Sockets.SocketType.Dgram,
                            System.Net.Sockets.ProtocolType.Udp);

                return this._ServerSocket;
            }
            set => this._ServerSocket = value;
        }

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private System.Net.EndPoint _EndPunktServer;

        /// <summary>
        /// Definiert den EndPunkt des UDP-Servers
        /// </summary>
        public System.Net.EndPoint EndPunktServer
        {
            get => this._EndPunktServer;
            set => this._EndPunktServer = value;
        }

        /// <summary>
        /// Verbindet den Client mit dem Ziel-UDP-Server
        /// </summary>
        public bool VerbindeZuServer()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.ZielServerAdresse) && this.UdpServerPort != 0 && !string.IsNullOrEmpty(this.BenutzerName))
                {
                    System.Net.IPAddress ipAddress = System.Net.IPAddress.Parse(this.ZielServerAdresse);

                    //Server is listening on port 1000
                    EndPunktServer = new System.Net.IPEndPoint(ipAddress, this.UdpServerPort);

                    // Teste ob der Server erreichbar ist, wenn nicht => abbrechen
                    var ZwischenErgebnis = new System.Net.NetworkInformation.Ping().Send(ipAddress);

                    if (ZwischenErgebnis.Status != System.Net.NetworkInformation.IPStatus.Success)
                        return false;
                    

                    // Erstelle eine Nachricht zum Anmelden am Server
                    byte[] AnmeldeNachricht = new Data
                    {
                        BefehlTyp = UdpBefehle.Login,
                        ClientNachricht = null,
                        ClientName = this.BenutzerName
                    }.ToByte();



                    this.ServerSocket.BeginSendTo(
                         AnmeldeNachricht,
                         0,
                         AnmeldeNachricht.Length,
                         System.Net.Sockets.SocketFlags.None,
                         EndPunktServer,
                         new AsyncCallback(OnSend),
                         null);

                    LogManager.Info($"The UDP-Conncetions was build up correctly!");
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogManager.Error($"An Error occured while building up the UDP-Conncetion: {ex.StackTrace}");
                return false;
            }


        }
        /// <summary>
        /// Sendet Daten über einen Asyncronen Callback zum UDP-Server
        /// </summary>
        private void OnSend(IAsyncResult ar)
        {
            try
            {
                this.ServerSocket.EndSend(ar);

            }
            catch (Exception ex)
            {
                this.OnFehlerAufgetreten(new Kern.FehlerAufgetretenEventArgs(ex));
            }
        }

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private string _ZielServerAdresse;

        /// <summary>
        /// Ruft die ZielAdresse des Servers ab oder legt diese fest
        /// </summary>
        public string ZielServerAdresse
        {
            get => this._ZielServerAdresse;
            set => this._ZielServerAdresse = value;
        }

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        /// <remarks>
        /// Standart-Port für den UDP-Server ist 1000
        /// </remarks>
        private int _UdpServerPort = 1000;

        /// <summary>
        /// Ruft den Port mit dem der UDP-Server/Client kommuniziert ab oder legt diesen fest
        /// </summary>
        public int UdpServerPort
        {
            get => this._UdpServerPort;
            set => this._UdpServerPort = value;
        }

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private string _BenutzerName;

        /// <summary>
        /// Ruft den Namen des Benutzers ab oder legt diesen fest
        /// </summary>
        public string BenutzerName
        {
            get => this._BenutzerName;
            set => this._BenutzerName = value;
        }


    }
}
