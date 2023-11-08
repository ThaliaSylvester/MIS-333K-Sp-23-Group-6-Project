using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Group_6_Final_Project.Models;
using System.Collections.Generic;


namespace Group6FinalProject.Models.Genre
{
    public enum Genres { Horror, Drama, Action, Comedy }

    public class Genre
    {
            [Key]
            public string GenreID { get; set; }
            public Genres Genres { get; set; }
            public List<Movie> Movies { get; set; }

        public Genre()
        {
            Movies ??= new List<Movie>();
        }

    }
}
