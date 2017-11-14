using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUser.BOLayer
{
    public class BOExamReports
    {
        public int ExamReportId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ExamId { get; set; }
        public string ExamCode { get; set; }
        public bool Result { get; set; }
        public decimal Score { get; set; }
        public decimal OutofScore { get; set; }
        public bool AllowPrint { get; set; }
        public int DigitalCertificateId { get; set; }
        public int CertificationNo { get; set; }
        public DateTime ExamGivenDate { get; set; }
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