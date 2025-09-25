using System;
using System.IO;
using System.Threading.Tasks;

namespace Utilities;

/// <summary>
/// Provides utility methods for logging actions and calculating factorials.
/// </summary>
public class UtilitiesClass
{
    /// <summary>
    /// Asynchronously logs a message to the ActionLogs.txt file in the application's base directory.
    /// </summary>
    /// <param name="message">The message to log. Null or empty messages are allowed.</param>
    public async Task LogActionAsync(string message)
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ActionLogs.txt");
        string logLine = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}\n";
        await File.AppendAllTextAsync(filePath, logLine);
    }

    /// <summary>
    /// Calculates the factorial of a non-negative integer.
    /// </summary>
    /// <param name="number">The number to calculate the factorial for. Must be non-negative.</param>
    /// <returns>The factorial of the number.</returns>
    /// <exception cref="ArgumentException">Thrown when the number is negative.</exception>
    public long CalculateFactorial(int number)
    {
        if (number < 0)
            throw new ArgumentException("Number must be non-negative.");
        if (number == 0 || number == 1)
            return 1;
        long result = 1;
        for (int i = 2; i <= number; i++)
        {
            result *= i;
        }
        return result;
    }
}
