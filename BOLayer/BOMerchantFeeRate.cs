using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOLayer
{
    public class BOMerchantFeeRate
    {
        public int MerchantFeeRateId { get; set; }
        public int MerchantFeeRate { get; set; }
        public int MerchantLevelId { get; set; }
        public string MerchantLevel { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Event { get; set; }
    }
}
