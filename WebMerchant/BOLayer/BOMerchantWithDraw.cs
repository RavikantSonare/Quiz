﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMerchant.BOLayer
{
    public class BOMerchantWithDraw
    {
        public int WithDrawOrderId { get; set; }
        public string WithDrawOrderNo { get; set; }
        public decimal Amount { get; set; }
        public int MerchantId { get; set; }
        public bool OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Event { get; set; }
    }
}