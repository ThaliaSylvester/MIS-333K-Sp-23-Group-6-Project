using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static Group6FinalProject.Models.Movie.Movie;

namespace Group6FinalProject.Models.Genre
{
    public class Genre
    {
        public enum Genres { Horror, Drama, Action, Comedy }
        public class GenreModel

        {
            public required string GenreID { get; set; }
            public Genres Genres { get; set; }

        }
    }
}