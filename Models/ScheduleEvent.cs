using System;

namespace BaseSchedule.Models
{
    public class ScheduleEvent
    {
        public int Id { get; set; }
        public EventType Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ZoomLink { get; set; } = string.Empty;
        public string LessonTopic { get; set; } = string.Empty;
        
        public bool IsTemporaryChange { get; set; }
        public int? OriginalEventId { get; set; }
        
        public int? StudentId { get; set; }
        public Student? Student { get; set; }
    }
}