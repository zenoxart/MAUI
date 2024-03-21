using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.App.MVVM.ApiClient
{
	/// <summary>
	/// Definiert die Kern-Basis für einen API-Client
	/// </summary>
	public class BaseApiClient
	{
		/// <summary>
		/// Öffentliche Eigenschaft für den ConnectionString
		/// </summary>
		public string ConnectionString { get; set; } = Maui.App.Properties.Resources.ConnectionString;

	}
}
