using SuperSprinter3000_MVC.DataAccess.Entities;

namespace SuperSprinter3000_MVC.DataAccess.Repositories;

public class UserStoriesEntityFrameworkRepository : IUserStoriesRepository
{
    private readonly AppDbContext _dbContext;

    public UserStoriesEntityFrameworkRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public IEnumerable<UserStory> GetAll() => _dbContext.UserStories.ToList();

    public UserStory? GetById(int id) => _dbContext.UserStories.Find(id);

    public void Add(UserStory userStory)
    {
        _dbContext.UserStories.Add(userStory);
        _dbContext.SaveChanges();
    }

    public void Update(UserStory userStory)
    {
        var userStoryToUpdate = _dbContext.UserStories.Find(userStory.Id);

        if (userStoryToUpdate is null)
        {
            return;
        }

        userStoryToUpdate.Title = userStory.Title;
        userStoryToUpdate.Description = userStory.Description;
        userStoryToUpdate.AcceptanceCriteria = userStory.AcceptanceCriteria;
        userStoryToUpdate.BusinessValue = userStory.BusinessValue;
        userStoryToUpdate.Estimation = userStory.Estimation;

        _dbContext.SaveChanges();
    }

    public bool Exists(int id) => _dbContext.UserStories.Find(id) is not null;
}