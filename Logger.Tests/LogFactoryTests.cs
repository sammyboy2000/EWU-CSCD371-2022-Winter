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
                LogFactory.ConfigureFileLogger(nameof(ClassName), filePath);

                // Act


                // Assert 

            }
            finally
            {
                File.Delete(filePath);
            }
        }
    }
}
