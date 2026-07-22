using System.Collections.Generic;

namespace BaseSchedule.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;
        public decimal LessonPrice { get; set; }
        public int DefaultDurationMinutes { get; set; }
        
        public ICollection<ScheduleEvent> Lessons { get; set; } = new List<ScheduleEvent>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}