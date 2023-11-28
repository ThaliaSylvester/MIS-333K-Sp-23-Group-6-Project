using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Group_6_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Group_6_Final_Project.ViewModels
{
    public class ScheduleViewModel
    {
        public IEnumerable<Schedule> Schedules { get; set; }

        public IEnumerable<string> TheatreOptions { get; set; }

        public Theatre? SelectedTheatre { get; set; }

        [DataType(DataType.Date)]
        public DateTime? SelectedWeekStartDate { get; set; }

        public String? searchString { get; set; }
    }
}
