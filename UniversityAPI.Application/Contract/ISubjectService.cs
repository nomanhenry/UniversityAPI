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
    public interface ISubjectService
    {
        Task<SubjectResponse> CreateSubjectAsync(SubjectRequest subjectRequest);

        Task<IEnumerable<SubjectResponse>> GetAllAsync();

        Task<SubjectResponse> GetSubjectAsync(int id);
        Task<IEnumerable<SubjectResponse>> GetByStudentIdAsync(int studentId);
        Task StudentEnrollmentAsync(EnrollmentRequest enroll);


    }

}
