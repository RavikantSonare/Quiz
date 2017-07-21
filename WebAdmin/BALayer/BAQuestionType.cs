using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebAdmin.BOLayer;
using WebAdmin.DALayer;

namespace WebAdmin.BALayer
{
    public class BAQuestionType
    {
        private DAQuestionType _daqtype = new DAQuestionType();

        public DataTable SelectQuestionType(string eventtxt)
        {
            return _daqtype.SelectQuestionType(eventtxt);
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

        internal DataTable SelectQuestionTypeWithID(string v, int qtypeId)
        {
            return _daqtype.SelectQuestionTypeWithID(v, qtypeId);
        }
    }
}