using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSV.Shareds;
using QLSV.Models.QL_DuLieu;
using QLSV.Models;

namespace QLSV.Views.QL_DuLieu
{
    public partial class frm_Khoa : Form
    {
        public frm_Khoa()
        {
            InitializeComponent();
        }
        Models.DataConnectDBDataContext db = new Models.DataConnectDBDataContext();
        Controls.QL_DuLieu.crt_QLKhoa ctrl = new Controls.QL_DuLieu.crt_QLKhoa();

        private void frm_Khoa_Load(object sender, EventArgs e)
        {
            //Hien thi form full parent
            Utils.ShowFormFullPanel(this);
            //load du lieu du lieu
            var rs=ctrl.GetAllKhoa();
            UpdateDtg(rs);
           
          }
        private void UpdateDtg(ActionResult<List<Khoa_ett>>lst)
        {
            switch(lst.ErrCode)
            {
                case CEnum.HaveNoData:
                    break;
                case CEnum.Success:
                    dtg_data.DataSource = lst.Data;
                    break;
                case CEnum.Fail:
                    break;

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_makhoa.Text == "")
            {
                MessageBox.Show(String.Format(Constants.msg_Err_NullData, "Ma Khoa"),
                    Constants.msg_capt_Err, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_makhoa.Focus();
            }
            else
            {
                var rs = ctrl.InsertKhoa(txt_makhoa.Text, txt_tenkhoa.Text, txt_diachi.Text, txt_sdt.Text, txt_email.Text);
                switch (rs.ErrCode)
                {
                   
                    case CEnum.Success:
                         MessageBox.Show(rs.ErrDesc, Constants.msg_capt_Info, MessageBoxButtons.OK, 
                             MessageBoxIcon.Information);
                        UpdateDtg(ctrl.GetAllKhoa());
                        break;
                    case CEnum.Fail:
                        MessageBox.Show(rs.ErrDesc,
                        Constants.msg_capt_Err, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }               
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (txt_makhoa.Text == "")
            {
                MessageBox.Show(String.Format(Constants.msg_Err_NullData, "Ma Khoa"),
                    Constants.msg_capt_Err, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_makhoa.Focus();
            }
            else
            {
                var rs = ctrl.UpdateKhoa(txt_makhoa.Text, txt_tenkhoa.Text, 
                    txt_diachi.Text, txt_sdt.Text, txt_email.Text);
                switch (rs.ErrCode)
                {
                    case CEnum.HaveNoData:
                        MessageBox.Show(rs.ErrDesc,
                        Constants.msg_capt_Err, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case CEnum.Success:
                        MessageBox.Show(rs.ErrDesc,
                       Constants.msg_capt_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateDtg(ctrl.GetAllKhoa());
                        break;
                    case CEnum.Fail:
                        MessageBox.Show(rs.ErrDesc,
                        Constants.msg_capt_Err, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (txt_makhoa.Text == "")
            {
                MessageBox.Show(String.Format(Constants.msg_Err_NullData, "Ma Khoa"),
                    Constants.msg_capt_Err, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_makhoa.Focus();
            }
            else
            {
                //confirm delete
                if(MessageBox.Show(Constants.msg_warning_Del,Constants.msg_capt_Warning,
                    MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.OK)
                {
                    var rs = ctrl.DeleteKhoa(txt_makhoa.Text);
                    switch (rs.ErrCode)
                    {
                        case CEnum.HaveNoData:
                            MessageBox.Show(rs.ErrDesc,
                            Constants.msg_capt_Err, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case CEnum.Success:
                            MessageBox.Show(rs.ErrDesc,
                           Constants.msg_capt_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            UpdateDtg(ctrl.GetAllKhoa());
                            break;
                        case CEnum.Fail:
                            MessageBox.Show(rs.ErrDesc,
                            Constants.msg_capt_Err, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }               
            }
            
        }

        private void dtg_data_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var r = dtg_data.Rows[e.RowIndex];
            txt_makhoa.Text = r.Cells[0].Value.ToString();
            txt_tenkhoa.Text = r.Cells[1].Value.ToString();
            txt_diachi.Text = r.Cells[2].Value.ToString();
            txt_sdt.Text = r.Cells[3].Value.ToString();
            txt_email.Text = r.Cells[4].Value.ToString();
        }
    }
}
