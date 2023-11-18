using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Group_6_Final_Project.Models;

namespace Group_6_Final_Project.Models
{
    public enum Theatre { Theatre1, Theatre2 }
    public class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScheduleID { get; set; }

        [Display(Name = "Start Time")]
        public DateTime DateTime { get; set; }

        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Theater")]
        public Theatre Theatre { get; set; }

        //NAVIGATIONAL PROPERTY
        public int PriceID { get; set; }  // Foreign key for the Product
        public Price Price { get; set; }

        public string MovieID { get; set; }  // Foreign key for the Product
        public Movie Movie { get; set; }

        public List<TransactionDetail> transactionDetails { get; set; }
    }
}