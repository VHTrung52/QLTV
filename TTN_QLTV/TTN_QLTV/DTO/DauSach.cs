using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTN_QLTV.DTO
{
    class DauSach
    {
        private int maDauSach;
        private string tenDauSach;
        private int maKeSach;
        private int soLuongHienTai;
        private int tongSo;
        public DauSach()
        {
            this.maDauSach = 1;
            this.tenDauSach = "";
            this.maKeSach = 1;
            this.soLuongHienTai = 1;
            this.tongSo = 1;
        }
        public DauSach(int maDauSach, string tenDauSach, int maKeSach, int soLuongHienTai, int tongSo)
        {
            this.maDauSach = maDauSach;
            this.tenDauSach = tenDauSach;
            this.maKeSach = maKeSach;
            this.soLuongHienTai = soLuongHienTai;
            this.tongSo = tongSo;
        }

        public int MaDauSach { get => maDauSach; set => maDauSach = value; }
        public string TenDauSach { get => tenDauSach; set => tenDauSach = value; }
        public int MaKeSach { get => maKeSach; set => maKeSach = value; }
        public int SoLuongHienTai { get => soLuongHienTai; set => soLuongHienTai = value; }
        public int TongSo { get => tongSo; set => tongSo = value; }
    }
}
