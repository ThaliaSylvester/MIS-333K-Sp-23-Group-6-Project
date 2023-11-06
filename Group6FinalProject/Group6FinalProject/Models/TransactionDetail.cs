using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_6_Final_Project.Models
{
    public enum SeatSelection { A1,A2,A3,A4,A5,B1,B2,B3,B4,B5,C1,C2,C3,C4,C5,D1,D2,D3,D4,D5,E1,E2,E3,E4,E5 }

    public class TransactionDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String TransactionDetailID { get; set; }

        public SeatSelection SeatSelection { get; set; }

        [Display(Name = "Extended Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal ExtendedPrice { get; set; }

        public bool SeniorTicket { get; set; }

        public bool CashCard { get; set; }

        //NAVIGATIONAL PROPERTIES
        public string TransactionID { get; internal set; }
        public Schedule Schedule { get; internal set; }
        public Price Price { get; internal set; }
    }
}