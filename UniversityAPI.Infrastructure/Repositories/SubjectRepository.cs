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
    public class SubjectRepository : ISubjectRepository
    {
        private readonly UniversityContext _context;

        public SubjectRepository(UniversityContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Subject entity)
        {
            await _context.Subjects.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Subject> GetAsync(int id)
        {
            return await _context.Subjects.Include(x => x.Lectures).ThenInclude(m => m.LectureTheatre).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await _context.Subjects.Include(x => x.Lectures).ToListAsync();
        }

        public async Task<IEnumerable<Subject>> GetByStudentIdAsync(int studentId)
        {
            return await _context.Subjects.Where(m => m.EnrolledStudents.Select(m => m.Id).Contains(studentId)).ToListAsync();
        }


    }
}
