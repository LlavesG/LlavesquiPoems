namespace LlavesquiPoems.Application.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Passsword { get; set; }
    public DateTime CreatedAt { get;  set; }
}