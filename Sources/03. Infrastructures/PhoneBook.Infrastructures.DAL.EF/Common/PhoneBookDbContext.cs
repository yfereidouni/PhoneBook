using Microsoft.EntityFrameworkCore;
using PB.Core.Entities.Contacts;
using PB.Core.Entities.Phones;
using PB.Core.Entities.Tags;
using PB.Infrastructures.DAL.EF.Contacts;
using PB.Infrastructures.DAL.EF.Phones;
using PB.Infrastructures.DAL.EF.Tags;
using PhoneBook.Core.Entities.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Infrastructures.DAL.EF.Common;

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
