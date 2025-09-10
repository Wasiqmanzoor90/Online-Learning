using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyApiProject.Controller;
using MyApiProject.Model.Enum;

namespace MyApiProject.Model.Entitties
{
    public class Question
    {
        [Key]
        public Guid QuestionId { get; set; }

        [ForeignKey("Examid")]
        public Guid ExamId { get; set; }  //fk

        [ForeignKey("UserId")]
        public Guid CreatedBy { get; set; }

        public string Text { get; set; } = null!;
        public QuestionType QuestionType { get; set; }
        public string Options { get; set; } = "{}"; // JSON string for options
        public string CorrectAnswer { get; set; } = "";
        public Exam? Exam { get; set; }   //many qstn  have one exan
        public User? User { get; set; } // mant question one answer
    
     }
}