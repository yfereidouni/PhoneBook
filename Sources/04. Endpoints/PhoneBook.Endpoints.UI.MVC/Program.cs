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

//Using "appsetings.jason" configurations
int minPasswordLength = int.Parse(builder.Configuration["MinPasswprdLength"]);

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

//Password
//builder.Services.AddScoped<IPasswordValidator<AppUser>, MyPassordValidator>();
builder.Services.AddScoped<IPasswordValidator<AppUser>, MyPassordValidator2>();

//Username
//builder.Services.AddScoped<IUserValidator<AppUser>, MyUserValidator>();
builder.Services.AddScoped<IUserValidator<AppUser>, MyUserValidator2>();


builder.Services.AddIdentity<AppUser, IdentityRole>(c =>
{
    //User configurations:
    c.User.RequireUniqueEmail = true;
    c.User.AllowedUserNameCharacters = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM." +
                                       "1234567890";

    //Password configurations:
    c.Password.RequireDigit = false;
    c.Password.RequiredLength = minPasswordLength;
    c.Password.RequireNonAlphanumeric=false;
    c.Password.RequireUppercase=false;
    c.Password.RequiredUniqueChars = 1;
    c.Password.RequireLowercase=false;

}).AddEntityFrameworkStores<UserDbContext>();


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
