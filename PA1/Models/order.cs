using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PA1.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public string Food_description { get; set; }
        public string Delivery_address { get; set; }
        public string Delivery_date { get; set; }
        public string Delivery_time { get; set; }
        public string Email_address { get; set; }
        public string Contact_number { get; set; }
        public string Order_status { get; set; }
      
    }
}