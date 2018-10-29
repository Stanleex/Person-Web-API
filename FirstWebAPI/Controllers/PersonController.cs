using FirstWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstWebAPI.Controllers
{
    public class PersonController : ApiController
    {
        PersonContext _context = new PersonContext();



        public PersonController()
        {
        }

        // GET: api/Person
        public List<Person> GetAllPersons()
        {
            return _context.Persons.ToList();
        }

        // GET: api/Person/5
        public Person GetPersonById(int id)
        {
            return _context.Persons.Where(p => p.Id == id).FirstOrDefault();
        }

        // POST: api/Person
        [HttpPost]
        public void CreateNewPerson(Person newPerson)
        {
            _context.Persons.Add(newPerson);

        }

        // PUT: api/Person/5
        [HttpPut]
        public void UpdatePersonInfo(int id, string firstName, string lastName)
        {
            var person = _context.Persons.Where(p => p.Id == id).FirstOrDefault();
            person.FirstName = firstName;
            person.LastName = lastName;
            _context.SaveChanges();
        }

        // DELETE: api/Person/5
        public void DeletePerson(int id)
        {
            var person = _context.Persons.Where(p => p.Id == id).FirstOrDefault();
            _context.Persons.Remove(person);
        }
    }
}
