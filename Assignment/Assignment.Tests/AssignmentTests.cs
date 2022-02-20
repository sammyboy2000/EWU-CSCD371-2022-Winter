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

        [TestMethod]
        public void GetUniqueSortedListOfStatesActuallyUnique()
        {
            SampleData sampleData = new();
            IEnumerable<string> dataSet = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            foreach(string data in dataSet)
            {
                Assert.IsFalse(ExistsMoreThanOnce(dataSet,data));
            }
        }
        [TestMethod]
        public void GetUniqueSortedListOfStatesActuallySorted()
        {
            string highest = " ";
            SampleData sampleData = new();
            IEnumerable<string> data = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            foreach(string d in data)
            {
                Assert.AreEqual<int>(1, string.Compare(d, highest));
                Assert.IsFalse(ExistsMoreThanOnce(data, d));
                highest = d;
            }
        }
        public void GetUniqueSortedListOfStatesActuallySortedString()
        {
            string highest = " ";
            SampleData sampleData = new();
            string result = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            IEnumerable<string> data = result.Split(",");
            foreach (string d in data)
            {
                Assert.AreEqual<int>(1, string.Compare(d, highest));
                Assert.IsFalse(ExistsMoreThanOnce(data, d));
                highest = d;
            }
        }

        [TestMethod]
        public void PeopleContainsPersons()
        {
            SampleData sampleData = new();
            IEnumerable<string> rows = sampleData.CsvRows;
            int count = 0;
            foreach (Person p in sampleData.People)
            {
                string person = rows.ElementAt(count);
                string[] info = person.Split(",");
                Assert.AreEqual<string>(info[1], p.FirstName);
                Assert.AreEqual<string>(info[2], p.LastName);
                Assert.AreEqual<string>(info[3], p.EmailAddress);
                Assert.AreEqual<string>(info[4], p.Address.StreetAddress);
                Assert.AreEqual<string>(info[5], p.Address.City);
                Assert.AreEqual<string>(info[6], p.Address.State);
                Assert.AreEqual<string>(info[7], p.Address.Zip);

                count++;
            }
        }
        [TestMethod]
        public void FilterByEmailAddressSuccessful()
        {
            SampleData sampleData = new SampleData();
            IEnumerable<(string firstName, string lastName)> results = sampleData.FilterByEmailAddress(new Predicate<string>(email => email == "pjenyns0@state.gov"));
            Person person = (Person)sampleData.People.First();
            foreach ((string fName, string lName) result in results)
            {
                Assert.AreEqual<string>(result.fName, person.FirstName);
                Assert.AreEqual(result.lName, person.LastName);
            }
        }
        [TestMethod]
        public void GetAggregatedListOfStatesGivenPeopleCollectionProperlyUnique()
        {
            SampleData sampleData = new SampleData();
            string result = sampleData.GetAggregateListOfStatesGivenPeopleCollection(null!);
            Assert.AreEqual<string>(result, sampleData.GetAggregateSortedListOfStatesUsingCsvRows());
        }
        public static bool ExistsMoreThanOnce(IEnumerable<string> collection, string check)
        {
            int count = 0;
            foreach(string existing in collection)
            {
                if (existing == check)
                    count++;
                if (count>1)
                    return true;
            }
            return false;
        }
    }

}
