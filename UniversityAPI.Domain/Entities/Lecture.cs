using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAPI.Domain.Entities
{
        public class Lecture
        {
            public int Id { get; set; }
            public DayOfWeek DayOfWeek { get; set; }

            [DataType(DataType.Time)]
            [DisplayFormat(DataFormatString = "{0:HH:mm:ss}")]
            public string  StartTime { get; set; }
            public int Duration { get; set; }
            public int LectureTheatreId { get; set; }
            public virtual LectureTheatre LectureTheatre { get; set; }
            public int SubjectId { get; set; }
            public virtual Subject Subject { get; set; }
        }
}
