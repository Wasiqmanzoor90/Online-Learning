
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

    [HttpGet]
    public async Task<IActionResult> GetExamsByUserId(Guid userId)
    {
        var exams = await _exam.GetAllExamsAsync(userId);
        return Ok(exams);
    }

    

    [HttpGet("{id}")]
    public async Task<IActionResult> GetExamById(Guid id)
    {
        var exam = await _exam.GetExamByIdAsync(id);
        return Ok(exam);
   }
}