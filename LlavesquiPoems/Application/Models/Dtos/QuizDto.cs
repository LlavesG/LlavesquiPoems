namespace LlavesquiPoems.Application.Models.Dtos;

public class QuizDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Answer { get; set; }
    public int? IdProduct { get; set; }
    public bool IsAnswered { get; set; }
    public DateTime CreatedAt { get;  set; }
    public DateTime UpdatedAt { get;  set; }
    public DateTime DeadLine { get;  set; }
    public string CreatedBy { get;  set; }
    public string UpdatedBy { get;  set; }
    public int Answers { get; set; }
}