using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTN_QLTV.DTO
{
    class NhanVien
    {
        private int maNhanVien;
        private string hoTen;
        private DateTime ngaySinh;
        private string soDienThoai;
        private string cMND;

        public NhanVien(int maNhanVien, string hoTen, DateTime ngaySinh, string soDienThoai, string cMND)
        {
            this.maNhanVien = maNhanVien;
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.soDienThoai = soDienThoai;
            this.cMND = cMND;
        }

        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string CMND { get => cMND; set => cMND = value; }
    }
}
