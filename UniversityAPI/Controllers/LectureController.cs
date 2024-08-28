using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Application.Contract;
using UniversityAPI.Application.DTOs.Request;

namespace UniversityAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LectureController : ControllerBase
    {
        private readonly ILectureService _lectureService;

        public LectureController(ILectureService lectureService)
        {
            _lectureService = lectureService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLecture([FromBody] LectureRequest lectureRequest)
        {
            var lecture = await _lectureService.CreateLectureAsync(lectureRequest);
            return CreatedAtAction(nameof(GetLectures), new { id = lecture }, lecture);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLectures(int id)
        {
            var lectures = await _lectureService.GetLectureAsync(id);
            if (lectures == null) return NotFound();
            return Ok(lectures);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLectures()
        {
            var res = await _lectureService.GetAllAsync();
            return Ok(res);
        }

    }
}
