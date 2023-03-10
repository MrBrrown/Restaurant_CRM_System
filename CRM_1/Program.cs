using CRM_1.Models;
using CRM_1.Services.ComponentRep;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IComponentRepository, MocComponentRepository>();
builder.Services.AddRazorPages();

//builder.Services.AddDbContext<ApplicationContext>(options =>
//options.UseMySQL(builder.Configuration.GetConnectionString("RunaTest_1_DB")));

//var context = services.GetRequiredService<ApplicationContext>();      добавить в app.Services.CreateScope()
//context.Database.EnsureCreated();                                     добавить в app.Services.CreateScope()

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

