using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMerchant.BOLayer
{
    public class BOMerchantBalance
    {
        public int Id { get; set; }
        public int MerchantId { get; set; }
        public decimal Balance { get; set; }
    }
}