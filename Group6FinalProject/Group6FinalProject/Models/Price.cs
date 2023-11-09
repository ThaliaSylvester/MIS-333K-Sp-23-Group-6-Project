using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace Group_6_Final_Project.Models
{
    public enum TicketType { WeekdayBase, Matinee, DiscountTuesday, Weekends, SpecialEvent }

    public class Price
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string PriceID { get; set; }

        public Decimal TicketPrice { get; set; }

        public TicketType TicketType { get; set; }

        //NAVIGATIONAL PROPERTIES
        public Schedule Schedule { get; set; }
    }
}