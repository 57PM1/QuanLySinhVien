using QLSV.Models;
using QLSV.Models.QL_DuLieu;
using QLSV.Shareds;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSV.Controls.QL_DuLieu;

namespace QLSV.Views.QL_DuLieu
{
    public partial class frm_KhoaHoc : Form
    {
        public frm_KhoaHoc()
        {
            InitializeComponent();
        }
        Models.DataConnectDBDataContext db = new Models.DataConnectDBDataContext();
        Controls.QL_DuLieu.crt_KhoaHoc ctrl = new Controls.QL_DuLieu.crt_KhoaHoc();

        private void frm_Khoahoc_Load(object sender, EventArgs e)
        {
            //Hien thi form full parent
            Utils.ShowFormFullPanel(this);
            //load du lieu du lieu
            var rs = ctrl.GetAllKhoaHoc;
            UpdateDtg(rs);
        }

        private void UpdateDtg(object rs)
        {
            throw new NotImplementedException();
        }

        private void UpdateDtg(ActionResult<List<KhoaHoc_ett>> lst)
        {
            switch (lst.ErrCode)
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

            if (txt_makhoahoc.Text == "")
            {
                MessageBox.Show(String.Format(Constants.msg_Err_NullData, "Ma Khoa Hoc"),
                    Constants.msg_capt_Err, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_makhoahoc.Focus();
            }
            else
            {
                var rs = ctrl.InsertKhoaHoc(txt_makhoahoc.Text, txt_tenkhoahoc.Text, txt_ghichu.Text);
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
            if (txt_makhoahoc.Text == "")
            {
                MessageBox.Show(String.Format(Constants.msg_Err_NullData, "Ma Khoa Hoc"),
                    Constants.msg_capt_Err, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_makhoahoc.Focus();
            }
            else
            {
                var rs = ctrl.UpdateKhoaHoc(txt_makhoahoc.Text, txt_tenkhoahoc.Text,
                    txt_ghichu.Text);
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
            if (txt_makhoahoc.Text == "")
            {
                MessageBox.Show(String.Format(Constants.msg_Err_NullData, "Ma Khoa Hoc"),
                    Constants.msg_capt_Err, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_makhoahoc.Focus();
            }
            else
            {
                //confirm delete
                if (MessageBox.Show(Constants.msg_warning_Del, Constants.msg_capt_Warning,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    var rs = ctrl.DeleteKhoa(txt_makhoahoc.Text);
                    switch (rs.ErrCode)
                    {
                        case CEnum.HaveNoData:
                            MessageBox.Show(rs.ErrDesc,
                            Constants.msg_capt_Err, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case CEnum.Success:
                            MessageBox.Show(rs.ErrDesc,
                           Constants.msg_capt_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            UpdateDtg(ctrl.GetAllKhoaHoc());
                            break;
                        case CEnum.Fail:
                            MessageBox.Show(rs.ErrDesc,
                            Constants.msg_capt_Err, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
            }
        }

        private void dtg_data_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            {
                var r = dtg_data.Rows[e.RowIndex];
                txt_makhoahoc.Text = r.Cells[0].Value.ToString();
                txt_tenkhoahoc.Text = r.Cells[1].Value.ToString();
                txt_ghichu.Text = r.Cells[2].Value.ToString();
                
            }
        }
    }
}


