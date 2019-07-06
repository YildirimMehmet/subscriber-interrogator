using SubscriberInterrogator.Data.Entities;
using SubscriberInterrogator.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriberInterrogator.Business.Contracts
{
    /// <summary>
    /// IPaymentProvider
    /// </summary>
    public interface IPaymentProvider
    {
        /// <summary>
        /// Import Payment
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        ImportData ImportPayment(List<string> datas);
    }
}
