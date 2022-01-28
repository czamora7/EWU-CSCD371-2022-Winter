using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void TestLogHasCorrectOutput()
        {
            FileLogger logger = new();
            logger.Log(nameof(FileLogger), LogLevel.Error, "testing", "");
            Assert.AreEqual(Console.ReadLine(), $"{DateTime.Now} {nameof(FileLogger)} {LogLevel.Error} testing");
        }
    }
}
