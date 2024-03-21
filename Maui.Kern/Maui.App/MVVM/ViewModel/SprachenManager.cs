using Maui.App.Attributes;
using Maui.App.MVVM.Utils;
using Maui.Erweitert;
using Maui.Erweitert.Daten;
using Maui.Erweitert.Komponenten;
using Maui.Kern.Daten;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.App.MVVM.ViewModel
{
    /// <summary>
    /// Stellt einen Manager zum Lokalisieren der Ressourcen
    /// </summary>
    public class LocalizationManager : INotifyPropertyChanged
    {
        /// <summary>
        /// Stellt die Funktionalität, Lokalisierte Ressourcen abzurufen
        /// </summary>
        public LocalizationManager()
        {
            Properties.Texte.Culture = CultureInfo.CurrentCulture;
        }
        /// <summary>
        /// Stellt eine statische Instanz um Zugriff auf die aktuelle Lokalisierung zu bekommen
        /// </summary>
        public static LocalizationManager Instance { get; set; } = new();

        /// <summary>
        /// Zugriff auf eine Objekt in den Ressourcen mit der passenden Lokalisierung
        /// </summary>
        /// <param name="resourceKey">Der zu suchende Ressourcen Schlüsselnamen</param>
        /// <returns>Liefert ein Objekt aus den Ressourcen</returns>
        public object this[string resourceKey]
            => Properties.Texte.ResourceManager.GetObject(resourceKey, Properties.Texte.Culture) ?? Array.Empty<byte>();


        /// <summary>
        /// Stellt den Event-Handler zum Verwalten von Oberflächenaktuallisierungen
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged = null;

        /// <summary>
        /// Hinterlegt die Lokalisierungs-Informationen in den Ressourcen und aktuallisiert die Oberfläche
        /// </summary>
        /// <param name="culture">Beinhaltet die Lokalisierungsinformationen</param>
        [ProtokollEintrag($"The culture of the {nameof(LocalizationManager)} is set.")]
        public void SetCulture(CultureInfo culture)
        {
            Properties.Texte.Culture = culture;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
    /// <summary>
    /// Implementiert einen modernen Sprachen-Manager angepasst für .NET MAUI
    /// </summary>
    public class SprachenManager : MauiAppObjekt
    {
        /// <summary>
        /// Stellt einen STATISCHEN Zugriff auf die private Instanz des Managers
        /// </summary>
        [ProtokollEintrag($"The instance of the {nameof(LocalizationManager)} was accessed.")]
        public static LocalizationManager AkutelleAppLokalisierung => LocalizationManager.Instance;


        /// <summary>
        /// Stellt einen Zugriff auf die private Instanz des Managers
        /// Wird für Eigenschaften benutzt welche gleich in der UI über Lokalisierung geladen werden sollen.
        /// Dafür darf dieser Lokalisierungs-Zugriff nicht Statisch sein!
        /// </summary>
#pragma warning disable CA1822 
        public LocalizationManager AkutelleUILokalisierung => SprachenManager.AkutelleAppLokalisierung;
#pragma warning restore CA1822 

        /// <summary>
        /// Stellt eine Sprachenliste, aller verfügbaren Lokalisierungen
        /// </summary>
        public Sprachen Sprachenliste { get; set; } =
        [
            new Sprache() { Code = "", Name = "English" },
            new Sprache() { Code = "de", Name = "German" }
        ];

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private Sprache? _AktuelleSprache;

        /// <summary>
        /// Ruft die Anwendungssprache ab oder legt diese fest
        /// </summary>
        public Sprache AktuelleSprache
        {
            get
            {
                _AktuelleSprache ??= Sprachenliste[0];
                return _AktuelleSprache;
            }

            [ProtokollEintrag($"The current language was set.")]
            set
            {
                _AktuelleSprache = value;
                if (value.Code != null)
                {
                    SprachenManager.AkutelleAppLokalisierung.SetCulture(new CultureInfo(value.Code));
                }
            }
        }
    }

}
