using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        private IEnumerable<string>? _CsvRows;
        // 1.
        public IEnumerable<string> CsvRows
        {
            get
            {
                if (this._CsvRows != null)
                {
                    return this._CsvRows;
                }
                string[] rows = File.ReadAllLines("People.csv");
                IEnumerable<string> CsvRows =
                    rows.Skip(1);
                return CsvRows;
            }
            set
            {
                _CsvRows = value;
            }
        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            IEnumerable<string> dataSet = CsvRows.Select(item =>
            {
                string[] split = item.Split(","); return split[6];
            }).Distinct();
            dataSet = from data in dataSet
                      orderby data ascending
                      select data;
            return dataSet;
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            IEnumerable<string> dataSet = GetUniqueSortedListOfStatesGivenCsvRows();
            string[] data = dataSet.ToArray();
            return String.Join(", ", data);

        }

        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                List<Person> people = new List<Person>();
                foreach (string person in CsvRows)
                {
                    string[] info = person.Split(",");
                    people.Add(new Person(info[1], info[2], new Address(info[4], info[5], info[6], info[7]), info[3]));
                }
                return people;
            }
            set
            {
                People = value;
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            IEnumerable<IPerson> people = People.Where(person => filter(person.EmailAddress));
            IEnumerable<(string, string)> results = people.Select(person => { return (person.FirstName, person.LastName); });
            return results;
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people)
        {
            if (people == null)
                people = People;
            IEnumerable<string> states = people.Select(people => people.Address.State)
                .OrderBy(state => state)
                .Distinct();

            return states.Aggregate((a, b) => a + ", " + b);
        }
    }
}
