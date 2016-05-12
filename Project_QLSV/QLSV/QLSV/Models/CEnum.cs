using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Models
{
    public enum CEnum
    {
        HaveNoData,
        Success,
        Fail
    }
    public class ActionResult<T>
    {
        public CEnum ErrCode { get; set; }
        public T Data { get; set; }
        public string ErrDesc;
        public ActionResult() { }
        public ActionResult(CEnum errcode,T data,string errdesc)
        {
            ErrCode = errcode;
            Data = data;
            ErrDesc = errdesc;
        }

    }
}
