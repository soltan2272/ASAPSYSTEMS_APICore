using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Configration
{
    public class AddressEntityConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(i => i.ID);
            builder.Property(i => i.ID).ValueGeneratedOnAdd();
            builder.Property(i => i.Country).IsRequired()
                .HasMaxLength(20);
            builder.Property(i => i.City).IsRequired()
                .HasMaxLength(20);
            builder.Property(i => i.State).IsRequired()
               .HasMaxLength(20);
            builder.Property(i => i.Postal_Code)
               .HasMaxLength(5);
        }
    }
}
