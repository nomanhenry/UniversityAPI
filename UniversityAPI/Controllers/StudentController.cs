using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Application.Contract;
using UniversityAPI.Application.DTOs;
using UniversityAPI.Application.DTOs.Request;
using UniversityAPI.Application.Services;
using UniversityAPI.Domain.Entities;
using UniversityAPI.Domain.Interfaces;
using UniversityAPI.Infrastructure.Repositories;

namespace UniversityAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentRequest studentRequest)
        {
            var student = await _studentService.CreateStudentAsync(studentRequest);
            return CreatedAtAction(nameof(GetStudent), new { id = student }, student);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var lectures = await _studentService.GetStudentAsync(id);
            if (lectures == null) return NotFound();
            return Ok(lectures);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            return Ok(await _studentService.GetAllAsync());
        }

        [HttpGet("GetBySubjectId")]
        public async Task<IActionResult> GetBySubjectId(int subjectId)
        {
            var response = await _studentService.GetBySubjectIdAsync(subjectId);

            return Ok(response);
        }
    }
}
