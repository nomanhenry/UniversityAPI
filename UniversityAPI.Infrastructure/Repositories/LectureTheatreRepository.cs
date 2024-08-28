using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAPI.Domain.Entities;
using UniversityAPI.Domain.Interfaces;
using UniversityAPI.Infrastructure.Data;

namespace UniversityAPI.Infrastructure.Repositories
{
    public class LectureTheatreRepository : ILectureTheatreRepository
    {
        private readonly UniversityContext _context;

        public LectureTheatreRepository(UniversityContext context)
        {
            _context = context;
        }

        public async Task AddAsync(LectureTheatre entity)
        {
            await _context.LectureTheatres.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<LectureTheatre> GetAsync(int id)
        {
            return await _context.LectureTheatres.FindAsync(id);
        }

        public async Task<IEnumerable<LectureTheatre>> GetAllAsync()
        {
            return await _context.LectureTheatres.ToListAsync();
        }

    }
}
