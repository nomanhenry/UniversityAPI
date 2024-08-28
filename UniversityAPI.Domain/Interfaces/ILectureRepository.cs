using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAPI.Domain.Entities;

namespace UniversityAPI.Domain.Interfaces
{
    public interface ILectureRepository 
    {
        Task<Lecture> GetAsync(int id);
        Task<IEnumerable<Lecture>> GetAllAsync();
        Task AddAsync(Lecture entity);
    }
}
