using Microsoft.EntityFrameworkCore;
using SuperSprinter3000_MVC.DataAccess.Entities;

namespace SuperSprinter3000_MVC.DataAccess;

public class AppDbContext : DbContext
{
    public DbSet<UserStory> UserStories => Set<UserStory>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // define the model

        modelBuilder.Entity<UserStory>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(e => e.AcceptanceCriteria)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(e => e.BusinessValue)
                .IsRequired();

            entity.Property(e => e.Estimation)
                .IsRequired();
        });

        // add some (test) data

        modelBuilder.Entity<UserStory>().HasData(new List<UserStory>
        {
            new UserStory
            {
                Id = 1, Title = "User Story 1", Description = "Description 1",
                AcceptanceCriteria = "Acceptance Criteria 1", BusinessValue = 100, Estimation = 0.5m
            },
            new UserStory
            {
                Id = 2, Title = "User Story 2", Description = "Description 2",
                AcceptanceCriteria = "Acceptance Criteria 2", BusinessValue = 200, Estimation = 1m
            }
        });

        base.OnModelCreating(modelBuilder);
    }
}