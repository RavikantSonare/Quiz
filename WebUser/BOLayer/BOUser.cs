using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUser.BOLayer
{
    public class BOUser
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string AccessPassword { get; set; }

        public int MerchantId { get; set; }

        public int SecondCategory { get; set; }

        public string ExamId { get; set; }

        public string ExamCode { get; set; }

        public DateTime ValidTime { get; set; }

        public string AccessOption { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public int Createdby { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string Event { get; set; }
    }
}