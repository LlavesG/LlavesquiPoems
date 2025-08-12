using System;

namespace LlavesquiPoems.Domain.Entities;

public class Recital
{
    public int Id { get;  set; }
    public string City { get;  set; }
    public string Name { get;  set; }
    public string Description { get;  set; }
    public DateTime Date { get;  set; }
    public string Venue { get;  set; }
    public string Address { get;  set; }
    public DateTime CreatedAt { get;  set; }
    public DateTime UpdatedAt { get;  set; }
    public string CreatedBy { get;  set; }
    public string UpdatedBy { get;  set; }
    public virtual ICollection<RecitalProduct> RecitalsProduct { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
}