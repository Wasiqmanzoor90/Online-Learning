
using MyApiProject.Model.Enum;

namespace MyApiProject.DTO;
public class ResultDto
{
    public Guid UserId { get; set; } // FK → User
    public Guid ExamId { get; set; } // FK → Exam
    public float Score { get; set; }
    public DateTime AttemptDate { get; set; }
    public Status Status { get; set; }
}