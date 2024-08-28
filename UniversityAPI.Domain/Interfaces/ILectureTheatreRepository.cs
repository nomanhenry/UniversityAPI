using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAPI.Domain.Entities;

namespace UniversityAPI.Domain.Interfaces
{
    public interface ILectureTheatreRepository 
    {
        Task<LectureTheatre> GetAsync(int id);
        Task<IEnumerable<LectureTheatre>> GetAllAsync();
        Task AddAsync(LectureTheatre entity);
    }
}
