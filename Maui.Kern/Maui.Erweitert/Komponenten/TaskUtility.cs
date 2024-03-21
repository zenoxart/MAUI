using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Erweitert.Komponenten
{
	/// <summary>
	/// Eine Unterstützung zur Verwaltung von Asyncronen Aufrufen
	/// </summary>
	public static class TaskUtility
	{
		/// <summary>
		/// Wiederholt die Asyncrone Funktion wenn diese Fehlschlägt
		/// </summary>
		public static async Task AusführenMitWiederholungAsync(Func<Task> taskFunc, int maxRetryCount, TimeSpan delayBetweenRetries)
		{
			int retryCount = 0;

			while (retryCount <= maxRetryCount)
			{
				try
				{
					await taskFunc();
					return; // Success, no need to retry
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Error: {ex.Message}");

					retryCount++;
					if (retryCount <= maxRetryCount)
					{
						Console.WriteLine($"Retrying in {delayBetweenRetries.TotalSeconds} seconds...");
						await Task.Delay(delayBetweenRetries);
					}
					else
					{
						Console.WriteLine($"Max retry count reached. Aborting.");
						throw; // Propagate the exception after retries
					}
				}
			}
		}

		/// <summary>
		/// Wiederholt die Asyncrone Funktion wenn diese Fehlschlägt
		/// </summary>
		public static async Task<TResult?> AusführenMitWiederholungAsync<TResult>(Func<Task<TResult>> taskFunc, int maxRetryCount, TimeSpan delayBetweenRetries)
		{
			int retryCount = 0;

			while (retryCount <= maxRetryCount)
			{
				try
				{
					return await taskFunc();
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Error: {ex.Message}");

					retryCount++;
					if (retryCount <= maxRetryCount)
					{
						Console.WriteLine($"Retrying in {delayBetweenRetries.TotalSeconds} seconds...");
						await Task.Delay(delayBetweenRetries);
					}
					else
					{
						Console.WriteLine($"Max retry count reached. Aborting.");
						throw; // Propagate the exception after retries
					}
				}
			}

			return default; // This line is not reachable; added to satisfy the compiler
		}
	}
}
