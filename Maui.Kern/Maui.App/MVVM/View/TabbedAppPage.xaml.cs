using Maui.App.Infrastuktur;
using Maui.App.MVVM.View.Administration;

namespace Maui.App.MVVM.View;

public partial class TabbedAppPage : TabbedPage
{
	public TabbedAppPage()
	{
		InitializeComponent();
	}

    protected void AnwendungFürAnsichtHinzufügen<T>() where T : Page, new()
    {
        this.Children.Add(new T() { BindingContext = this.BindingContext as Anwendung });
    }
    protected void KontextFürAnsichtHinzufügen<T>() where T : Page, new()
    {
        this.Children.Add(new T() { BindingContext = (this.BindingContext as Anwendung)?.AppKontext });
    }

    protected override void OnAppearing()
	{
		base.OnAppearing();

        //AnwendungFürAnsichtHinzufügen<ProgressPage>();
        AnwendungFürAnsichtHinzufügen<Benutzerverwaltung>();
		AnwendungFürAnsichtHinzufügen<EinstellungenPage>();

    }
}