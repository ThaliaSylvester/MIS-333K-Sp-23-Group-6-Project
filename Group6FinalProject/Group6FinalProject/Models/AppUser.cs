using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Group_6_Final_Project.Models
{
    public class AppUser : IdentityUser
    {
        [Display(Name ="First Name: ")]
        public string FirstName { get; set; }

        [Display(Name ="Last Name: ")]
        public string LastName { get; set; }

        [Display(Name = "Email: ")]
        public string Email { get; set; }

        [Display(Name ="Date of Birth: ")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Zip")]
        public string Zip { get; set; }

    }
}