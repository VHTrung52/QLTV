using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TTN_QLTV.DTO;
using TTN_QLTV.DAL;

namespace TTN_QLTV.BUS
{
    class BUSNXB
    {
        public List<NhaXuatBan> ConvertNXB(DataTable data)
        {
            List<NhaXuatBan> lnxb = new List<NhaXuatBan>();
            lnxb = (from DataRow dr in data.Rows
                   select new NhaXuatBan()
                   {
                       MaNhaXuatBan = (int)dr["MaNhaXuatBan"],
                       TenNhaXuatBan = dr["TenNhaXuatBan"].ToString()
                   }
                   ).ToList();
            return lnxb;
        }
        public List<DauSach> ConvertDSNXB(DataTable data)
        {
            List<DauSach> lds = new List<DauSach>();
            lds = (from DataRow dr in data.Rows
                   select new DauSach()
                   {
                       MaDauSach = (int)dr["MaDauSach"],
                       TenDauSach = dr["TenDauSach"].ToString(),
                       MaKeSach = (int)dr["MaKeSach"],
                       SoLuongHienTai = (int)dr["SoLuongHienTai"],
                       TongSo = (int)dr["TongSo"]
                   }
                   ).ToList();
            return lds;
        }
        public DataTable GetDanhSachNXB()
        {
            return DataProvider.Instance.ExecuteQuery("select * from NHAXUATBAN");
        }
        public DataTable GetDanhSachDSNXB(int maNXB)
        {
            return DataProvider.Instance.ExecuteQuery("select * from DAUSACH where MaDauSach in (select MaDauSach from DS_NHAXUATBAN where MaNhaXuatBan = " + maNXB + ")");
        }
        public DataTable GetDanhSachDSNXBfilter(int maNXB, string str)
        {
            return DataProvider.Instance.ExecuteQuery("select * from DAUSACH where MaDauSach in (select MaDauSach from DS_NHAXUATBAN where MaNhaXuatBan = " + maNXB + ") " +
                "AND MaDauSach LIKE '%" + str + "%' OR TenDauSach LIKE '%" + str + "%'");
        }
        public DataTable GetDanhSachNXBfilter(string str)
        {
            return DataProvider.Instance.ExecuteQuery("select * from NhaXuatBan where MaNhaXuatBan LIKE '%" + str + "%' OR TenNhaXuatBan LIKE '%" + str + "%'");
        }
        public void AddNXB(string tenTG)
        {
            int index = (int)DataProvider.Instance.ExecuteScalar("select MAX(MaNhaXuatBan) from NhaXuatBan");
            DataProvider.Instance.ExecuteNonQuery("");
        }
        public void EditNXB(int manxb, string tenNXB)
        {
            DataProvider.Instance.ExecuteNonQuery("");
        }
        public void DelDauSach_NXB(int ma)
        {
            DataProvider.Instance.ExecuteNonQuery("delete from DauSach where MaDauSach = '" + ma + "'");
        }
    }
}
