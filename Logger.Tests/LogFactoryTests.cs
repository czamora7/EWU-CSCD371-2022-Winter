using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void TestConfigureFileLoggerWorks()
        {
            //test to confirm path is being set to a private member
            string pathName = "jerry";
            LogFactory tf = new();
            tf.ConfigureFileLogger(pathName);

            Assert.AreEqual(tf.Path, pathName);
        }

        [TestMethod]
        public void TestCreateLoggerWorks()
        {
            //test to confirm the logger is successfully created
            FileLogger tl = new();
            LogFactory tf = new();

            string success = tf.CreateLogger(nameof(FileLogger), LogLevel.Error, "testing 1 2 3", tl);
            Assert.AreEqual(success, "success");
        }


        
    }
}
