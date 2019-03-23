using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using IshchenkoKMAPractice4.Models;
using IshchenkoKMAPractice4.Tools.Managers;

namespace IshchenkoKMAPractice4.Tools.Storage
{
    internal class SerializedDataStorage : IDataStorage
    {
        private readonly List<Person> _persons;

        internal SerializedDataStorage()
        {
            
            try
            {
                _persons = SerializationManager.Deserialize<List<Person>>(FileFolderHelper.StorageFilePath);
            }
            catch (FileNotFoundException)
            {
                _persons = new List<Person>();
                for (int i = 10; i < 500; i+=10)
                {
                    _persons.Add(new Person("Ivan_#" + i, "Ishchenko_#" + i, "larderino_" + i + "@ukma.edu.ua", DateTime.Today));
                }

                Save();
            }
        }

        private void Save()
        {
           SerializationManager.Serialize(_persons, FileFolderHelper.StorageFilePath);
        }

        public bool PersonExists(string email)
        {
            return _persons.Exists(e => e.Email == email);
        }

        public Person GetPersonByEmail(string email)
        {
            return _persons.FirstOrDefault(e => e.Email == email);
        }

        public void RemovePerson(Person person)
        {
            _persons.Remove(person);
            Save();
        }

        public void AddPerson(Person person)
        {
           _persons.Add(person);
           Save();
        }

        public List<Person> PersonsList
        {
            get { return _persons.ToList(); }
        }
    }
}