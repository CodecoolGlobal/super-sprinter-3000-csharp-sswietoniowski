using SuperSprinter3000.WebUI.RazorPages.DataAccess.Entities;
using SuperSprinter3000.WebUI.RazorPages.DataAccess.Repositories;
using SuperSprinter3000.WebUI.RazorPages.Models;

namespace SuperSprinter3000.WebUI.RazorPages.Services;

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
        Estimation = us.Estimation,
        Status = us.Status
    });

    public EditUserStoryViewModel? GetByIdForEdit(int id) => _userStoriesRepository.GetById(id) switch
    {
        null => null,
        var userStory => new EditUserStoryViewModel
        {
            Title = userStory.Title,
            Description = userStory.Description,
            AcceptanceCriteria = userStory.AcceptanceCriteria,
            BusinessValue = userStory.BusinessValue,
            Estimation = userStory.Estimation,
            Status = userStory.Status
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
            Estimation = userStory.Estimation,
            Status = Status.Planning
        });
    }

    public void Update(int id, EditUserStoryViewModel userStory)
    {
        _userStoriesRepository.Update(new UserStory
        {
            Id = id,
            Title = userStory.Title,
            Description = userStory.Description,
            AcceptanceCriteria = userStory.AcceptanceCriteria,
            BusinessValue = userStory.BusinessValue,
            Estimation = userStory.Estimation,
            Status = userStory.Status
        });
    }

    public bool ExistsById(int id) => _userStoriesRepository.ExistsById(id);
}