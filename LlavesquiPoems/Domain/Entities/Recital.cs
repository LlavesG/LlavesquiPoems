using System;

namespace LlavesquiPoems.Domain.Entities;

public class Recital
{
    public int Id { get; private set; }
    public string City { get; private set; }
    public DateTime Date { get; private set; }
    public string Venue { get; private set; }
    public string Address { get; private set; }

    public Recital(string city, DateTime date, string venue, string addess)
    {
        City = city;
        Date = date;
        Venue = venue;
        Address = addess;
    }
}