using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMerchant.BOLayer
{
    public class BOUserAccess
    {
        public int AccessOptionId { get; set; }

        public string AccessOption { get; set; }

        public bool? DefaultPermission { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDelete { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string Event { get; set; }
    }
}