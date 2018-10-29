using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FirstWebAPI.Models
{
    public class EFDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }
}