using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuperSprinter3000.WebUI.RazorPages.Models;
using SuperSprinter3000.WebUI.RazorPages.Services;

namespace SuperSprinter3000.WebUI.RazorPages.Pages.UserStories;

public class AddModel : PageModel
{
    private readonly IUserStoriesService _userStoriesService;

    [BindProperty]
    public AddUserStoryViewModel Input { get; set; } = new();

    public AddModel(IUserStoriesService userStoriesService)
    {
        _userStoriesService = userStoriesService ?? throw new ArgumentNullException(nameof(userStoriesService));
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        // in post methods we're using post-redirect-get pattern to prevent double form submission

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _userStoriesService.Add(Input);

        return RedirectToPage(nameof(Index));
    }
}