using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMerchant.BOLayer
{
    class BOFinanceConfig
    {
        public int FinanceConfigId { get; set; }
        public int PaymentOptionId { get; set; }
        public string PaymentOption { get; set; }
        public int MerchantId { get; set; }
        public string AccountEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string BankOfName { get; set; }
        public string SwiftCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Event { get; set; }
    }
}
