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
        public DataTable TimKiemDauSachTheoDauSach(string tenDauSach)
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
        //////////////////////////// test ///////////////////////////////////////
        public List<DauSach> TimKiemDauSachTheoNhieuTheLoai(string theLoai)
        {

            if(theLoai.Contains("+") == true)
            {
                List<string> listTheLoai = theLoai.Split('+').ToList();
                List<DauSach> lds1 = new List<DauSach>();
                List<DauSach> lds2 = new List<DauSach>();
                List<DauSach> lds = new List<DauSach>();
                /*List<string> ls1 = new List<string>();
                List<string> ls2 = new List<string>();
                List<string> ls = new List<string>();*/
                for (int i = 0;i < listTheLoai.Count;i++)
                {
                    if (i == 0)
                    {
                        lds1 = ConvertToListDauSach(DataProvider.Instance.ExecuteQuery("" +
                            "select DAUSACH.MaDauSach , TenDauSach, MaKeSach, SoLuongHienTai, TongSo " +
                            "from DAUSACH , DS_THELOAI, THELOAI " +
                            $"where DAUSACH.MaDauSach = DS_THELOAI.MaDauSach " +
                            $"and " +
                            $"DS_THELOAI.MaTheLoai = THELOAI.MaTheLoai " +
                            $"and TenTheLoai Like N'%{listTheLoai[i]}%'"));
                        /*foreach(DauSach ds in lds1)
                        {
                            ls1.Add(ds.TenDauSach);
                        }*/
                    }
                    else
                    {
                        lds2 = ConvertToListDauSach(DataProvider.Instance.ExecuteQuery("" +
                            "select DAUSACH.MaDauSach , TenDauSach, MaKeSach, SoLuongHienTai, TongSo " +
                            "from DAUSACH , DS_THELOAI, THELOAI " +
                            $"where DAUSACH.MaDauSach = DS_THELOAI.MaDauSach " +
                            $"and " +
                            $"DS_THELOAI.MaTheLoai = THELOAI.MaTheLoai " +
                            $"and TenTheLoai Like N'%{listTheLoai[i]}%'"));
                        /*foreach (DauSach ds in lds2)
                        {
                            ls2.Add(ds.TenDauSach);
                        }
                        foreach(string s in ls1)
                        {
                            if (ls2.Contains(s) == true)
                                ls.Add(s);
                        }
                        ls1 = ls;*/
                        foreach (DauSach ds in lds1)
                        {
                            if (lds2.Find(x=>x.TenDauSach == ds.TenDauSach) != null)
                            {
                                lds.Add(ds);
                            }
                        }
                        lds1 = lds;
                        lds = new List<DauSach>();
                    }
                }
                return lds1;
            }    
            else
                return ConvertToListDauSach(DataProvider.Instance.ExecuteQuery("PROC_TimKiemDauSachTheoTheLoai N'%" + theLoai + "%'"));
        }

        public List<DauSach> ConvertToListDauSach(DataTable dt)
        {
            List<DauSach> lds = new List<DauSach>();
            lds = (from DataRow dr in dt.Rows
                   select new DauSach()
                   {
                       MaDauSach = (int)dr["MaDauSach"],
                       TenDauSach = dr["TenDauSach"].ToString(),
                       MaKeSach = (int)dr["MaKeSach"],
                       SoLuongHienTai = (int)dr["SoLuongHienTai"],
                       TongSo = (int)dr["TongSo"]
                   }).ToList();
            return lds;
        }
        
        //////////////////////////// test ///////////////////////////////////////
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
        public DataTable GetTenTacGia(int maDauSach)
        {
            return DataProvider.Instance.ExecuteQuery("PROC_GetTenTacGia '" + maDauSach + "'");
        }

        public DataTable GetTenNhaXuatBan(int maDauSach)
        {
            return DataProvider.Instance.ExecuteQuery("PROC_GetTenNhaXuatBan '" + maDauSach + "'");
        }

        public DataTable GetTenTheLoai(int maDauSach)
        {
            return DataProvider.Instance.ExecuteQuery("PROC_GetTheLoai '" + maDauSach + "'");
        }
        public DataTable GetDanhSachDauSach()
        {
            return DataProvider.Instance.ExecuteQuery("select * from DAUSACH");
        }
        public DataTable GetSachThuocDauSach(int maDauSach)
        {
            return DataProvider.Instance.ExecuteQuery("PROC_GetSachThuocDauSach '" + maDauSach + "'");
        }

        public DataTable GetDauSachTheoMaDauSach(int maDauSach)
        {
            return DataProvider.Instance.ExecuteQuery("PROC_GetDauSachTheoMaDauSach '" + maDauSach + "'");
        }
        public DataTable TimKiemDauSachTheoTacGia(string tenTacGia)
        {
            return DataProvider.Instance.ExecuteQuery("PROC_TimKiemDauSachTheoTacGia N'%" + tenTacGia + "%'");
        }
        public DataTable XemTatCaDauSach()
        {
            string query = string.Format("XemTatCaDauSach");
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable XemTatCaDauSachTacGia(string i)
        {
            string query = string.Format("XemTatCaDauSachTacGia N'{0}'", i);
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable XemTatCaDauSachDauSach(string i)
        {
            string query = string.Format("XemTatCaDauSachDauSach N'{0}'", i);
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable XemTatCaDauSachTheLoai(string i)
        {
            string query = string.Format("XemTatCaDauSachTheLoai N'{0}'", i);
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable XemTatCaDauSachNXB(string i)
        {
            string query = string.Format("XemTatCaDauSachNXB N'{0}'", i);
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable XemTatCaDauSachKeSach(string i)
        {
            string query = string.Format("XemTatCaDauSachKeSach {0}", i);
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable DauSach_Sach(int maDauSach)
        {
            return DataProvider.Instance.ExecuteQuery("PROC_DauSach_Sach '" + maDauSach + "'");

        public DataTable XemDauSachTheLoai(string i)
        {
            string query = string.Format("XemDauSachTheLoai {0}", i);
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
