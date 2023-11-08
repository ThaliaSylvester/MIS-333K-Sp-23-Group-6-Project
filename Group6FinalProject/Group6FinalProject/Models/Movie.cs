using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace Group6FinalProject.Models
{
    public enum MPAARating { G, PG, PG13, R }

    public class Movie
    {
        [Key]
        public string MovieID { get; set; }
        public MPAARating MPAARating { get; set; }

        [Required(ErrorMessage = "Movie title is required")]
        [Display(Name = "Title: ")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description of movie is required")]
        [Display(Name = "Description: ")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Movie tagline is required")]
        [Display(Name = "Tagline ")]
        public string Tagline { get; set; }

        [Required(ErrorMessage = "Published date is required")]
        [Display(Name = "Published Date: ")]
        public DateTime PublishedDate { get; set; }

        [Required(ErrorMessage = "Featured actors is required")]
        [Display(Name = "Actors: ")]
        public string Actors { get; set; }

        [Required(ErrorMessage = "Runtime is required")]
        [Display(Name = "Runtime: ")]
        public Int32 Runtime { get; set; }
    }
}