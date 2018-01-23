using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMerchant.BOLayer
{
    public class BOMerchantCertificate
    {
        public int CertificateId { get; set; }

        public string CertificateTitle { get; set; }

        public string CertificatePic { get; set; }

        public string NameBox { get; set; }

        public string DateBox { get; set; }

        public string SampleUserName { get; set; }

        public int? MerchantId { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDelete { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string Event { get; set; }
    }
}