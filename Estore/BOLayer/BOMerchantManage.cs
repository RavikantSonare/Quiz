using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estore.BOLayer
{
    public class BOMerchantManage
    {
        public int MerchantId { get; set; }
        public string MerchantName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
        public int StateId { get; set; }
        public string State { get; set; }
        public string Telephone { get; set; }
        public int MerchantLevelId { get; set; }
        public string MerchantLevel { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool ActiveStatus { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string EmailId { get; set; }
    }
}