﻿using Time_Tracking.DAL.Entities.Enums;

namespace Time_Tracking.DAL.Entities.Models
{
    public class Todo : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueAt { get; set; }
        public State State { get; set; } = State.NotStarted;
        public Priority Priority { get; set; } = Priority.Normal;
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
