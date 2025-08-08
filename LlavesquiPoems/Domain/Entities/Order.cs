namespace LlavesquiPoems.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public int IdUser { get; set; }
    public int IdProduct { get; set; }
    public int Amount { get; set; }
    public DateTime CreatedAt { get;  set; }
    public DateTime UpdatedAt { get;  set; }
    public string CreatedBy { get;  set; }
    public string UpdatedBy { get;  set; }
}