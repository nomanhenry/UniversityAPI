using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAPI.Application.DTOs;
using UniversityAPI.Application.DTOs.Request;
using UniversityAPI.Application.DTOs.Response;

namespace UniversityAPI.Application.Contract
{
    public interface IStudentService
    {
        Task<StudentResponse> CreateStudentAsync(StudentRequest studentRequest);

        Task<IEnumerable<StudentResponse>> GetAllAsync();

        Task<StudentResponse> GetStudentAsync(int id);

        Task<IEnumerable<StudentResponse>> GetBySubjectIdAsync(int subjectId);

        

    }
}
