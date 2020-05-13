using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTN_QLTV.DAL;
using TTN_QLTV.DTO;
using System.Data;

namespace TTN_QLTV.BUS
{
    class DocGiaBUS
    {
        public bool ThemDocGia(DocGia docgia)
        {
            string query = string.Format("exec ThemDocGia N'{0}', '{1}', '{2}', '{3}' ", docgia.HoTen, docgia.NgaySinh, docgia.CMND, docgia.SoDienThoai);

            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        public bool SuaDocGia(DocGia docgia)
        {
            string query = string.Format("exec SuaDocGia {0}, N'{1}', '{2}', '{3}', '{4}' ", docgia.MaDocGia, docgia.HoTen, docgia.NgaySinh, docgia.CMND, docgia.SoDienThoai);

            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        public List<DocGia> XemTatCaDocGia()
        {
            string query = string.Format("exec XemTatCaDocGia ");

            return DataProvider.Instance.ExecuteQuery(query).AsEnumerable().Select(m =>
           new DocGia(m.Field<int>("MaDocGia"), m.Field<string>("HoTen"), m.Field<DateTime>("NgaySinh"), m.Field<string>("SoDienThoai"), m.Field<string>("CMND"))).ToList();
        }

        public DocGia XemChiTietDG(int maDocGia)
        {
            string query = string.Format("exec XemChiTietDG {0} ", maDocGia);

            DataTable dt = DataProvider.Instance.ExecuteQuery(query);

            DocGia docgia = new DocGia();


            docgia.MaDocGia = Int16.Parse(dt.Rows[0]["MaDocGia"].ToString());
            docgia.HoTen = dt.Rows[0]["HoTen"].ToString();
            docgia.NgaySinh = DateTime.Parse(dt.Rows[0]["NgaySinh"].ToString());
            docgia.SoDienThoai = dt.Rows[0]["SoDienThoai"].ToString();
            docgia.CMND = dt.Rows[0]["CMND"].ToString();

            return docgia;
        }
}
}
