using Mapster;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAPI.Application.DTOs.Request;
using UniversityAPI.Application.DTOs.Response;
using UniversityAPI.Application.Services;
using UniversityAPI.Domain.Entities;
using UniversityAPI.Domain.Interfaces;

namespace UniversityAPI.Tests.Application.Service
{
    public class SubjectServiceUnitTests
    {
        private readonly SubjectService _subjectService;
        private readonly Mock<ISubjectRepository> _subjectRepoMock;
        private readonly Mock<IStudentRepository> _studentRepoMock;

        public SubjectServiceUnitTests()
        {
            _subjectRepoMock = new Mock<ISubjectRepository>();
            _studentRepoMock = new Mock<IStudentRepository>();
            _subjectService = new SubjectService(_subjectRepoMock.Object, _studentRepoMock.Object);
        }

        [Fact]
        public async Task CreateSubjectAsync_ShouldReturnSubjectResponse()
        {
            // Arrange
            var subjectRequest = new SubjectRequest 
            {
                Id = 1,
                Name = "CS"
            };
            var subject = new Subject 
            {
                Id = 1,
                Name = "CS",
                Lectures = new List<Lecture>(),
                EnrolledStudents = new List<Student>()
            };

            var subjectResponse = new SubjectResponse { Id = 1, Name = "CS", Lectures = new List<Lecture>(), EnrolledStudents = new List<Student>() };

            _subjectRepoMock.Setup(repo => repo.AddAsync(It.IsAny<Subject>())).Returns(Task.CompletedTask);
            subjectRequest.Adapt<Subject>();
            subject.Adapt<SubjectResponse>();

            // Act
            var result = await _subjectService.CreateSubjectAsync(subjectRequest);

            // Assert
            Assert.Equal(subjectResponse.Id, result.Id);
            Assert.Equal(subjectResponse.Name, result.Name);
            Assert.Equal(subjectResponse.Lectures.Count, result.Lectures.Count);
            Assert.Equal(subjectResponse.EnrolledStudents.Count, result.EnrolledStudents.Count);

            for (int i = 0; i < subjectResponse.Lectures.Count; i++)
            {
                Assert.Equal(subjectResponse.Lectures[i], result.Lectures[i]);
            }

            for (int i = 0; i < subjectResponse.EnrolledStudents.Count; i++)
            {
                Assert.Equal(subjectResponse.EnrolledStudents[i], result.EnrolledStudents[i]);
            }
        }

        [Fact]
        public async Task GetSubjectAsync_ShouldReturnSubjectResponse()
        {
            // Arrange
            var subjectId = 1;
            var subject = new Subject
            {
                Id = subjectId,
                Name = "CSS",
                Lectures = new List<Lecture>(),
                EnrolledStudents = new List<Student>()
            };
            var subjectResponse = new SubjectResponse { Id = subjectId, Name = "CS" };

            _subjectRepoMock.Setup(repo => repo.GetAsync(subjectId)).ReturnsAsync(subject);

            // Act
            var result = await _subjectService.GetSubjectAsync(subjectId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(subjectResponse.Id, result.Id);
            Assert.Equal(subjectResponse.Name, result.Name);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllSubjects()
        {
            // Arrange
            var subjects = new List<Subject>
            {
                new Subject { Id = 1, Name = "CS1", Lectures = new List<Lecture>(), EnrolledStudents = new List<Student>() },
                new Subject { Id = 2, Name = "CS2", Lectures = new List<Lecture>(), EnrolledStudents = new List<Student>() }
            };

            var subjectResponses = subjects.Select(s => new SubjectResponse { Id = s.Id, Name = s.Name }).ToList();

            _subjectRepoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(subjects);

            // Act
            var result = await _subjectService.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(subjectResponses.Count, result.Count());
        }

        
        [Fact]
        public async Task StudentEnrollmentAsync_SubjectNotFound_ThrowsKeyNotFoundException()
        {
            // Arrange
            var enrollmentRequest = new EnrollmentRequest { SubjectId = 1, StudentId = 1 };

            _subjectRepoMock.Setup(repo => repo.GetAsync(enrollmentRequest.SubjectId))
                            .ReturnsAsync((Subject)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _subjectService.StudentEnrollmentAsync(enrollmentRequest));
            Assert.Equal($"Entity with ID '{enrollmentRequest.SubjectId}' was not found in the database.", exception.Message);
        }

        [Fact]
        public async Task StudentEnrollmentAsync_StudentNotFound_ThrowsKeyNotFoundException()
        {
            // Arrange
            var enrollmentRequest = new EnrollmentRequest { SubjectId = 1, StudentId = 1 };
            var subject = new Subject();

            _subjectRepoMock.Setup(repo => repo.GetAsync(enrollmentRequest.SubjectId))
                            .ReturnsAsync(subject);
            _studentRepoMock.Setup(repo => repo.GetAsync(enrollmentRequest.StudentId))
                            .ReturnsAsync((Student)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _subjectService.StudentEnrollmentAsync(enrollmentRequest));
            Assert.Equal($"Entity with ID '{enrollmentRequest.StudentId}' was not found in the database.", exception.Message);
        }

    
    }
}
