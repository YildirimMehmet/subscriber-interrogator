using SubscriberInterrogator.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriberInterrogator.Data.Entities
{
    /// <summary>
    /// Subscriber model
    /// </summary>
    public class Subscriber : BaseEntity<Guid>
    {
        public string No { get; set; }
        public virtual Customer Customer { get; set; }
        
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }

    }
}
