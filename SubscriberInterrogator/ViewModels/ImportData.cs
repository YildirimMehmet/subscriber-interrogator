using SubscriberInterrogator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriberInterrogator.ViewModels
{
    /// <summary>
    /// Import view model
    /// </summary>
    public class ImportData
    {
        public List<Subscriber> Subscribers { get; set; }
        public int BlackList { get; set; }
    }
}
