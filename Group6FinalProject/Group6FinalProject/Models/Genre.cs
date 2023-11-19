using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Group_6_Final_Project.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_6_Final_Project.Models
{
    public enum Genres { Horror, Drama, Action, Comedy, ChildrenFamily, Romance, Musical, SciFi }

    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenreID { get; set; }

        public Genres Genres { get; set; }

        //NAVIGATIONAL PROPERTIES
        public List<Movie> Movie { get; set; }

    }
}