using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Kern.Manager.Logging
{
    /// <summary>
    /// Definiert die unterschiedlichen Level der Aufzeichnung
    /// </summary>
    public enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error
    }

    /// <summary>
    /// Definiert einen Manager-Service zur Aufzeichnung von Anwendungsaktivitäten
    /// </summary>
    public static class LogManager
    {
        /// <summary>
        /// Definiert den Dateipfad der Aufzeichnungsdatei
        /// </summary>
        private static readonly string LogDateiPfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "app.log");

        /// <summary>
        /// Löst die Aufzeichnung einer Nachricht aus
        /// </summary>
        public static void Log(string Nachricht, LogLevel Level = LogLevel.Info)
        {
            string LogNachricht = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{Level}] {Nachricht}";
            Trace.WriteLine(LogNachricht); // (Debug-Fenster in Visual Studio)
            File.AppendAllText(LogDateiPfad, LogNachricht + Environment.NewLine);
        }

        /// <summary>
        /// Löst die Aufzeichnung einer Debug-Nachricht auf
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message) 
            => Log(message, LogLevel.Debug);

        /// <summary>
        /// Löst die Aufzeichnung einer Info-Nachricht auf
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message) 
            => Log(message, LogLevel.Info);

        /// <summary>
        /// Löst die Aufzeichnung einer Warnungs-Nachricht auf
        /// </summary>
        /// <param name="message"></param>
        public static void Warning(string message) 
            => Log(message, LogLevel.Warning);

        /// <summary>
        /// Löst die Aufzeichnung einer Fehler-Nachricht auf
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message) 
            => Log(message, LogLevel.Error);

    }
}
