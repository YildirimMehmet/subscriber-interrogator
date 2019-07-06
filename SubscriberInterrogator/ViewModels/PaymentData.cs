using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriberInterrogator.ViewModels
{
    /// <summary>
    /// Payment view model
    /// </summary>
    public class PaymentData
    {
        public string SubscriberNo { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
