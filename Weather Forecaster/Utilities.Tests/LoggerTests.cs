using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Utilities;

namespace UtilitiesLib.Tests
{
    [TestClass]
    public class LoggerTests
    {
        private string LogFilePath;

        [TestInitialize]
        public void TestInitialize()
        {
            LogFilePath = Path.Combine(TestContext.TestRunDirectory, $"ActionLogs_{Guid.NewGuid()}.txt");
        }

        public TestContext TestContext { get; set; }

        [TestCleanup]
        public void TestCleanup()
        {
            if (File.Exists(LogFilePath))
                File.Delete(LogFilePath);
        }

        [TestMethod]
        public void Log_WritesMessageToFile()
        {
            var logger = new Logger(LogFilePath);
            var message = "Test log entry";
            logger.Log(message);
            Assert.IsTrue(File.Exists(LogFilePath));
            var content = File.ReadAllText(LogFilePath);
            StringAssert.Contains(content, message);
        }

        [TestMethod]
        public void Log_AppendsMultipleMessages()
        {
            var logger = new Logger(LogFilePath);
            var message1 = "First entry";
            var message2 = "Second entry";
            logger.Log(message1);
            logger.Log(message2);
            var content = File.ReadAllText(LogFilePath);
            StringAssert.Contains(content, message1);
            StringAssert.Contains(content, message2);
            Assert.AreEqual(2, content.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Length);
        }

        [TestMethod]
        public void Log_HandlesEmptyMessage()
        {
            var logger = new Logger(LogFilePath);
            var message = string.Empty;
            logger.Log(message);
            var content = File.ReadAllText(LogFilePath);
            StringAssert.Contains(content, " - ");
        }

        [TestMethod]
        public void Log_ThrowsOnNullMessage()
        {
            var logger = new Logger(LogFilePath);
            Assert.ThrowsException<ArgumentNullException>(() => logger.Log(null));
        }
    }
}
