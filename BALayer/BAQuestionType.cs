using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BOLayer;
using DALayer;

namespace BALayer
{
    public class BAQuestionType
    {
        DAQuestionType _daqtype = new DAQuestionType();
        public DataTable SelectQuestionType(BOQuestionType _boqtyp)
        {
          return  _daqtype.SelectQuestionType(_boqtyp);
        }

        public int Update(BOQuestionType _boqtype)
        {
            return _daqtype.IUDQuestionType(_boqtype);
        }

        public int Insert(BOQuestionType _boqtype)
        {
            return _daqtype.IUDQuestionType(_boqtype);
        }

        public int Delete(BOQuestionType _boqtype)
        {
            return _daqtype.IUDQuestionType(_boqtype);
        }
    }
}
