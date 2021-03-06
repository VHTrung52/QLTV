﻿using System;
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
            return DataProvider.Instance.ExecuteQuery("GetDanhSachTheLoai");
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
            return DataProvider.Instance.ExecuteQuery("GetDanhSachDSTheLoai " + matl);
        }
        public DataTable GetDanhSachDSTheLoaifilter(int matl, string str)
        {
            return DataProvider.Instance.ExecuteQuery("select * " +
                "from DAUSACH " +
                "where " +
                $"MaDauSach in (select MaDauSach from DS_THELOAI where MaTheLoai = {matl} ) " +
                "AND " +
                $"( MaDauSach LIKE '%{str}%' " +
                "OR " +
                $"TenDauSach LIKE N'%{str}%')");
        }
        public DataTable GetDanhSachTheLoaifilter(string str)
        {
            return DataProvider.Instance.ExecuteQuery("" +
                "select * " +
                "from TheLoai " +
                $"where MaTheLoai LIKE '%{str}%' " +
                $"OR " +
                $"TenTheLoai LIKE N'%{str}%'");
        }
        public void AddTheLoai(string tenTL)
        {
            DataProvider.Instance.ExecuteNonQuery("AddTheLoai "+tenTL);
        }
        public void EditTheLoai(int matl, string tenTL)
        {
            DataProvider.Instance.ExecuteNonQuery("EditTheLoai "+matl+", '"+tenTL+"'");
        }
        public void DelDauSach_TheLoai(int matl, int mads)
        {
            DataProvider.Instance.ExecuteNonQuery("DelDauSach_THELOAI " + matl + ", " + mads);
        }
    }
}
