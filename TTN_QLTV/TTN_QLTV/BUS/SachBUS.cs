using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTN_QLTV.DAL;
using TTN_QLTV.DTO;

namespace TTN_QLTV.BUS
{
    class SachBUS
    {
        public void ThemSachVaoPhieuMuon(int maSach,int maPhieuMuon)
        {
            int row = DataProvider.Instance.ExecuteNonQuery("" +
                "insert into CHITIETPHIEUMUON(MaPhieuMuon,MaSach) " +
                $"values({maPhieuMuon},{maSach})");
            if (row > 0)
            {
                DataProvider.Instance.ExecuteNonQuery("" +
                    $"update Sach set TinhTrang = 1 where MaSach = {maSach}");
            }
            
        }
    }
}
