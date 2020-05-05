using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTN_QLTV.DTO
{
    class PhieuMuon
    {
        private int maPhieuMuon;
        private int maNhanVien;
        private int maDocGia;
        private int thoiGian;
        private DateTime ngayMuon;
        private DateTime ngayTra;

        public PhieuMuon(int maPhieuMuon, int maNhanVien, int maDocGia, int thoiGian, DateTime ngayMuon, DateTime ngayTra)
        {
            this.maPhieuMuon = maPhieuMuon;
            this.maNhanVien = maNhanVien;
            this.maDocGia = maDocGia;
            this.thoiGian = thoiGian;
            this.ngayMuon = ngayMuon;
            this.ngayTra = ngayTra;
        }

        public int MaPhieuMuon { get => maPhieuMuon; set => maPhieuMuon = value; }
        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public int MaDocGia { get => maDocGia; set => maDocGia = value; }
        public int ThoiGian { get => thoiGian; set => thoiGian = value; }
        public DateTime NgayMuon { get => ngayMuon; set => ngayMuon = value; }
        public DateTime NgayTra { get => ngayTra; set => ngayTra = value; }
    }
}
