using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_6_Final_Project.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String ReviewID { get; set; }

        [Display(Name = "Description: ")]
        public string Description { get; set; }

        [Display(Name = "Rating: ")]
        public Int32 Rating { get; set; }

        [Display(Name = "Status: ")]
        public string Status { get; set; }
    }
}