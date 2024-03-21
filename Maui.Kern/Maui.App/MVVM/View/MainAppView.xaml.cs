using Maui.App.MVVM.Utils;
using Maui.App.MVVM.View.Tabellen;

namespace Maui.App.MVVM.View;

public partial class MainAppView : TabbedPage
{
	protected void AnwendungFürAnsichtHinzufügen<T>() where T : Page, new()
	{
		this.Children.Add(new T() { BindingContext = this.BindingContext as Anwendung });
	}
	protected void KontextFürAnsichtHinzufügen<T>() where T : Page, new()
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

        //AnwendungFürAnsichtHinzufügen<ProgressPage>();
        AnwendungFürAnsichtHinzufügen<Benutzerverwaltung>();
		AnwendungFürAnsichtHinzufügen<SettingsPage>();


    }



}