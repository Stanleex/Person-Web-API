using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWebAPI.Models
{
    public class EFPersonRepository : IPersonRepository
    {
        private EFDbContext _context = new EFDbContext();

        public IEnumerable<Person> Persons => _context.Persons;
        public void AddPerson(Person newPerson)
        {
            if (newPerson != null)
            {
                _context.Persons.Add(newPerson);
                _context.SaveChanges();
            }
     
        }

        public void RemovePerson(int id)
        {
            var person = _context.Persons.Where(p => p.Id == id).FirstOrDefault();
            if (person != null)
            {
                _context.Persons.Remove(person);
                _context.SaveChanges();
            }

        }
        public void UpdatePerson(int id, Person newPerson)
        {
            
            var person = _context.Persons.Where(p => p.Id == id).FirstOrDefault();
            if (person != null)
            {
                person.FirstName = newPerson.FirstName;
                person.LastName = newPerson.LastName;
                _context.SaveChanges();
            }

        }
        public void SaveDatabase()
        {
            _context.SaveChanges();
        }
    }
}