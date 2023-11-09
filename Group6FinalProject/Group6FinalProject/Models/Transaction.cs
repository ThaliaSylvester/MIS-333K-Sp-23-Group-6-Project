using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_6_Final_Project.Models
{
    public class Transaction
    {
        private const decimal TAX_RATE = 0.0825m;

        // Navigational Property: Represents the order details associated with this order
        public List<TransactionDetail> TransactionDetails { get; set; }

        // Navigational Property: Represents the customer who placed this order
        public AppUser AppUser { get; set; }

        public string UserID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string TransactionID { get; set; }

        [Display(Name = "Transaction Number")]
        public int TransactionNumber { get; set; }

        [Display(Name = "Transaction Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime TransactionDate { get; set; }

        [Display(Name = "Number of Tickets")]
        public int NumberofTickets{ get; set; }

        [Display(Name = "Order Subtotal")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TransactionSubtotal
        {
            get { return TransactionDetails.Sum(od => od.ExtendedPrice); }
        }

        [Display(Name = "Popcorn Points")]
        public decimal PopcornPoints
        {
            get { return (decimal)TransactionSubtotal; }
        }

        [Display(Name = "Transaction Tax")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TransactionTax
        {
            get { return TransactionSubtotal * TAX_RATE; }
        }

        [Display(Name = "Transaction Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TransactionTotal
        {
            get { return TransactionSubtotal + TransactionTax; }
        }

        public Transaction()
        {
            // Initialize TransactionDetail as a new List<TransactionDetail>
            TransactionDetails = new List<TransactionDetail>();
        }

        [Display(Name = "Status")]
        public string Status { get; set; }
    }
}
