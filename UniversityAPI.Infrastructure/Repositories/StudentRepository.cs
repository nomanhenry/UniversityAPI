using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UniversityAPI.Domain.Entities;
using UniversityAPI.Domain.Interfaces;
using UniversityAPI.Infrastructure.Data;

namespace UniversityAPI.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly UniversityContext _context;

        public StudentRepository(UniversityContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Student entity)
        {
            await _context.Students.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Student> GetAsync(int id)
        {
            return await _context.Students.Include(x => x.EnrolledSubjects).ThenInclude(m => m.Lectures).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async void Update(Student Student)
        {
             _context.Students.Update(Student);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.Include(m => m.EnrolledSubjects).ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetBySubjectIdAsync(int subjectId) 
        {
            return await _context.Students.Where(m => m.EnrolledSubjects.Select(m => m.Id).Contains(subjectId)).ToListAsync();

        }

    }
}
