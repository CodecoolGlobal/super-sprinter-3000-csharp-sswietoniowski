using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SuperSprinter3000.WebUI.MVC.Models;
using SuperSprinter3000.WebUI.MVC.Services;

namespace SuperSprinter3000.WebUI.MVC.Controllers;

public class UserStoriesController : Controller
{
    private readonly IUserStoriesService _userStoriesService;
    private readonly ILogger<UserStoriesController> _logger;

    public UserStoriesController(IUserStoriesService userStoriesService, ILogger<UserStoriesController> logger)
    {
        _userStoriesService = userStoriesService ?? throw new ArgumentNullException(nameof(userStoriesService));
        _logger = logger;
    }

    public IActionResult Index()
    {
        var userStoriesViewModels = _userStoriesService.GetAll();

        return View(userStoriesViewModels);
    }

    public IActionResult Add()
    {
        var userStoryViewModel = new AddUserStoryViewModel();

        return View(userStoryViewModel);
    }

    [HttpPost]
    public IActionResult Add(AddUserStoryViewModel userStoryViewModel)
    {
        // in post methods we're using post-redirect-get pattern to prevent double form submission

        if (!ModelState.IsValid)
        {
            return View(userStoryViewModel);
        }

        _userStoriesService.Add(userStoryViewModel);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var editUserStoryViewModel = _userStoriesService.GetByIdForEdit(id);

        if (editUserStoryViewModel is null)
        {
            return NotFound();
        }

        return View(editUserStoryViewModel);
    }

    [HttpPost]
    public IActionResult Edit(int id, EditUserStoryViewModel editUserStoryViewModel)
    {
        // in post methods we're using post-redirect-get pattern to prevent double form submission

        if (!ModelState.IsValid)
        {
            return View(editUserStoryViewModel);
        }

        if (!_userStoriesService.ExistsById(id))
        {
            return NotFound();
        }

        _userStoriesService.Update(id, editUserStoryViewModel);

        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}