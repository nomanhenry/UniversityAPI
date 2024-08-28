using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAPI.Domain.Entities
{
    public class LectureTheatre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Lecture> Lectures { get; set; } = new List<Lecture>();

        public bool VerifyCapacity() => Lectures.Count > Capacity;
    }
}
