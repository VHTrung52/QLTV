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

namespace TTN_QLTV.GUI.QuanLy1
{
    public partial class QuanLyTheLoai : Form
    {
        private List<TheLoai> ltl = new List<TheLoai>();
        private List<DauSach> lds = new List<DauSach>();
        private BUSTheLoai busTL = new BUSTheLoai();
        private int maTheLoai;
        public QuanLyTheLoai()
        {
            InitializeComponent();
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
            buttonThemVaoDauSach.Visible = false;
            ltl = busTL.ConvertTL(busTL.GetDanhSachTheLoai());
            dataGridViewTheLoai.DataSource = null;
            dataGridViewTheLoai.DataSource = ltl;
            SetUpDataGrVTheLoai();
            buttonXoaDauSach.Enabled = true;
        }

        private void dataGridViewTheLoai_TheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonHuy.Enabled = true;
            buttonSua.Enabled = true;
            buttonTimKiemDauSach.Enabled = true;
            buttonThemDauSach.Enabled = true;
            //buttonTimKiemTheLoai_TheLoai.Enabled = false;
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
            textBoxThongTinDauSach.Text = "";
            SetUpDataGrVDauSachTL();
        }

        private void buttonHuy_TheLoai_Click(object sender, EventArgs e)
        {
            buttonHuy.Enabled = false;
            buttonSua.Enabled = false;
            buttonTimKiemDauSach.Enabled = false;
            buttonThemDauSach.Enabled = false;
            buttonThem.Enabled = true;
            buttonTimKiem.Enabled = true;
            buttonXoaDauSach.Enabled = false;
            
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
    }
}
