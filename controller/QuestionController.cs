

using Microsoft.AspNetCore.Mvc;
using MyApiProject.DTO;
using MyApiProject.Interface;

namespace MyApiProject.Controller;

[ApiController]
[Route("api/[controller]")]
public class QuestionController(IQuestion question) : ControllerBase
{
    private readonly IQuestion _question = question;


    [HttpPost]
    public async Task<IActionResult> PostQuestion(QuestionDto questionDto)
    {
        var res = await _question.CreateQuestionAsync(questionDto);
        if (!res)
        {
            return BadRequest("Something went wrong");
        }
        return Ok(new { message = "Question Posted sucessfully" });
    }


    [HttpGet]
    public async Task<IActionResult> GetQuestion(Guid ExamId)
    {
        if (ExamId == Guid.Empty)
        {
            return BadRequest(new { message = "ExamId is missing" });
        }
        ;
        var res = await _question.GetquestionsByExamId(ExamId);
        return Ok(res);
    }


    [HttpDelete]
    public async Task<IActionResult> DeleteQuestion(Guid QuestionId)
    {
        var res = await _question.DeleteQuestionAsync(QuestionId);
        return Ok(new{message="Question deleted successfully"});
  }

}
