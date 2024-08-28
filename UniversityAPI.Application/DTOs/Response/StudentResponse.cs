using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAPI.Domain.Entities;

namespace UniversityAPI.Application.DTOs.Response
{
    public class StudentResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Subject> EnrolledSubjects { get; set; } = new List<Subject>();
    }
}
