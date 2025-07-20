using System;

namespace LlavesquiPoems.Domain.Entities;

public class Recital
{
    public int Id { get;  set; }
    public string City { get;  set; }
    public DateTime Date { get;  set; }
    public string Venue { get;  set; }
    public string Address { get;  set; }
}