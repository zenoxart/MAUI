# Maui-Framework 🔮

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![MAUI](https://img.shields.io/badge/MAUI-Kern%20%2B%20MVVM-blue)](Maui.Kern)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

Eine **.NET 8 MAUI Kern-Anwendung** mit Erweiterung für eine **MVVM-Architektur**.

Die Klassen sind für .NET & MAUI ausgelegt, funktionieren aber genauso in WinForms, WPF & UWP — dafür müssen sie nur in die passende Klassenbibliothek kopiert werden.

## Inhaltsverzeichnis

- [Projektstruktur](#projektstruktur)
- [Benutzung](#benutzung-)
- [Maui.Kern](#mauikern-)
- [Maui.Kern.Erweitert](#mauikernerweitert-)
- [Lizenz](#lizenz)

## Projektstruktur

| Projekt | Beschreibung |
|---|---|
| `Maui.Kern` | Basis-Infrastruktur: `AppObjekt`, `AppKontext`, `IAppKontext`, `FehlerAufgetreten` |
| `Maui.Erweitert` | MVVM-Erweiterung: `ViewModelAppObjekt`, `ViewModelAppKontext`, `Befehl`, `Daten` |
| `Maui.DatenObjekte` | Daten-Transfer-Objekte für den Austausch zwischen Server & Client |
| `Maui.App` | Beispiel-.NET-MAUI-Anwendung, die die Bibliotheken nutzt |

## Benutzung 🎉

1. Füge beide `.csproj`-Files der Projektmappe hinzu und verweise vom Client darauf.

2. Erstelle eine MVVM-Datei-Struktur am Client:
   - `Model`
   - `View`
   - `ViewModel`
     - `MainViewModel : ViewModelAppObjekt`
       ```csharp
       private ExampleViewModel _Example = null;
       public ExampleViewModel Example
       {
           get
           {
               _Example ??= this.AppKontext?.Produziere<ExampleViewModel>();
               return _Example;
           }
       }
       ```
     - `ExampleViewModel : ViewModelAppObjekt, IAppKontext`

3. Das `MainViewModel` **muss** beim Anwendungs-Start initialisiert werden. In .NET MAUI geht das am besten über die `AppShell.xaml`:

   - Füge der Shell einen XML-Namespace hinzu:
     ```xaml
     xmlns:vm="clr-namespace:MyApp.MVVM.ViewModel"
     ```

   - Setze den `BindingContext` der Shell auf das Haupt-ViewModel:
     ```xaml
     <Shell.BindingContext>
         <vm:MainViewModel/>
     </Shell.BindingContext>
     ```

Nun sollte in jeder View die gleiche Infrastruktur verfügbar sein.

## Maui.Kern 🎇

- `AppObjekt`
- `AppKontext`
- `FehlerAufgetreten`
- `IAppKontext`

### AppObjekt

Definiert die Grundeigenschaften, damit das vererbende Objekt im `AppKontext` initialisiert werden kann. Basis-Objekt für themenspezifische Manager.

### AppKontext

**Die Anwendungs-Infrastruktur.** Besitzt die generische Funktion `Produziere<T>()`, mit der `AppObjekte` erstellt werden, die per Call-by-Reference rekursiv auf die Instanz des `AppKontext` zugreifen können. Dadurch kommuniziert jeder Manager mit derselben Instanz der Infrastruktur.

```csharp
AppKontext.ManagerA.AppKontext.ManagerB
```

### IAppKontext

Interface, das eine Implementierung des `AppKontext` voraussetzt.

### FehlerAufgetreten

Definiert einen eigenen `EventHandler` und ein Custom-Event zum Behandeln von Fehlern, die beim Produzieren neuer Manager auftreten.

## Maui.Kern.Erweitert 🎇

- `ViewModelAppObjekt`
- `ViewModelAppKontext`
- `Befehl`
- `Daten`
  - `DatenBasis`
  - `Protokoll`
  - `SchwacherMethodenVerweis`

### ViewModelAppObjekt

Basis für nicht-statische Manager, die in der Infrastruktur verfügbar sein müssen. Erweitert um das Interface `INotifyPropertyChanged`, mit dem aus der MVVM-Architektur UI-Updates gemacht werden können, ohne den Property-Namen übergeben zu müssen. Besitzt außerdem einen `AppKontext` (als `ViewModelAppKontext`), einen Wahrheitswert für den Beschäftigt-Status samt Synchronisation und einen HTTP-Client.

### ViewModelAppKontext

Erweitert den `AppKontext` um einen Cache, Wahrheitswerte für aufgetretene Fehler sowie Felder für SqlServer, DB-Pfad & DB-Name.

### Befehl

Kapselung von `System.Windows.Input.ICommand`, um Funktionen & Methoden in MVVM zu definieren und in XAML zu binden.

```csharp
public Command Foo =>
    new(p =>
    {
        //...
    }
    );
```

### Daten.DatenBasis

Basis für Daten-Transfer-Objekte, die zwischen ASP.NET-REST-API-Server & Forms/WPF-Client gesendet werden. Ziel: einmal schreiben, zweimal nutzen. **Funktioniert seit UWP & .NET MAUI nicht mehr (Verweisprobleme)!** Enthält zudem ein `InToString`-Attribut, mit dem der Inhalt des Objekts beim Debuggen leichter einsehbar ist.

### Protokoll

Definiert die Basis für ein Log-Protokoll mit Zeitstempel, Text & Typ.

### SchwacherMethodenVerweis

Stellt eine `WeakReference`-Action sowie eine Auflistung mehrerer `WeakReference`-Actions bereit.

## Lizenz

Dieses Projekt steht unter der [MIT-Lizenz](LICENSE).
