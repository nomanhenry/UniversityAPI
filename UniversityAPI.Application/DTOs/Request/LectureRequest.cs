using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAPI.Application.DTOs.Request
{
    public class LectureRequest
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}")]
        public string StartTime { get; set; }
        public int Duration { get; set; }
        public int SubjectId { get; set; }
        public int LectureTheatreId { get; set; }
    }
}
