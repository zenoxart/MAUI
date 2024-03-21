using Maui.App.MVVM.Utils;

namespace Maui.App.Attributes
{
    /// <summary>
    /// Definiert ein Attribut zur leichteren erstellung eines Protokoll-Eintrags
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class ProtokollEintragAttribute : System.Attribute
    {
        public ProtokollEintragAttribute(string eintrag, Erweitert.Daten.ProtokollEintragTyp art)
        {
            Erweitert.Manager.ProtokollManager? Manager = (Application.Current?.BindingContext as Anwendung)?.AppKontext!.Protokoll;
            Manager?.Eintragen(eintrag, art);
        }
        public ProtokollEintragAttribute(string eintrag)
        {
            Erweitert.Manager.ProtokollManager? Manager = (Application.Current?.BindingContext as Anwendung)?.AppKontext!.Protokoll;
            Manager?.Eintragen(eintrag, Erweitert.Daten.ProtokollEintragTyp.Normal);
        }
    }
}
