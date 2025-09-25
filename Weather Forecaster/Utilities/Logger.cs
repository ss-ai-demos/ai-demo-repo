using System;
using System.IO;
using System.Text;

namespace Utilities
{
    public class Logger
    {
        private readonly string _logFilePath;

        public Logger(string logFilePath = "ActionLogs.txt")
        {
            _logFilePath = logFilePath;
        }

        public void Log(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            var logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}";
            using (var stream = new FileStream(_logFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            using (var writer = new StreamWriter(stream, Encoding.UTF8))
            {
                writer.Write(logEntry);
            }
        }
    }
}
