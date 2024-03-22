using CommunityToolkit.Mvvm.ComponentModel;
using Maui.DatenObjekte;
using Maui.DatenObjekte.Benutzer;
using Maui.Erweitert.Daten;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.App.MVVM.ViewModel.CollectionManager
{
    /// <summary>
    /// Stellt einen Verwaltungs-Manager zum verarbeiten der Anwendungsbenutzer
    /// </summary>
    public partial class BenutzerVerwaltungsManager : SammlungManager<BenutzerDto>
    {

        /// <summary>
        /// Läd die PersonenListe Asyncron von der Datenbank
        /// </summary>
        /// <returns></returns>
        [CommunityToolkit.Mvvm.Input.RelayCommand]
        private void LadeBenutzerListe()
        {
            if (this.AppKontext != null)
            {
                var neueListe = new BenutzerListe() {
                        new BenutzerDto { Id = 0, Benutzername="PetHans", Vorname = "Peter", Nachname = "Hans" },
                        new BenutzerDto { Id = 1, Benutzername="SimBrau", Vorname = "Simon", Nachname = "Braun" },
                        new BenutzerDto { Id = 2, Benutzername="Heinhü", Vorname = "Heinrich", Nachname = "Hüpfer" }
                    };

                BenutzerSammlung = BenutzerSammlung != neueListe ? neueListe : BenutzerSammlung;
            }
        }

        /// <summary>
        /// Läd die PersonenListe Asyncron von der Datenbank
        /// </summary>
        /// <returns></returns>
        [CommunityToolkit.Mvvm.Input.RelayCommand]
        private void BenutzerBlockieren()
        {
            if (this.AppKontext != null && BenutzerAktuell != null && !BenutzerAktuell.Gebannt)
            {
                BenutzerAktuell.Gebannt = true;
                // TODO: Auf der Datenbank aktuallisieren
            }
        }
        
        /// <summary>
        /// Läd die PersonenListe Asyncron von der Datenbank
        /// </summary>
        /// <returns></returns>
        [CommunityToolkit.Mvvm.Input.RelayCommand]
        private void BenutzerBlockierungAufheben()
        {
            if (this.AppKontext != null && BenutzerAktuell != null && BenutzerAktuell.Gebannt)
            {
                BenutzerAktuell.Gebannt = false;
                // TODO: Auf der Datenbank aktuallisieren
            }
        }

        /// <summary>
        /// Stellt eine Liste an Personen zur Verfügung oder setzt diese
        /// </summary>
        [ObservableProperty]
        DatenObjekte.Benutzer.BenutzerListe benutzerSammlung = [];

        /// <summary>
        /// Stellt ein aktuelles Objekt einer Person zur Verfügung oder setzt dieses
        /// </summary>
        [ObservableProperty]
        DatenObjekte.Benutzer.BenutzerDto benutzerAktuell = new();

    }
}
