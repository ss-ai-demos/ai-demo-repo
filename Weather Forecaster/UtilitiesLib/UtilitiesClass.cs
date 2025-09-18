namespace UtilitiesLib
{
    /// <summary>
    /// Provides utility methods for logging actions and mathematical calculations.
    /// </summary>
    public class UtilitiesClass
    {
        /// <summary>
        /// Logs the specified message to ActionLogs.txt with a timestamp.
        /// Throws ArgumentNullException if the message is null.
        /// Throws InvalidOperationException if log content cannot be read after writing.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogAction(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            var logFilePath = "ActionLogs.txt";
            var logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}";
            File.AppendAllText(logFilePath, logEntry);
            string logContent = ReadFullLogs(logFilePath)
                ?? throw new InvalidOperationException("Failed to read log content after writing.");
        }

        /// <summary>
        /// Calculates the factorial of a non-negative integer.
        /// Throws ArgumentOutOfRangeException if the number is negative.
        /// </summary>
        /// <param name="number">The non-negative integer to calculate the factorial for.</param>
        /// <returns>The factorial of the specified number.</returns>
        public long CalculateFactorial(int number)
        {
            if (number < 0) throw new ArgumentOutOfRangeException(nameof(number), "Number must be non-negative.");
            if (number == 0 || number == 1) return 1;
            long result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }

        /// <summary>
        /// Reads the full content of the specified log file.
        /// Returns an empty string if the file does not exist.
        /// </summary>
        /// <param name="filePath">The path to the log file.</param>
        /// <returns>The content of the log file, or empty string if file does not exist.</returns>
        private string ReadFullLogs(string filePath)
        {
            if (!File.Exists(filePath)) return string.Empty;
            return File.ReadAllText(filePath);
        }
    }
}
