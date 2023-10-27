using System;
using Microsoft.EntityFrameworkCore;
using Group_6_Final_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Group_6_Final_Project.DAL
{
    //NOTE: This class definition references the user class for this project.  
    //If your User class is called something other than AppUser, you will need
    //to change it in the line below
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //this code makes sure the database is re-created on the $5/month Azure tier
            builder.HasPerformanceLevel("Basic");
            builder.HasServiceTier("Basic");
            base.OnModelCreating(builder);
        }

        //TODO: Add Dbsets here.  Products is included as an example.
        public DbSet<AppUser> FirstName { get; set; }
        public DbSet<AppUser> LastName { get; set; }
        public DbSet<AppUser> DateOfBirth { get; set; }
        public DbSet<AppUser> AddressLine1 { get; set; }
        public DbSet<AppUser> AddressLine2 { get; set; }
        public DbSet<AppUser> City { get; set; }
        public DbSet<AppUser> State { get; set; }
        public DbSet<AppUser> Zip { get; set; }
    }
}
