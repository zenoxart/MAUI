using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui.App.MVVM.Controls;
using Maui.App.MVVM.ViewModel;
using Maui.App.MVVM.ViewModel.CollectionManager;
using Maui.DatenObjekte;
using Maui.Erweitert.Daten;
using Maui.Erweitert.Komponenten;
using Maui.Erweitert.Manager;
using Maui.Kern;
using Maui.Kern.Daten;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.App.MVVM.Utils
{
    /// <summary>
    /// Erweitert die Infrastruktur um
    /// Dienste für die .NET MAUI Anwendung
    /// </summary>
    public class MauiAppKontext : Maui.Erweitert.ViewModelAppKontext
    {
        #region Infrastruktur-Prozess
        public override T Produziere<T>()
        {
            // Zuerst einmal das machen,
            // was sonst gemacht wird
            var NeuesAppObjekt = base.Produziere<T>();

            // Im Protokoll eintragen, 
            // dass ein neues Anwendungsobjekt
            // erstellt wurde. Damit keine Rekursion
            // eintritt, mit Ausnahme vom Protokoll
            if (NeuesAppObjekt is not ProtokollManager)
            {
                this.Protokoll.Eintragen(
                    $"{NeuesAppObjekt} was produced.",
                    Maui.Erweitert.Daten.ProtokollEintragTyp.NeueInstanz);

                // Bei Anwendungsobjekten dafür sorgen,
                // dass die Ursache von FehlerAufgetreten
                // im Protokoll steht


                if (NeuesAppObjekt is MauiAppObjekt AppObjekt)
                {
                    AppObjekt.FehlerAufgetreten
                        // --- Ereignisbehandler
                        += (sender, e) => this.Protokoll.Eintragen(
                            $"{AppObjekt} triggers an exception:\r\n{e.Ursache?.Message}",
                            Maui.Erweitert.Daten.ProtokollEintragTyp.Fehler);
                    // ----------------------

                    this.Protokoll.Eintragen($"{AppObjekt} handles {nameof(AppObjekt.FehlerAufgetreten)}...");
                }
            }

            // Neues Objekt liefern...
            return NeuesAppObjekt;
        }


        #endregion

        #region Manager-Deklaration
        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private BenutzerVerwaltungsManager? _BenutzerManager;

        /// <summary>
        /// Ruft den TabellenManager für das Test-Daten-Transfer-Objekt ab oder legt diesen fest
        /// </summary>
        public BenutzerVerwaltungsManager BenutzerManager
        {
            get
            {
                _BenutzerManager ??= this.Produziere<BenutzerVerwaltungsManager>();
                return _BenutzerManager;
            }

            set => _BenutzerManager = value;
        }

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private EinstellungsManager? _EinstellungsManager;

        /// <summary>
        /// Ruft den Einstellungsmanager ab oder legt diesen fest
        /// </summary>
        public EinstellungsManager EinstellungsManager
        {
            get => _EinstellungsManager ??= this.Produziere<EinstellungsManager>();
            set => _EinstellungsManager = value;
        }


        #endregion
    }


    

}
