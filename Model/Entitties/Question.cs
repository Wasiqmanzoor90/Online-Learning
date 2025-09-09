using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyApiProject.Model.Enum;

namespace MyApiProject.Model.Entitties
{
    public class Question
    {
        [Key]
        public Guid QuestionId { get; set; }

        [ForeignKey("Examid")]
        public Guid ExamId { get; set; }  //fk

        public string Text { get; set; } = null!;
        public QuestionType QuestionType { get; set; }
        public string Options { get; set; } = "{}"; // JSON string for options
        public string CorrectAnswer { get; set; } = "";
    public Exam? Exam { get; set; }   //many qstn  have one exan
     }
}