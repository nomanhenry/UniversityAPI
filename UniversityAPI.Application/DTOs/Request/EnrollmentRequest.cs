using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAPI.Application.DTOs.Request
{
    public class EnrollmentRequest
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
    }
}
