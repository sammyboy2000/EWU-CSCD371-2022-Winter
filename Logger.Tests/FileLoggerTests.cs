using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        private readonly string ClassName = "FileLoggerTests";

        [TestMethod]
        public void FileLogger_GivenError_Log()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                // Arrange
                LogFactory logFactory = new();
                BaseLogger logger = LogFactory.ConfigureFileLogger(ClassName, filePath);

                // Act
                logger.Log(LogLevel.Error, "Test Message");

                // Assert 
                Assert.IsNotNull(File.ReadAllText(filePath));
            }
            finally
            {
                File.Delete(filePath);
            }
        }
    }
}
