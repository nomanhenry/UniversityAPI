using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAPI.Application.Contract;
using UniversityAPI.Application.DTOs.Request;
using UniversityAPI.Application.Services;
using UniversityAPI.Domain.Interfaces;
using UniversityAPI.Infrastructure.Data;
using UniversityAPI.Infrastructure.Repositories;

namespace UniversityAPI.Tests.Application.Service
{
    public class SubjectServiceIntegrationTests
    {
        private readonly ServiceProvider _serviceProvider;

        public SubjectServiceIntegrationTests()
        {
            var serviceCollection = new ServiceCollection();

            // Configure in-memory database
            serviceCollection.AddDbContext<UniversityContext>(options =>
                options.UseInMemoryDatabase("UniversityDb"));

            // Add your repositories
            serviceCollection.AddScoped<ISubjectRepository, SubjectRepository>();
            serviceCollection.AddScoped<IStudentRepository, StudentRepository>();

            // Add your service
            serviceCollection.AddScoped<ISubjectService, SubjectService>();

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        [Fact]
        public async Task CreateAndGetSubject_ShouldReturnSubject()
        {
            // Arrange
            using var scope = _serviceProvider.CreateScope();
            var subjectService = scope.ServiceProvider.GetRequiredService<ISubjectService>();
            var subjectRepo = scope.ServiceProvider.GetRequiredService<ISubjectRepository>();

            var subjectRequest = new SubjectRequest { Name = "CS" };

            // Act
            var createdSubjectResponse = await subjectService.CreateSubjectAsync(subjectRequest);
            var retrievedSubjectResponse = await subjectService.GetSubjectAsync(createdSubjectResponse.Id);

            // Assert
            Assert.NotNull(createdSubjectResponse);
            Assert.Equal(subjectRequest.Name, createdSubjectResponse.Name);
            Assert.NotNull(retrievedSubjectResponse);
            Assert.Equal(createdSubjectResponse.Id, retrievedSubjectResponse.Id);
            Assert.Equal(createdSubjectResponse.Name, retrievedSubjectResponse.Name);
        }

    }
}
