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
using TTN_QLTV.DAL;
using TTN_QLTV.DTO;
using TTN_QLTV.GUI.QuanLy1;

namespace TTN_QLTV.GUI.QuanLy
{
    public partial class QuanLyDauSach : Form
    {
        private List<DauSach> lds = new List<DauSach>();
        private List<TacGia> ltg = new List<TacGia>();
        private List<NhaXuatBan> lnxb = new List<NhaXuatBan>();
        private List<TheLoai> ltl = new List<TheLoai>();

        DauSachBUS dauSachBUS = new DauSachBUS();
        public static int maDauSach;
        

        private string xoaTacGia;
        private string xoaTheLoai;
        private string xoaNhaXuatBan;
        private BUSTacGia busTG = new BUSTacGia();
        private BUSNXB busNXB = new BUSNXB();
        private BUSTheLoai busTL = new BUSTheLoai();
        private TheLoaiBUS theLoaiBUS = new TheLoaiBUS();
        private KeSachBus keSachBus = new KeSachBus();

        private static QuanLyDauSach formQuanLyDauSach = null;
        public QuanLyDauSach()
        {
            
            InitializeComponent();
            formQuanLyDauSach = this;
        }
        public static void Static_VisiableButtonThemVao()
        {
            if (formQuanLyDauSach != null)
            {
                formQuanLyDauSach.EnableButtonThemVao();
            }
        }
        private void EnableButtonThemVao()
        {
            buttonThemVao.Visible = true;
        }
        public static void Static_ChangeButtonThemVaoText(string text)
        {
            if(formQuanLyDauSach != null)
            {
                formQuanLyDauSach.ChangeButtonThemVaoText(text);
            }
        }
        private void ChangeButtonThemVaoText(string text)
        {
            buttonThemVao.Text = text;
        }
        private void dataGridViewDauSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonSua.Enabled = true;
            buttonThem.Enabled = false;
            DataGridViewRow row = dataGridViewDauSach.CurrentRow;

            if (!string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
            {
                maDauSach = Convert.ToInt32(row.Cells[0].Value);

                dataGridViewTacGia.DataSource = dauSachBUS.GetTenTacGia(maDauSach);

                dataGridViewTheLoai.DataSource = dauSachBUS.GetTenTheLoai(maDauSach);

                dataGridViewNhaXuatBan.DataSource = dauSachBUS.GetTenNhaXuatBan(maDauSach);
                changeDataGridViewHeader_tabDauSach();
                textBoxMaDauSach.Text = row.Cells[0].Value.ToString();
                textBoxTenDauSach.Text = row.Cells[1].Value.ToString();
                textBoxMaKeSach.Text = row.Cells[2].Value.ToString();
                textBoxSoLuongHienTai.Text = row.Cells[3].Value.ToString();
                textBoxTongSo.Text = row.Cells[4].Value.ToString();
            }
        }
        private void changeDataGridViewHeader_tabDauSach()
        {
            dataGridViewTheLoai.Columns["TenTheLoai"].HeaderText = "Thể Loại";
            dataGridViewTacGia.Columns["TenTacGia"].HeaderText = "Tác Giả";
            dataGridViewNhaXuatBan.Columns["TenNhaXuatBan"].HeaderText = "Nhà Xuất Bản";
        }

        

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            if (comboBoxLoaiThongTin.Text == "Tác Giả")
            {
                dataGridViewDauSach.DataSource = dauSachBUS.TimKiemDauSachTheoTacGia(textBoxTimKiem.Text);
            }
            else if (comboBoxLoaiThongTin.Text == "Đầu Sách")
            {
                dataGridViewDauSach.DataSource = dauSachBUS.TimKiemDauSachTheoDauSach(textBoxTimKiem.Text);
            }
            else if (comboBoxLoaiThongTin.Text == "Thể Loại")
            {
                //dataGridViewDauSach.DataSource = dauSachBUS.TimKiemDauSachTheoTheLoai(textBoxTimKiem.Text);
                dataGridViewDauSach.DataSource = dauSachBUS.TimKiemDauSachTheoNhieuTheLoai(textBoxTimKiem.Text);
            }
            else if (comboBoxLoaiThongTin.Text == "Nhà Xuất Bản")
            {
                dataGridViewDauSach.DataSource = dauSachBUS.TimKiemDauSachTheoNhaXuatBan(textBoxTimKiem.Text);
            }
            else if (comboBoxLoaiThongTin.Text == "Kệ Sách")
            {
                dataGridViewDauSach.DataSource = dauSachBUS.TimKiemDauSachTheoKeSach(textBoxTimKiem.Text);
            }
            else
            {
                dataGridViewDauSach.DataSource = dauSachBUS.GetDanhSachDauSach();
            }
        }

        private void QuanLyDauSach_Load(object sender, EventArgs e)
        {
            buttonThemVao.Visible = false;
            buttonThem.Enabled = false;
            
            dataGridViewDauSach.DataSource = dauSachBUS.GetDanhSachDauSach();
            dataGridViewDauSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDauSach.Columns["TenDauSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewDauSach.Columns[0].HeaderText = "Mã Đầu Sách";
            dataGridViewDauSach.Columns[1].HeaderText = "Tên Đầu Sách";
            dataGridViewDauSach.Columns[2].HeaderText = "Mã Kệ Sách";
            dataGridViewDauSach.Columns[3].HeaderText = "Số Lượng Hiện Tại";
            dataGridViewDauSach.Columns[4].HeaderText = "Tổng Số";

            DataGridViewRow currentRow = dataGridViewDauSach.CurrentRow;
            if (!string.IsNullOrEmpty(currentRow.Cells[0].Value.ToString()))
            {
                maDauSach = Convert.ToInt32(currentRow.Cells[0].Value);

                dataGridViewTacGia.DataSource = dauSachBUS.GetTenTacGia(maDauSach);

                dataGridViewTheLoai.DataSource = dauSachBUS.GetTenTheLoai(maDauSach);

                dataGridViewNhaXuatBan.DataSource = dauSachBUS.GetTenNhaXuatBan(maDauSach);
                changeDataGridViewHeader_tabDauSach();
                textBoxMaDauSach.Text = currentRow.Cells[0].Value.ToString();
                textBoxTenDauSach.Text = currentRow.Cells[1].Value.ToString();
                textBoxMaKeSach.Text = currentRow.Cells[2].Value.ToString();
                textBoxSoLuongHienTai.Text = currentRow.Cells[3].Value.ToString();
                textBoxTongSo.Text = currentRow.Cells[4].Value.ToString();
            }
            currentRow = dataGridViewTacGia.CurrentRow;
            xoaTacGia = currentRow.Cells[0].Value.ToString();
            currentRow = dataGridViewTheLoai.CurrentRow;
            xoaTheLoai = currentRow.Cells[0].Value.ToString();
            currentRow = dataGridViewNhaXuatBan.CurrentRow;
            xoaNhaXuatBan = currentRow.Cells[0].Value.ToString();
        }

        private void dataGridViewTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentRow = dataGridViewTacGia.CurrentRow;
            xoaTacGia = currentRow.Cells[0].Value.ToString();
        }

        private void buttonXoaTacGia_Click(object sender, EventArgs e)
        {
            try
            {
                dauSachBUS.XoaTacGia_DauSach(maDauSach, xoaTacGia);
                MessageBox.Show("---Thành Công---");
            }
            catch (Exception)
            {
                MessageBox.Show("Tác Giả Này Chưa Có Trong Đầu Sách");
            }
            dataGridViewTacGia.DataSource = dauSachBUS.GetTenTacGia(maDauSach);
        }

        private void dataGridViewTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentRow = dataGridViewTheLoai.CurrentRow;
            xoaTheLoai = currentRow.Cells[0].Value.ToString();
        }

        private void buttonXoaTheLoai_Click(object sender, EventArgs e)
        {
            try
            {
                dauSachBUS.XoaTheLoai_DauSach(maDauSach, xoaTheLoai);
                MessageBox.Show("---Thành Công---");
            }
            catch (Exception)
            {

                MessageBox.Show("Thể Loại Này Chưa Có Trong Đầu Sách");
            }
            dataGridViewTheLoai.DataSource = dauSachBUS.GetTenTheLoai(maDauSach);
        }

        private void dataGridViewNhaXuatBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentRow = dataGridViewNhaXuatBan.CurrentRow;
            xoaNhaXuatBan = currentRow.Cells[0].Value.ToString();
        }

        private void buttonXoaNhaXuatBan_Click(object sender, EventArgs e)
        {
            try
            {
                dauSachBUS.XoaNhaXuatBan_DauSach(maDauSach, xoaNhaXuatBan);
                MessageBox.Show("---Thành Công---");
            }
            catch (Exception)
            {

                MessageBox.Show("Thể Loại Này Chưa Có Trong Đầu Sách");
            }
            dataGridViewNhaXuatBan.DataSource = dauSachBUS.GetTenNhaXuatBan(maDauSach);
        }
        public string XoaKiTuTrang(string s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if (s.IndexOf("  ") >= 0)
                {
                    s = s.Replace("  ", " ");
                }
            }
            return s;
        }

        private void buttonThemDauSach_Click(object sender, EventArgs e)
        {
            bool IsTenDauSach = Regex.IsMatch(textBoxTenDauSach.Text, @"^\s");
            bool IsSoLuongHienTai = Regex.IsMatch(textBoxSoLuongHienTai.Text, @"\d");
            bool IsTongSo = Regex.IsMatch(textBoxTongSo.Text, @"\d");
            bool IsMaKeSach = Regex.IsMatch(textBoxMaKeSach.Text, @"\d");

            textBoxTenDauSach.Text = textBoxTenDauSach.Text.Trim();
            textBoxSoLuongHienTai.Text = textBoxSoLuongHienTai.Text.Trim();
            textBoxTongSo.Text = textBoxTongSo.Text.Trim();
            textBoxMaKeSach.Text = textBoxMaKeSach.Text.Trim();


            if (textBoxTenDauSach.Text == "")
            {
                MessageBox.Show("Tên Đầu Sách Không Được Để Trống!");
                textBoxTenDauSach.Focus();
            }
            else if (textBoxSoLuongHienTai.Text == "")
            {
                MessageBox.Show("Số Lượng Đầu Sách Hiện Tại Không Được Để Trống");
                textBoxSoLuongHienTai.Focus();
            }
            else if (textBoxTongSo.Text == "")
            {
                MessageBox.Show("Tổng Số Lượng Đầu Sách Không Được Để Trống");
                textBoxTongSo.Focus();
            }
            else if (textBoxMaKeSach.Text == "")
            {
                MessageBox.Show("Mã Kệ Sách Không Được Để Trống");
                textBoxMaKeSach.Focus();
            }
            else
            {
                if (IsTenDauSach)
                {
                    MessageBox.Show("Tên Đầu Sách không Được Để Nhiều Khoảng Trắng");
                    textBoxTenDauSach.Focus();
                }
                else if (!IsSoLuongHienTai)
                {
                    MessageBox.Show("Số Lượng Đầu Sách Hiện Tại Phải Là Số Nguyên");
                    textBoxSoLuongHienTai.Focus();
                }
                else if (!IsTongSo)
                {
                    MessageBox.Show("Tổng Số Đầu Sách Phải Là 1 Số Nguyên");
                    textBoxTongSo.Focus();
                }
                else if (!IsMaKeSach)
                {
                    MessageBox.Show("Mã Kệ Sách Phải Là 1 Số Nguyên");
                    textBoxMaKeSach.Focus();
                }
                else
                {
                    if (MessageBox.Show("Bạn Có Chắc Chắn Muốn Thêm Đầu Sách Này Không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            textBoxTenDauSach.Text = XoaKiTuTrang(textBoxTenDauSach.Text);

                            dauSachBUS.ThemDauSach(textBoxTenDauSach.Text, Convert.ToInt32(textBoxMaKeSach.Text), Convert.ToInt32(textBoxSoLuongHienTai.Text), Convert.ToInt32(textBoxTongSo.Text));

                            dataGridViewDauSach.DataSource = dauSachBUS.GetDanhSachDauSach();
                            MessageBox.Show("----Thành Công----");
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Thất Bại!");
                        }

                    }
                }
            }
        }

        private void buttonHuyDauSach_Click(object sender, EventArgs e)
        {
            textBoxMaDauSach.Text = "";
            textBoxTenDauSach.Text = "";
            textBoxSoLuongHienTai.Text = "";
            textBoxTongSo.Text = "";
            textBoxMaKeSach.Text = "";
            buttonThem.Enabled = true;
            buttonSua.Enabled = false;
            
        }

        private void buttonSuaDauSach_Click(object sender, EventArgs e)
        {
            bool IsTenDauSach = Regex.IsMatch(textBoxTenDauSach.Text, @"^\s");
            bool IsSoLuongHienTai = Regex.IsMatch(textBoxSoLuongHienTai.Text, @"\d");
            bool IsTongSo = Regex.IsMatch(textBoxTongSo.Text, @"\d");
            bool IsMaKeSach = Regex.IsMatch(textBoxMaKeSach.Text, @"\d");

            textBoxTenDauSach.Text = textBoxTenDauSach.Text.Trim();
            textBoxSoLuongHienTai.Text = textBoxSoLuongHienTai.Text.Trim();
            textBoxTongSo.Text = textBoxTongSo.Text.Trim();
            textBoxMaKeSach.Text = textBoxMaKeSach.Text.Trim();


            if (textBoxTenDauSach.Text == "")
            {
                MessageBox.Show("Tên Đầu Sách Không Được Để Trống!");
                textBoxTenDauSach.Focus();
            }
            else if (textBoxSoLuongHienTai.Text == "")
            {
                MessageBox.Show("Số Lượng Đầu Sách Hiện Tại Không Được Để Trống");
                textBoxSoLuongHienTai.Focus();
            }
            else if (textBoxTongSo.Text == "")
            {
                MessageBox.Show("Tổng Số Lượng Đầu Sách Không Được Để Trống");
                textBoxTongSo.Focus();
            }
            else if (textBoxMaKeSach.Text == "")
            {
                MessageBox.Show("Mã Kệ Sách Không Được Để Trống");
                textBoxMaKeSach.Focus();
            }
            else
            {
                if (IsTenDauSach)
                {
                    MessageBox.Show("Tên Đầu Sách không Được Để Nhiều Khoảng Trắng");
                    textBoxTenDauSach.Focus();
                }
                else if (!IsSoLuongHienTai)
                {
                    MessageBox.Show("Số Lượng Đầu Sách Hiện Tại Phải Là Số Nguyên");
                    textBoxSoLuongHienTai.Focus();
                }
                else if (!IsTongSo)
                {
                    MessageBox.Show("Tổng Số Đầu Sách Phải Là 1 Số Nguyên");
                    textBoxTongSo.Focus();
                }
                else if (!IsMaKeSach)
                {
                    MessageBox.Show("Mã Kệ Sách Phải Là 1 Số Nguyên");
                    textBoxMaKeSach.Focus();
                }
                else
                {
                    if (MessageBox.Show("Bạn Có Chắc Chắn Muốn Cập Nhật Lại Đầu Sách Này Không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            textBoxTenDauSach.Text = XoaKiTuTrang(textBoxTenDauSach.Text);

                            dauSachBUS.SuaDauSach(maDauSach, textBoxTenDauSach.Text, Convert.ToInt32(textBoxMaKeSach.Text), Convert.ToInt32(textBoxSoLuongHienTai.Text), Convert.ToInt32(textBoxTongSo.Text));

                            dataGridViewDauSach.DataSource = dauSachBUS.GetDanhSachDauSach();
                            MessageBox.Show("----Thành Công----");
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Thất Bại!");
                        }

                    }
                }
            }
        }

        private void buttonSachThuocDauSach_Click(object sender, EventArgs e)
        {
            MainQuanLy.StaticChangeTab(1);
            QuanLySach.StaticChangeDataSouce(dauSachBUS.GetSachThuocDauSach(maDauSach));
        }

        private void buttonThemTacGia_Click(object sender, EventArgs e)
        {
            MainQuanLy.StaticChangeTab(2);
            QuanLyTacGia.Static_EnableButtonThemVaoDauSach();
        }

        private void buttonThemTheLoai_Click(object sender, EventArgs e)
        {
            MainQuanLy.StaticChangeTab(4);
            QuanLyTheLoai.Static_EnableButtonThemVaoDauSach();
        }

        private void buttonThemNhaXuatBan_Click(object sender, EventArgs e)
        {
            MainQuanLy.StaticChangeTab(3);
            QuanLyTheLoai.Static_EnableButtonThemVaoDauSach();
        }

        private void buttonThemVao_Click(object sender, EventArgs e)
        {
            if(buttonThemVao.Text == "Thêm Vào Kệ Sách")
            {
                //if()
            } 
            else if(buttonThemVao.Text == "Thêm Vào Thể Loại")
            {
                try
                {
                    TheLoaiBUS theLoaiBUS = new TheLoaiBUS();
                    theLoaiBUS.InsertDSTheLoai(maDauSach, QuanLyTheLoai.maTheLoai);
                    dataGridViewDauSach.DataSource = dauSachBUS.GetDanhSachDauSach();
                    MessageBox.Show("Thành Công");
                }
                catch(Exception)
                {
                    MessageBox.Show("Thất Bại");
                }
            }
            else if (buttonThemVao.Text == "Thêm Vào Nhà Xuất Bản")
            {
                try
                {
                    NhaXuatBanBUS nhaXuatBanBUS = new NhaXuatBanBUS();
                    nhaXuatBanBUS.InsertDSNhaXuatBan(maDauSach, QuanLyNhaXuatBan.maNhaXuatBan);
                    dataGridViewDauSach.DataSource = dauSachBUS.GetDanhSachDauSach();
                    MessageBox.Show("Thành Công");
                }
                catch (Exception)
                {
                    MessageBox.Show("Thất Bại");
                }
            }
            else if (buttonThemVao.Text == "Thêm Vào Tác Giả")
            {
                try
                {
                    TacGiaBUS tacGiaBUS = new TacGiaBUS();
                    tacGiaBUS.InsertDSTacGia(maDauSach, QuanLyTacGia.maTacGia);
                    dataGridViewDauSach.DataSource = dauSachBUS.GetDanhSachDauSach();
                    MessageBox.Show("Thành Công");
                }
                catch (Exception)
                {
                    MessageBox.Show("Thất Bại");
                }
            }
        }
    }
}
