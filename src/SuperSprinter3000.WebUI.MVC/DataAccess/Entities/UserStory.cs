namespace SuperSprinter3000.WebUI.MVC.DataAccess.Entities;

public class UserStory
{
    //[Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    //[Required]
    //[MinLength(5)]
    //[MaxLength(100)]
    public string Title { get; set; } = string.Empty;
    //[Required]
    //[MaxLength(500)]
    public string Description { get; set; } = string.Empty;
    //[Required]
    //[MaxLength(500)]
    public string AcceptanceCriteria { get; set; } = string.Empty;
    //[Required]
    public int BusinessValue { get; set; }
    //[Required]
    public decimal Estimation { get; set; }
}