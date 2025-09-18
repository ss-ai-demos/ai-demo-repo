using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using UtilitiesLib;

namespace UtilitiesLib
{
    [TestClass]
    public class UtilitiesClassTests
    {
        private const string LogFileName = "ActionLogs.txt";

        [TestInitialize]
        public void TestInitialize()
        {
            // Ensure log file is clean before each test
            if (File.Exists(LogFileName))
                File.Delete(LogFileName);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Clean up log file after each test
            if (File.Exists(LogFileName))
                File.Delete(LogFileName);
        }

        [TestMethod]
        public void LogAction_WritesMessageToFile()
        {
            // Arrange
            var util = new UtilitiesClass();
            var message = "Test log entry";

            // Act
            util.LogAction(message);

            // Assert
            Assert.IsTrue(File.Exists(LogFileName));
            var content = File.ReadAllText(LogFileName);
            StringAssert.Contains(content, message);
        }

        [TestMethod]
        public void LogAction_AppendsMultipleMessages()
        {
            // Arrange
            var util = new UtilitiesClass();
            var message1 = "First entry";
            var message2 = "Second entry";

            // Act
            util.LogAction(message1);
            util.LogAction(message2);

            // Assert
            var content = File.ReadAllText(LogFileName);
            StringAssert.Contains(content, message1);
            StringAssert.Contains(content, message2);
            Assert.AreEqual(2, content.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Length);
        }

        [TestMethod]
        public void LogAction_HandlesEmptyMessage()
        {
            // Arrange
            var util = new UtilitiesClass();
            var message = string.Empty;

            // Act
            util.LogAction(message);

            // Assert
            var content = File.ReadAllText(LogFileName);
            StringAssert.Contains(content, " - ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LogAction_ThrowsOnNullMessage()
        {
            // Arrange
            var util = new UtilitiesClass();

            // Act
            util.LogAction(null);
        }
    }
}