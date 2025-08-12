namespace LlavesquiPoems.Domain.Entities;

public class AnswersUser
{
    public int Id { get; set; }
    public int IdUser { get; set; }
    public int IdQuiz { get; set; }
    public string Answer { get; set; } 
    public DateTime CreatedAt { get;  set; }
    public DateTime UpdatedAt { get;  set; }
    public string CreatedBy { get;  set; }
    public string UpdatedBy { get;  set; }
    public virtual Quiz Quiz { get;  set; }
    public virtual User User { get;  set; }
}