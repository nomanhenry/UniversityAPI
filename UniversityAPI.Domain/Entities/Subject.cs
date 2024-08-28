using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAPI.Domain.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Lecture> Lectures { get; set; } = new List<Lecture>();
        public List<Student> EnrolledStudents { get; set; } = new List<Student>();

        public bool VerifyEnrollment(Student student)
        {
            if (Lectures.Count != 0 && !Lectures.Exists(lecture => lecture.LectureTheatre.VerifyCapacity()))
            {
                int totalMinutes = student.EnrolledSubjects.Sum(s => s.Lectures.Sum(l => l.Duration));
                if (totalMinutes + Lectures.Sum(l => l.Duration) > (10 * 60))
                {
                    return false;
                }

                return true;
            }

            return false;
        }
    }
}
