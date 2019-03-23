using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IshchenkoKMAPractice4.Models;

namespace IshchenkoKMAPractice4.Tools.Storage
{
    internal interface IDataStorage
    {
        bool PersonExists(string email);

        Person GetPersonByEmail(string email);

        void RemovePerson(Person person);
        void AddPerson(Person person);
        List<Person> PersonsList { get; }
    }
}