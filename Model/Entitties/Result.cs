using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyApiProject.Controller;
using MyApiProject.Model.Enum;

namespace MyApiProject.Model.Entitties;


public class Result
{
    [Key]
    public Guid ResultId { get; set; }


    public Guid UserId { get; set; } // FK → User

    [ForeignKey("ExamId")]
    public Guid ExamId { get; set; } // FK → Exam
    public float Score { get; set; }
    public DateTime AttemptDate { get; set; }

    public Status Status { get; set; } = Status.InProgress;


    public User? User { get; set; }   //result belong to user


    public Exam? Exam { get; set; }    //exam belong to result

      public Certificate? Certificate { get; set; }

 }