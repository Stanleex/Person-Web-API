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
        EFPersonRepository db = new EFPersonRepository();
        public PersonController()
        {
        }

        // GET: api/Person
        public List<Person> GetAllPersons()
        {
            return db.Persons.ToList();
        }

        // GET: api/Person/5
        public Person GetPersonById(int id)
        {
            return db.Persons.Where(p => p.Id == id).FirstOrDefault();
        }

        // POST: api/Person
        [HttpPost]
        public void CreateNewPerson(Person newPerson)
        {
            db.AddPerson(newPerson);
        }

        // PUT: api/Person/5
        [HttpPut]
        public void UpdatePersonInfo(int id, Person newPerson)
        {
            db.UpdatePerson(id, newPerson);
        }

        // DELETE: api/Person/5
        public void DeletePerson(int id)
        {
            db.RemovePerson(id);
        }
    }
}
