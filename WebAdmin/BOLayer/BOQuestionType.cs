using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAdmin.BOLayer
{
    public class BOQuestionType
    {
        public int QuestionTypeId { get; set; }
        public string QuestionType { get; set; }
        public bool DefaultPermission { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string MerchantLevelId { get; set; }
        public string Event { get; set; }
    }
}