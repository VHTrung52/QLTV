using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTN_QLTV.BUS;
using TTN_QLTV.GUI.QuanLy;

namespace TTN_QLTV.GUI.QuanLy1
{
    public partial class QuanLyKeSach : Form
    {
        private KeSachBus keSachBUS = new KeSachBus();
        private DauSachBUS dauSachBUS = new DauSachBUS();
        public static int MaKeSach;
        public QuanLyKeSach()
        {
            InitializeComponent();
        }
        private void changeDataGridViewHeader_tabKeSach()
        {
            dataGridViewKeSach.Columns["TenKeSach"].HeaderText = "Tên Kệ Sách";
            dataGridViewKeSach.Columns["MaKeSach"].HeaderText = "Mã Kệ Sách";
            dataGridViewDauSach.Columns[0].HeaderText = "Mã Đầu Sách";
            dataGridViewDauSach.Columns[1].HeaderText = "Tên Đầu Sách";
            dataGridViewDauSach.Columns[2].HeaderText = "Mã Kệ Sách";
            dataGridViewDauSach.Columns[3].HeaderText = "Số Lượng Hiện Tại";
            dataGridViewDauSach.Columns[4].HeaderText = "Tổng Số";
        }

        private void QuanLyKeSach_Load(object sender, EventArgs e)
        {
            buttonThem.Enabled = false;
            dataGridViewKeSach.DataSource = keSachBUS.XemTatCaKeSach();
            dataGridViewDauSach.DataSource = dauSachBUS.XemTatCaDauSachKeSach(dataGridViewKeSach.Rows[0].Cells[0].Value.ToString());
            changeDataGridViewHeader_tabKeSach();
            MaKeSach = Convert.ToInt32(dataGridViewKeSach.Rows[0].Cells[0].Value);
            textBoxMaKeSach.Text = dataGridViewKeSach.CurrentRow.Cells[0].Value.ToString();
            textBoxTenKeSach.Text = dataGridViewKeSach.CurrentRow.Cells[1].Value.ToString();
        }

        private void buttonXoaDauSach_Click(object sender, EventArgs e)
        {
            keSachBUS.BoSach(dataGridViewDauSach.CurrentRow.Cells[0].Value.ToString());
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            keSachBUS.SuaKeSach(dataGridViewKeSach.CurrentRow.Cells[0].Value.ToString(), dataGridViewKeSach.CurrentRow.Cells[1].Value.ToString());
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            keSachBUS.ThemKeSach(textBoxTenKeSach.Text = dataGridViewKeSach.CurrentRow.Cells[1].Value.ToString());
            dataGridViewKeSach.DataSource = keSachBUS.XemTatCaKeSach();
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            buttonSua.Enabled = false;
            buttonThem.Enabled = true;
            textBoxMaKeSach.Text = "";
            textBoxTenKeSach.Text = "";
        }

        private void buttonTimKiemKeSach_Click(object sender, EventArgs e)
        {
            if (textBoxThongTinKeSach.Text.ToString() != "")
            {
                dataGridViewKeSach.DataSource = keSachBUS.TimKeSach(textBoxThongTinKeSach.Text);
            }
            else
            {
                dataGridViewKeSach.DataSource = keSachBUS.XemTatCaKeSach();
            }
        }

        private void dataGridViewKeSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewDauSach.DataSource = dauSachBUS.XemTatCaDauSachKeSach(dataGridViewKeSach.CurrentRow.Cells[0].Value.ToString());
            buttonThem.Enabled = false;
            buttonSua.Enabled = true;
            textBoxMaKeSach.Text = dataGridViewKeSach.CurrentRow.Cells[0].Value.ToString();
            textBoxTenKeSach.Text = dataGridViewKeSach.CurrentRow.Cells[1].Value.ToString();
            dataGridViewDauSach.Columns["TenDauSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Nam
            MaKeSach = Convert.ToInt32(dataGridViewKeSach.CurrentRow.Cells[0].Value.ToString());
            //Trung
        }

        private void buttonThemDauSach_Click(object sender, EventArgs e)
        {
            MainQuanLy.StaticChangeTab(0);
            QuanLyDauSach.Static_VisiableButtonThemVao();
            QuanLyDauSach.Static_ChangeButtonThemVaoText("Thêm Vào Kệ Sách");
        }

        private void buttonTimKiemDauSach_Click(object sender, EventArgs e)
        {
            if(textBoxThongTinDauSach.Text != "")
                dataGridViewDauSach.DataSource = keSachBUS.TimKiemDauSachThuocKeSach(MaKeSach, textBoxThongTinDauSach.Text);
            else
                dataGridViewDauSach.DataSource = dauSachBUS.XemTatCaDauSachKeSach(dataGridViewKeSach.CurrentRow.Cells[0].Value.ToString());
        }
    }
}
