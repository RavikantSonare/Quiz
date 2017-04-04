using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMerchant.BOLayer
{
    class BOTemplate
    {
        public int TemplateId { get; set; }
        public string CertificateTitle { get; set; }
        public string SampleUserName { get; set; }
        public string TemplatePicture { get; set; }
        public int MerchantId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Event { get; set; }
    }
}
