using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Group_6_Final_Project.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_6_Final_Project.Models
{
    public class AppDateTime
    {
        public int AppDateTimeId { get; set; } // Placeholder property for EF Core

        private DateTime _dateTime;

        // Parameterless constructor for Entity Framework
        protected AppDateTime()
        {
        }

        // Constructor with parameters for your application logic
        public AppDateTime(int year = 2023, int month = 1, int day = 1, int hour = 0, int minute = 0, int second = 0)
        {
            SetDateTime(year, month, day, hour, minute, second);
        }

        public void SetDateTime(int year, int month, int day, int hour, int minute, int second)
        {
            _dateTime = new DateTime(year, month, day, hour, minute, second);
        }

        public DateTime GetDateTime()
        {
            return _dateTime;
        }

        public override string ToString()
        {
            return _dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}