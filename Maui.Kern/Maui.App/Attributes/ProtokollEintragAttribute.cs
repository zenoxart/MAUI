using Maui.App.Infrastuktur;
using Maui.Kern.Manager.Logging;

namespace Maui.App.Attributes
{
    /// <summary>
    /// Definiert ein Attribut zur leichteren erstellung eines Protokoll-Eintrags
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class ProtokollEintragAttribute : System.Attribute
    {
        public ProtokollEintragAttribute(string eintrag, LogLevel art)
        {
            LogManager.Log(eintrag, art);
        }

        public ProtokollEintragAttribute(string eintrag)
        {
            LogManager.Info(eintrag);
        }
    }
}
