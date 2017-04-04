using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMerchant.BOLayer
{
    class BOMyUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string AccessPassword { get; set; }
        public int MerchantId { get; set; }
        public string MerchantName { get; set; }
        public int SecondCategoryId { get; set; }
        public string SecondCategory { get; set; }
        public string ExamId { get; set; }
        public string ExamCode { get; set; }
        public int ValidTime { get; set; }
        public string AccessOption { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Event { get; set; }
    }
}
