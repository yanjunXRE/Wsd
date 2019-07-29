using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PA1.Models
{
 
        [Table("AcceptedOrders")]
        public class AcceptedOrder
        {
            [Key]
            public int OrderID { get; set; }
            public string FoodDescription { get; set; }
            public string DeliveryAddress { get; set; }
            public DateTime DeliveryDateTime { get; set; }
            public string EmailAddress { get; set; }
            public int ContactNumber { get; set; }
            public string OrderStatus { get; set; }
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual customer Customer{ get; set; }


    }
}
