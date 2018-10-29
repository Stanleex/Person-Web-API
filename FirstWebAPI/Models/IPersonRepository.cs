using System.Collections.Generic;

namespace FirstWebAPI.Models
{
    public interface IPersonRepository
    {
        IEnumerable<Person> Persons { get; }
    }
}