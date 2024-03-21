using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace Maui.App
{
	/// <summary>
	/// Stellt das Kern-Programm
	/// </summary>
	public static class MauiProgram
	{
		/// <summary>
		/// Definiert die neue .NET MAUI App
		/// </summary>
		/// <returns></returns>
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder()
				.UseMauiApp<App>()
				.UseMauiCommunityToolkit()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}

	}


}
