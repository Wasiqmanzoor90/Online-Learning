
using Microsoft.AspNetCore.Mvc;
using MyApiProject.DTO;
using MyApiProject.Interface;

namespace MyApiProject.Controller;

[ApiController]
[Route("api/[controller]")]
public class ResultController(ResultInterface result) : ControllerBase
{
    private readonly ResultInterface _result = result;


    [HttpPost]
    public async Task<IActionResult> PostResult(ResultDto resultDto)
    {
        var res = await _result.PostResultAsync(resultDto);
        if (!res)
        {
            return BadRequest("Something went wrong");
        }
        return Ok(new { message = "Result Posted Sucessfully" });
    }
 [HttpGet("{userId}/{examId}")]
public async Task<IActionResult> GetResult(Guid userId, Guid examId)
{
    try
    {
        var result = await _result.GetResultAsync(userId, examId);
        return Ok(result);
    }
    catch (ArgumentException ex)
    {
        // Handle validation errors (user not found, result not found)
        return NotFound(new { message = ex.Message });
    }
    
}
}