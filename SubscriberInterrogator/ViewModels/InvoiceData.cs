using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriberInterrogator.ViewModels
{
    /// <summary>
    /// Invoice view model
    /// </summary>
    public class InvoiceData
    {
        public string SubscriberNo { get; set; }
        public DateTime DueDate { get; set; }
        public string Period { get; set; }
        public string InvoiceNo { get; set; }
    }
}
