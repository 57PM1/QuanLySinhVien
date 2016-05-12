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


namespace QLSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void đăngNhậpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Views.TaiKhoan.frm_dangnhap f = new Views.TaiKhoan.frm_dangnhap();
            Utils.ShowFormInPanel(panel1, f);
            Utils.ShowFormCenterOfPanel(f);
          
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            foreach (var i in panel1.Controls)
            {
                if (i is Form) {
                    if(i is Views.TaiKhoan.frm_dangnhap)
                    {
                        Form f = (Form)i;
                        Utils.ShowFormCenterOfPanel(f);
                    }
                    else
                    {
                        Form f = (Form)i;
                        Utils.ShowFormFullPanel(f);
                    }
                }
            }
        }

        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.QL_DuLieu.frm_Khoa f = new Views.QL_DuLieu.frm_Khoa();
            Utils.ShowFormInPanel(panel1, f);

        }

        private void quảnLýKhóaHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.QL_DuLieu.frm_KhoaHoc f = new Views.QL_DuLieu.frm_KhoaHoc();
            Utils.ShowFormInPanel(panel1, f);
        }
    }
}
