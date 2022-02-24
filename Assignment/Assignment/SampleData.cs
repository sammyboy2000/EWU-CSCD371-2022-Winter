using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        private IEnumerable<string>? _CsvRows;
        IEnumerable<IPerson>? _People;
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
                if (_People != null)
                    return _People;
                return CsvRows.Select(line => line.Split(','))
                        .OrderBy(state => state[6])
                        .ThenBy(city => city[5])
                        .ThenBy(zip => zip[7])
                        .Select(
                            person => new Person(person[1], person[2],
                                new Address(person[4], person[5], person[6], person[7]),
                                person[3]));
            }
            set
            {
                _People = value;
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            IEnumerable<IPerson> people = People;
            IEnumerable<(string FirstName, string LastName)> result = people.Where(x => filter(x.EmailAddress)).Select(name => (first: name.FirstName.Trim(), last: name.LastName.Trim()));
            return result;
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
