using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace Group6FinalProject.Models.Movie
{
    public class Movie
    {
        public enum MPAARating { G, PG, PG12, R }
        public class MovieModel
        {
            public required string MovieID { get; set; }
            public MPAARating MPAARating { get; set; }

            [Required(ErrorMessage = "Date is required")]
            [Display(Name = "Date: ")]
            public DateTime Date { get; set; }

            [Required(ErrorMessage = "Movie titile is required")]
            [Display(Name = "Titile: ")]
            public string Titile { get; set; }

            [Required(ErrorMessage = "Movie tagline is required")]
            [Display(Name = "Tagline ")]
            public string Tagline { get; set; }

            [Required(ErrorMessage = "Movie releases year is required")]
            [Display(Name = "Releases Year: ")]
            public DateTime ReleasesYear { get; set; }

            [Display(Name = "Customer Rating: ")]
            public string CustomerRating { get; set; }

            [Display(Name = "Actors: ")]
            public string Actors { get; set; }
        }
    }
}