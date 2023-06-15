using System.ComponentModel.DataAnnotations;
using SuperSprinter3000.Domain.Entities;

namespace SuperSprinter3000.Application.Models;

public class UserStoryViewModel
{
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Display(Name = "Story Title")]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "User Story")]
    public string Description { get; set; } = string.Empty;

    [Display(Name = "Acceptance Criteria")]
    public string AcceptanceCriteria { get; set; } = string.Empty;

    [Display(Name = "Business Value")]
    public int BusinessValue { get; set; }

    [Display(Name = "Estimation")]
    public decimal Estimation { get; set; }

    [Display(Name = "Status")]
    public Status Status { get; set; } = Status.Planning;
}