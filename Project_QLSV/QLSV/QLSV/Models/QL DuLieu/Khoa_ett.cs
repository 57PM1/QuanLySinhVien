using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Models.QL_DuLieu
{
    class Khoa_ett
    {
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }

        public Khoa_ett() { }
        public Khoa_ett(tbl_khoa k){
            this.MaKhoa = k.MaKhoa;
            this.TenKhoa = k.TenKhoa;
            this.DiaChi = k.DiaChi;
            this.SDT = k.SDT;
            this.Email = k.Email;
        }
    }
}
