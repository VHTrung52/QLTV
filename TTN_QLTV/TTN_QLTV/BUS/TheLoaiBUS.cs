using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTN_QLTV.DAL;

namespace TTN_QLTV.BUS
{
    class TheLoaiBUS
    {
        public DataTable XemTheLoai(string idSach)
        {
            string query = string.Format("XemTheLoai {0} ", idSach);
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable XemTheLoai()
        {
            string query = string.Format("XemTatCaTheLoai");
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
