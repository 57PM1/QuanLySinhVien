using QLSV.Models;
using QLSV.Models.QL_DuLieu;
using QLSV.Shareds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Controls.QL_DuLieu
{
    class crt_QLKhoa
    {
        Models.DataConnectDBDataContext db = new Models.DataConnectDBDataContext();
        public ActionResult<List<Khoa_ett>> GetAllKhoa()
        {
            ActionResult<List<Khoa_ett>> op = new ActionResult<List<Khoa_ett>>();
            op.Data = new List<Khoa_ett>();
            try
            {
                var qr = db.tbl_khoas;
                if (qr.Count() > 0)
                {
                    // co du lieu
                    foreach (var i in qr)
                    {
                        Khoa_ett k = new Khoa_ett(i);
                        op.Data.Add(k);
                    }
                    op.ErrCode = CEnum.Success;
                    op.ErrDesc = String .Format(Constants.act_rs_get_Data_Success,"Khoa");
                    return op;
                }
                else
                {
                    //khong co du lieu 
                    op.ErrCode = CEnum.HaveNoData;
                    op.ErrDesc =String.Format( Constants.act_rs_get_Null,"Khoa");
                    op.Data = null;
                    return op;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowExceptionMsg(ex);
                //khong co du lieu
                op.ErrCode = CEnum.Fail;
                op.ErrDesc = String.Format( Constants.act_rs_get_Data_Fail,"Khoa");
                op.Data = null;
                return op;
            }
        }
        //Phuong thuc them moi khoa
        public ActionResult<Khoa_ett> InsertKhoa(string makhoa, string tenkhoa, string diachi, string sdt, string email)
        {
            ActionResult<Khoa_ett> op = new ActionResult<Khoa_ett>();
            try
            {
                tbl_khoa k = new tbl_khoa();
                k.MaKhoa = makhoa;
                k.TenKhoa = tenkhoa;
                k.DiaChi = diachi;
                k.SDT = sdt;
                k.Email = email;
                db.tbl_khoas.InsertOnSubmit(k);
                db.SubmitChanges();

                op.ErrCode = CEnum.Success;
                op.ErrDesc = String.Format(Constants.act_rs_insert_Data_Success,"Khoa");
                op.Data = new Khoa_ett(k);
                return op;
            }
            catch (Exception ex)
            {
                Utils.ShowExceptionMsg(ex);
                op.ErrCode = CEnum.Fail;
                op.ErrDesc = String.Format(Constants.act_rs_insert_Data_Fail,"Khoa");
                op.Data = null;
                return op;

            }
        }
        //Phuong thuc sua thong tin khoa
        public ActionResult<Khoa_ett> UpdateKhoa(string makhoa, string tenkhoa, string diachi, string sdt, string email)
        {
            ActionResult<Khoa_ett> op = new ActionResult<Khoa_ett>();
            try
            {
                var qr = db.tbl_khoas.Where(o => o.MaKhoa == makhoa);
                if (qr.Count() > 0)
                {
                    tbl_khoa k = qr.SingleOrDefault();
                    k.TenKhoa = tenkhoa;
                    k.DiaChi = diachi;
                    k.SDT = sdt;
                    k.Email = email;

                    db.SubmitChanges();
                    op.ErrCode = CEnum.Success;
                    op.ErrDesc = String.Format(Constants.act_rs_update_Data_Success,"Khoa");
                    op.Data = new Khoa_ett(k);
                    return op;
                }else
                {
                    op.ErrCode = CEnum.HaveNoData;
                    op.ErrDesc = String.Format(Constants.act_rs_get_Null,"Khoa");
                    op.Data = null;
                    return op;
                }
               
            }
            catch (Exception ex)
            {
                Utils.ShowExceptionMsg(ex);
                op.ErrCode = CEnum.Fail;
                op.ErrDesc = String.Format(Constants.act_rs_update_Data_Fail,"khoa");
                op.Data = null;
                return op;

            }
        }
        //Phuong thuc xoa thong tin khoa
        public ActionResult<bool> DeleteKhoa(string makhoa)
        {
            ActionResult<bool> op = new ActionResult<bool>();
            try
            {
                var qr = db.tbl_khoas.Where(o => o.MaKhoa == makhoa);
                if (qr.Count() > 0)
                {
                    tbl_khoa k = qr.SingleOrDefault();
                    db.tbl_khoas.DeleteOnSubmit(k);
                    
                    db.SubmitChanges();
                    op.ErrCode = CEnum.Success;
                    op.ErrDesc = String.Format(Constants.act_rs_del_Data_Success, "Khoa");
                    op.Data = true;
                    return op;
                }
                else
                {
                    op.ErrCode = CEnum.HaveNoData;
                    op.ErrDesc = String.Format(Constants.act_rs_get_Null, "Khoa");
                    op.Data = false;
                    return op;
                }

            }
            catch (Exception ex)
            {
                Utils.ShowExceptionMsg(ex);
                op.ErrCode = CEnum.Fail;
                op.ErrDesc = String.Format(Constants.act_rs_del_Data_Fail, "khoa");
                op.Data = false;
                return op;

            }
        }
    }        
}
