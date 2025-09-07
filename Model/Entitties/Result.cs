using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyApiProject.Controller;
using MyApiProject.Model.Enum;

namespace MyApiProject.Model.Entitties;


public class Result
{
    [Key]
    public Guid ResultId { get; set; }

    [ForeignKey("UserId")]
    public Guid UserId { get; set; } // FK → User

    [ForeignKey("ExamId")]
    public Guid ExamId { get; set; } // FK → Exam
    public float Score { get; set; }
    public DateTime AttemptDate { get; set; }

    public Status Status { get; set; } = Status.InProgress;


    public User? user { get; set; }   //result belong to user


    public Exam? exam { get; set; }    //exam belong to result

      public Certificate? Certificate { get; set; }

 }