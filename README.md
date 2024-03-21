# Maui-Framework 🔮
Enthält eine **.NET 6 MAUI Kern-Anwendung** plus Erweiterung für eine **MVVM-Architektur**

Die Anwendungen sind für .NET & MAUI ausgelegt!
Die Klassen funktionieren genauso in WinForms, WPF & UWP.
Dafür müssen Sie nur in die passende Klassenbibliothek kopiert werden.



# Benutzung 🎉
1. Füge beide **.csproj-Files der Projektmappe** hinzu und **verweise vom Client** darauf

2. **Erstelle eine MVVM-File-Sturktur** am Client
  - Model
  - View
  - ViewModel
    - MainViewModel : ViewModelAppObjekt 
    ``` csharp
        private ExampleViewModel _Example = null;
        public ExampleViewModel Example {
          get {
            _Example ??= this.AppKontext?.Produziere<ExampleViewModel>();
            return _Example;
          }
        } 
    ```
    - ExampleViewModel : ViewModelAppObjekt , IAppKontext

3. Nun **muss** das MainViewModel **beim Anwendungs-Start initialisiert werden**.
In .NET MAUI geht das am besten über die AppShell.xaml

- Füge der Shell einen XML-Namespace hinzu
``` csharp
    xmlns:vm="clr-namespace:MyApp.MVVM.ViewModel"
```

- Setze den BindingContext der Shell auf das Haupt-ViewModel
``` csharp
    <Shell.BindingContext>
        <vm:MainViewModel/>
    </Shell.BindingContext>
```

Nun sollte in jeder View die selbe Infrastruktur verfügbar sein.


# Maui.Kern 🎇
- AppObjekt
- AppKontext
- FehlerAufgetreten
- IAppKontext

## AppObjekt
Das AppObjekt definiert die Grundeigenschaften, damit das vererbende Objekt im AppKontext initialisiert werden kann.
Das ist das Basis-Objekt für Themenspezifische Manager

## AppKontext
**Der AppKontext ist unsere Anwendungs-Infrastruktur**.
Dieser besitzt eine generische Funktion **Produziere<T>()** mit dem AppObjekte erstellt werden können, welche durch CallByReference rekursiv auf die Instanz des AppKontext zugreifen können.
Dadurch kann man gewerleisten, dass jeder Manager mit der selben Instanz der Infrastruktur miteinander kommuniziert.

### Example:
AppKontext.ManagerA.AppKontext.ManagerB
  
## IAppKontext
Ist ein Interface welches eine implementierung des AppKontext vorraussetzt
  
## FehlerAufgetreten
Definiert einen eigenen EventHandler & ein Custom-Event zum Behandeln von Fehlern die beim Produzieren von neuen Managern auftreten
  
  
# Maui.Kern.Erweitert 🎇
- ViewModelAppObjekt
- ViewModelAppKontext
- Befehl
- Daten
  - DatenBasis
  - Protokoll
  - SchacherMethodenVerweis
  
## ViewModelAppObjekt
Dieses Objekt ist die Basis für nicht statische Manager, welche in der Infrastruktur verfügbar sein müssen.
Es Erweitert um das Interface **INotifyPropertyChanged** mit welchem aus der MVVM-Architektur UI-Updates gemacht werden können, ohne den Property-Namen übergeben zu müssen
Desweiteren besitzt es einen **AppKontext** welcher als ViewModelAppKontext benutzt wird, sowie einen Wahrheitswert ob die Anwendung beschäftigt ist, Syncronisation für den Wahrheitswert und einen **HTTP-Client**

## ViewModelAppKontext
Dieser erweitert den AppKontext um einen **Cache**, Wahrheitswerte für aufgetretene Fehler, sowie **Felder für SqlServer, DB-Pfad & DB-Name** 

## Befehl
Der Befehl stellt eine **Kapslung von System.Windows.Input.ICommand** um Funktionen & Methoden in MVVM zu definieren und in XAML zu binden

### Example:
```csharp
public Command Foo => 
  new(p => 
    {
      //...
    }
  );
```

  
## Daten.DatenBasis
Stellt die Basis für Daten-Transfer-Objekte, welche zwischen (ASP.NET Rest-API) Server & (Forms/WPF) Client gesendet werden.
Hat den Sinn 1 Mal die DatenBasis zu schreiben & 2 mal nutzen zu können. **Funktioniert seit UWP & .NET MAUI nicht mehr! (Verweißprobleme)**
Beinhaltet des weiteren ein InToString-Attribute mit dem der Inhalt des Objektes leichert beim Debuggen einzusehen ist

## Protokoll
Definiert die Basis für ein Log-Protokoll mit **Zeitstempel, Text & Typ**

## SchwacherMethodenVerweis
Stellt eine Möglichkeit für eine **WeakReference-Action & einer Auflistung mehrerer WeakReference-Actions**


