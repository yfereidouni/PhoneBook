using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Core.Entities.Phones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infrastructures.DAL.EF.Phones;

public class PhoneTypeConfiguration : IEntityTypeConfiguration<PhoneType>
{
    public void Configure(EntityTypeBuilder<PhoneType> builder)
    {
        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        builder.HasData(
            new PhoneType() { Id = 1, Name = "Home" },
            new PhoneType() { Id = 2, Name = "Work" },
            new PhoneType() { Id = 3, Name = "Mobile" },
            new PhoneType() { Id = 4, Name = "Other" });
    }
}
