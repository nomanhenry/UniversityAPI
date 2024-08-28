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
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepo;
        private readonly IStudentRepository _studentRep;

        public SubjectService(ISubjectRepository subjectRepo, IStudentRepository studentRep)
        {
            _subjectRepo = subjectRepo;
            _studentRep = studentRep;
        }


        public async Task<SubjectResponse> CreateSubjectAsync(SubjectRequest subjectRequest)
        {
            var subject = subjectRequest.Adapt<Subject>();

            await _subjectRepo.AddAsync(subject);

            return subject.Adapt<SubjectResponse>();
        }

        public async Task<SubjectResponse> GetSubjectAsync(int id)
        {
            var subject = await _subjectRepo.GetAsync(id);

            return subject.Adapt<SubjectResponse>();
        }

        public async Task<IEnumerable<SubjectResponse>> GetAllAsync()
        {
            var subject = await _subjectRepo.GetAllAsync();

            return subject.Adapt<IEnumerable<SubjectResponse>>();
        }

        public async Task<IEnumerable<SubjectResponse>> GetByStudentIdAsync(int studentId)
        {
            var subjects = await _subjectRepo.GetByStudentIdAsync(studentId);

            return subjects.Adapt<IEnumerable<SubjectResponse>>();
        }

        public async Task StudentEnrollmentAsync(EnrollmentRequest enroll)
        {
            var subject = await _subjectRepo.GetAsync(enroll.SubjectId);

            if (subject == null)
            {
                throw new KeyNotFoundException($"Entity with ID '{enroll.SubjectId}' was not found in the database.");
                
            }

            var student = await _studentRep.GetAsync(enroll.StudentId);

            if (student == null)
            {
                throw new KeyNotFoundException($"Entity with ID '{enroll.StudentId}' was not found in the database.");
            }

            if (!subject.VerifyEnrollment(student))
            {
                throw new InvalidOperationException("The Student exceed the maximum allowed weekly lecture hours or Lecture Theatre capacity gets exceeed.");

            }

            student.EnrolledSubjects.Add(subject);

            _studentRep.Update(student);

        }

    }
}
