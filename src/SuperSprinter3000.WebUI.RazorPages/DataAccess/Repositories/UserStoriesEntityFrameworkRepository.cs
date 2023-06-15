using Microsoft.EntityFrameworkCore;
using SuperSprinter3000.WebUI.RazorPages.DataAccess.Entities;

namespace SuperSprinter3000.WebUI.RazorPages.DataAccess.Repositories;

public class UserStoriesEntityFrameworkRepository : IUserStoriesRepository
{
    private readonly AppDbContext _dbContext;

    public UserStoriesEntityFrameworkRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public IEnumerable<UserStory> GetAll() => _dbContext.UserStories.AsNoTracking().ToList();

    public UserStory? GetById(int id) => _dbContext.UserStories.Find(id);

    public void Add(UserStory userStory)
    {
        _dbContext.UserStories.Add(userStory);

        _dbContext.SaveChanges();
    }

    public void Update(UserStory userStory)
    {
        var existingUserStory = _dbContext.UserStories.Find(userStory.Id);

        if (existingUserStory is null)
        {
            return;
        }

        existingUserStory.Title = userStory.Title;
        existingUserStory.Description = userStory.Description;
        existingUserStory.AcceptanceCriteria = userStory.AcceptanceCriteria;
        existingUserStory.BusinessValue = userStory.BusinessValue;
        existingUserStory.Estimation = userStory.Estimation;
        existingUserStory.Status = userStory.Status;

        _dbContext.SaveChanges();
    }

    public bool ExistsById(int id) => _dbContext.UserStories.Find(id) is not null;
}