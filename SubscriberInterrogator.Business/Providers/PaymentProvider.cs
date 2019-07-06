using SubscriberInterrogator.Business.Contracts;
using SubscriberInterrogator.Business.Helpers;
using SubscriberInterrogator.Data.Entities;
using SubscriberInterrogator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubscriberInterrogator.Business.Providers
{
    /// <summary>
    /// Payment işlemleri için sağlayıcıdır.
    /// </summary>
    public class PaymentProvider : IPaymentProvider
    {

        /// <summary>
        /// Müşterinin sisteme verdiği veriyi objelere dönüştürür. Yüklenen dosyalarda her bir veri 61 karakter olmalıdır aksi taktirde hatalı olarak sisteme yansır ve log eklenir. 
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public ImportData ImportPayment(List<string> datas)
        {
            int blackList = 0;

            Customer customer = new Customer();
            customer.Id = 1;

            List<Subscriber> subscribers = new List<Subscriber>();
            List<Payment> payments = new List<Payment>();
            List<Invoice> invoices = new List<Invoice>();

            Subscriber subscriber;
            foreach (var item in datas)
            {
                
                if (item.Length == 61)
                {
                    subscriber = new Subscriber
                    {
                        No = item.Substring(1, 9)
                    };

                    subscribers.Add(subscriber);

                    payments.Add(new Payment
                    {
                        Id = Guid.NewGuid(),
                        Amount = Convert.ToDecimal(item.Substring(18, 15)),
                        Subscriber = subscriber
                    });

                    invoices.Add(new Invoice
                    {
                        Id = Guid.NewGuid(),
                        Subscriber = subscriber,
                        DueDate = Convert.ToDateTime(item.Substring(33, 10)),
                        Period = item.Substring(46, 4),
                        No = item.Substring(50, 11)
                    });
                }
                else
                {
                    Logger.LogMessage($"Wrong data: {item}");
                    blackList++;
                }
            }
            subscribers = subscribers.Distinct().ToList();



            foreach (var item in subscribers)
            {
                item.Customer = customer;
                item.Invoices = invoices.Where(i => i.Subscriber == item).ToList();
                item.Payments = payments.Where(i => i.Subscriber == item).ToList();
            }

            return new ImportData()
            {
                Subscribers = subscribers,
                BlackList = blackList
            };

        }
    }
}
