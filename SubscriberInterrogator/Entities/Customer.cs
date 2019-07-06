using SubscriberInterrogator.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriberInterrogator.Data.Entities
{
    /// <summary>
    /// Customer model
    /// </summary>
    public class Customer : BaseEntity<int>
    {

        public virtual ICollection<Subscriber> Subscribers { get; set; }
    }
}
