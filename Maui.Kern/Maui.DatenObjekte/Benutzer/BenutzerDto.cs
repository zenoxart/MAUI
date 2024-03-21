using CommunityToolkit.Mvvm.ComponentModel;
using Maui.DatenObjekte;
using System.ComponentModel.DataAnnotations;

namespace Maui.DatenObjekte.Benutzer
{
    /// <summary>
    /// Definiert ein Transfer-Objekt eines Benutzers
    /// </summary>
    public partial class BenutzerDto : ObservableValidator, IDto
    {
        /// <summary>
        /// Definiert die Mindestgrenze der Benutzer-Id damit diese nicht negativ wird
        /// </summary>
        private readonly int minId = -1;

        /// <summary>
        /// Definiert die Benutzer-Id 
        /// </summary>
        [ObservableProperty]
        [Maui.Erweitert.Attribute.GrößerAls(nameof(minId))]
        int id;

        /// <summary>
        /// Definiert den Benutzernamen
        /// </summary>
        [ObservableProperty]
        string benutzername = string.Empty;

        /// <summary>
        /// Definiert den Vornamen des Benutzers
        /// </summary>
        [ObservableProperty]
        string vorname = string.Empty;

        /// <summary>
        /// Definiert den Nachnamen des Benutzers
        /// </summary>
        [ObservableProperty]
        string nachname = string.Empty;

        /// <summary>
        /// Definiert und Validiert die Email-Adresse die mit dem Benutzer gekoppelt ist
        /// </summary>
        [ObservableProperty]
        [EmailAddress]
        string email = string.Empty;

        /// <summary>
        /// Definiert ob der Benutzer aktuell in der Applikation angemeldet ist oder nicht
        /// </summary>
        [ObservableProperty]
        bool online;

        /// <summary>
        /// Definiert ob der Benutzer auf die Applikation Zugriff hat
        /// </summary>
        [ObservableProperty]
        bool gebannt = false;
        
        /// <summary>
        /// Definiert den Zeitstempeln, wann der Benutzer sich zum letzen mal angemeldet hat
        /// </summary>
        [ObservableProperty]
        DateTime letzerLoggin;

        /// <summary>
        /// Definiert die Art der Benutzer-Rolle die dem Benutzer zugewiesen wurde
        /// </summary>
        [ObservableProperty]
        BenutzerRollen rolle;

       
    }
}
