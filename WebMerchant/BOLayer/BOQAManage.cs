using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMerchant.BOLayer
{
    public class BOQAManage
    {
        public int QAId { get; set; }
        public int ExamCodeId { get; set; }
        public string ExamCode { get; set; }
        public int QuestionTypeId { get; set; }
        public decimal Score { get; set; }
        public string Question { get; set; }
        public int NoofAnswer { get; set; }
        public string Explanation { get; set; }
        public int MerchantId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Resource { get; set; }
        public string Exhibit { get; set; }
        public string Topology { get; set; }
        public string Scenario { get; set; }
        public string Event { get; set; }
    }
}