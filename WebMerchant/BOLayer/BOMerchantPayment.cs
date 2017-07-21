using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMerchant.BOLayer
{
    public class BOMerchantPayment
    {
        public int PaymentId { get; set; }

        public int MerchantId { get; set; }

        public string MerchantOrderNo { get; set; }

        public string SId { get; set; }

        public string Key { get; set; }

        public string Order_Number { get; set; }

        public string CurrencyCode { get; set; }

        public string InvoiceId { get; set; }

        public decimal TotalAmount { get; set; }

        public string CCProcess { get; set; }

        public string PayMethod { get; set; }

        public DateTime Date { get; set; }

        public string PaymentData { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public string Event { get; set; }
    }
}