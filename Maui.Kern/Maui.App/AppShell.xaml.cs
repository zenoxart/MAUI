using Maui.App.Infrastuktur;
using Maui.Kern.Daten;
using System.Globalization;

namespace Maui.App
{
    /// <summary>
    /// Stellt die App-Hülle in der die Anwendungsoberflächen dargestellt werden
    /// </summary>
    public partial class AppShell : Shell
    {
        /// <summary>
        /// Läd alle Komponenten
        /// </summary>
        public AppShell()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Internes Feld für den Counter damit der Haupt-App-Prozess maximal 1 mal gestartet wird
        /// </summary>
        int firstAppearance = 0;

        /// <summary>
        /// Starte den Haupt-App-Prozess, wenn die Anwendungshülle auftaucht
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (firstAppearance == 0)
            {
                MainAppProcess();

                BindingContext = AnwendungApp;

                firstAppearance++;
            }

        }

        ///<summary>
        /// Öffentliches Feld für das Zugreifen auf die Business-Logik
        ///</summary>
        public Anwendung? AnwendungApp { get; set; }

        

        ///<summary>
        /// Startet den Haupt-Prozess der Anwendung, welche die Kontext- und Applikations-Infrastruktur im Multi-Sprachen-System startet
        ///</summary>
        protected void MainAppProcess()
        {

            // Ein Anwendungsfenster mit der Infrastruktur initialisieren
            AnwendungApp = new Anwendung();

            // Setze den BindingContext der gesammten Anwendung auf die eigene Infrastruktur
            Application.Current!.BindingContext = AnwendungApp;


            AnwendungApp.Sprachen.AktuelleSprache = new Sprache() { Code = "", Name = "English" };

            string? sprache = SecureStorage.GetAsync("DefaultLang")?.GetAwaiter().GetResult();


            if (sprache != null)
            {
                AnwendungApp.Sprachen.AktuelleSprache = AnwendungApp.Sprachen.Sprachenliste.FirstOrDefault(x =>
                   x.Name == sprache
                   ) ?? AnwendungApp.Sprachen.Sprachenliste[0];

            }
        }


        /// <summary>
        /// Wenn die Anwendungshülle verschwindet, wird die Sprache in der SecureStorage für den nächsten Appstart gespeichert
        /// </summary>
        protected override async void OnDisappearing()
        {
            string? SprachenName = AnwendungApp?.Sprachen.AktuelleSprache.Name;

            if (SprachenName != null)
            {
                await SecureStorage.SetAsync("DefaultLang", SprachenName);
            }
            base.OnDisappearing();
        }
    }
}
