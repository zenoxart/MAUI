using System;
using System.Collections.Generic;
using System.Text;

namespace Maui.Erweitert.Udp
{
    /// <summary>
    /// Stellt eine Datenstruktur für ein User Datagram Protocol-Protokoll
    /// </summary>
    public class Data
    {
        public Data()
        {

            this.BefehlTyp = UdpBefehle.Null;
            this.ClientNachricht = null;
            this.ClientName = null;
        }

        /// <summary>
        /// Erstellt ein Objekt aus dem UDP-Byte-Stream
        /// </summary>
        /// <param name="data"></param>
        public Data(byte[] data)
        {
            //Die ersten 4 Bytes sind die Art an Befehl
            this.BefehlTyp = (UdpBefehle)BitConverter.ToInt32(data, 0);

            //Die nächsten 4 Bytes speichern die Länge des Namen
            int NamenLänge = BitConverter.ToInt32(data, 4);

            this.RaumNummer = BitConverter.ToInt32(data, 8);


            //Die nächsten 4 Bytes speichern die Länge der Nachricht
            int NachrichtLänge = BitConverter.ToInt32(data, 12);

            //Stellt sicher, dass der ClientName in der übergebenen data vorhanden ist
            if (NamenLänge > 0)
                this.ClientName = Encoding.UTF8.GetString(data, 16, NamenLänge);
            else
                this.ClientName = null;

            //Stellt sicher, dass die Nachricht nicht leer ist
            if (NachrichtLänge > 0)
                this.ClientNachricht = Encoding.UTF8.GetString(data, 16 + NamenLänge, NachrichtLänge);
            else
                this.ClientNachricht = null;
        }


        //Konvertiert die Struktur in ein byte[]-Protokoll
        public byte[] ToByte()
        {
            List<byte> Ergebnis =
            [
                //Die ersten 4 Bytes sind für die Befehlsart
                .. BitConverter.GetBytes((int)BefehlTyp),
            ];

            //Fügt die Länge des Namen hinzu
            if (ClientName != null)
                Ergebnis.AddRange(BitConverter.GetBytes(ClientName.Length));
            else
                Ergebnis.AddRange(BitConverter.GetBytes(0));

            //Fügt die Raumnummer hinzu
            if (RaumNummer != 0)
                Ergebnis.AddRange(BitConverter.GetBytes(RaumNummer));
            else
                Ergebnis.AddRange(BitConverter.GetBytes(0));


            //Fügt die Länge der Nachricht hinzu
            if (ClientNachricht != null)
                Ergebnis.AddRange(BitConverter.GetBytes(ClientNachricht.Length));
            else
                Ergebnis.AddRange(BitConverter.GetBytes(0));

            //Fügt den Namen hinzu
            if (ClientName != null)
                Ergebnis.AddRange(Encoding.UTF8.GetBytes(ClientName));

            //Fügt die Nachricht hinzu
            if (ClientNachricht != null)
                Ergebnis.AddRange(Encoding.UTF8.GetBytes(ClientNachricht));

            return [.. Ergebnis];
        }

        /// <summary>
        /// Ruft die Raumnummer ab oder legt diese fest
        /// </summary>
        public int RaumNummer { get; set; }

        /// <summary>
        /// Ruft den Cliennamen ab oder legt diesen fest
        /// </summary>
        public string? ClientName { get; set; }

        /// <summary>
        /// Ruft die Nachricht eines Clients ab oder legt diese fest
        /// </summary>
        public string? ClientNachricht { get; set; }

        /// <summary>
        /// Ruft die Befehlsart ab oder legt diese fest
        /// </summary>
        public UdpBefehle BefehlTyp { get; set; }


    }
}
