using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAdmin.BOLayer
{
    public class BOSecondCategory
    {
        public int SecondCategoryId { get; set; }
        public string SecondCategoryName { get; set; }
        public int TopCategoryId { get; set; }
        public string TopCategoryName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Event { get; set; }
    }
}