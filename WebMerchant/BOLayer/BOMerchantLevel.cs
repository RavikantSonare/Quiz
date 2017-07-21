using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMerchant.BOLayer
{
    public class BOMerchantLevel
    {
        public int MerchantLevelId { get; set; }
        public string MerchantLevel { get; set; }
        public decimal AnnualFee { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Event { get; set; }
    }
}