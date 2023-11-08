using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Group_6_Final_Project.Models;
using System.Collections.Generic;


namespace Group6FinalProject.Models.Review
{
    public enum CustomerRating { One = 1, Two = 2, Three = 3, Four = 4, Five = 5 };
    public class Review
    {
            [Key]
            public string ReviewID { get; set; }

            public CustomerRating Rating { get; set; }

            [Display(Name = "Description: ")]
            public string Description { get; set; }

            [Display(Name = "Status: ")]
            public string Status { get; set; }

            public List<AppUser> AppUser { get; set; }



    }
}