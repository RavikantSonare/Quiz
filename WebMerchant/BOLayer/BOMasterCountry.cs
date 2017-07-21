using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMerchant.BOLayer
{
    public class BOMasterCountry
    {
        public int CountryId { get; set; }

        public string Country { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdateBy { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}