using Microsoft.EntityFrameworkCore;
using PB.Core.Contracts.Contacts;
using PB.Core.Contracts.Phones;
using PB.Core.Contracts.Tags;
using PB.Infrastructures.DAL.EF.Common;
using PB.Infrastructures.DAL.EF.Contacts;
using PB.Infrastructures.DAL.EF.Phones;
using PB.Infrastructures.DAL.EF.Tags;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddRazorPages();

builder.Services.AddMvc(option => option.EnableEndpointRouting = false);

builder.Services.AddDbContext<PhoneBookDbContext>(options => options
                .UseSqlServer(builder.Configuration
                .GetConnectionString("PhoneBook_ConnectionString")));

builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IPhoneRepository, PhoneRepository>();
builder.Services.AddScoped<IPhoneTypeRepository, PhoneTypeRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();


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
