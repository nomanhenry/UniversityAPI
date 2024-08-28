using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Application.Contract;
using UniversityAPI.Application.DTOs;
using UniversityAPI.Application.DTOs.Request;
using UniversityAPI.Application.Services;

namespace UniversityAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LectureTheatreController : ControllerBase
    {
        private readonly ILectureTheatreService _lectureTheatreService;

        public LectureTheatreController(ILectureTheatreService lectureTheatreService)
        {
            _lectureTheatreService = lectureTheatreService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLectureTheatre([FromBody] LectureTheatreRequest lectureTheatreRequest)
        {
            var lectureTheatre = await _lectureTheatreService.CreateLectureTheatreAsync(lectureTheatreRequest);
            return CreatedAtAction(nameof(GetLectureTheatre), new { id = lectureTheatre }, lectureTheatre);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLectureTheatre(int id)
        {
            var lectureTheatre = await _lectureTheatreService.GetLectureTheatreAsync(id);
            if (lectureTheatre == null) return NotFound();
            return Ok(lectureTheatre);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLectures()
        {
            return Ok(await _lectureTheatreService.GetAllAsync());
        }
    }
}
