
using MyApiProject.Model.Enum;

namespace MyApiProject.DTO;

public class QuestionDto
{
    public QuestionType QuestionType { get; set; }
    public Guid ExamId { get; set; }  //fk
    public string Options { get; set; } = "{}"; // JSON string for options
    public string Text { get; set; } = null!;
    public string CorrectAnswer { get; set; } = "";
    public Guid CreatedBy { get; set; }
 }