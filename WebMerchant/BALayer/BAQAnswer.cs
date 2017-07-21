using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BAQAnswer
    {
        private DAQAnswer _daqand = new DAQAnswer();
        internal int Insert(BOQAnswer _boqans)
        {
            return _daqand.IUDAnswer(_boqans);
        }

        internal int Update(BOQAnswer _boqans)
        {
            return _daqand.IUDAnswer(_boqans);
        }
    }
}