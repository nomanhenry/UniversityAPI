using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAPI.Application.DTOs.Request;
using UniversityAPI.Application.DTOs.Response;

namespace UniversityAPI.Application.Contract
{
    public interface ILectureService
    {
        Task<LectureResponse> CreateLectureAsync(LectureRequest LectureRequest);

        Task<IEnumerable<LectureResponse>> GetAllAsync();

        Task<LectureResponse> GetLectureAsync(int id);
    }
}
