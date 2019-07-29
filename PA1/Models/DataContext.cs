using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PA1.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("conn") { }
        public DbSet<customer> customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<AcceptedOrder> AcceptedOrder { get; set; }
       

    }
}