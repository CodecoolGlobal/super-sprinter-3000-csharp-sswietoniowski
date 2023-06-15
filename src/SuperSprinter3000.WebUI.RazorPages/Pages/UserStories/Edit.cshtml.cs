using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuperSprinter3000.WebUI.RazorPages.Models;
using SuperSprinter3000.WebUI.RazorPages.Services;

namespace SuperSprinter3000.WebUI.RazorPages.Pages.UserStories;

public class EditModel : PageModel
{
    private readonly IUserStoriesService _userStoriesService;

    [BindProperty]
    public EditUserStoryViewModel Input { get; set; } = new();

    public EditModel(IUserStoriesService userStoriesService)
    {
        _userStoriesService = userStoriesService ?? throw new ArgumentNullException(nameof(userStoriesService));
    }

    public IActionResult OnGet(int id)
    {
        var editUserStoryViewModel = _userStoriesService.GetByIdForEdit(id);

        if (editUserStoryViewModel is null)
        {
            return NotFound();
        }

        Input = editUserStoryViewModel;

        return Page();
    }

    public IActionResult OnPost(int id)
    {
        // in post methods we're using post-redirect-get pattern to prevent double form submission

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _userStoriesService.Update(id, Input);

        return RedirectToPage(nameof(Index));
    }
}