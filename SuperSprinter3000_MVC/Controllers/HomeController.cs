using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SuperSprinter3000_MVC.Models;
using SuperSprinter3000_MVC.Services;

namespace SuperSprinter3000_MVC.Controllers;

public class HomeController : Controller
{
    private readonly IUserStoriesService _userStoriesService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IUserStoriesService userStoriesService, ILogger<HomeController> logger)
    {
        _userStoriesService = userStoriesService ?? throw new ArgumentNullException(nameof(userStoriesService));
        _logger = logger;
    }

    public IActionResult Index()
    {
        var userStoriesViewModels = _userStoriesService.GetAll();

        return View(userStoriesViewModels);
    }

    public IActionResult AddUserStory()
    {
        var userStoryViewModel = new AddUserStoryViewModel();

        return View(userStoryViewModel);
    }

    [HttpPost]
    public IActionResult AddUserStory(AddUserStoryViewModel userStoryViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(userStoryViewModel);
        }

        _userStoriesService.Add(userStoryViewModel);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult EditUserStory(int id)
    {
        var userStoryViewModel = _userStoriesService.GetById(id);

        if (userStoryViewModel is null)
        {
            return NotFound();
        }

        var editUserStoryViewModel = new EditUserStoryViewModel
        {
            Title = userStoryViewModel.Title,
            Description = userStoryViewModel.Description,
            AcceptanceCriteria = userStoryViewModel.AcceptanceCriteria,
            BusinessValue = userStoryViewModel.BusinessValue,
            Estimation = userStoryViewModel.Estimation
        };

        return View(editUserStoryViewModel);
    }

    [HttpPost]
    public IActionResult EditUserStory(int id, EditUserStoryViewModel editUserStoryViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(editUserStoryViewModel);
        }

        var userStoryViewModel = _userStoriesService.GetById(id);

        if (userStoryViewModel is null)
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