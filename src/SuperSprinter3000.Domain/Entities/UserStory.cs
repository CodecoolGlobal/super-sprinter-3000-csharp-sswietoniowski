namespace SuperSprinter3000.Domain.Entities;

public class UserStory
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string AcceptanceCriteria { get; set; } = string.Empty;
    public int BusinessValue { get; set; }
    public decimal Estimation { get; set; }
    public Status Status { get; set; } = Status.Planning;
}