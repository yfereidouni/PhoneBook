using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Core.Entities.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infrastructures.DAL.EF.Tags;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        builder.HasData(new Tag() { Id = 1, Name = "Father" });
        builder.HasData(new Tag() { Id = 2, Name = "Mother" });
        builder.HasData(new Tag() { Id = 3, Name = "Brother" });
        builder.HasData(new Tag() { Id = 4, Name = "Sister" });
        builder.HasData(new Tag() { Id = 5, Name = "Family" });
        builder.HasData(new Tag() { Id = 6, Name = "Friends" });
        builder.HasData(new Tag() { Id = 7, Name = "Colleague" });
        builder.HasData(new Tag() { Id = 8, Name = "Classmate" });
    }
}
