using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        private readonly string ClassName = "LogFactoryTests";

        [TestMethod]
        public void ConfigureFileLogger_GivenValidFilePath_FileLogger()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                // Arrange

                // Act
                BaseLogger logger = LogFactory.ConfigureFileLogger(ClassName, filePath);

                // Assert 
                Assert.IsNotNull(logger);
            }
            finally
            {
                File.Delete(filePath);
            }
        }
        [TestMethod]
        public void ParseMessage_GivenProperArgs_Message()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                // Arrange
                TestLogger logger = new();

                // Act
                logger.Error("Test message: {0}", 39);

                // Assert 
                Assert.AreEqual(logger.LoggedMessages[0].Message, "Test message: 39");
            }
            finally
            {
                File.Delete(filePath);
            }
        }
    }
}
