using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class AssignmentTests
    {
        [DeploymentItem("People.csv")]
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
            foreach (string row in allRows)
            {
                Assert.IsNotNull(row);
                count++;
            }
            Assert.AreEqual<int>(50, count);
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesActuallyUnique()
        {
            SampleData sampleData = new();
            IEnumerable<string> dataSet = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            foreach (string data in dataSet)
            {
                Assert.IsFalse(ExistsMoreThanOnce(dataSet, data));
            }
        }
        [TestMethod]
        public void GetUniqueSortedListOfStatesActuallySorted()
        {
            string highest = " ";
            SampleData sampleData = new();
            IEnumerable<string> data = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            foreach (string d in data)
            {
                Assert.AreEqual<int>(1, string.Compare(d, highest));
                Assert.IsFalse(ExistsMoreThanOnce(data, d));
                highest = d;
            }
        }
        [TestMethod]
        public void GetUniqueSortedListOfStatesActuallySortedUsingLINQ()
        {
            SampleData sampleData = new();
            IEnumerable<string> data = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            IEnumerable<string> testData = sampleData.CsvRows.Select(item =>
            {
                string[] split = item.Split(","); return split[6];
            }).Distinct();
            testData = from d in testData
                       orderby d ascending
                       select d;
            int count = 0;
            foreach (string d in data)
            {
                Assert.AreEqual<int>(0, string.Compare(d, testData.ElementAt(count)));
                Assert.IsFalse(ExistsMoreThanOnce(data, d));
                count++;
            }
        }
        [TestMethod]
        public void GetUniqueSortedListOfStatesUsingSpokaneAddresses()
        {
            SampleData sampleData = new();
            sampleData.CsvRows = new List<string> {"1,John,Smith,example@email.com,123 Street Ave,Spokane,WA,99207",
                                         "2,Jane,Doe,example@email.com,456 Avenue St,Spokane,WA,99206",
                                         "3,Walter,White,example@email.com,789 Avenue St,Spokane,WA,99208",
                                         "4,Linus,Torvalds,example@email.com,101 Street Ave,Spokane,WA,99203",
                                         "5,Not,Me,example@email.com,112 Street Ave,Spokane,WA,99207"
                                        };
            IEnumerable<string> dataSet = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            foreach (string data in dataSet)
            {
                Assert.IsFalse(ExistsMoreThanOnce(dataSet, data));
            }
        }
        [TestMethod]
        public void GetUniqueSortedListOfStatesActuallySortedString()
        {
            string highest = " ";
            SampleData sampleData = new();
            string result = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            string[] data = result.Split(", ");
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
            IEnumerable<string[]> rows = sampleData.CsvRows.Select(line => line.Split(","))
                .OrderBy(state => state[6])
                        .ThenBy(city => city[5])
                        .ThenBy(zip => zip[7]);
            int count = 0;
            foreach (Person p in sampleData.People)
            {
                string[] info = rows.ElementAt(count);
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
            SampleData sampleData = new();
            Predicate<string> filter = email;
            static bool email(string email) => email.Contains("pjenyns0@state.gov");
            IEnumerable<(string, string)> result = sampleData.FilterByEmailAddress(filter);

            string[] test = {"Priscilla", "Jenyns"};
            Console.WriteLine(result.First().Item1);

            Assert.AreEqual((test[0], test[1]), (result.First().Item1, result.First().Item2));
        }
        [TestMethod]
        public void GetAggregatedListOfStatesGivenPeopleCollectionProperlyUnique()
        {
            SampleData sampleData = new SampleData();
            string result = sampleData.GetAggregateListOfStatesGivenPeopleCollection(null!);
            Assert.AreEqual<string>(result, sampleData.GetAggregateSortedListOfStatesUsingCsvRows());
        }
        //Used multiple times within other tests
        public static bool ExistsMoreThanOnce(IEnumerable<string> collection, string check)
        {
            int count = 0;
            foreach (string existing in collection)
            {
                if (existing == check)
                    count++;
                if (count > 1)
                    return true;
            }
            return false;
        }
    }

}
