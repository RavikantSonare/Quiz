using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BOLayer
{
    public class BOWithDrawManage
    {
        public int WithDrawOrderId { get; set; }
        public string WithDrawOrderNo { get; set; }
        public decimal Amount { get; set; }
        public int MerchantId { get; set; }
        public bool OrderStatus { get; set; }
        public string MerchantName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Event { get; set; }
    }
}
