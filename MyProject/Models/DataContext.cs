using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Deseases> Deseases { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<AuthOptions> AuthOptions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AboutTheFund> AboutTheFunds { get; set; }


        public DataContext(DbContextOptions<DataContext>options) : base (options)
        {
            Database.EnsureCreated();
        }
    }
}
