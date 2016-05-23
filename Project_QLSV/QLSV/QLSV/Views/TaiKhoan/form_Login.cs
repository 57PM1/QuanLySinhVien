using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSV.Models;
using QLSV.Shareds;

namespace QLSV.Views.TaiKhoan
{
    public partial class frm_dangnhap : Form
    {
        
        DataConnectDBDataContext db = new DataConnectDBDataContext();
        public frm_dangnhap()
        {
            InitializeComponent();
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            if (txt_tk.Text == "")
            {
                MessageBox.Show(String.Format(Constants.msg_Err_NullData, "Tai Khoan"), Constants.msg_capt_Err, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_tk.Focus();
            }
            else
            {
                if (txt_tk.Text == "")
                {
                    MessageBox.Show(String.Format(Constants.msg_Err_NullData, "Mat Khau"), Constants.msg_capt_Err, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_mk.Focus();
                }
                else
                {
                    string tk = txt_tk.Text;
                    string mk = txt_mk.Text;
                    //lay tu csdl
                    var qr = db.tbl_taikhoans.Where(o => o.TaiKhoan == tk && o.MatKhau == mk);
                    
                    if (qr.Count() > 0)
                    {
                        //truong hop thanh cong hien thi menu tuong ung
                        MessageBox.Show(Constants.msg_Info_Login_Success,
                       Constants.msg_capt_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_tk.Focus();
                        //lay ve doi tuong tai khoan
                        var tk_obj = qr.SingleOrDefault();
                        dangnhap_ett tk_ett = new dangnhap_ett();
                        tk_ett.TaiKhoan = tk_obj.TaiKhoan;
                        tk_ett.Email = tk_obj.Email;
                        tk_ett.SDT = tk_obj.SDT;
                        Constants.dangnhap_session = tk_ett;
                    }
                    else
                    {
                        MessageBox.Show(Constants.msg_Err_Login_Fail,
                        Constants.msg_capt_Err, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_tk.Focus();
                    }
                }
            }
            
        }

        public object t { get; set; }
    }
}
