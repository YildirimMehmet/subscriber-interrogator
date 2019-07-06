using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriberInterrogator.Contracts
{
    interface IBaseEntity<TKey> 
    {
        TKey Id { get; set; }
    }
}
