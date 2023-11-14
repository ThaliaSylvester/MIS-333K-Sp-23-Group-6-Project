using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Group_6_Final_Project.Models;

namespace Group_6_Final_Project.Models
{
    public class Transaction
    {
        private const decimal TAX_RATE = 0.0825m;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionID { get; set; }

        [Display(Name = "Transaction Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime TransactionDate { get; set; }

        [Display(Name = "Number of Tickets")]
        public int NumberofTickets { get; set; }

        [Display(Name = "Order Subtotal")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TransactionSubtotal
        {
            get { return TransactionDetail.Sum(od => od.ExtendedPrice); }
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

        [Display(Name = "Status")]
        public string Status { get; set; }

        //NAVIGATIONAL PROPERTIES 
        public List<TransactionDetail> TransactionDetail { get; set; }
        public AppUser AppUser { get; set; }

        public Transaction()
        {
            if (TransactionDetail == null)
            {
                TransactionDetail = new List<TransactionDetail>();
            }
        }
    }
}