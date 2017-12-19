using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMerchant.BOLayer
{
    public class BOBundleExam
    {
        public int BundleId { get; set; }

        public string BundleContent { get; set; }

        public decimal? Price { get; set; }

        public bool? FeaturedSelfsEstore { get; set; }

        public int MerchantId { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDelete { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string Event { get; set; }
    }
}