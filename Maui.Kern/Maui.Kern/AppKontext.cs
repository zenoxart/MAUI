using Maui.Kern.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maui.Kern.Erweiterungen;


namespace Maui.Kern
{

	/// <summary>
	/// Stellt die Infrastruktur 
	/// einer Anwendung bereit
	/// </summary>
	/// <remarks>Hier handelt es sich um 
	/// Xml Dokumentationskommentar</remarks>
	public class AppKontext
	{
		/// <summary>
		/// Gibt ein initialisiertes Anwendungsobjekt zurück
		/// </summary>
		/// <typeparam name="T">Gibt den Typ des benötigten Anwendungsobjekts an</typeparam>
		/// <returns>Ein Objekt bei dem die AppKontext Eigenschaft eingestellt ist</returns>
		public virtual T Produziere<T>() where T : IAppKontext, new()
		{
			var NeuesObjekt = new T () { AppKontext = this };


			var AppObjekt = NeuesObjekt as AppObjekt;
			if (AppObjekt != null)
			{
				AppObjekt.FehlerAufgetreten
					+= (sender, e) => System.Console.WriteLine(
						$"ERROR: Ausname \"{e.Ursache?.Message}\" in Objekt {AppObjekt}");
			}

			return NeuesObjekt;
		}
		/// <summary>
		/// Internes Feld für die gecachte Eigenschaft
		/// </summary>
		/// <remarks>Kann sich während der Sitzung nicht ändern</remarks>
		private static string? _LokalerDatenpfad = null;

		/// <summary>
		/// Legt den Datenpfad fest
		/// </summary>
		private static void SetLokalerDatenpfad(string value)
			=> _LokalerDatenpfad = value;
		/// <summary>
		/// Gibt den Datenpfad zurück
		/// </summary>

		private static string? GetLokalerDatenpfad()
		{
			return _LokalerDatenpfad;
		}

		/// <summary>
		/// Ruft das lokale Anwendungsdatenverzeichnis ab
		/// </summary>
		/// <remarks>Es wird sichergestellt, dass 
		/// das Verzeichnis existiert</remarks>
		public string? LokalerDatenpfad
		{
			// 20210128 Absturz behoben, wenn im
			//          Firmenname oder im Titel
			//          nicht erlaubt Zeichen vorkommen,
			//          z. B. "/" oder "&"
			get
			{
				if (AppKontext.GetLokalerDatenpfad() == null)
				{
					string GetPfad()
					{
						return System.IO.Path.Combine(
						// Basisverzeichnis %user%\AppData\Local
						System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
						// Firmenname anhängen
						// 20210128
						//, this.HoleFirmenname()
						, this.HoleFirmenname().Replace('/', '_').Replace('&', '_')
						// Anwendungsname anhängen
						// 20210128
						//, this.HoleTitel()
						, this.HoleTitel().Replace('/', '_').Replace('&', '_')
						// Version
						, this.HoleVersion()
						);
					}

					SetLokalerDatenpfad(GetPfad());

				}

				// Sicherstellen, dass der Pfad vorhanden ist
				System.IO.Directory.CreateDirectory(AppKontext.GetLokalerDatenpfad() ?? string.Empty);

				return _LokalerDatenpfad;
			}
		}

		/// <summary>
		/// Internes Feld für die gecachte Eigenschaft
		/// </summary>
		/// <remarks>Kann sich während der Sitzung nicht ändern</remarks>
		private static string? _Datenpfad = null;

		/// <summary>
		/// Ruft das roaming Anwendungsdatenverzeichnis ab
		/// </summary>
		/// <remarks>Es wird sichergestellt, dass 
		/// das Verzeichnis existiert</remarks>
		public string Datenpfad
		{
			// 20210128 Absturz behoben, wenn im
			//          Firmenname oder im Titel
			//          nicht erlaubt Zeichen vorkommen,
			//          z. B. "/" oder "&"
			get
			{
				if (AppKontext._Datenpfad == null)
				{
					string pfad = System.IO.Path.Combine(
					// Basisverzeichnis %user%\AppData\Roaming
					System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
					// Firmenname anhängen
					// 20210128
					//, this.HoleFirmenname()
					, this.HoleFirmenname().Replace('/', '_').Replace('&', '_')
					// Anwendungsname anhängen
					// 20210128
					//, this.HoleTitel()
					, this.HoleTitel().Replace('/', '_').Replace('&', '_')
					// Version
					, this.HoleVersion()
					);

					_Datenpfad = pfad;
				}

				// Sicherstellen, dass der Pfad vorhanden ist
				System.IO.Directory.CreateDirectory(AppKontext._Datenpfad);

				return AppKontext._Datenpfad;
			}
		}

		/// <summary>
		/// Internes Feld für die Eigenschaft
		/// </summary>
		private string? _Anwendungspfad = null;

		/// <summary>
		/// Ruft das Verzeichnis ab,
		/// aus dem die Anwendung gestartet wurde
		/// </summary>
		public string? Anwendungspfad
		{
			get
			{
				this._Anwendungspfad
						??= System.IO.Path.GetDirectoryName(
									System.Reflection.Assembly
										.GetEntryAssembly()?.Location
							);

				return this._Anwendungspfad;
			}
		}

		/// <summary>
		/// Internes Feld für die Eigenschaft
		/// </summary>
		private FensterManager? _Fenster = null;

		/// <summary>
		/// Ruft den Dienst zum Verwalten
		/// der Anwendungsfenster ab
		/// </summary>
		public FensterManager Fenster
		{
			get
			{
                // Dazu gibt's eine eigene Methode
                this._Fenster ??= this.Produziere<FensterManager>();

                return this._Fenster;
			}
		}

		
	}
}
