using System;

namespace BaseSchedule.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsPaid { get; set; }
        
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        
        public int? ScheduleEventId { get; set; }
        public ScheduleEvent? ScheduleEvent { get; set; }
    }
}