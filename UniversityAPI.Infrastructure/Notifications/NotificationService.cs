using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAPI.Infrastructure.Notifications
{
    public class NotificationService
    {
        public void NotifyStudent(string studentId, string studentName)
        {
            File.WriteAllText($"{studentId}_notification.txt", $"Student {studentName} has been enrolled.");
        }
    }
}
