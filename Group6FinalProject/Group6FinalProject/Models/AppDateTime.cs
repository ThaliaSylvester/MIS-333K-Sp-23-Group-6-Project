using System;
using System.ComponentModel.DataAnnotations;

namespace Group_6_Final_Project.Models
{
    public class AppDateTime
    {
        public int AppDateTimeId { get; set; } // Placeholder property for EF Core

        [Display(Name = "Global Time:")]
        public DateTime GlobalTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }

        private DateTime _dateTime;

        // Parameterless constructor for Entity Framework
        protected AppDateTime()
        {
        }

        // Constructor with parameters for your application logic
        public AppDateTime(DateTime globalTime)
        {
            SetDateTime(globalTime);
        }

        public void SetDateTime(DateTime globalTime)
        {
            _dateTime = globalTime;
        }

        public override string ToString()
        {
            return _dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}