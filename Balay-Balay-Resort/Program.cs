using Balay_Balay_Resort.Data;
using Balay_Balay_Resort.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSession();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    var adminEmail = "admin@rentgala.com";

    var adminExists = context.Users.Any(u => u.Email == adminEmail);

    if (!adminExists)
    {
        var adminUser = new User
        {
            FirstName = "System",
            LastName = "Admin",
            Email = adminEmail,
            PhoneNumber = "09478412351",
            Password = "admin123",
            ProfileImagePath = "/images/profile-picture.jpg",
            UserType = "Admin"
        };

        context.Users.Add(adminUser);
        context.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}")
    .WithStaticAssets();


app.Run();
