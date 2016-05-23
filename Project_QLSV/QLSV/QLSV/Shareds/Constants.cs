using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Shareds
{
    class Constants
    {
        public static Models.dangnhap_ett dangnhap_session { get; set; }
        #region msg content
        public const string msg_Err_Exeption= "Da xay ra loi trong khi thuc thi !ban co muon xem chi tiet loi khong";
        public const string msg_Err_NullData = "Truong{0} khong duoc de trong";
        public const string msg_Err_Login_Fail = "Tai Khoan hoac Mat Khau khong dung !Vui long nhap lai";
        public const string msg_Info_Login_Success= "Dang nhap thanh cong";

        public const string msg_Info_Them_Success = "Them moi {0} thanh cong";
        public const string msg_Info_Them_Fail = "Them moi {0} that bai";
        public const string msg_Info_Update_Success = "cap nhat {0} thanh cong";
        public const string msg_Info_Update_Fail = "cap nhat {0} that bai";
        public const string msg_Info_Del_Success = "Xoa moi {0} thanh cong";
        public const string msg_Info_Del_Fail = "Xoa {0} that bai";

        public const string msg_warning_Del = "Ban co muon that su muon xoa du lieu khong?";
        #endregion

        #region msg caption
        public const string msg_capt_Err = "Thong bao loi";
        public const string msg_capt_Info = "Thong bao ";
        public const string msg_capt_Warning = "Canh bao";
        #endregion
        #region msg Action Result
        public const string act_rs_get_Data_Success = "Lay {0} thanh cong";
        public const string act_rs_get_Data_Fail = "Lay {0} that bai";
        public const string act_rs_get_Null = "Khong co {0} ton tai thoa man dieu kien";
        public const string act_rs_insert_Data_Success = "Them {0} thanh cong";
        public const string act_rs_insert_Data_Fail = "Them {0} that bai";
        public const string act_rs_update_Data_Success = "Cap nhat {0} thanh cong";
        public const string act_rs_update_Data_Fail = "Cap nhat {0} that bai";
        public const string act_rs_del_Data_Success = "Xoa {0} thanh cong";
        public const string act_rs_del_Data_Fail = "Xoa {0} that bai";
        #endregion
    }
}
