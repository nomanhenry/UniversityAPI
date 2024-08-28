using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAPI.Domain.Entities;

namespace UniversityAPI.Domain.Interfaces
{
    public interface IStudentRepository 
    {
        Task<Student> GetAsync(int id);
        Task<IEnumerable<Student>> GetAllAsync();
        Task AddAsync(Student entity);
        Task<IEnumerable<Student>> GetBySubjectIdAsync(int subjectId);
        void Update(Student Student);
    }
}
