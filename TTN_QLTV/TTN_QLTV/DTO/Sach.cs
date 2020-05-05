using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTN_QLTV.DTO
{
    class Sach
    {
        private int maSach;
        private int maDauSach;
        private string tenSach;
        private bool tinhTrang;

        public Sach(int maSach, int maDauSach, string tenSach, bool tinhTrang)
        {
            this.maSach = maSach;
            this.maDauSach = maDauSach;
            this.tenSach = tenSach;
            this.tinhTrang = tinhTrang;
        }

        public int MaSach { get => maSach; set => maSach = value; }
        public int MaDauSach { get => maDauSach; set => maDauSach = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public bool TinhTrang { get => tinhTrang; set => tinhTrang = value; }
    }
}
