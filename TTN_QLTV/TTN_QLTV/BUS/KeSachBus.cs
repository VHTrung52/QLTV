using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTN_QLTV.DAL;

namespace TTN_QLTV.BUS
{
    class KeSachBus
    {
        public DataTable XemTatCaKeSach()
        {
            string query = string.Format("XemKeSach");
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool ThemKeSach(string tenKeSach)
        {
            string query = string.Format("ThemKeSach {0}",tenKeSach);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool SuaKeSach(string maKeSach, string tenKeSach)
        {
            string query = string.Format("ThemKeSach {0}, {1}", maKeSach, tenKeSach);
            return DataProvider.Instance.ExecuteNonQuery(tenKeSach) > 0;
        }

        public DataTable TimKeSach(string i)
        {
            string query = string.Format("TimKeSach {0}",i);
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool BoSach(string maSach)
        {
            string query = string.Format("update DAUSACH set MaKeSach = null where MaDauSach = {0}", maSach);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public string HienTenKeSach(string maKeSach)
        {
            string query = "" +
                "select TenKeSach " +
                "from KeSach " +
                $"where MaKeSach = {maKeSach}";
            return DataProvider.Instance.ExecuteScalar(query).ToString();
        }
    }
}
