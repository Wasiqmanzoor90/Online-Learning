

using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using MyApiProject.Data;
using MyApiProject.Interface;
using MyApiProject.Service.AuthService;
using MyApiProject.Service.ExamService;
using MyApiProject.Service.TokenService;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

//Auth Service
builder.Services.AddScoped<IUser, UserService>();
//Exam service
builder.Services.AddScoped<IExam, ExamService>();
//TokenService
builder.Services.AddScoped<IJsonToken, TokenService>();

builder.Services.AddDbContext<SqlDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        options.RoutePrefix = string.Empty; // this makes Swagger UI load at "/"
    });
}
app.UseHttpsRedirection();
app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();
app.Run();

