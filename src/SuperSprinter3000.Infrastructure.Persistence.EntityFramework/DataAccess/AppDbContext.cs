using Microsoft.EntityFrameworkCore;
using SuperSprinter3000.Domain.Entities;

namespace SuperSprinter3000.Infrastructure.Persistence.EntityFramework.DataAccess;

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
            entity.Property(e => e.Status)
                .IsRequired()
                .HasConversion<string>();
        });

        // add some (test) data

        modelBuilder.Entity<UserStory>().HasData(new List<UserStory>
        {
            // User stories are typically structured in the following format: "As a [type of user], I want [some goal] so that [some reason/benefit]."
            new UserStory
            {
                Id = 1,
                Title = "Customer Account Creation",
                Description = "As a new customer, I want to be able to create my own account so that I can make purchases and have a personalized shopping experience.",
                AcceptanceCriteria = "The customer can navigate to the 'Sign Up' page, input all necessary details, and successfully create an account. A verification email is sent to the email address provided during registration.",
                BusinessValue = 900,
                Estimation = 8m,
                Status = Status.Done
            },
            new UserStory
            {
                Id = 2,
                Title = "Product Search Functionality",
                Description = "As a customer, I want a search functionality so that I can easily find specific products I'm interested in.",
                AcceptanceCriteria = "The customer can enter keywords in the search bar and get a list of relevant product results. The search should include product names and descriptions.",
                BusinessValue = 1300,
                Estimation = 20m,
                Status = Status.InProgress
            },
            new UserStory
            {
                Id = 3,
                Title = "Secure Online Payment",
                Description = "As a customer, I want to make secure online payments so that I can purchase products without compromising my personal information.",
                AcceptanceCriteria = "The customer can choose a product, add to cart, checkout, and make payment using a credit card or a trusted payment gateway like PayPal. The customer's card data is not stored and all transactions are encrypted.",
                BusinessValue = 1500,
                Estimation = 30m,
                Status = Status.Todo
            },
            new UserStory
            {
                Id = 4,
                Title = "Order Tracking",
                Description = "As a customer, I want to be able to track my order so that I can know when to expect my delivery.",
                AcceptanceCriteria = "After a successful purchase, the customer should receive an order confirmation with a tracking number. The customer can input this number in the 'Order Tracking' section to see the status of the order.",
                BusinessValue = 700,
                Estimation = 15m,
                Status = Status.Planning
            }
        });

        base.OnModelCreating(modelBuilder);
    }
}