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
    class BUSTheLoai
    {
        public List<TheLoai> ConvertTL(DataTable data)
        {
            List<TheLoai> ltl = new List<TheLoai>();
            ltl = (from DataRow dr in data.Rows
                   select new TheLoai()
                   {
                       MaTheLoai = (int)dr["MaTheLoai"],
                       TenTheLoai = dr["TenTheLoai"].ToString()
                   }
                   ).ToList();
            return ltl;
        }
        public DataTable GetDanhSachTheLoai()
        {
            return DataProvider.Instance.ExecuteQuery("select * from TheLoai");
        }
        public List<DauSach> ConvertDSTL(DataTable data)
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
        public DataTable GetDanhSachDSTheLoai(int matl)
        {
            return DataProvider.Instance.ExecuteQuery("select * from TheLoai where MaTheLoai in (select MaTheLoai from DS_TheLoai where MaTheLoai = " + matl + ")");
        }
        public DataTable GetDanhSachDSTheLoaifilter(int matl, string str)
        {
            return DataProvider.Instance.ExecuteQuery("select * from TheLoai where MaTheLoai in (select MaTheLoai from DS_TheLoai where MaTheLoai = " + matl + ") " +
                "AND MaTheLoai LIKE '%" + str + "%' OR TenTheLoai LIKE '%" + str + "%'");
        }
        public DataTable GetDanhSachTheLoaifilter(string str)
        {
            return DataProvider.Instance.ExecuteQuery("select * from TheLoai where MaTheLoai LIKE '%" + str + "%' OR TenTheLoai LIKE '%" + str + "%'");
        }
        public void AddTheLoai(string tenTL)
        {
            int index = (int)DataProvider.Instance.ExecuteScalar("select MAX(MaTheLoai) from TheLoai");
            DataProvider.Instance.ExecuteNonQuery("");
        }
        public void EditTheLoai(int matl, string tenTL)
        {
            DataProvider.Instance.ExecuteNonQuery("");
        }
        public void DelDauSach_TheLoai(int ma)
        {
            DataProvider.Instance.ExecuteNonQuery("delete from DauSach where MaDauSach = '" + ma + "'");
        }
    }
}
