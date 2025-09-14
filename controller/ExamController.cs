
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApiProject.DTO;
using MyApiProject.Interface;
using MyApiProject.Migrations;

namespace MyApiProject.Controller;


[ApiController]
[Route("api/[controller]")]
public class ExamController(IExam exam) : ControllerBase
{
    private readonly IExam _exam = exam;



[Authorize]
    [HttpPost]
    public async Task<IActionResult> ExamPost(ExamDto examDto)
    {
        var res = await _exam.CreateExamAsync(examDto);
        if (!res)
        {
            return BadRequest("Something Wernt wrong");
        }
        return Ok("Eam sucessfull");
    }


[Authorize]
    [HttpGet("/{userId}")]
    public async Task<IActionResult> GetExamsByUserId(Guid userId)
    {
        var exams = await _exam.GetAllExamsAsync(userId);
        return Ok(exams);
    }

    


[Authorize]

    [HttpGet("{ExamId}")]
    public async Task<IActionResult> GetExamById(Guid ExamId)
    {
        var exam = await _exam.GetExamByIdAsync(ExamId);
        return Ok(exam);
   }
}