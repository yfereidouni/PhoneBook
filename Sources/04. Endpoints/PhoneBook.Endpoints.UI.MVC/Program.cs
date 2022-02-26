using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Contracts.Contacts;
using PhoneBook.Core.Contracts.Phones;
using PhoneBook.Core.Contracts.Tags;
using PhoneBook.Endpoints.UI.MVC.Models.AAA;
using PhoneBook.Infrastructures.DAL.EF.Common;
using PhoneBook.Infrastructures.DAL.EF.Contacts;
using PhoneBook.Infrastructures.DAL.EF.Phones;
using PhoneBook.Infrastructures.DAL.EF.Tags;
using PhoneBook.Services.ApplicationServices.Contacts;
using PhoneBook.Services.ApplicationServices.Phones;
using PhoneBook.Services.ApplicationServices.Tags;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddRazorPages();

builder.Services.AddMvc(option => option.EnableEndpointRouting = false);

builder.Services.AddDbContext<PhoneBookDbContext>(options => options
                .UseSqlServer(builder.Configuration
                .GetConnectionString("PhoneBook_DB_ConnectionString")));

builder.Services.AddDbContext<UserDbContext>(options => options
                .UseSqlServer(builder.Configuration
                .GetConnectionString("PhoneBook_AAA_ConnectionString")));


//Repository
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IPhoneRepository, PhoneRepository>();
builder.Services.AddScoped<IPhoneTypeRepository, PhoneTypeRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IContactTagRepository, ContactTagRepository>();

//Service
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IPhoneService, PhoneService>();
builder.Services.AddScoped<IPhoneTypeService, PhoneTypeService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<UserDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseMvc(routes =>
{
    routes.MapRoute(
      name: "default",
      template: "{Controller=Home}/{Action=Index}/{Id?}"
      );
});

//app.MapRazorPages();

app.Run();
