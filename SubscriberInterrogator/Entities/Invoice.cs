using SubscriberInterrogator.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriberInterrogator.Data.Entities
{
    /// <summary>
    /// Invoice model
    /// </summary>
    public class Invoice : BaseEntity<Guid>
    {
        
        public DateTime DueDate { get; set; }
        public string Period { get; set; }
        public string No { get; set; }


        public virtual Subscriber Subscriber { get; set; }
    }
}
