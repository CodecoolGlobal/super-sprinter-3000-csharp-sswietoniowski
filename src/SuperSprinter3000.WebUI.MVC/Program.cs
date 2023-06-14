using Microsoft.EntityFrameworkCore;
using SuperSprinter3000.WebUI.MVC.DataAccess;
using SuperSprinter3000.WebUI.MVC.DataAccess.Repositories;
using SuperSprinter3000.WebUI.MVC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("AppConnection"));
});
builder.Services.AddScoped<IUserStoriesRepository, UserStoriesEntityFrameworkRepository>();
builder.Services.AddScoped<IUserStoriesService, UserStoriesService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UserStories}/{action=Index}/{id?}");

// recreate the database on each run
using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
dbContext.Database.EnsureDeleted();
dbContext.Database.EnsureCreated();

app.Run();
