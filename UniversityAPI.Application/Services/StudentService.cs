using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAPI.Application.Contract;
using UniversityAPI.Application.DTOs;
using UniversityAPI.Application.DTOs.Request;
using UniversityAPI.Application.DTOs.Response;
using UniversityAPI.Domain.Entities;
using UniversityAPI.Domain.Interfaces;

namespace UniversityAPI.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepo;

        public StudentService(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }


        public async Task<StudentResponse> CreateStudentAsync(StudentRequest studentRequest)
        {
            var student = studentRequest.Adapt<Student>();

            await _studentRepo.AddAsync(student);

            return student.Adapt<StudentResponse>();
        }

        public async Task<StudentResponse> GetStudentAsync(int id)
        {
            var student = await _studentRepo.GetAsync(id);

            return student.Adapt<StudentResponse>();
        }

        public async Task<IEnumerable<StudentResponse>> GetAllAsync()
        {
            var students = await _studentRepo.GetAllAsync();

            return students.Adapt<IEnumerable<StudentResponse>>();
        }

        public async Task<IEnumerable<StudentResponse>> GetBySubjectIdAsync(int subjectId)
        {
            var students = await _studentRepo.GetBySubjectIdAsync(subjectId);

            return students.Adapt<IEnumerable<StudentResponse>>();
        }
    }
}
