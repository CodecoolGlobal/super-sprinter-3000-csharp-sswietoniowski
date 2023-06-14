using System.ComponentModel.DataAnnotations;
using SuperSprinter3000.WebUI.MVC.DataAccess.Entities;

namespace SuperSprinter3000.WebUI.MVC.Models;

public class UserStoryViewModel
{
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Display(Name = "Story Title")]
    public string Title { get; set; } = String.Empty;

    [Display(Name = "User Story")]
    public string Description { get; set; } = String.Empty;

    [Display(Name = "Acceptance Criteria")]
    public string AcceptanceCriteria { get; set; } = String.Empty;

    [Display(Name = "Business Value")]
    public int BusinessValue { get; set; }

    [Display(Name = "Estimation")]
    public decimal Estimation { get; set; }

    [Display(Name = "Status")]
    public Status Status { get; set; } = Status.Planning;
}