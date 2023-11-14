using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Group_6_Final_Project.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_6_Final_Project.Models
{
    public enum CustomerRating { One = 1, Two = 2, Three = 3, Four = 4, Five = 5 };
    public class Review
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ReviewID { get; set; }

            public CustomerRating Rating { get; set; }

            [Display(Name = "Description: ")]
            public string Description { get; set; }

            [Display(Name = "Status: ")]
            public string Status { get; set; }

            public List<AppUser> AppUser { get; set; }
            public List<Movie> Movies { get; set; }
    }
}