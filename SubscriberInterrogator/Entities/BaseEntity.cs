using SubscriberInterrogator.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriberInterrogator.Entities
{
    /// <summary>
    /// Base Entity
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class BaseEntity<TKey> : IBaseEntity<TKey>
    {
        
        public TKey Id { get; set; }

    }
}
