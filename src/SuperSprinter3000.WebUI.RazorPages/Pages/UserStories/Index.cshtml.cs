using Microsoft.AspNetCore.Mvc.RazorPages;
using SuperSprinter3000.WebUI.RazorPages.Models;
using SuperSprinter3000.WebUI.RazorPages.Services;

namespace SuperSprinter3000.WebUI.RazorPages.Pages.UserStories;

public class IndexModel : PageModel
{
    private readonly IUserStoriesService _userStoriesService;
    private readonly ILogger<Pages.IndexModel> _logger;

    public InputModel Input { get; set; } = new InputModel();

    public IndexModel(IUserStoriesService userStoriesService, ILogger<Pages.IndexModel> logger)
    {
        _userStoriesService = userStoriesService ?? throw new ArgumentNullException(nameof(userStoriesService));
        _logger = logger;
    }

    public void OnGet()
    {
        Input.UserStories = _userStoriesService.GetAll();
    }

    public class InputModel
    {
        public IEnumerable<UserStoryViewModel> UserStories { get; set; } = Enumerable.Empty<UserStoryViewModel>();
    }
}