using Microsoft.EntityFrameworkCore;
using Models;
using Models.Configration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class ProjectDBContect:DbContext
    {
        public ProjectDBContect(DbContextOptions<ProjectDBContect> options)
         : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PersonEntityConfiguration());

            modelBuilder.Entity<Address>()
            .HasOne<Person>(s => s.person)
            .WithMany(g => g.Addresses)
            .HasForeignKey(s => s.CurrentPersonId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
