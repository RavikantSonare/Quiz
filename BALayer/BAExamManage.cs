using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLayer;
using DALayer;

namespace BALayer
{
    public class BAExamManage
    {
        DAExamManage _daexmmng = new DAExamManage();
        public List<BOExamManage> SelectExamManageList(BOExamManage _boexmmng)
        {
            return _daexmmng.SelectExamManageList(_boexmmng);
        }

        public int Update(BOExamManage _boexmmng)
        {
            return _daexmmng.IUD_ExamManage(_boexmmng);
        }
    }
}
