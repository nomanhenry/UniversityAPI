using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAPI.Application.DTOs.Request;
using UniversityAPI.Application.DTOs.Response;

namespace UniversityAPI.Application.Contract
{
    public interface ILectureTheatreService
    {
        Task<LectureTheatreResponse> CreateLectureTheatreAsync(LectureTheatreRequest LectureTheatreRequest);

        Task<IEnumerable<LectureTheatreResponse>> GetAllAsync();

        Task<LectureTheatreResponse> GetLectureTheatreAsync(int id);
    }
}
