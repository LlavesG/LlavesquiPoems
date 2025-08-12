namespace LlavesquiPoems.Application.Dtos;

public class RewardDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public int State { get; set; }
    public int IdProduct { get; set; }
    public DateTime CreatedAt { get;  set; }
    public DateTime UpdatedAt { get;  set; }
}