using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Entities.Contacts;
using PhoneBook.Core.Entities.Phones;
using PhoneBook.Core.Entities.Tags;
using PhoneBook.Infrastructures.DAL.EF.Contacts;
using PhoneBook.Infrastructures.DAL.EF.Phones;
using PhoneBook.Infrastructures.DAL.EF.Tags;
using PhoneBook.Core.Entities.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infrastructures.DAL.EF.Common;

public class PhoneBookDbContext : DbContext
{
    public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options) : base(options) { }

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<ContactTag> ContactTags { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Phone> Phones { get; set; }
    public DbSet<PhoneType> PhoneTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Use: PhoneBookDbContextFactory
        //optionsBuilder.UseSqlServer("server=.;initial catalog=PhoneBook_DB;Integrated Security=True;");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ContactConfiguration());
        modelBuilder.ApplyConfiguration(new PhoneConfiguration());
        modelBuilder.ApplyConfiguration(new PhoneTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
