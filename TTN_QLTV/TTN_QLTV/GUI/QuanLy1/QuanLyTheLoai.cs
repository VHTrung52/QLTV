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
using TTN_QLTV.DTO;
using TTN_QLTV.GUI.QuanLy;

namespace TTN_QLTV.GUI.QuanLy1
{
    public partial class QuanLyTheLoai : Form
    {
        private List<TheLoai> ltl = new List<TheLoai>();
        private List<DauSach> lds = new List<DauSach>();
        private BUSTheLoai busTL = new BUSTheLoai();
        public static int maTheLoai;
        private static QuanLyTheLoai formQuanLyTheLoai = null;
        public QuanLyTheLoai()
        {
            InitializeComponent();
            formQuanLyTheLoai = this;
        }
        public static void Static_EnableButtonThemVaoDauSach()
        {
            if (formQuanLyTheLoai != null)
                formQuanLyTheLoai.EnableButtonThemVaoDauSach();
        }
        private void EnableButtonThemVaoDauSach()
        {
            buttonThemVaoDauSach.Enabled = true;
        }
        private void SetUpDataGrVTheLoai()
        {
            dataGridViewTheLoai.Columns["MaTheLoai"].HeaderText = "Mã Thể Loại";
            dataGridViewTheLoai.Columns["TenTheLoai"].HeaderText = "Tên Thể Loại";
        }
        private void SetUpDataGrVDauSachTL()
        {
            dataGridViewDauSach.Columns["MaDauSach"].HeaderText = "Mã Đầu Sách";
            dataGridViewDauSach.Columns["TenDauSach"].HeaderText = "Tên Đầu Sách";
            dataGridViewDauSach.Columns["MaKeSach"].HeaderText = "Mã Kệ Sách";
            dataGridViewDauSach.Columns["SoLuongHienTai"].HeaderText = "Số Lượng Hiện Tại";
            dataGridViewDauSach.Columns["TongSo"].HeaderText = "Tổng Số";
        }

        private void QuanLyTheLoai_Load(object sender, EventArgs e)
        {
            buttonThemVaoDauSach.Enabled = false;
            buttonThem.Enabled = false;
            ltl = busTL.ConvertTL(busTL.GetDanhSachTheLoai());
            dataGridViewTheLoai.DataSource = null;
            dataGridViewTheLoai.DataSource = ltl;
            SetUpDataGrVTheLoai();
            lds = busTL.ConvertDSTL(busTL.GetDanhSachDSTheLoai(ltl[dataGridViewTheLoai.CurrentCell.RowIndex].MaTheLoai));
            dataGridViewDauSach.DataSource = lds;
            SetUpDataGrVDauSachTL();
            textBoxMaTheLoai.Text = ltl[dataGridViewTheLoai.CurrentCell.RowIndex].MaTheLoai.ToString();
            textBoxTenTheLoai.Text = ltl[dataGridViewTheLoai.CurrentCell.RowIndex].TenTheLoai.ToString();
            dataGridViewDauSach.Columns["TenDauSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            lds = busTL.ConvertDSTL(busTL.GetDanhSachDSTheLoai(ltl[dataGridViewTheLoai.CurrentCell.RowIndex].MaTheLoai));
            dataGridViewDauSach.DataSource = lds;
            SetUpDataGrVDauSachTL();
            textBoxMaTheLoai.Text = ltl[dataGridViewTheLoai.CurrentCell.RowIndex].MaTheLoai.ToString();
            textBoxTenTheLoai.Text = ltl[dataGridViewTheLoai.CurrentCell.RowIndex].TenTheLoai.ToString();
            dataGridViewDauSach.Columns["TenDauSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //Dũng
            DataGridViewRow currentRow = dataGridViewTheLoai.CurrentRow;
            maTheLoai = Convert.ToInt32(currentRow.Cells[0].Value);

        }

        private void dataGridViewTheLoai_TheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonSua.Enabled = true;
            buttonThem.Enabled = false;
            lds = busTL.ConvertDSTL(busTL.GetDanhSachDSTheLoai(ltl[dataGridViewTheLoai.CurrentCell.RowIndex].MaTheLoai));
            dataGridViewDauSach.DataSource = lds;
            SetUpDataGrVDauSachTL();
            textBoxMaTheLoai.Text = ltl[dataGridViewTheLoai.CurrentCell.RowIndex].MaTheLoai.ToString();
            textBoxTenTheLoai.Text = ltl[dataGridViewTheLoai.CurrentCell.RowIndex].TenTheLoai.ToString();
            dataGridViewDauSach.Columns["TenDauSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //Dũng
            DataGridViewRow currentRow = dataGridViewTheLoai.CurrentRow;
            maTheLoai = Convert.ToInt32(currentRow.Cells[0].Value);
        }

        private void buttonTimKiemDauSach_TheLoai_Click(object sender, EventArgs e)
        {
            if (textBoxThongTinDauSach.Text.ToString() != "")
            {
                lds = busTL.ConvertDSTL(busTL.GetDanhSachDSTheLoaifilter(ltl[dataGridViewTheLoai.CurrentCell.RowIndex].MaTheLoai, textBoxThongTinDauSach.Text.ToString()));
            }
            else
            {
                lds = busTL.ConvertDSTL(busTL.GetDanhSachDSTheLoai(ltl[dataGridViewTheLoai.CurrentCell.RowIndex].MaTheLoai));
            }
            dataGridViewDauSach.DataSource = null;
            dataGridViewDauSach.DataSource = lds;
            SetUpDataGrVDauSachTL();
        }

        private void buttonHuy_TheLoai_Click(object sender, EventArgs e)
        {
            buttonSua.Enabled = false;
            buttonThem.Enabled = true;
            textBoxThongTin.Text = "";
            textBoxMaTheLoai.Text = "";
            textBoxTenTheLoai.Text = "";
            textBoxThongTinDauSach.Text = "";
        }

        private void buttonTimKiemTheLoai_TheLoai_Click(object sender, EventArgs e)
        {
            if (textBoxThongTin.Text.ToString() != "")
            {
                ltl = busTL.ConvertTL(busTL.GetDanhSachTheLoaifilter(textBoxThongTin.Text.ToString()));
            }
            else
            {
                ltl = busTL.ConvertTL(busTL.GetDanhSachTheLoai());
            }
            dataGridViewTheLoai.DataSource = null;
            dataGridViewTheLoai.DataSource = ltl;
            SetUpDataGrVTheLoai();
        }

        private void buttonThemTheLoai_TheLoai_Click(object sender, EventArgs e)
        {
            busTL.AddTheLoai(textBoxTenTheLoai.Text.ToString());
            ltl = busTL.ConvertTL(busTL.GetDanhSachTheLoai());
            dataGridViewTheLoai.DataSource = null;
            dataGridViewTheLoai.DataSource = ltl;
            SetUpDataGrVTheLoai();
        }

        private void buttonSuaTheLoai_TheLoai_Click(object sender, EventArgs e)
        {
            busTL.EditTheLoai(ltl[dataGridViewTheLoai.CurrentCell.RowIndex].MaTheLoai, textBoxTenTheLoai.Text.ToString());
            ltl = busTL.ConvertTL(busTL.GetDanhSachTheLoai());
            dataGridViewTheLoai.DataSource = null;
            dataGridViewTheLoai.DataSource = ltl;
            SetUpDataGrVTheLoai();
        }

        private void buttonXoaDauSach_TheLoai_Click(object sender, EventArgs e)
        {
            busTL.DelDauSach_TheLoai(ltl[dataGridViewTheLoai.CurrentCell.RowIndex].MaTheLoai, lds[dataGridViewDauSach.CurrentCell.RowIndex].MaDauSach);
            lds = busTL.ConvertDSTL(busTL.GetDanhSachDSTheLoai(ltl[dataGridViewTheLoai.CurrentCell.RowIndex].MaTheLoai));
            dataGridViewDauSach.DataSource = null;
            dataGridViewDauSach.DataSource = lds;
            textBoxThongTinDauSach.Text = "";
            SetUpDataGrVDauSachTL();
        }

        private void buttonThemVaoDauSach_Click(object sender, EventArgs e)
        {
            try
            {
                DauSachBUS dauSachBUS = new DauSachBUS();
                dauSachBUS.ThemTheLoaiChoDauSach(QuanLyDauSach.maDauSach, maTheLoai);
                MessageBox.Show("---Thành Công---");
            }
            catch (Exception)
            {

                MessageBox.Show("Thể Loại Này Đã Có Trong Đầu Sách");
            }
        }

        private void buttonThemDauSach_Click(object sender, EventArgs e)
        {
            MainQuanLy.StaticChangeTab(0);
            QuanLyDauSach.Static_VisiableButtonThemVao();
            QuanLyDauSach.Static_ChangeButtonThemVaoText("Thêm Vào Thể Loại");
        }
    }
}
