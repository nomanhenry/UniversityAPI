using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Application.Contract;
using UniversityAPI.Application.DTOs;
using UniversityAPI.Application.DTOs.Request;
using UniversityAPI.Application.Services;
using UniversityAPI.Domain.Entities;
using UniversityAPI.Domain.Interfaces;

namespace UniversityAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject([FromBody] SubjectRequest subjectRequest)
        {
            var subject = await _subjectService.CreateSubjectAsync(subjectRequest);
            return CreatedAtAction(nameof(GetSubject), new { id = subject }, subject);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubject(int id)
        {
            var subject = await _subjectService.GetSubjectAsync(id);
            if (subject == null) return NotFound();
            return Ok(subject);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubject()
        {
            return Ok(await _subjectService.GetAllAsync());
        }

        [HttpGet("GetByStudentId")]
        public async Task<IActionResult> GetByStudentId(int studentId)
        {
            var response = await _subjectService.GetByStudentIdAsync(studentId);

            return Ok(response);
        }


        [HttpPost("StudentEnrollment")]
        public async Task<IActionResult> StudentEnrollment([FromBody] EnrollmentRequest enroll)
        {
            await _subjectService.StudentEnrollmentAsync(enroll);

            return Ok("Student Gets Enrolled Successfully!");
        }

    }
}
