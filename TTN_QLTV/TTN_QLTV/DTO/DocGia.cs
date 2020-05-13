using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTN_QLTV.DTO
{
    class DocGia
    {
        private int maDocGia;
        private string hoTen;
        private DateTime ngaySinh;
        private string soDienThoai;
        private string cMND;

        public DocGia()
        {

        }

        public DocGia(int maDocGia, string hoTen, DateTime ngaySinh, string soDienThoai, string cMND)
        {
            this.maDocGia = maDocGia;
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.soDienThoai = soDienThoai;
            this.cMND = cMND;
        }

        public int MaDocGia { get => maDocGia; set => maDocGia = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string CMND { get => cMND; set => cMND = value; }
    }
}
