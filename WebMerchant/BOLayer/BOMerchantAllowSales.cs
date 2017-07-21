using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMerchant.BOLayer
{
    public class BOMerchantAllowSales
    {
        public int Id { get; set; }

        public int ExamId { get; set; }

        public int NoofQuestion { get; set; }

        public decimal Price { get; set; }

        public string SelfDescription { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string Event { get; set; }
    }
}