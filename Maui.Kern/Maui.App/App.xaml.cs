namespace Maui.App
{
    public partial class App : Application
    {
        /// <summary>
        /// Initialisiert die Haupt-Seite der Anwendung mit der Anwendungshülle, welche alle anderen Ansichten beinhaltet
        /// </summary>
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

        }
        


    }
}
