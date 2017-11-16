using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUser.BOLayer
{
    public class BOQAnswer
    {
        public int AnswerId { get; set; }

        public string Answer { get; set; }

        public int QuestionId { get; set; }

        public bool RightAnswer { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
        public string Event { get; set; }

        public bool UserAnswer { get; set; }
    }
}