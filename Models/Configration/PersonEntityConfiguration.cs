using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Configration
{
    public class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");
            builder.HasKey(i => i.ID);
            builder.Property(i => i.ID).ValueGeneratedOnAdd();
            builder.Property(i => i.First_Name).IsRequired()
                .HasMaxLength(150);
            builder.Property(i => i.Last_Name).IsRequired()
                .HasMaxLength(150);
            builder.Property(i => i.Email).IsRequired()
               .HasMaxLength(300);
            builder.Property(i => i.Phone)
               .HasMaxLength(11);
        }
    }
}
