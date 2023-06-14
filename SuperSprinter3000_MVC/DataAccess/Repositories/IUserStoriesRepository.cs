using SuperSprinter3000_MVC.DataAccess.Entities;

namespace SuperSprinter3000_MVC.DataAccess.Repositories;

public interface IUserStoriesRepository
{
    public IEnumerable<UserStory> GetAll();
    public UserStory? GetById(int id);
    public void Add(UserStory userStory);
    public void Update(UserStory userStory);
    public bool Exists(int id);
}