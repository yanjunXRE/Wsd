using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PA1.Models
{
    [Table("Customer")]
    public class customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string Password { get; set; }
      
    }
}