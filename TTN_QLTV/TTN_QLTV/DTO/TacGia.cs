using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTN_QLTV.DTO
{
    class TacGia
    {
        private int maTacGia;
        private string tenTacGia;
        private DateTime ngaySinh;

        public TacGia(int maTacGia, string tenTacGia, DateTime ngaySinh)
        {
            this.maTacGia = maTacGia;
            this.tenTacGia = tenTacGia;
            this.ngaySinh = ngaySinh;
        }

        public int MaTacGia { get => maTacGia; set => maTacGia = value; }
        public string TenTacGia { get => tenTacGia; set => tenTacGia = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
    }
}
