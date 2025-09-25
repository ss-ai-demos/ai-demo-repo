using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading.Tasks;
using Utilities;

namespace Utilities
{
    [TestClass]
    public class UtilitiesClassTests
    {
        private string testLogFile;
        private UtilitiesClass utilities;

        [TestInitialize]
        public void Setup()
        {
            utilities = new UtilitiesClass();
            testLogFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ActionLogs.txt");
            if (File.Exists(testLogFile))
                File.Delete(testLogFile);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(testLogFile))
                File.Delete(testLogFile);
        }

        [TestMethod]
        public async Task LogActionAsync_WritesMessageToFile()
        {
            string message = "Test log entry";
            await utilities.LogActionAsync(message);
            string content = File.ReadAllText(testLogFile);
            Assert.IsTrue(content.Contains(message));
        }

        [TestMethod]
        public async Task LogActionAsync_AppendsMultipleMessages()
        {
            string message1 = "First entry";
            string message2 = "Second entry";
            await utilities.LogActionAsync(message1);
            await utilities.LogActionAsync(message2);
            string content = File.ReadAllText(testLogFile);
            Assert.IsTrue(content.Contains(message1));
            Assert.IsTrue(content.Contains(message2));
            Assert.IsTrue(content.IndexOf(message1) < content.IndexOf(message2));
        }

        [TestMethod]
        public async Task LogActionAsync_HandlesEmptyMessage()
        {
            string message = string.Empty;
            await utilities.LogActionAsync(message);
            string content = File.ReadAllText(testLogFile);
            Assert.IsTrue(content.Contains(" - \n"));
        }

        [TestMethod]
        public async Task LogActionAsync_HandlesSpecialCharacters()
        {
            string message = "Special chars: !@#$%^&*()_+";
            await utilities.LogActionAsync(message);
            string content = File.ReadAllText(testLogFile);
            Assert.IsTrue(content.Contains(message));
        }
    }
}
