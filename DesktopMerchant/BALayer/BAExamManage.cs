using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopMerchant.BOLayer;
using DesktopMerchant.DALayer;

namespace DesktopMerchant.BALayer
{
    class BAExamManage
    {
        private DAExamManage _daexmmng = new DAExamManage();
        public List<BOExamManage> SelectMerchantExamDetail(BOExamManage _boexmmng)
        {
            return _daexmmng.SelectMerchantExam(_boexmmng);
        }
    }
}
