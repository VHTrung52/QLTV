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
        public DataTable XemTatCaDauSach()
        {
            string query = string.Format("XemTatCaDauSach");
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable XemTatCaDauSachTacGia(string i)
        {
            string query = string.Format("XemTatCaDauSachTacGia N'{0}'",i);
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable XemTatCaDauSachDauSach(string i)
        {
            string query = string.Format("XemTatCaDauSachDauSach N'{0}'",i);
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
    }
}
