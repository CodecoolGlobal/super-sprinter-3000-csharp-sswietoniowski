using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SuperSprinter3000.WebUI.RazorPages.Attributes;
using SuperSprinter3000.WebUI.RazorPages.DataAccess.Entities;

namespace SuperSprinter3000.WebUI.RazorPages.Models;

public class EditUserStoryViewModel
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
    [DivisibleBy(100)]
    public int BusinessValue { get; set; }

    [Display(Name = "Estimation")]
    [Required]
    [Range(0.5, 40)]
    [DivisibleBy(0.5)]
    [ModelBinder(BinderType = typeof(DecimalModelBinder))]
    public decimal Estimation { get; set; }

    [Display(Name = "Status")]
    [Required]
    public Status Status { get; set; } = Status.Planning;
}
