using SuperSprinter3000.WebUI.MVC.DataAccess.Entities;
using SuperSprinter3000.WebUI.MVC.DataAccess.Repositories;
using SuperSprinter3000.WebUI.MVC.Models;

namespace SuperSprinter3000.WebUI.MVC.Services;

public class UserStoriesService : IUserStoriesService
{
    private readonly IUserStoriesRepository _userStoriesRepository;

    public UserStoriesService(IUserStoriesRepository userStoriesRepository)
    {
        _userStoriesRepository = userStoriesRepository ?? throw new ArgumentNullException(nameof(userStoriesRepository));
    }

    public IEnumerable<UserStoryViewModel> GetAll() => _userStoriesRepository.GetAll().Select(us => new UserStoryViewModel
    {
        Id = us.Id,
        Title = us.Title,
        Description = us.Description,
        AcceptanceCriteria = us.AcceptanceCriteria,
        BusinessValue = us.BusinessValue,
        Estimation = us.Estimation
    });

    public UserStoryViewModel? GetById(int id) => _userStoriesRepository.GetById(id) switch
    {
        null => null,
        var userStory => new UserStoryViewModel
        {
            Id = userStory.Id,
            Title = userStory.Title,
            Description = userStory.Description,
            AcceptanceCriteria = userStory.AcceptanceCriteria,
            BusinessValue = userStory.BusinessValue,
            Estimation = userStory.Estimation
        }
    };

    public void Add(AddUserStoryViewModel userStory)
    {
        _userStoriesRepository.Add(new UserStory
        {
            Title = userStory.Title,
            Description = userStory.Description,
            AcceptanceCriteria = userStory.AcceptanceCriteria,
            BusinessValue = userStory.BusinessValue,
            Estimation = userStory.Estimation
        });
    }

    public void Update(int id, EditUserStoryViewModel userStory)
    {
        var userStoryToUpdate = _userStoriesRepository.GetById(id);

        if (userStoryToUpdate is null)
        {
            return;
        }

        userStoryToUpdate.Title = userStory.Title;
        userStoryToUpdate.Description = userStory.Description;
        userStoryToUpdate.AcceptanceCriteria = userStory.AcceptanceCriteria;
        userStoryToUpdate.BusinessValue = userStory.BusinessValue;
        userStoryToUpdate.Estimation = userStory.Estimation;

        _userStoriesRepository.Update(userStoryToUpdate);
    }
}