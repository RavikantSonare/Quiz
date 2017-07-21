using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAdmin.BOLayer
{
    public class BOPaymentOption
    {
        public int PaymentOptionId { get; set; }
        public string PaymentOption { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Event { get; set; }
    }
}