
using MyApiProject.DTO;
using MyApiProject.Model.Entitties;

namespace MyApiProject.Interface;

public interface IQuestion
{
    Task<bool> CreateQuestionAsync(QuestionDto questionDto);
    Task<List<Question>> GetquestionsByExamId(Guid UserId);
    Task<bool> DeleteQuestionAsync( Guid QuestionId);
 }