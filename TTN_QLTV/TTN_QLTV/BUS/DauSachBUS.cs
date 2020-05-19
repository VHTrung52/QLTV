using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TTN_QLTV.DAL;
using TTN_QLTV.DTO;

namespace TTN_QLTV.BUS
{
    class DauSachBUS
    {
            return DataProvider.Instance.ExecuteQuery("PROC_TimKiemDauSachTheoDauSach N'%" + tenDauSach + "%'");
        }
        
        public DataTable TimKiemDauSachTheoNhaXuatBan(string tenNhaXuatBan)
        {
            return DataProvider.Instance.ExecuteQuery("PROC_TimKiemDauSachTheoNhaXuatBan N'%" + tenNhaXuatBan + "%'");
        }

        public DataTable TimKiemDauSachTheoKeSach(string tenKeSach)
        {
            return DataProvider.Instance.ExecuteQuery("PROC_TimKiemDauSachTheoKeSach N'%" + tenKeSach + "%'");
        }


        public DataTable TimKiemDauSachTheoTheLoai(string theLoai)
        {
            return DataProvider.Instance.ExecuteQuery("PROC_TimKiemDauSachTheoTheLoai N'%" + theLoai + "%'");
        }

        public DataTable GetTatCaSach()
        {
            return DataProvider.Instance.ExecuteQuery("PROC_GetTatCaSach");
        }

        

        public DataTable GetTacGia()
        {
            return DataProvider.Instance.ExecuteQuery("select * from TACGIA ");
        }

        public DataTable GetTheLoai()
        {
            return DataProvider.Instance.ExecuteQuery("select * from THELOAI ");
        }

        public DataTable GetNhaXuatBan()
        {
            return DataProvider.Instance.ExecuteQuery("select * from NHAXUATBAN ");
        }

        public void ThemTacGiaChoDauSach(int maDauSach , int maTacGia)
        {
            DataProvider.Instance.ExecuteNonQuery("PROC_ThemTacGiaChoDauSach '" + maDauSach + "','" + maTacGia + "'");
        }

        public void XoaTacGia_DauSach(int maDauSach, string tenTacGia)
        {
            DataProvider.Instance.ExecuteNonQuery("PROC_XoaTacGiaChoDauSach '" + maDauSach + "',N'" + tenTacGia + "'");
        }

        public void ThemTheLoaiChoDauSach(int maDauSach, int maTheLoai)
        {
            DataProvider.Instance.ExecuteNonQuery("PROC_ThemTheLoaiChoDauSach '" + maDauSach + "','" + maTheLoai + "'");
        }

        public void XoaTheLoai_DauSach(int maDauSach, string tenTheLoai)
        {
            DataProvider.Instance.ExecuteNonQuery("PROC_XoaTheLoaiChoDauSach '" + maDauSach + "',N'" + tenTheLoai + "'");
        }


        public void ThemNhaXuatBanChoDauSach(int maDauSach, int maNhaXuatban)
        {
            DataProvider.Instance.ExecuteNonQuery("PROC_ThemNhaXuatBanChoDauSach '" + maDauSach + "','" + maNhaXuatban + "'");
        }

        public void XoaNhaXuatBan_DauSach(int maDauSach, string tenNhaXuatBan)
        {
            DataProvider.Instance.ExecuteNonQuery("PROC_XoaNhaXuatBanChoDauSach '" + maDauSach + "',N'" + tenNhaXuatBan + "'");
        }

        public void ThemDauSach(string tenDauSach , int maKeSach , int soLuongHienTai , int tongSo)
        {
            DataProvider.Instance.ExecuteNonQuery("PROC_ThemDauSach N'" + tenDauSach + "','" + maKeSach + "','" + soLuongHienTai + "','" + tongSo + "'");
        }


        public void SuaDauSach(int maDauSach,string tenDauSach, int maKeSach, int soLuongHienTai, int tongSo)
        {
            DataProvider.Instance.ExecuteNonQuery("PROC_SuaDauSach '" + maDauSach + "',N'" + tenDauSach + "','" + maKeSach + "','" + soLuongHienTai + "','" + tongSo + "'");
        }


        public DataTable TimKiemSach(string tenSach)
        {
            return DataProvider.Instance.ExecuteQuery("PROC_TimKiemSach N'%" + tenSach + "%' ");
        }

        public void XoaSach_Sach(int maSach)
        {
            DataProvider.Instance.ExecuteNonQuery("PROC_XoaSach '" + maSach + "'");
        }

        public void ThemSach_Sach( int maDauSach, string tenSach, bool tinhTrang)
        {
            DataProvider.Instance.ExecuteNonQuery("PROC_ThemSach '" + maDauSach + "',N'" + tenSach + "','" + tinhTrang + "'");
        }


        public void SuaSach_Sach(int maSach, int maDauSach, string tenSach, bool tinhTrang)
        {
            DataProvider.Instance.ExecuteNonQuery("PROC_SuaThongTinSach '" + maSach + "','" + maDauSach + "',N'" + tenSach + "','" + tinhTrang +  "'");
        }


        public void ThemDauSachChoSach(int maSach , int maDauSach)
        {
            DataProvider.Instance.ExecuteNonQuery("PROC_ThemDauSachChoSach '" + maSach + "','" + maDauSach + "'");
        }

        public void XoaDauSachChoSach(int maSach)
        {
            DataProvider.Instance.ExecuteNonQuery("PROC_XoaDauSachChoSach '" + maSach + "'");
        }

    }
}
