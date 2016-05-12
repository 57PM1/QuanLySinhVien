using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Models
{
    class KhoaHoc_ett
    {
         public string MaKhoaHoc { get; set; }
        public string TenKhoaHoc { get; set; }
        public string GhiChu { get; set; }
        

        public KhoaHoc_ett() { }
        public KhoaHoc_ett(tbl_khoahoc kh){
            this.MaKhoaHoc = kh.MaKhoa;
            this.TenKhoaHoc = kh.TenKhoa;
            this.GhiChu = kh.GhiChu;
            
        }
    }
}
