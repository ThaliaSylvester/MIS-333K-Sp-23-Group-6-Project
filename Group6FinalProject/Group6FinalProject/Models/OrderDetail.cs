using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using Mikel_Ethan_HW5.Models;

namespace Mikel_Ethan_HW5.Models
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 OrderDetailID { get; set; }

        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Product Price")]
        public Decimal ProductPrice { get; set; }

        [Display(Name = "Extended Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal ExtendedPrice { get; set; }

        public int OrderID { get; set; }  // Foreign key for the Order
        public Order Order { get; set; }

        public int ProductID { get; set; }  // Foreign key for the Product
        public Product Product { get; set; }
    }
}
