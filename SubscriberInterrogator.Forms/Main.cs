using SubscriberInterrogator.Business.Helpers;
using SubscriberInterrogator.Business.Providers;
using SubscriberInterrogator.Data.Entities;
using SubscriberInterrogator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubscriberInterrogator.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            FillDatas();
        }

        /// <summary>
        /// Fill subscriber datas
        /// </summary>
        /// <param name="subscriberNo"></param>
        public void FillDatas(string subscriberNo = null)
        {
            int totalBlackList = 0;
            FileParser fileParser = new FileParser();
            PaymentProvider paymentProvider = new PaymentProvider();
            string targetPath = @"Datas";
            Directory.CreateDirectory(targetPath);
            string[] filesindirectory = Directory.GetFiles(targetPath);
            List<Subscriber> subscribers = new List<Subscriber>();
            ImportData importData;
            foreach (var item in filesindirectory)
            {
                importData = paymentProvider.ImportPayment(FileParser.ParseFile(item));
                subscribers.AddRange(importData.Subscribers);
                totalBlackList += importData.BlackList;
            }

            if (subscriberNo != string.Empty && subscriberNo != null)
            {
                subscribers = subscribers.Where(i => i.No == subscriberNo).ToList();
            }

            List<PaymentData> paymentDatas = new List<PaymentData>();
            List<InvoiceData> invoiceDatas = new List<InvoiceData>();
            foreach (var item in subscribers)
            {

                foreach (var payment in item.Payments)
                {
                    paymentDatas.Add(new PaymentData
                    {
                        Amount = payment.Amount,
                        SubscriberNo = payment.Subscriber.No,
                        Date = payment.Date
                    });
                }
                lblPayment.Text = paymentDatas.Sum(i => i.Amount).ToString();
                foreach (var invoice in item.Invoices)
                {
                    invoiceDatas.Add(new InvoiceData
                    {
                        DueDate = invoice.DueDate,
                        InvoiceNo = invoice.No,
                        Period = invoice.Period,
                        SubscriberNo = invoice.Subscriber.No
                    });
                }
            }
            

            DataTable dt = new DataTable();
            ConvertDataTable convertDataTable = new ConvertDataTable();
            dt = convertDataTable.ConvertToDataTable<InvoiceData>(invoiceDatas);
            dViewInvoices.DataSource = dt;

            DataTable dt2 = new DataTable();
            ConvertDataTable convertDataTable2 = new ConvertDataTable();
            dt2 = convertDataTable.ConvertToDataTable<PaymentData>(paymentDatas);
            dViewPayments.DataSource = dt2;

            if (totalBlackList > 0) MessageBox.Show($"{totalBlackList } datas could not be added to the system.");
        }


        /// <summary>
        /// Button click : Upload new datas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChoose_Click(object sender, EventArgs e)
        {
            FileChooser fileChooser = new FileChooser();
            string filePath = fileChooser.ChooseFile();
            if (filePath != string.Empty)
            {
                FillDatas();
            }
        }

        /// <summary>
        /// Button click : Filter datas by subscriber no
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilter_Click(object sender, EventArgs e)
        {
            string promptValue = Prompt.ShowDialog("Subscriber No:", "Filter Subscriber");
            FillDatas(promptValue);
        }

    }
}
