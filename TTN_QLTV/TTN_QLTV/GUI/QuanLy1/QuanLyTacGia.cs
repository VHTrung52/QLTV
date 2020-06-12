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
    public partial class QuanLyTacGia : Form
    {
        private List<DauSach> lds = new List<DauSach>();
        private List<TacGia> ltg = new List<TacGia>();
        
        private List<TheLoai> ltl = new List<TheLoai>();
        private BUSTacGia busTG = new BUSTacGia();
        
        private BUSTheLoai busTL = new BUSTheLoai();
        private int maDauSach;
        private int maTacGia;
        private int maTheLoai;
        private int maNhaXuatBan;
        public QuanLyTacGia()
        {
            InitializeComponent();
        }
        private void SetUpDataGrVTacGia()
        {
            dataGridViewTacGia.Columns["MaTacGia"].HeaderText = "Mã Tác Giả";
            dataGridViewTacGia.Columns["TenTacGia"].HeaderText = "Tên Tác Giả";
            dataGridViewTacGia.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
        }
        private void SetUpDataGrVDauSachTG()
        {
            dataGridViewDauSach.Columns["MaDauSach"].HeaderText = "Mã Đầu Sách";
            dataGridViewDauSach.Columns["TenDauSach"].HeaderText = "Tên Đầu Sách";
            dataGridViewDauSach.Columns["MaKeSach"].HeaderText = "Mã Kệ Sách";
            dataGridViewDauSach.Columns["SoLuongHienTai"].HeaderText = "Số Lượng Hiện Tại";
            dataGridViewDauSach.Columns["TongSo"].HeaderText = "Tổng Số";
        }

        private void QuanLyTacGia_Load(object sender, EventArgs e)
        {
            buttonThemVaoDauSach.Enabled = false;
            ltg = busTG.ConvertTG(busTG.GetDanhSachTacGia());
            dataGridViewTacGia.DataSource = null;
            dataGridViewTacGia.DataSource = ltg;
            SetUpDataGrVTacGia();
        }

        private void buttonXoaDauSach_Click(object sender, EventArgs e)
        {
            busTG.DelDauSach_TacGia(ltg[dataGridViewTacGia.CurrentCell.RowIndex].MaTacGia, lds[dataGridViewDauSach.CurrentCell.RowIndex].MaDauSach);
            dataGridViewDauSach.DataSource = null;
            lds = busTG.ConvertDSTG(busTG.GetDanhSachDSTacGia(ltg[dataGridViewTacGia.CurrentCell.RowIndex].MaTacGia));
            dataGridViewDauSach.DataSource = lds;
            SetUpDataGrVDauSachTG();
        }

        private void buttonTimKiemDauSach_Click(object sender, EventArgs e)
        {
            if (textBoxThongTinDauSach.Text != "")
            {
                lds = busTG.ConvertDSTG(busTG.GetDanhSachDSTacGiafilter(ltg[dataGridViewTacGia.CurrentCell.RowIndex].MaTacGia, textBoxThongTinDauSach.Text));
            }
            else
            {
                lds = busTG.ConvertDSTG(busTG.GetDanhSachDSTacGia(ltg[dataGridViewTacGia.CurrentCell.RowIndex].MaTacGia));
            }
            dataGridViewDauSach.DataSource = null;
            dataGridViewDauSach.DataSource = lds;
            SetUpDataGrVDauSachTG();
        }

        private void dataGridViewTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonSua.Enabled = true;
            buttonHuy.Enabled = true;
            buttonTimKiemDauSach.Enabled = true;
            buttonThem.Enabled = false;
            buttonThemDauSach.Enabled = true;
            //buttonTimKiemTacGia_TacGia.Enabled = false;
            lds = busTG.ConvertDSTG(busTG.GetDanhSachDSTacGia(ltg[dataGridViewTacGia.CurrentCell.RowIndex].MaTacGia));
            dataGridViewDauSach.DataSource = lds;
            SetUpDataGrVDauSachTG();
            textBoxMaTacGia.Text = ltg[dataGridViewTacGia.CurrentCell.RowIndex].MaTacGia.ToString();
            textBoxTenTacGia.Text = ltg[dataGridViewTacGia.CurrentCell.RowIndex].TenTacGia;
            textBoxNgaySinh.Text = ltg[dataGridViewTacGia.CurrentCell.RowIndex].NgaySinh.ToShortDateString();
            dataGridViewDauSach.Columns["TenDauSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //Dũng
            DataGridViewRow currentRow = dataGridViewTacGia.CurrentRow;
            maTacGia = Convert.ToInt32(currentRow.Cells[0].Value);
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            buttonSua.Enabled = false;
            buttonTimKiemDauSach.Enabled = false;
            buttonHuy.Enabled = false;
            buttonThemDauSach.Enabled = false;
            buttonXoaDauSach.Enabled = false;
            buttonThem.Enabled = true;
            buttonTimKiemTacGia.Enabled = true;
            dataGridViewDauSach.DataSource = null;
            textBoxMaTacGia.Text = "";
            textBoxTenTacGia.Text = "";
            textBoxNgaySinh.Text = "";
            textBoxThongTinDauSach.Text = "";
            textBoxThongTinTacGia.Text = "";
        }

        private void buttonTimKiemTacGia_Click(object sender, EventArgs e)
        {
            if (textBoxThongTinTacGia.Text.ToString() != "")
            {
                ltg = busTG.ConvertTG(busTG.GetDanhSachTacGiafilter(textBoxThongTinTacGia.Text.ToString()));
            }
            else
            {
                ltg = busTG.ConvertTG(busTG.GetDanhSachTacGia());
            }
            dataGridViewTacGia.DataSource = null;
            dataGridViewTacGia.DataSource = ltg;
            SetUpDataGrVTacGia();
            textBoxThongTinDauSach.Text = "";
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            try
            {
                busTG.AddTacGia(textBoxTenTacGia.Text.ToString(), textBoxNgaySinh.Text.ToString());
                ltg = busTG.ConvertTG(busTG.GetDanhSachTacGia());
                dataGridViewTacGia.DataSource = null;
                dataGridViewTacGia.DataSource = ltg;
                SetUpDataGrVTacGia();
                textBoxMaTacGia.Text = "";
                textBoxTenTacGia.Text = "";
                textBoxNgaySinh.Text = "";
            }
            catch
            {
                MessageBox.Show("Nhập sai ngày tháng năm!");
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            busTG.EditTacGia(ltg[dataGridViewTacGia.CurrentCell.RowIndex].MaTacGia, textBoxTenTacGia.Text.ToString(), textBoxNgaySinh.Text.ToString());
            ltg = busTG.ConvertTG(busTG.GetDanhSachTacGia());
            dataGridViewTacGia.DataSource = null;
            dataGridViewTacGia.DataSource = ltg;
            SetUpDataGrVTacGia();
        }
    }
}
