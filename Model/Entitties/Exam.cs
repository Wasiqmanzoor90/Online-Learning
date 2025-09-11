using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyApiProject.Controller;

namespace MyApiProject.Model.Entitties;

public class Exam
{
    [Key]
    public Guid ExamId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    public int DurationMinutes { get; set; }

    [ForeignKey("UserId")]
    public Guid CreatedBy { get; set; } // FK → User
  public User? Creator { get; set; }

    public Result? Result { get; set; }   //one result have only one exam

    public ICollection<Question> Questions { get; set; } = new List<Question>();    //one exam could have multiple questions
  
    
    

}