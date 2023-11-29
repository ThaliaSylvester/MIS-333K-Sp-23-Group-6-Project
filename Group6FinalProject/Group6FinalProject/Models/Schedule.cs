using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_6_Final_Project.Models
{
    public enum Theatre { Theatre1, Theatre2 }

    public class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScheduleID { get; set; }

        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Display(Name = "End Time")]
        public DateTime EndTime => StartTime + Movie.Runtime;

        [Display(Name = "Theater")]
        public Theatre Theatre { get; set; }

        // NAVIGATIONAL PROPERTY
        public int PriceID { get; set; }  // Foreign key for the Price
        public Price Price { get; set; }

        public string MovieID { get; set; }  // Foreign key for the Movie
        public Movie Movie { get; set; }

        public List<TransactionDetail> TransactionDetails { get; set; }

        public Schedule()
        {
            TransactionDetails ??= new List<TransactionDetail>();
        }
    }
}