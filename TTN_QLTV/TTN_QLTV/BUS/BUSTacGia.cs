﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TTN_QLTV.DAL;
using TTN_QLTV.DTO;

namespace TTN_QLTV.BUS
{
    class BUSTacGia
    {
        public List<TacGia> ConvertTG(DataTable data)
        {
            List<TacGia> ltg = new List<TacGia>();
            ltg = (from DataRow dr in data.Rows
                   select new TacGia()
                   {
                       MaTacGia = (int) dr["MaTacGia"],
                       TenTacGia = dr["TenTacGia"].ToString(),
                       NgaySinh = Convert.ToDateTime(dr["NgaySinh"])
                   }
                   ).ToList();
            return ltg;
        }
        public DataTable GetDanhSachTacGia()
        {
            return DataProvider.Instance.ExecuteQuery("select * from TACGIA");
        }
        public List<DauSach> ConvertDSTG(DataTable data)
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
        public DataTable GetDanhSachDSTacGia(int matg)
        {
            return DataProvider.Instance.ExecuteQuery("select * from DAUSACH where MaDauSach in (select MaDauSach from DS_TACGIA where MaTacGia = "+matg+")");
        }
        public DataTable GetDanhSachDSTacGiafilter(int matg, string str)
        {
            return DataProvider.Instance.ExecuteQuery("select * from DAUSACH where MaDauSach in (select MaDauSach from DS_TACGIA where MaTacGia = " + matg + ") " +
                "AND MaDauSach LIKE '%"+str+"%' OR TenDauSach LIKE '%"+str+"%'");
        }
        public void DelDauSach_TacGia(int ma)
        {
            DataProvider.Instance.ExecuteNonQuery("delete from DauSach where MaDauSach = '"+ma+"'");
        }
        public DataTable GetDanhSachTacGiafilter(string str)
        {
            return DataProvider.Instance.ExecuteQuery("select * from TacGia where MaTacGia LIKE '%" + str + "%' OR TenTacGia LIKE '%" + str + "%'");
        }
        public void AddTacGia(string tenTG, string ngaysinh) {
            int index = (int) DataProvider.Instance.ExecuteScalar("select MAX(MaTacGia) from TACGIA");
            DataProvider.Instance.ExecuteNonQuery("");            
        }
        public void EditTacGia(int matg, string tenTG, string ngaysinh)
        {
            DataProvider.Instance.ExecuteNonQuery("");
        }
    }
}
