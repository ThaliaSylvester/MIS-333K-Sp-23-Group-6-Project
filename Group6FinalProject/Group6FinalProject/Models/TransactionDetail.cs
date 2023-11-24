using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_6_Final_Project.Models
{
    public enum SeatSelection { A1, A2, A3, A4, A5, B1, B2, B3, B4, B5, C1, C2, C3, C4, C5, D1, D2, D3, D4, D5, E1, E2, E3, E4, E5 }

    public enum PaymentMethod { CashCard, Points }

    public class TransactionDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionDetailID { get; set; }

        [Range(1, 25, ErrorMessage = "Number of Tickets must be between 1 and 25")]
        [Display(Name = "Number of Tickets")]
        public int NumberOfTickets
        {
            get
            {
                // Calculate the number of tickets based on the SeatSelection
                // For example, you may want to count the number of selected seats
                // and use that as the number of tickets.
                // This is just a placeholder; adjust it based on your logic.

                var selectedSeats = Enum.GetValues(typeof(SeatSelection))
                                        .Cast<SeatSelection>()
                                        .Count(s => s.HasFlag(SeatSelection));

                return selectedSeats;
            }
            private set { }
        }

        public SeatSelection SeatSelection { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        //[Display(Name = "Product Price")]
        //public decimal SchedulePrice { get; set; }

        public int TransactionID { get; set; } // Foreign key for the Order
        public Transaction Transaction { get; set; }

        public int ScheduleID { get; set; } // Foreign key for the Order
        public Schedule Schedule { get; set; }
    }
}
