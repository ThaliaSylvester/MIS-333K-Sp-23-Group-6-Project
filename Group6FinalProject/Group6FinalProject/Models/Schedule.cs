using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Group_6_Final_Project.Models
{
    public enum Theatre { Theatre1, Theatre2 }
    public class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String ScheduleID { get; set; }

        [Display(Name = "Start Time")]
        public DateTime DateTime { get; set; }

        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Theater")]
        public Theatre Theatre { get; set; }

        [Display(Name = "Special Event")]
        public Boolean SpecialEvent { get; set; }

        //NAVIGATIONAL PROPERTY
        public List<Price> Prices { get; set; }
        public List<Movie> Movie { get; set; }

    }
}