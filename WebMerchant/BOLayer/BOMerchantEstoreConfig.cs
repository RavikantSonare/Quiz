using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMerchant.BOLayer
{
    public class BOMerchantEstoreConfig
    {
        public int EstroeConfigId { get; set; }

        public int? QuestionNumber { get; set; }

        public decimal? Price { get; set; }

        public string ExamPicture { get; set; }

        public string ExamDescription { get; set; }

        public int? ExamId { get; set; }

        public int? MerchantId { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDelete { get; set; }

        public int? Createdby { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public string Event { get; set; }
    }
}