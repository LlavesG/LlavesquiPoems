using System;

namespace LlavesquiPoems.Domain.Entities;

public class Product
{
    public int Id { get;  set; }
    public string Name { get;  set; }
    public string Description { get;  set; }    
    public double Price { get;  set; }
    public double PublicPrice { get;  set; }
    public string ImgUrl { get;  set; }
    public int Type { get;  set; }
    public bool Available { get;  set; }
    public DateTime CreatedAt { get;  set; }
    public DateTime UpdatedAt { get;  set; }
    public string CreatedBy { get;  set; }
    public string UpdatedBy { get;  set; }
    public virtual ICollection<RecitalProduct> RecitalsProduct { get; set; }
}