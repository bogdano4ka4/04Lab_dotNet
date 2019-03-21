using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Practice7UserList.Models;
using Practice7UserList.Tools.Managers;

namespace Practice7UserList.Tools.DataStorage
{
    internal class SerializedDataStorage : IDataStorage
    {
        private readonly List<Person> _users;
        
        internal SerializedDataStorage()
        {
            try
            {
                _users = SerializationManager.Deserialize<List<Person>>(FileFolderHelper.StorageFilePath);
            }
            catch (FileNotFoundException)
            {
                _users = new List<Person>();
                CreatePeople();
               

            }
        }
        public void AddUser(Person user)
        {
            _users.Add(user);
            SaveChanges();
        }

        public void DeleteUser(Person user)
        {
            _users.Remove(user);
            SaveChanges();

        }
        public List<Person> UsersList
        {
            get { return _users.ToList(); }
        }

        public void SaveChanges()
        {
            SerializationManager.Serialize(_users, FileFolderHelper.StorageFilePath);
        }
        private void CreatePeople()
        {
            AddUser(new Person("Ann", "Sesryk", "Sesryk@gmail.com", new DateTime(2015, 1, 9)));
            AddUser(new Person("Bob", "Michailov", "Michailov@gmail.com", new DateTime(1920, 12,15 )));
            AddUser(new Person("Fill", "Coi", "Coi@a.a", new DateTime(2001, 2, 1)));
            AddUser(new Person("Alexander", "Pavlik", "Pavlik@gmail.com", new DateTime(1945, 3, 12)));
            AddUser(new Person("Mona", "Rubin", "Rubin@gmail.com", new DateTime(1945, 4, 1)));
            AddUser(new Person("Mara", "Bodnar", "Bodnar@gmail.com", new DateTime(2001, 5, 2)));
            AddUser(new Person("Swish", "Ager", "Ager@gmail.com", new DateTime(199, 6, 3)));
            AddUser(new Person("Cooper", "Monir", "Monir1@gmail.com", new DateTime(1916, 7, 4)));
            AddUser(new Person("Lola", "Forex", "Forex@gmail.com", new DateTime(2018, 9, 5)));
            AddUser(new Person("Lolita", "Forew", "Forew@gmail.com", new DateTime(1921, 6, 6)));

            AddUser(new Person("Looker", "Soi", "Soi@gmail.com", new DateTime(1911, 1, 5)));
            AddUser(new Person("Bob", "Kokyt", "Kokyt@gmail.com", new DateTime(1930, 9, 7)));
            AddUser(new Person("Nik", "Kiiler", "Kiiler@a.a", new DateTime(2001, 2, 8)));
            AddUser(new Person("Andry", "Pullover", "Pullover@gmail.com", new DateTime(1925, 3, 9)));
            AddUser(new Person("Monika", "Aler", "Aler@gmail.com", new DateTime(2006, 4, 10)));
            AddUser(new Person("Shaha", "Kitlin", "Kitlin@gmail.com", new DateTime(1921, 5, 1)));
            AddUser(new Person("Swish", "Anyr", "Anyr@gmail.com", new DateTime(2019, 6, 12)));
            AddUser(new Person("Barby", "Monir", "Monir@gmail.com", new DateTime(2006, 7, 13)));
            AddUser(new Person("Nastya", "Kitten", "Kitten@gmail.com", new DateTime(2008, 9, 14)));
            AddUser(new Person("Yasya", "Cat", "Cat@gmail.com", new DateTime(1911, 6, 15)));

            AddUser(new Person("Arnold", "Schvartsneger", "Schvartsneger@rambler.ru", new DateTime(2010, 1, 16)));
            AddUser(new Person("Archi", "Shy", "Shy@rambler.ru", new DateTime(2007, 9, 17)));
            AddUser(new Person("Aro", "Kim", "Kim@rambler.ru", new DateTime(2011, 2, 18)));
            AddUser(new Person("Bro", "Happy", "Happy@rambler.ru", new DateTime(2005, 3, 19)));
            AddUser(new Person("Cox", "Wunder", "Wunder@rambler.ru", new DateTime(2004, 4, 20)));
            AddUser(new Person("Momma", "Oma", "Oma@rambler.ru", new DateTime(2009, 6, 20)));
            AddUser(new Person("Lotter", "Opa", "Opa@rambler.ru", new DateTime(1910, 5, 21)));
            AddUser(new Person("Zoya", "In", "In@rambler.ru", new DateTime(1929, 9, 22)));
            AddUser(new Person("Kostik", "Chin", "Chin@rambler.ru", new DateTime(2002, 9, 23)));
            AddUser(new Person("Lolita", "Chika", "Chika@rambler.ru", new DateTime(2002, 2, 24)));
            
            AddUser(new Person("Arnold", "Koko", "Koko@rambler.ru", new DateTime(2010, 1, 25)));
            AddUser(new Person("Archi", "Loko", "Loko@rambler.ru", new DateTime(2009, 2, 26)));
            AddUser(new Person("Aro", "Oko", "Oko@rambler.ru", new DateTime(2008, 3, 27)));
            AddUser(new Person("Bro", "Pera", "Pera@rambler.ru", new DateTime(2007, 4, 26)));
            AddUser(new Person("Cox", "Vera", "Vera@rambler.ru", new DateTime(2006, 5, 28)));
            AddUser(new Person("Momma", "Shriki", "Shriki@rambler.ru", new DateTime(2005, 6, 28)));
            AddUser(new Person("Lotter", "Piki", "Piki@rambler.ru", new DateTime(2004, 7, 29)));
            AddUser(new Person("Zoya", "Miki", "Miki@rambler.ru", new DateTime(2003, 8, 30)));
            AddUser(new Person("Kostik", "Fryti", "Fryti@rambler.ru", new DateTime(2002, 9, 1)));
            AddUser(new Person("Lolita", "Tyti", "Tyti@rambler.ru", new DateTime(2001, 10, 1)));

            AddUser(new Person("Fora", "Kolker", "Kolker@rambler.ru", new DateTime(2001, 1, 20)));
            AddUser(new Person("Mora", "Yoorker", "Yoorker@rambler.ru", new DateTime(2002, 2, 19)));
            AddUser(new Person("Gamora", "Parker", "Parker@rambler.ru", new DateTime(2003, 3, 18)));
            AddUser(new Person("Avrora", "Land", "Land@rambler.ru", new DateTime(1930, 4, 12)));
            AddUser(new Person("Cupora", "Rover", "Rover@rambler.ru", new DateTime(1929, 5, 23)));
            AddUser(new Person("Senioura", "Range", "Range@rambler.ru", new DateTime(1928, 6, 9)));
            AddUser(new Person("Anakora", "Renault", "Renault@rambler.ru", new DateTime(1927, 7, 1)));
            AddUser(new Person("Zoya", "Toyota", "Toyota@rambler.ru", new DateTime(1926, 8, 2)));
            AddUser(new Person("Luiss", "Ferrari", "Ferrari@rambler.ru", new DateTime(1925, 9, 3)));
            AddUser(new Person("Lolita", "Opel", "Opel@rambler.ru", new DateTime(1924, 10, 1)));
        }

    }
}
