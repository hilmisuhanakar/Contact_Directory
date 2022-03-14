using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Directory_API.Models
{
    public class ContextDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-U0A1F27\SQLEXPRESS; database=Directory; integrated security=true");
        }
        public DbSet<Person> Persons { get; set; }
    }
}
