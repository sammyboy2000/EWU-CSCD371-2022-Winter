using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests
{
    [TestClass]
    public class AssignmentTests
    {
        [DeploymentItem ("People.csv")]
        [TestMethod]
        public void FileExists()
        {
            Assert.IsTrue(File.Exists("People.csv"));
        }

        [TestMethod]
        public void CsvRowsReturnsAllRows()
        {
            SampleData sampleData = new();
            IEnumerable<string> allRows = sampleData.CsvRows;
            int count = 0;
            foreach(string row in allRows)
            {
                Assert.IsNotNull(row);
                count++;
            }
            Assert.AreEqual<int>(51-1, count);
        }
    }
}
