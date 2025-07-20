using System;

namespace LlavesquiPoems.Application.Dtos;

public class RecitalDto
{
        public int Id { get;  set; }
        public string City { get;  set; }
        public DateTime Date { get;  set; }
        public string Venue { get;  set; }
        public string Address { get;  set; }
        public DateTime CreatedAt { get;  set; }
        public DateTime UpdatedAt { get;  set; }
        public string CreatedBy { get;  set; }
        public string UpdatedBy { get;  set; }
}