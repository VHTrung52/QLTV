﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTN_QLTV.DAL;

namespace TTN_QLTV.BUS
{
    class NhaXuatBanBUS
    {
        public DataTable XemNhaXuatBan(string idSach)
        {
            string query = string.Format("XemNhaXuatBan {0} ", idSach);
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
