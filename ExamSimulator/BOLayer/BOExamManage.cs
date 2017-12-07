using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamSimulator.BOLayer
{
    class BOExamManage
    {
        public int ExamCodeId { get; set; }
        public string ExamCode { get; set; }
        public string ExamTitle { get; set; }
        public int TopCategoryId { get; set; }
        public string TopCategory { get; set; }
        public int SecondCategoryId { get; set; }
        public string SecondCategory { get; set; }
        public decimal PassingPercentage { get; set; }
        public int TestTime { get; set; }
        public string TestOption { get; set; }
        public DateTime ValidDate { get; set; }
        public int MerchantId { get; set; }
        public string MerchantName { get; set; }
        public int LevelId { get; set; }
        public string Level { get; set; }
        public decimal Price { get; set; }
        public bool ExamSimulator { get; set; }
        public bool ExamSimulatorDemo { get; set; }
        public bool OnlyTestOnce { get; set; }
        public bool AllowPrint { get; set; }
        public bool AllowSales { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Event { get; set; }
        public List<BOQAManage> QuestionList { get; set; }
    }
}
