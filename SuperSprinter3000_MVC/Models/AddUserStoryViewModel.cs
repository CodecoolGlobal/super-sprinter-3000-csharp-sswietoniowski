using System.ComponentModel.DataAnnotations;
using SuperSprinter3000_MVC.Attributes;

namespace SuperSprinter3000_MVC.Models;

public class AddUserStoryViewModel
{
    [Display(Name = "Story Title")]
    [Required]
    [MinLength(5)]
    public string Title { get; set; } = String.Empty;

    [Display(Name = "User Story")]
    [Required]
    [DataType(DataType.MultilineText)]
    public string Description { get; set; } = String.Empty;

    [Display(Name = "Acceptance Criteria")]
    [Required]
    [DataType(DataType.MultilineText)]
    public string AcceptanceCriteria { get; set; } = String.Empty;

    [Display(Name = "Business Value")]
    [Required]
    [Range(100, 1500)]
    [DivisibleBy(100)]
    public int BusinessValue { get; set; }

    [Display(Name = "Estimation")]
    [Required]
    [Range(0.5, 40)]
    [DivisibleBy(0.5)]
    public decimal Estimation { get; set; }
}