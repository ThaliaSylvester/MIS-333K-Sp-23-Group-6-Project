using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Mikel_Ethan_HW5.Models;

namespace Mikel_Ethan_HW5.Models
{
    public class Order
    {
        public const Decimal TAX_RATE = 0.0825m;

        [Key]
        public Int32 OrderID { get; set; }

        [Display(Name = "Order Number:")]
        public Int32 OrderNumber { get; set; }

        [Display(Name = "Order Date:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM d, yyyy}")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Order Notes:")]
        public String OrderNotes { get; set; }

        [Display(Name = "Order Subtotal")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal OrderSubtotal
        {
            get { return OrderDetails.Sum(od => od.ExtendedPrice); }
        }

        [Display(Name = "Tax Rate")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal TaxRate
        {
            get { return OrderSubtotal * TAX_RATE; }
        }

        [Display(Name = "Order Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal OrderTotal
        {
            get { return OrderSubtotal + TaxRate; }
        }

        //NAVIGATIONAL PROPERTIES 
        public List<OrderDetail> OrderDetails { get; set; }
        public AppUser User { get; set; }

        public Order()
        {
            if (OrderDetails == null)
            {
                OrderDetails = new List<OrderDetail>();
            }
        }
    }
}