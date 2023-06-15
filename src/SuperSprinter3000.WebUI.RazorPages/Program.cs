using Microsoft.EntityFrameworkCore;
using SuperSprinter3000.Application.Repositories;
using SuperSprinter3000.Application.Services;
using SuperSprinter3000.Infrastructure.Persistence.EntityFramework.DataAccess;
using SuperSprinter3000.Infrastructure.Persistence.EntityFramework.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("AppConnection"));
});
builder.Services.AddScoped<IUserStoriesRepository, UserStoriesEntityFrameworkRepository>();
builder.Services.AddScoped<IUserStoriesService, UserStoriesService>();

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseRequestLocalization("en-EN", "pl-PL");

// recreate the database on each run
using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
dbContext.Database.EnsureDeleted();
dbContext.Database.EnsureCreated();

app.Run();
