using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAPI.Domain.Entities;

namespace UniversityAPI.Domain.Interfaces
{
    public interface ISubjectRepository 
    {
        Task<Subject> GetAsync(int id);
        Task<IEnumerable<Subject>> GetAllAsync();
        Task AddAsync(Subject entity);
        Task<IEnumerable<Subject>> GetByStudentIdAsync(int studentId);

    }
}
