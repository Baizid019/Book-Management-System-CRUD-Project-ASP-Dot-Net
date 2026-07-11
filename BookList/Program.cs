using BookList.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Configure application

builder.Services.AddControllersWithViews(); // This is an MVC application 

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
// Whenever someone needs an ApplicationDbContext, create one for them.
/*
    It uses a SQL Server database. Whenever someone needs ApplicationDbContext, 
    create it and use the connection information named DefaultConnection.
*/

var app = builder.Build();

// Middleware configuration

app.UseHttpsRedirection(); // Redirect HTTP requests to secure HTTPS. 

app.UseStaticFiles();  // Serve static files like CSS, JavaScript, and images from the wwwroot folder.

app.UseRouting(); // Enable routing to match incoming requests to the appropriate controller and action.

app.UseAuthorization(); // Enable authorization to restrict access to certain parts of the application based on user roles or policies.


// default route (URL pattern) that ASP.NET Core uses to map incoming requests to the appropriate controller and action.

app.MapControllerRoute( 
    name: "default",
    pattern: "{controller=Books}/{action=Index}/{id?}");

// Run application

app.Run();