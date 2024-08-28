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
    public class LectureRepository : ILectureRepository
    {
        private readonly UniversityContext _context;

        public LectureRepository(UniversityContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Lecture entity)
        {
            await _context.Lectures.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Lecture> GetAsync(int id)
        {

            return await _context.Lectures.Include(x => x.Subject).Include(m => m.LectureTheatre).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Lecture>> GetAllAsync()
        {
            return await _context.Lectures.Include(x => x.Subject).Include(m => m.LectureTheatre).ToListAsync();
        }

    }
}
