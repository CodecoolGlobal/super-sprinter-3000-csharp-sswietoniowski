using SuperSprinter3000.Domain.Entities;

namespace SuperSprinter3000.Application.Repositories;

public interface IUserStoriesRepository
{
    public IEnumerable<UserStory> GetAll();
    public UserStory? GetById(int id);
    public void Add(UserStory userStory);
    public void Update(UserStory userStory);
    public bool ExistsById(int id);
}