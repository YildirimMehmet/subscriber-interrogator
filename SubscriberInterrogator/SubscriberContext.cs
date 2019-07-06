using SubscriberInterrogator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace SubscriberInterrogator
{
    public class SubscriberContext : DbContext
    {
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Subscriber> Subscribers { get; set; }
        public IDbSet<Invoice> Invoices { get; set; }
        public IDbSet<Payment> Payments { get; set; }
 
    }
}
