
using MyApiProject.DTO;
using MyApiProject.Model.Entitties;


namespace MyApiProject.Interface;

public interface IExam
{
    Task<bool> CreateExamAsync(ExamDto examDto);
    Task<Exam> GetExamByIdAsync(Guid id);
    Task<List<Exam>> GetAllExamsAsync(Guid id);
  
 }
