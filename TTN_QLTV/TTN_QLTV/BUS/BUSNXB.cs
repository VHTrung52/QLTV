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
            return DataProvider.Instance.ExecuteQuery("GetDanhSachNXB");
        }
        public DataTable GetDanhSachDSNXB(int maNXB)
        {
            return DataProvider.Instance.ExecuteQuery("GetDanhSachDSNXB " + maNXB);
        }
        public DataTable GetDanhSachDSNXBfilter(int maNXB, string str)
        {
            return DataProvider.Instance.ExecuteQuery("GetDanhSachDSNXBfilter "+maNXB+", '"+str+"'");
        }
        public DataTable GetDanhSachNXBfilter(string str)
        {
            return DataProvider.Instance.ExecuteQuery("GetDanhSachNXBfilter '"+str+"'");
        }
        public void AddNXB(string tenTG)
        {
            DataProvider.Instance.ExecuteNonQuery("AddNXB '"+tenTG+"'");
        }
        public void EditNXB(int manxb, string tenNXB)
        {
            DataProvider.Instance.ExecuteNonQuery("EditNXB "+manxb+", '"+tenNXB+"'");
        }
        public void DelDauSach_NXB(int manxb, int mads)
        {
            DataProvider.Instance.ExecuteNonQuery("DelDauSach_NXB " + manxb + ", " + mads);
        }
    }
}
