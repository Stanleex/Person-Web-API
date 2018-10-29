using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWebAPI.Models
{
    public class FakeRepository
    {
        public static List<Person> FPeople = new List<Person>()
        {
            new Person(){Id = 1, FirstName = "Kamil", LastName = "Kowalski"},
            new Person(){Id = 2, FirstName = "Jon", LastName = "Snow"},
            new Person(){Id = 3, FirstName = "Steven", LastName = "Seagal"}
        };

    }
}