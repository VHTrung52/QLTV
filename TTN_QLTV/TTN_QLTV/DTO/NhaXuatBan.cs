using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTN_QLTV.DTO
{
    class NhaXuatBan
    {
        private int maNhaXuatBan;
        private string tenNhaXuatBan;

        public NhaXuatBan(int maNhaXuatBan, string tenNhaXuatBan)
        {
            this.maNhaXuatBan = maNhaXuatBan;
            this.tenNhaXuatBan = tenNhaXuatBan;
        }

        public int MaNhaXuatBan { get => maNhaXuatBan; set => maNhaXuatBan = value; }
        public string TenNhaXuatBan { get => tenNhaXuatBan; set => tenNhaXuatBan = value; }
    }
}
