using SubscriberInterrogator.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriberInterrogator.Data.Entities
{
 
    /// <summary>
    /// Payment model
    /// </summary>
    public class Payment : BaseEntity<Guid>
    {
        
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
 

        public virtual Subscriber Subscriber { get; set; }

    }
}
