using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Kern
{
	/// <summary>
	/// Stellt die Methode dar, die das
	/// FehlerAufgetreten Ereignis behandelt
	/// </summary>
	/// <param name="sender">Wer ruft den Behandler auf</param>
	/// <param name="e">Die Ereignisdaten</param>
	public delegate void FehlerAufgetretenEventHandler(object sender, FehlerAufgetretenEventArgs e);

    /// <summary>
    /// Stellt die Daten für das
    /// FehlerAufgetreten Ereignis bereit
    /// </summary>
    /// <remarks>
    /// Initialisiert ein neues Objekt
    /// </remarks>
    /// <param name="ursache">Das Ausnahmeobjekt,
    /// das den Fehler beschreibt</param>
    public class FehlerAufgetretenEventArgs(System.Exception ursache) : System.EventArgs
	{
		/// <summary>
		/// Internes Feld für die Eigenschaft
		/// </summary>
		private readonly System.Exception? _Ursache = ursache;

		/// <summary>
		/// Ruft das Ausnahmeobjekt ab,
		/// das den Fehler beschreibt
		/// </summary>
		public System.Exception? Ursache
		{
			get
			{


				return this._Ursache;
			}
		}
    }
}
