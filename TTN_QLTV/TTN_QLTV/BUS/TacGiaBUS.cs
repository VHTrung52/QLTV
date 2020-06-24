using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTN_QLTV.DAL;

namespace TTN_QLTV.BUS
{
    class TacGiaBUS
    {
        public DataTable XemTacGia(string idSach)
        {
            string query = string.Format("XemTacGia {0} ",idSach);             
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public void InsertDSTacGia(int maDauSach,int maTacGia)
        {
            DataProvider.Instance.ExecuteNonQuery("" +
                "insert into DS_TacGia(MaDauSach,MaTacGia) " +
                $"values({maDauSach},{maTacGia})");
        }
    }
}
