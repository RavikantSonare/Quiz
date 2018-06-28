using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMerchant.BOLayer
{
    public class BOUserGroup
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public int? MerchantId { get; set; }

        public string ExamId { get; set; }

        public string AccessOption { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDelete { get; set; }

        public int? Createdby { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string Event { get; set; }

        public int SecondCategoryId { get; set; }
    }
}