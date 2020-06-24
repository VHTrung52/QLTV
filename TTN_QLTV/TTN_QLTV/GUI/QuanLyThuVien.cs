using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTN_QLTV.BUS;
using TTN_QLTV.GUI;
using TTN_QLTV.GUI.QuanLy;

namespace TTN_QLTV
{
    public partial class QuanLyThuVien : Form
    {
        DauSachBUS dauSach;
        TacGiaBUS tacGia;
        TheLoaiBUS theLoai;
        NhaXuatBanBUS nhaXuatBan;
        KeSachBus keSach;
        public QuanLyThuVien()
        {
            InitializeComponent();
            dauSach = new DauSachBUS();
            tacGia = new TacGiaBUS();
            theLoai = new TheLoaiBUS();
            nhaXuatBan = new NhaXuatBanBUS();
            keSach = new KeSachBus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewDauSach.DataSource = dauSach.XemTatCaDauSach();
            dataGridViewDauSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDauSach.Columns["TenDauSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTacGia.DataSource = tacGia.XemTacGia(dataGridViewDauSach.CurrentRow.Cells[0].Value.ToString());
            dataGridViewTheLoai.DataSource = theLoai.XemTheLoai(dataGridViewDauSach.CurrentRow.Cells[0].Value.ToString());
            dataGridViewNhaXuatBan.DataSource = nhaXuatBan.XemNhaXuatBan(dataGridViewDauSach.CurrentRow.Cells[0].Value.ToString());
            textBoxKeSach.Text = keSach.HienTenKeSach(dataGridViewDauSach.CurrentRow.Cells[2].Value.ToString());
                //dataGridViewDauSach.CurrentRow.Cells[2].Value.ToString();
            comboBoxLoaiThongTin.SelectedIndex = 0;
            changeDataGridViewHeader();
        }

        private void dataGridViewDauSach_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            UpdateThongTin(); 
        }
        private void changeDataGridViewHeader()
        {
            dataGridViewDauSach.Columns["MaDauSach"].HeaderText = "Mã Đầu Sách";
            dataGridViewDauSach.Columns["TenDauSach"].HeaderText = "Mã Đầu Sách";
            dataGridViewDauSach.Columns["MaKeSach"].HeaderText = "Mã Kệ Sách";
            dataGridViewDauSach.Columns["SoLuongHienTai"].HeaderText = "Số Lượng Hiện Tại";
            dataGridViewDauSach.Columns["TongSo"].HeaderText = "Tổng Số";

            dataGridViewTheLoai.Columns["TenTheLoai"].HeaderText = "Thể Loại";
            dataGridViewTacGia.Columns["TenTacGia"].HeaderText = "Tác Giả";
            dataGridViewNhaXuatBan.Columns["TenNhaXuatBan"].HeaderText = "Nhà Xuất Bản";
        }
        private void UpdateThongTin()
        {
            if (dataGridViewDauSach.CurrentRow != null)
            {
                dataGridViewTacGia.DataSource = tacGia.XemTacGia(dataGridViewDauSach.CurrentRow.Cells[0].Value.ToString());
                dataGridViewTheLoai.DataSource = theLoai.XemTheLoai(dataGridViewDauSach.CurrentRow.Cells[0].Value.ToString());
                dataGridViewNhaXuatBan.DataSource = nhaXuatBan.XemNhaXuatBan(dataGridViewDauSach.CurrentRow.Cells[0].Value.ToString());
                textBoxKeSach.Text = keSach.HienTenKeSach(dataGridViewDauSach.CurrentRow.Cells[2].Value.ToString());
            }
            else
            {
                dataGridViewTacGia.DataSource = new DataTable();
                dataGridViewTheLoai.DataSource = new DataTable();
                dataGridViewNhaXuatBan.DataSource = new DataTable();
                textBoxKeSach.Text = "";
            }    
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            
            switch (comboBoxLoaiThongTin.Text)
            {
                case "Tác Giả":
                    {
                        dataGridViewDauSach.DataSource = dauSach.TimKiemDauSachTheoTacGia(textBoxThongTinTimKiem.Text);
                        break;
                    }
                case "Đầu Sách":
                    {
                        dataGridViewDauSach.DataSource = dauSach.XemTatCaDauSachDauSach(textBoxThongTinTimKiem.Text);
                        break;
                    }
                case "Thể Loại":
                    {
                        dataGridViewDauSach.DataSource = dauSach.TimKiemDauSachTheoNhieuTheLoai(textBoxThongTinTimKiem.Text);
                        break;
                    }
                case "Nhà Xuất Bản":
                    {
                        dataGridViewDauSach.DataSource = dauSach.XemTatCaDauSachNXB(textBoxThongTinTimKiem.Text);
                        break;
                    }
                case "Kệ Sách":
                    {
                        if(Regex.IsMatch(textBoxThongTinTimKiem.Text, "^[0-9]*$"))
                        {
                            dataGridViewDauSach.DataSource = dauSach.XemTatCaDauSachKeSach(textBoxThongTinTimKiem.Text);
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Phải là 1 số");
                            break;
                        }                        
                    }
                default:
                    {
                        break;
                    }
            }
            UpdateThongTin();
        }

        private void buttonQuanLySach_Click(object sender, EventArgs e)
        {
            //QuanLy2 formQuanLy = new QuanLy2();
            GUI.MainMenu.Static_OpenChildForm(new MainQuanLy());
        }

        private void buttonQuanLyDocGia_Click(object sender, EventArgs e)
        {
            GUI.MainMenu.Static_OpenChildForm(new QuanLyDocGia());
            /*QuanLyDocGia formQuanLyDocGia = new QuanLyDocGia();
            formQuanLyDocGia.Show();*/
        }

        private void buttonQuanLyPhieuMuon_Click(object sender, EventArgs e)
        {
            GUI.MainMenu.Static_OpenChildForm(new QuanLyPhieuMuon());
            /*QuanLyPhieuMuon formQuanLyPhieuMuon = new QuanLyPhieuMuon();
            formQuanLyPhieuMuon.Show();*/
        }
    }
}
