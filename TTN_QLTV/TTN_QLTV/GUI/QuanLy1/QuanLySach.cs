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
using TTN_QLTV.DTO;
using TTN_QLTV.GUI.QuanLy;

namespace TTN_QLTV.GUI.QuanLy1
{
    public partial class QuanLySach : Form
    {
        private static QuanLySach formQuanLySach = null;
        public QuanLySach()
        {
            InitializeComponent();
            formQuanLySach = this;
        }
        public static void Static_EnableButtonThemVaoPhieuMuon()
        {
            if(formQuanLySach != null)
            {
                formQuanLySach.EnableButtonThemVaoPhieuMuon();
            }    
        }
        private void EnableButtonThemVaoPhieuMuon()
        {
            buttonThemVaoPhieuMuon.Enabled = true;
        }
        public static void StaticChangeDataSouce(DataTable dataTable)
        {
            if (formQuanLySach != null)
            {
                formQuanLySach.ChangeDataSouce(dataTable);
            }
        }
        private void ChangeDataSouce(DataTable dataTable)
        {
            dataGridViewSach.DataSource = dataTable;
        }
        DauSachBUS dauSachBUS = new DauSachBUS();
        private int sach_MaSach;
        private void QuanLySach_Load(object sender, EventArgs e)
        {
            buttonThem.Enabled = false;
            buttonThemVaoPhieuMuon.Enabled = false;
            dataGridViewSach.DataSource = dauSachBUS.GetTatCaSach();
            dataGridViewDauSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            dataGridViewSach.Columns["TenSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewSach.Columns[0].HeaderText = "Mã Sách";
            dataGridViewSach.Columns[1].HeaderText = "Mã Đầu Sách";
            dataGridViewSach.Columns[2].HeaderText = "Tên Sách";
            dataGridViewSach.Columns[3].HeaderText = "Tình Trạng";
            DataGridViewRow row = dataGridViewSach.CurrentRow;

            if (!string.IsNullOrEmpty(row.Cells[0].Value.ToString()) && !string.IsNullOrEmpty(row.Cells[1].Value.ToString()))
            {
                textBoxMaSach.Text = row.Cells[0].Value.ToString();
                textBoxMaDauSach.Text = row.Cells[1].Value.ToString();
                textBoxTenSach.Text = row.Cells[2].Value.ToString();
                checkBoxTinhTrang.Checked = (bool)row.Cells[3].Value;
                sach_MaSach = Convert.ToInt32(row.Cells[0].Value);

                dataGridViewDauSach.DataSource = dauSachBUS.DauSach_Sach(Convert.ToInt32(row.Cells[1].Value));
                dataGridViewDauSach.Columns[0].HeaderText = "Mã Đầu Sách";
                dataGridViewDauSach.Columns[1].HeaderText = "Tên Đầu Sách";
                dataGridViewDauSach.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridViewDauSach.Columns[2].HeaderText = "Mã Kệ Sách";
                dataGridViewDauSach.Columns[3].HeaderText = "Số Lượng Hiện Tại";
                dataGridViewDauSach.Columns[4].HeaderText = "Tổng Số";
            }
        }

        private void dataGridViewSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonThem.Enabled = false;
            buttonXoa.Enabled = true;
            buttonSua.Enabled = true;
            DataGridViewRow row = dataGridViewSach.CurrentRow;

            if (!string.IsNullOrEmpty(row.Cells[0].Value.ToString()) && !string.IsNullOrEmpty(row.Cells[1].Value.ToString()))
            {
                textBoxMaSach.Text = row.Cells[0].Value.ToString();
                textBoxMaDauSach.Text = row.Cells[1].Value.ToString();
                textBoxTenSach.Text = row.Cells[2].Value.ToString();
                checkBoxTinhTrang.Checked = (bool)row.Cells[3].Value;
                sach_MaSach = Convert.ToInt32(row.Cells[0].Value);

                dataGridViewDauSach.DataSource = dauSachBUS.DauSach_Sach(Convert.ToInt32(row.Cells[1].Value));
                dataGridViewDauSach.Columns[0].HeaderText = "Mã Đầu Sách";
                dataGridViewDauSach.Columns[1].HeaderText = "Tên Đầu Sách";
                dataGridViewDauSach.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                
                dataGridViewDauSach.Columns[2].HeaderText = "Mã Kệ Sách";
                dataGridViewDauSach.Columns[3].HeaderText = "Số Lượng Hiện Tại";
                dataGridViewDauSach.Columns[4].HeaderText = "Tổng Số";
            }
        }

        private void buttonTimKiemSach_Click(object sender, EventArgs e)
        {
            dataGridViewSach.DataSource = dauSachBUS.TimKiemSach(textBoxTimKiem.Text);
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            bool IsTenSach = Regex.IsMatch(textBoxTenSach.Text, @"^\s");

            textBoxTenSach.Text = textBoxTenSach.Text.Trim();


            if (textBoxTenSach.Text == "")
            {
                MessageBox.Show("Tên Sách Không Được Để Trống!");
                textBoxTenSach.Focus();
            }
            else
            {
                if (IsTenSach)
                {
                    MessageBox.Show("Tên Sách không Được Để Nhiều Khoảng Trắng");
                    textBoxTenSach.Focus();
                }
                else
                {
                    if (MessageBox.Show("Bạn Có Chắc Chắn Muốn Thêm Sách Này Không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            textBoxTenSach.Text = XoaKiTuTrang(textBoxTenSach.Text);

                            dauSachBUS.ThemSach_Sach(Convert.ToInt32(textBoxMaDauSach.Text), textBoxTenSach.Text, false);

                            dataGridViewSach.DataSource = dauSachBUS.GetTatCaSach();

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

        private void buttonSua_Click(object sender, EventArgs e)
        {
            bool IsTenSach = Regex.IsMatch(textBoxTenSach.Text, @"^\s");
            bool IsMaDauSach = Regex.IsMatch(textBoxMaDauSach.Text, @"\d");

            textBoxTenSach.Text = textBoxTenSach.Text.Trim();
            textBoxMaDauSach.Text = textBoxMaDauSach.Text.Trim();


            if (textBoxTenSach.Text == "")
            {
                MessageBox.Show("Tên Sách Không Được Để Trống!");
                textBoxTenSach.Focus();
            }
            else if (textBoxMaDauSach.Text == "")
            {
                MessageBox.Show("Mã Đầu Sách Không Được Để Trống");
                textBoxMaDauSach.Focus();
            }
            else
            {
                if (IsTenSach)
                {
                    MessageBox.Show("Tên Sách không Được Để Nhiều Khoảng Trắng");
                    textBoxTenSach.Focus();
                }
                else if (!IsMaDauSach)
                {
                    MessageBox.Show("Mã Đầu Sách Phải Là Số Nguyên");
                    textBoxMaDauSach.Focus();
                }
                else
                {
                    if (MessageBox.Show("Bạn Có Chắc Chắn Muốn Sửa Thông Tin Sách Này Không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            textBoxTenSach.Text = XoaKiTuTrang(textBoxTenSach.Text);

                            dauSachBUS.SuaSach_Sach(Convert.ToInt32(textBoxMaSach.Text), Convert.ToInt32(textBoxMaDauSach.Text), textBoxTenSach.Text, checkBoxTinhTrang.Checked);

                            dataGridViewSach.DataSource = dauSachBUS.GetTatCaSach();

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

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            textBoxMaSach.Text = "";
            textBoxMaDauSach.Text = "";
            textBoxTenSach.Text = "";
            checkBoxTinhTrang.Checked = false;
            buttonThem.Enabled = true;
            buttonSua.Enabled = false;
            buttonXoa.Enabled = false;
            dataGridViewDauSach.DataSource = dauSachBUS.XemTatCaDauSach();
            dataGridViewSach.CurrentRow.Selected = false;
            dataGridViewDauSach.Columns[0].HeaderText = "Mã Đầu Sách";
            dataGridViewDauSach.Columns[1].HeaderText = "Tên Đầu Sách";
            dataGridViewDauSach.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewDauSach.Columns[2].HeaderText = "Mã Kệ Sách";
            dataGridViewDauSach.Columns[3].HeaderText = "Số Lượng Hiện Tại";
            //dataGridViewDauSach.Columns[4].HeaderText = "Tổng Số";
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                dauSachBUS.XoaSach_Sach(Convert.ToInt32(textBoxMaSach.Text));

                dataGridViewSach.DataSource = dauSachBUS.GetTatCaSach();

                MessageBox.Show("----Thành Công----");
            }
            catch (Exception)
            {

                MessageBox.Show("Thất Bại!");
            }
        }

        private void buttonThemDauSach_Click(object sender, EventArgs e)
        {

        }

        private void buttonXoaDauSach_Click(object sender, EventArgs e)
        {
            dauSachBUS.XoaDauSachChoSach(sach_MaSach);
            dataGridViewSach.DataSource = dauSachBUS.GetTatCaSach();
            MessageBox.Show("--Xóa đầu sách thành công--");
        }

        private void buttonThemVaoPhieuMuon_Click(object sender, EventArgs e)
        {
            int maSach = Convert.ToInt32(dataGridViewSach.CurrentRow.Cells[0].Value.ToString());
            try
            {
                SachBUS sachBUS = new SachBUS();
                sachBUS.ThemSachVaoPhieuMuon(maSach, QuanLyPhieuMuon.maPhieuMuon);
                MessageBox.Show("Thành công");
                dataGridViewSach.DataSource = dauSachBUS.GetTatCaSach();
                dataGridViewDauSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dataGridViewSach.Columns["TenSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridViewSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dataGridViewSach.Columns[0].HeaderText = "Mã Sách";
                dataGridViewSach.Columns[1].HeaderText = "Mã Đầu Sách";
                dataGridViewSach.Columns[2].HeaderText = "Tên Sách";
                dataGridViewSach.Columns[3].HeaderText = "Tình Trạng";
            }
            catch(Exception)
            {
                MessageBox.Show("Sách đã được mượn");
            }
        }

        private void dataGridViewDauSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*DataGridViewRow dr = null;
            dr = */
            if(buttonSua.Enabled == false)
            {
                textBoxMaDauSach.Text = dataGridViewDauSach.CurrentRow.Cells[0].Value.ToString();
            }

        }
    }
}
