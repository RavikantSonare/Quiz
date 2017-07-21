using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSimulator.BOLayer;
using ExamSimulator.DALayer;

namespace ExamSimulator.BALayer
{
    class BAUser
    {
        private DAUser _dausr = new DAUser();
        internal BOUser SelectUserDetail(string v1, string text, string v2)
        {
            return _dausr.SelectUserDetail(v1, text, v2);
        }
    }
}
