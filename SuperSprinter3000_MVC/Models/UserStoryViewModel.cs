using System.ComponentModel.DataAnnotations;

namespace SuperSprinter3000_MVC.Models;

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
}