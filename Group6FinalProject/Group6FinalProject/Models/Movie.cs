using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_6_Final_Project.Models
{
    public enum MPAARating { G, PG, PG13, R }

    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MovieID { get; set; }

        [Required(ErrorMessage = "Movie releases year is required")]
        [Display(Name = "Releases Year: ")]
        public MPAARating MPAARating { get; set; }

        [Required(ErrorMessage = "Published Date is required")]
        [Display(Name = "Date: ")]
        public DateTime PublishedDate { get; set; }

        [Required(ErrorMessage = "Movie title is required")]
        [Display(Name = "Title: ")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Movie description is required")]
        [Display(Name = "Description: ")]
        public string Description { get; set; } 

        [Required(ErrorMessage = "Movie tagline is required")]
        [Display(Name = "Tagline ")]
        public string Tagline { get; set; }

        [Display(Name = "Actors: ")]
        public string Actors { get; set; }

        [Display(Name = "Runtime: ")]
        public int Runtime { get; set; }

        public Genre Genre { get; internal set; }
    }
}
