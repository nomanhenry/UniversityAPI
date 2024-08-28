using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAPI.Domain.Entities;

namespace UniversityAPI.Application.DTOs.Response
{
    public class SubjectResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Lecture> Lectures { get; set; } = new List<Lecture>();
        public List<Student> EnrolledStudents { get; set; } = new List<Student>();
    }
}
