using SuperSprinter3000_MVC.Models;

namespace SuperSprinter3000_MVC.Services;

public interface IUserStoriesService
{
    public IEnumerable<UserStoryViewModel> GetAll();
    public UserStoryViewModel? GetById(int id);
    public void Add(AddUserStoryViewModel userStory);
    public void Update(int id, EditUserStoryViewModel userStory);
}