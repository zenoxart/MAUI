using System;
using System.Collections.Generic;
using System.Linq;

namespace Maui.Erweitert.Udp
{
    /// <summary>
    /// Stellt einen User Datagram Protocol - Server zum Verwalten von Anfragen
    /// </summary>
    public class UdpServer : ViewModelAppObjekt
    {
        // <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private ClientInfo _ClientInformationen;

        /// <summary>
        /// Ruft die Informationen zu den Clients ab oder legt diese fest
        /// </summary>
        public ClientInfo ClientInformationen
        {
            get => this._ClientInformationen;
            set => this._ClientInformationen = value;
        }


        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private List<UdpRaum> _ChatRäume;

        /// <summary>
        /// Ruft eine Auflistung an Clients ab oder legt diese fest
        /// </summary>
        public List<UdpRaum> ChatRäume
        {
            get
            {
                this._ChatRäume ??= [];
                return this._ChatRäume;
            }
            set => this._ChatRäume = value;
        }

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private System.Net.Sockets.Socket _ServerSocket;

        /// <summary>
        /// Ruft den Socket mit dem der Server kommuniziert ab oder legt diesen fest
        /// </summary>
        public System.Net.Sockets.Socket ServerSocket
        {
            get => this._ServerSocket;
            set => this._ServerSocket = value;
        }

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private byte[] _ByteData;

        /// <summary>
        /// Ruft die Daten ab oder legt diese fest
        /// </summary>
        public byte[] ByteData
        {
            get
            {
                this._ByteData ??= new byte[1024];

                return this._ByteData;
            }
            set => this._ByteData = value;
        }


        /// <summary>
        /// Stellt ein Event zum Erhalten von Protokollen
        /// </summary>
        public void OnReceive(IAsyncResult ar)
        {
            try
            {
                System.Net.EndPoint EndPunktSender = 
                    new System.Net.IPEndPoint(System.Net.IPAddress.Any, 0) 
                    as System.Net.EndPoint;


                this.ServerSocket.EndReceiveFrom(ar, ref EndPunktSender);

                // Konvertiert alle Daten in ein Data-Objekt
                Data NachrichtErhalten = new(this.ByteData);

                Data NachrichtZumSenden = new() { BefehlTyp = NachrichtErhalten.BefehlTyp, ClientName = NachrichtErhalten.ClientName };

                byte[] Nachricht;

                switch (NachrichtErhalten.BefehlTyp)
                {
                    case UdpBefehle.Login:
                        // Wenn noch keine Räume existieren
                        if (this.ChatRäume.Count == 0)
                        {
                            // Erstelle einen neuen mit der Nummer 0
                            this.ChatRäume.Add(new UdpRaum() { RaumNummer = 0 });
                        }

                        // Hole den Raum mit der Nummer 0
                        UdpRaum room = this.ChatRäume.Where(x => x.RaumNummer == 0).Single();

                        // Fügt den Benutzer dem Raum 0 hinzu
                        room.Add(new ClientInfo
                        {
                            EndPunkt = EndPunktSender,
                            ClientBenutzerName = NachrichtErhalten.ClientName
                        });

                        NachrichtZumSenden.ClientNachricht = "<<<" + NachrichtErhalten.ClientName + " ist dem Raum " + room.RaumNummer + " begetreten.>>>";

                        break;
                    case UdpBefehle.Logout:

                        int nIndex = 0;
                        int roomNumber = 0;
                        foreach (UdpRaum Raum in this.ChatRäume)
                        {
                            foreach (ClientInfo Benutzer in Raum)
                            {
                                if (Benutzer.EndPunkt == EndPunktSender)
                                {
                                    roomNumber = Raum.RaumNummer;
                                    Raum.Remove(Benutzer);
                                }
                                ++nIndex;
                            }
                        }


                        NachrichtZumSenden.ClientNachricht = "<<<" + NachrichtErhalten.ClientName + " hat den Raum " + roomNumber + " verlassen...>>>";
                        break;
                    case UdpBefehle.Message:


                        //Sende den Text
                        NachrichtZumSenden.ClientNachricht = NachrichtErhalten.ClientName + ": " + NachrichtErhalten.ClientNachricht;


                        break;
                    case UdpBefehle.List:

                        //Send the names of all users in the chat room to the new user
                        NachrichtZumSenden.BefehlTyp = UdpBefehle.List;
                        NachrichtZumSenden.ClientName = null;
                        NachrichtZumSenden.ClientNachricht = null;
                        NachrichtZumSenden.RaumNummer = NachrichtErhalten.RaumNummer;
                        //Collect the names of the user in the chat room
                        foreach (ClientInfo client in ChatRäume.Where(x => x.RaumNummer == NachrichtZumSenden.RaumNummer).Single())
                        {
                            //To keep things simple we use asterisk as the marker to separate the user names
                            NachrichtZumSenden.ClientNachricht += client.ClientBenutzerName + "*";
                        }

                        Nachricht = NachrichtZumSenden.ToByte();

                        //Send the name of the users in the chat room
                        this.ServerSocket.BeginSendTo(Nachricht, 0, Nachricht.Length, System.Net.Sockets.SocketFlags.None, EndPunktSender,
                                new AsyncCallback(this.OnSend), EndPunktSender);

                        break;
                    case UdpBefehle.Null:
                        break;
                    default:
                        break;
                }



            }
            catch (Exception ex)
            {

                this.OnFehlerAufgetreten(new Kern.FehlerAufgetretenEventArgs(ex));
            }
        }

        /// <summary>
        /// Definiert die Aktion wärend des Sendens
        /// </summary>
        /// <param name="ar"></param>
        public void OnSend(IAsyncResult ar)
        {
            try
            {
                this.ServerSocket.EndSend(ar);
            }
            catch (Exception ex)
            {

                this.OnFehlerAufgetreten(new Kern.FehlerAufgetretenEventArgs(ex));
                //MessageBox.Show(ex.Message, "SGSServerUDP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

