namespace LlavesquiPoems.Domain.Entities;

public class Reward
{
    public int Id { get; set; }
    public int IdProduct { get; set; }
    public int IdUser { get; set; }
    public int State { get; set; } 
    public string Description { get; set; } 
    public string Name { get; set; } 
    public DateTime CreatedAt { get;  set; }
    public DateTime UpdatedAt { get;  set; }
    public string CreatedBy { get;  set; }
    public string UpdatedBy { get;  set; }
    public virtual Product Product { get; set; }
    public virtual User User { get; set; }
}