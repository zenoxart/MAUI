using Maui.App.MVVM.Utils;
using Maui.App.MVVM.View.Tabellen;

namespace Maui.App.MVVM.View;

public partial class MainAppView : TabbedPage
{
	protected void AnwendungF�rAnsichtHinzuf�gen<T>() where T : Page, new()
	{
		this.Children.Add(new T() { BindingContext = this.BindingContext as Anwendung });
	}
	protected void KontextF�rAnsichtHinzuf�gen<T>() where T : Page, new()
	{
		this.Children.Add(new T() { BindingContext = (this.BindingContext as Anwendung)?.AppKontext });
	}
	public MainAppView()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

        //AnwendungF�rAnsichtHinzuf�gen<ProgressPage>();
        AnwendungF�rAnsichtHinzuf�gen<Benutzerverwaltung>();
		AnwendungF�rAnsichtHinzuf�gen<SettingsPage>();


    }



}