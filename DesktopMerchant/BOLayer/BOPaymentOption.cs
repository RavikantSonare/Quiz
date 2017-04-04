using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMerchant.BOLayer
{
    class BOPaymentOption
    {
        public int PaymentOptionId { get; set; }
        public string PaymentOption { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string Event { get; set; }
    }
}
