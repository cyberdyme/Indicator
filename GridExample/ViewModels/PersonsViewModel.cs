using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GridExample.Models;

namespace GridExample.ViewModels
{
    public class PersonsViewModel {
        readonly ObservableCollection<Person> _persons;
        
        public PersonsViewModel() {
            List<string> names = new List<string> { "Alex", "Alice", "Tony", "Den", "Andrew", "John", "Donald", "Brian", "Effy", "Lisa", "Matthew" };
            _persons = new ObservableCollection<Person>();
            for (int i = 0; i < 10; i++) {
                _persons.Add(new Person(names[i], "Last name " + i, 21 + i, i % 2 == 0, 170 + i, 75 + i));
            }
            _persons[5].Age = 22;
            _persons[8].Age = 50;

            _persons[0].WorkDetails.Add(new WorkInfo("BAML", new DateTime(2017,06,09), WorkStatus.Good));
            _persons[0].WorkDetails.Add(new WorkInfo("RBS", new DateTime(2016, 06, 08), WorkStatus.Good));
            _persons[0].WorkDetails.Add(new WorkInfo("Credit Suisse", new DateTime(2015, 06, 07), WorkStatus.Okay));
            _persons[0].WorkDetails.Add(new WorkInfo("BNP Paribas", new DateTime(2014, 06, 06), WorkStatus.Bad));

            _persons[1].WorkDetails.Add(new WorkInfo("A", new DateTime(2010, 06, 05), WorkStatus.Good));
            _persons[1].WorkDetails.Add(new WorkInfo("B", new DateTime(2007, 06, 04), WorkStatus.Good));
            _persons[2].WorkDetails.Add(new WorkInfo("C", new DateTime(2007, 06, 03), WorkStatus.Okay));
            _persons[2].WorkDetails.Add(new WorkInfo("D", new DateTime(2005, 06, 02), WorkStatus.Bad));

            _persons[3].WorkDetails.Add(new WorkInfo("ONE", new DateTime(2004, 06, 01), WorkStatus.Good));
            _persons[3].WorkDetails.Add(new WorkInfo("TWO", new DateTime(2005, 06, 20), WorkStatus.Good));
            _persons[4].WorkDetails.Add(new WorkInfo("THREE", new DateTime(2002, 06, 19), WorkStatus.Okay));
            _persons[4].WorkDetails.Add(new WorkInfo("FOUR", new DateTime(2001, 06, 18), WorkStatus.Bad));

        }

        public ObservableCollection<Person> Persons => _persons;
    }
}