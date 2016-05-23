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
    class crt_KhoaHoc
    {
        Models.DataConnectDBDataContext db = new Models.DataConnectDBDataContext();
        private string tenkhoahoc;
        public ActionResult<List<KhoaHoc_ett>> GetAllKhoaHoc()
        {
            ActionResult<List<KhoaHoc_ett>> op = new ActionResult<List<KhoaHoc_ett>>();
            op.Data = new List<KhoaHoc_ett>();
            try
            {
                var qr = db.tbl_khoahocs;
                if (qr.Count() > 0)
                {
                    // co du lieu
                    foreach (var i in qr)
                    {
                        KhoaHoc_ett kh = new KhoaHoc_ett(i);
                        op.Data.Add(kh);
                    }
                    op.ErrCode = CEnum.Success;
                    op.ErrDesc = String.Format(Constants.act_rs_get_Data_Success, "Khoa Hoc");
                    return op;
                }
                else
                {
                    //khong co du lieu 
                    op.ErrCode = CEnum.HaveNoData;
                    op.ErrDesc = String.Format(Constants.act_rs_get_Null, "Khoa Hoc");
                    op.Data = null;
                    return op;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowExceptionMsg(ex);
                //khong co du lieu
                op.ErrCode = CEnum.Fail;
                op.ErrDesc = String.Format(Constants.act_rs_get_Data_Fail, "Khoa Hoc");
                op.Data = null;
                return op;
            }
        }
        //Phuong thuc them moi khoa hoc
        public ActionResult<KhoaHoc_ett> InsertKhoaHoc(string makhoahoc, string tenkhoaten, string ghichu)
        {
            ActionResult<KhoaHoc_ett> op = new ActionResult<KhoaHoc_ett>();
            try
            {
                tbl_khoahoc kh = new tbl_khoahoc();
                kh.MaKhoaHoc = makhoahoc;
                kh.TenKhoaHoc = tenkhoahoc;
                kh.GhiChu= ghichu;
              
                db.SubmitChanges();

                op.ErrCode = CEnum.Success;
                op.ErrDesc = String.Format(Constants.act_rs_insert_Data_Success, "Khoa Hoc");
                op.Data = new KhoaHoc_ett(kh);
                return op;
            }
            catch (Exception ex)
            {
                Utils.ShowExceptionMsg(ex);
                op.ErrCode = CEnum.Fail;
                op.ErrDesc = String.Format(Constants.act_rs_insert_Data_Fail, "Khoa Hoc");
                op.Data = null;
                return op;

            }
        }
        //Phuong thuc sua thong tin khoa hoc
        public ActionResult<KhoaHoc_ett> UpdateKhoaHoc(string makhoahoc, string tenkhoaten, string ghichu)
        {
            ActionResult<KhoaHoc_ett> op = new ActionResult<KhoaHoc_ett>();
            try
            {
                var qr = db.tbl_khoahocs.Where(o => o.MaKhoaHoc == makhoahoc);
                if (qr.Count() > 0)
                {
                    tbl_khoahoc kh = qr.SingleOrDefault();
                    kh.TenKhoaHoc = tenkhoahoc;
                    kh.GhiChu = ghichu;
                    

                    db.SubmitChanges();
                    op.ErrCode = CEnum.Success;
                    op.ErrDesc = String.Format(Constants.act_rs_update_Data_Success, "Khoa Hoc");
                    op.Data = new KhoaHoc_ett(kh
                        
                        );
                    return op;
                }
                else
                {
                    op.ErrCode = CEnum.HaveNoData;
                    op.ErrDesc = String.Format(Constants.act_rs_get_Null, "Khoa Hoc");
                    op.Data = null;
                    return op;
                }

            }
            catch (Exception ex)
            {
                Utils.ShowExceptionMsg(ex);
                op.ErrCode = CEnum.Fail;
                op.ErrDesc = String.Format(Constants.act_rs_update_Data_Fail, "khoa Hoc");
                op.Data = null;
                return op;

            }
        }
        //Phuong thuc xoa thong tin khoa
        public ActionResult<bool> DeleteKhoaHoc(string makhoahoc)
        {
            ActionResult<bool> op = new ActionResult<bool>();
            try
            {
                var qr = db.tbl_khoahocs.Where(o => o.MaKhoaHoc == makhoahoc);
                if (qr.Count() > 0)
                {
                    tbl_khoahoc kh = qr.SingleOrDefault();
                    db.tbl_khoahocs.DeleteOnSubmit(kh);

                    db.SubmitChanges();
                    op.ErrCode = CEnum.Success;
                    op.ErrDesc = String.Format(Constants.act_rs_del_Data_Success, "Khoa Hoc");
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
                op.ErrDesc = String.Format(Constants.act_rs_del_Data_Fail, "khoa Hoc");
                op.Data = false;
                return op;

            }
        }

}
