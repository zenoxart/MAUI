using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui.App.Infrastuktur;
using Maui.App.MVVM.View;
using Maui.App.MVVM.ViewModel;
using Maui.App.MVVM.ViewModel.CollectionManager;
using Maui.Kern.Daten;
using Microsoft.Maui.Controls;
using System.Globalization;

namespace Maui.App.Infrastuktur
{
    /// <summary>
    /// Definiert die Kern-Anwendung, welche es Ermöglich ViewModels zu Produzieren
    /// </summary>
    public sealed partial class Anwendung : MauiAppObjekt
    {
        #region Init with Binding-Context

        /// <summary>
        /// Startet eine neue Seite mit der Anwendung als Binding Context,
        /// damit überall auf den MauiAppKontext zugegriffen werden kann.
        /// </summary>
        /// <typeparam name="T">Die zu startenden Seite</typeparam>
        public async Task Starten<T>() where T : Page, new()
            => await Application.Current!.MainPage!.Navigation.PushAsync(
                new T()
                {
                    BindingContext = this
                });

        /// <summary>
        /// Startet eine neue Tab-Ansicht mit der Anwendung als Binding Context,
        /// damit überall auf den MauiAppKontext zugegriffen werden kann.
        /// </summary>
        /// <typeparam name="T">Die zu startenden Seite</typeparam>
        public async Task StarteTabbedView<T>() where T : TabbedPage, new()
        {
            INavigation? Nav = Application.Current!.MainPage!.Navigation;

            if (Nav != null && (Nav.NavigationStack.Count == 0 || Nav!.NavigationStack[Nav!.NavigationStack.Count - 1] is not T))
            {
                await Nav.PushAsync(
                   new T()
                   {
                       BindingContext = this
                   });
            }
        }

        #endregion



        #region Sprachenspezifische Eigenschaften


        /// <summary>
        /// Läd die Sprachenspezifische Anwendungs-Start-Beschreibung, abhängend davon ob ein Login-Service in den Ressourcen definiert wurde 
        /// </summary>
        /// <remarks>Darf nicht als Statisch definiert werden, weil .NET MAUI sonst die Lokalisierungen nicht auflösen kann</remarks>
#pragma warning disable CA1822 
        public string? StartBtnText
#pragma warning restore CA1822 
            => Maui.App.Properties.Resources.LoginService != "true"
            ? SprachenManager.AkutelleAppLokalisierung["StartBtnText"].ToString()
            : SprachenManager.AkutelleAppLokalisierung["StartBtnTextLogin"].ToString();


        #endregion

        #region Sprachen-Lokalisierung

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private SprachenManager? _Sprachen;

        /// <summary>
        /// Definiert den Sprachenmanager in der Infrastruktur der Anwendung 
        /// </summary>
        public SprachenManager Sprachen => _Sprachen ??= AppKontext!.Produziere<SprachenManager>();


        #endregion


        #region Anwendungsweite Befehle
        /// <summary>
        /// Öffnet die entsprechende Anzeige im Startmenü
        /// </summary>
        /// <remarks>
        /// Entscheiden nach dem Resources.LoginService ob die Anwendung eine Anmeldung benötigt
        /// </remarks>
        [RelayCommand]
        public async Task LoginOrTabbedViewAsync ()
        {
            if (Maui.App.Properties.Resources.LoginService == "true")
            {
                // Öffnet den Login-Screen

                AppKontext!.Protokoll.Eintragen($"{nameof(LoginPage)} is starting...");
                await Starten<LoginPage>();
            }
            else
            {
                // Öffnet die Tabbed-View der Anwendung

                AppKontext!.Protokoll.Eintragen($"{nameof(TabbedAppPage)} is starting...");
                await StarteTabbedView<TabbedAppPage>();
            }
        }

        #endregion
    }
}
