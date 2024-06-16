using Maui.Kern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maui.Kern.Manager.Logging;

namespace Maui.Erweitert
{
    /// <summary>
    /// Erweitert die Infrastruktur um
    /// Dienste für Datenbank Anwendungen
    /// </summary>
    public class ViewModelAppKontext : AppKontext
    {

        /// <summary>
        /// Gibt ein initialisiertes Anwendungsobjekt zurück
        /// </summary>
        /// <typeparam name="T">Gibt den Typ des benötigten Anwendungsobjekts an</typeparam>
        /// <returns>Ein Objekt, bei dem die AppKontext Eigenschaft eingestellt ist</returns>
        /// <remarks>Im Anwendungsprotokoll wird automatisch
        /// ein Eintrag erstellt, dass eine neue Instanz initialisiert wurde</remarks>
        public override T Produziere<T>()
        {
            // Zuerst einmal das machen,
            // was sonst gemacht wird
            var NeuesAppObjekt = base.Produziere<T>();

            // Im Protokoll eintragen, 
            // dass ein neues Anwendungsobjekt
            // erstellt wurde. Damit keine Rekursion
            // eintritt, mit Ausnahme vom Protokoll

            LogManager.Info(
                $"{NeuesAppObjekt} was produced.");

            // Bei Anwendungsobjekten dafür sorgen,
            // dass die Ursache von FehlerAufgetreten
            // im Protokoll steht


            if (NeuesAppObjekt is ViewModelAppObjekt AppObjekt)
            {
                AppObjekt.FehlerAufgetreten
                    // --- Ereignisbehandler
                    += (sender, e) => LogManager.Error(
                        $"{AppObjekt} triggers an exception:\r\n{e.Ursache?.Message}");
                // ----------------------

                LogManager.Debug($"{AppObjekt} handles {nameof(AppObjekt.FehlerAufgetreten)}...");
            }


            // Neues Objekt liefern...
            return NeuesAppObjekt;
        }

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private System.Collections.Hashtable? _Cache = null;

        /// <summary>
        /// Ruft den Cache der Anwendung ab
        /// </summary>
        public System.Collections.Hashtable Cache
        {
            get
            {
                if (this._Cache == null)
                {
                    this._Cache = [];
                    LogManager.Debug(
                        "The application initialized the cache...");

                }

                return this._Cache;
            }
        }

        /// <summary>
        /// Ruft einen Warheitswert ab ob ein Fehler enthalten ist 
        /// oder legt fest
        /// </summary>
        public bool EnthältFehler { get; set; }

    }
}
