using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace Group6FinalProject.Models.Review
{
    public class Review
    {
        public class ReviewModel
        {
            public required string ReviewID { get; set; }

            [Display(Name = "Description: ")]
            public string Description { get; set; }

            [Display(Name = "Rating: ")]
            public Int32 Rating { get; set; }

            [Display(Name = "Status: ")]
            public string Status { get; set; }

        }
    }
}