﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMerchant.BOLayer
{
    class BOExamConfig
    {
        public int ExamCodeId { get; set; }
        public string ExamCode { get; set; }
        public string ExamTitle { get; set; }
        public string Category { get; set; }
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
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Event { get; set; }
    }
}
