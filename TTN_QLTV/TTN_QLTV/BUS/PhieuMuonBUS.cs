using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTN_QLTV.DAL;
using TTN_QLTV.DTO;

namespace TTN_QLTV.BUS
{
    class PhieuMuonBUS
    {
        public bool ThemPhieuMuon(PhieuMuon phieumon)
        {
            string query = "" +
                "insert intp PHIEUMUON(MaPhieuMuon,MaNhanVien,MaDocGia,NgayMuon,NgayTra,ThoiGian,ThanhTien) " +
                $"values({phieumon.MaPhieuMuon},{phieumon.MaNhanVien},{phieumon.MaDocGia}," +
                $"'{phieumon.NgayMuon.Month}/{phieumon.NgayMuon.Date}/{phieumon.NgayMuon.Year}'," +
                $"'{phieumon.NgayTra.Month}/{phieumon.NgayTra.Date}/{phieumon.NgayTra.Year}',0)";

            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        
        public bool SuaPhieuMuon(PhieuMuon phieumon)
        {
            string query = string.Format("exec SuaPhieuMuon  {0}, {1}, {2}, {3}, '{4}', '{5}' ", phieumon.MaPhieuMuon, phieumon.MaNhanVien, phieumon.MaDocGia, phieumon.ThoiGian, phieumon.NgayMuon, phieumon.NgayTra);

            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        public bool XoaSachTrongPhieuMuon(int maphieumon, int masach)
        {
            string query = string.Format("exec XoaSachTrongPhieuMuon  {0}, {1}", maphieumon, masach);

            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        public List<PhieuMuon> XemTatCaPhieuMuon()
        {
            string query = string.Format("exec XemTatCaPhieuMuon ");

            return DataProvider.Instance.ExecuteQuery(query).AsEnumerable().Select(m =>
           new PhieuMuon(m.Field<int>("MaPhieuMuon"), m.Field<int>("MaNhanVien"), m.Field<int>("MaDocGia"), m.Field<int>("ThoiGian"), m.Field<DateTime>("NgayMuon"), m.Field<DateTime>("NgayTra"), m.Field<decimal>("ThanhTien"))).ToList();
        }


        public List<Sach> XemDSSachPhieuMuon(int maPhieuMuon)
        {
            string query = string.Format("exec XemDSSachPhieuMuon {0} ", maPhieuMuon);

            return DataProvider.Instance.ExecuteQuery(query).AsEnumerable().Select(m =>
           new Sach(m.Field<int>("MaSach"), m.Field<int>("MaDauSach"), m.Field<string>("TenSach"), m.Field<bool>("TinhTrang"))).ToList();
        }

        public List<Sach> TimKiemTTSach(int maPM, int maTimKiem)
        {
            string query = string.Format("Select SACH.* from CHITIETPHIEUMUON inner join SACH on CHITIETPHIEUMUON.MaSach = SACH.MaSach where MaPhieuMuon like {0} and Sach.MaSach like {1} ", maPM, maTimKiem);

            return DataProvider.Instance.ExecuteQuery(query).AsEnumerable().Select(m =>
           new Sach(m.Field<int>("MaSach"), m.Field<int>("MaDauSach"), m.Field<string>("TenSach"), m.Field<bool>("TinhTrang"))).ToList();
        }
        public void TraSach(int maPhieuMuon)
        {
            DataProvider.Instance.ExecuteNonQuery("" +
                "update SACH set TinhTrang = 0 where MaSach in " +
                $"(select MaSach from CHITIETPHIEUMUON where MaPhieuMuon = {maPhieuMuon})");
        }
    }
}
