using Microsoft.EntityFrameworkCore;
using UniversityAPI.Application.Contract;
using UniversityAPI.Application.Services;
using UniversityAPI.Domain.Interfaces;
using UniversityAPI.Infrastructure.Data;
using UniversityAPI.Infrastructure.Repositories;
using UniversityAPI.Presentation.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<UniversityContext>(options =>
    options.UseInMemoryDatabase("UniversityDb")); // In-memory database for simplicity

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ILectureService, LectureService>();
builder.Services.AddScoped<ILectureTheatreService, LectureTheatreService>();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ILectureRepository, LectureRepository>();
builder.Services.AddScoped<ILectureTheatreRepository, LectureTheatreRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
