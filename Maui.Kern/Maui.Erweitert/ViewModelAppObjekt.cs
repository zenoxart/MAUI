﻿using Maui.Kern;
using Maui.Kern.Manager.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Erweitert
{
	/// <summary>
	/// Stellt die Grundlage für ViewModels
	/// bereit und untersützt diese mit der Infrastruktur
	/// </summary>
	public abstract class ViewModelAppObjekt
		: AppObjekt
	{

		/// <summary>
		/// Ruft die erweiterte Infrastruktur
		/// ab oder legt diese fest
		/// </summary>
		/// <remarks>Als Feld wird der AppKontext
		/// der Basisklasse benutzt. Durch diese
		/// Eigenschaft erspart man sich das
		/// spätere ständige Casten.</remarks>
		public new ViewModelAppKontext? AppKontext
		{
			get
			{
				return base.AppKontext as ViewModelAppKontext;
			}
			set
			{
				//Erlaubt, weil DatenbankAppKontext
				//AppKontext erweitert...
				base.AppKontext = value;
			}
		}

		/// <summary>
		/// Internes Hilfsfeld für die
		/// IstBeschäftigt Eigenschaft
		/// </summary>
		private int _IstBeschäftigtZähler = 0;

		/// <summary>
		/// Ruft einen Wahrheitswert ab,
		/// der angibt, ob die Anwendung
		/// aktuelle Berechnungen durchführt
		/// oder anderweitig beschäftigt ist
		/// </summary>
		/// <remarks>Der Inhalt der Eigenschaft
		/// wird mit StartProtokollieren und
		/// EndeProtokollieren gesetzt</remarks><remarks>
		/// Mit der IstBeschäftigtSynchronisieren Methode 
		/// kann ein anderes ViewModel informiert werden.</remarks>
		public bool IstBeschäftigt
		{
			get
			{
				return this._IstBeschäftigtZähler > 0;
			}
			private set
			{
				if (value)
				{
					this._IstBeschäftigtZähler++;
				}
				else
				{
					this._IstBeschäftigtZähler--;
				}

				this.OnPropertyChanged();
			}
		}

		
		/// <summary>
		/// Stellt sicher, dass eine Änderung
		/// von IstBeschäftigt auch in dem anderen
		/// ViewModel geändert wird
		/// </summary>
		/// <param name="mitViewModel">ViewModel, wo die 
		/// IstBeschäftigt Einstellung ebenfalls sichtbar
		/// sein soll</param>
		public virtual void IstBeschäftigtSynchronisieren(ViewModelAppObjekt mitViewModel)
		{

			this.PropertyChanged += (sender, e) =>
			{
				if (e.PropertyName == "IstBeschäftigt")
				{
					mitViewModel.IstBeschäftigt = this.IstBeschäftigt;
				}
			};

            LogManager.Info(
				$"{this} shares {nameof(mitViewModel.IstBeschäftigt)} {mitViewModel} with...");
		}

		
	}
}
