using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOLayer
{
    public class BOSalesReports
    {
        public int OrderId { get; set; }
        public string OrderNo { get; set; }
        public int ExamCodeId { get; set; }
        public string ExamCode { get; set; }
        public int SecondCategoryId { get; set; }
        public string SecondCategory { get; set; }
        public int MerchantId { get; set; }
        public string MerchantName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
        public int FeeRateId { get; set; }
        public int FeeRate { get; set; }
        public decimal NetAmount { get; set; }
        public bool OrderStatus { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Event { get; set; }
    }
}
