using System;
using System.Text.Json.Serialization;

namespace BaseSchedule.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsPaid { get; set; }
        
        public int StudentId { get; set; }
        
        [JsonIgnore]
        public Student? Student { get; set; }
        
        public int? ScheduleEventId { get; set; }
        
        [JsonIgnore]
        public ScheduleEvent? ScheduleEvent { get; set; }
    }
}