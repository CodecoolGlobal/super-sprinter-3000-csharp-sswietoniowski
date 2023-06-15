using System.ComponentModel.DataAnnotations;

namespace SuperSprinter3000.Application.Models;

public class AddUserStoryViewModel
{
    [Display(Name = "Story Title")]
    [Required]
    [MinLength(5)]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "User Story")]
    [Required]
    [DataType(DataType.MultilineText)]
    public string Description { get; set; } = string.Empty;

    [Display(Name = "Acceptance Criteria")]
    [Required]
    [DataType(DataType.MultilineText)]
    public string AcceptanceCriteria { get; set; } = string.Empty;

    [Display(Name = "Business Value")]
    [Required]
    [Range(100, 1500)]
    public int BusinessValue { get; set; }

    [Display(Name = "Estimation")]
    [Required]
    [Range(0.5, 40)]
    public decimal Estimation { get; set; }
}