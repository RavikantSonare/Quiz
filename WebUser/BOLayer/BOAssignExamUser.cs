using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUser.BOLayer
{
    public class BOAssignExamUser
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ExamId { get; set; }

        public int SecondCatId { get; set; }

        public bool TestOnce { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string Event { get; set; }
    }
}