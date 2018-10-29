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
        //PersonContext _context = new PersonContext();

        public PersonController()
        {
        }

        // GET: api/Person
        public List<Person> GetAllPersons()
        {
            return FakeRepository.FPeople.OrderBy(p => p.Id).ToList();
        }

        // GET: api/Person/5
        public Person GetPersonById(int id)
        {
            return FakeRepository.FPeople.Where(p => p.Id == id).FirstOrDefault();
        }

        // POST: api/Person
        [HttpPost]
        public void CreateNewPerson(Person newPerson)
        {

            FakeRepository.FPeople.Add(newPerson);

        }

        // PUT: api/Person/5
        [HttpPut]
        public void UpdatePersonInfo(int id, Person newPerson)
        {
            var person = FakeRepository.FPeople.FindIndex(p => p.Id == id);
            FakeRepository.FPeople[person].FirstName = newPerson.FirstName;
            FakeRepository.FPeople[person].LastName = newPerson.LastName;

        }

        // DELETE: api/Person/5
        public void DeletePerson(int id)
        {
            var person = FakeRepository.FPeople.Where(p => p.Id == id).FirstOrDefault();
            FakeRepository.FPeople.Remove(person);
        }
    }
}
