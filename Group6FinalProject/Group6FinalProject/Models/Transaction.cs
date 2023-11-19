using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Group_6_Final_Project.Models
{
    public enum PurchaseStatus { Pending, Purchased, Cancelled }

    public class Transaction
    {
        private const decimal TAX_RATE = 0.0825m;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionID { get; set; }

        [Display(Name = "Transaction Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime TransactionDate { get; set; }

        [Display(Name = "Transaction Notes:")]
        public string? TransactionNote { get; set; }

        [Display(Name = "Order Subtotal")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TransactionSubtotal
        {
            get { return TransactionDetail.Sum(od => od.MoviePrice); }
            private set { /* Make the set accessor private to prevent external modification */ }
        }

        [Display(Name = "Popcorn Points")]
        public int PopcornPoints
        {
            get { return (int)TransactionSubtotal; }
            private set { /* Make the set accessor private to prevent external modification */ }
        }

        [Display(Name = "Transaction Tax")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TransactionTax
        {
            get { return TransactionSubtotal * TAX_RATE; }
            private set { /* Make the set accessor private to prevent external modification */ }
        }

        [Display(Name = "Transaction Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TransactionTotal
        {
            get { return TransactionSubtotal + TransactionTax; }
            private set { /* Make the set accessor private to prevent external modification */ }
        }

        [Display(Name = "Transaction Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public int TotalNumberofSeats
        {
            get { return TransactionDetail.Sum(od => od.NumberofTickets); }
            private set { /* Make the set accessor private to prevent external modification */ }
        }

        [Display(Name = "Status")]
        public PurchaseStatus PurchaseStatus { get; set; }

        // NAVIGATIONAL PROPERTIES
        public List<TransactionDetail> TransactionDetail { get; set; }

        public Transaction()
        {
            if (TransactionDetail == null)
            {
                TransactionDetail = new List<TransactionDetail>();
            }
        }

        public string UserID { get; set; }  // Foreign key for the Product
    }
}