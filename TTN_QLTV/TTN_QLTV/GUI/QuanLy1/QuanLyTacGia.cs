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
    public partial class QuanLyTacGia : Form
    {
        private List<DauSach> lds = new List<DauSach>();
        private List<TacGia> ltg = new List<TacGia>();
        private List<TheLoai> ltl = new List<TheLoai>();
        private BUSTacGia busTG = new BUSTacGia();     
        private BUSTheLoai busTL = new BUSTheLoai();
        
        //private int maDauSach;
        public static int maTacGia;
        //private int maTheLoai;
        //private int maNhaXuatBan;
        private static QuanLyTacGia formQuanLyTacGia = null;
        public QuanLyTacGia()
        {
            InitializeComponent();
            formQuanLyTacGia = this;
        }
        public static void Static_EnableButtonThemVaoDauSach()
        {
            if (formQuanLyTacGia != null)
                formQuanLyTacGia.EnableButtonThemVaoDauSach();
        }
        private void EnableButtonThemVaoDauSach()
        {
            buttonThemVaoDauSach.Enabled = true;
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
            buttonThem.Enabled = false;

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
            buttonThem.Enabled = false;
            
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
            buttonThem.Enabled = true;
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
                string ngaySinh = Convert.ToDateTime(textBoxNgaySinh.Text.ToString()).Month.ToString() +
                "/" + Convert.ToDateTime(textBoxNgaySinh.Text.ToString()).Day.ToString() +
                "/" + Convert.ToDateTime(textBoxNgaySinh.Text.ToString()).Year.ToString();
                busTG.AddTacGia(textBoxTenTacGia.Text.ToString(),ngaySinh );
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
                MessageBox.Show("Error");
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            string ngaySinh = Convert.ToDateTime(textBoxNgaySinh.Text.ToString()).Month.ToString() +
                "/" + Convert.ToDateTime(textBoxNgaySinh.Text.ToString()).Day.ToString() +
                "/" + Convert.ToDateTime(textBoxNgaySinh.Text.ToString()).Year.ToString();
            busTG.EditTacGia(ltg[dataGridViewTacGia.CurrentCell.RowIndex].MaTacGia, textBoxTenTacGia.Text.ToString(), ngaySinh);
            ltg = busTG.ConvertTG(busTG.GetDanhSachTacGia());
            dataGridViewTacGia.DataSource = null;
            dataGridViewTacGia.DataSource = ltg;
            SetUpDataGrVTacGia();
        }

        private void buttonThemVaoDauSach_Click(object sender, EventArgs e)
        {
            try
            {
                DauSachBUS dauSachBUS = new DauSachBUS();
                dauSachBUS.ThemTacGiaChoDauSach(QuanLyDauSach.maDauSach, maTacGia);
                MessageBox.Show("---Thành Công---");
            }
            catch (Exception)
            {
                MessageBox.Show("Tác Giả Này Đã Có Trong Đầu Sách");
            }           
        }

        private void buttonThemDauSach_Click(object sender, EventArgs e)
        {
            MainQuanLy.StaticChangeTab(0);
            QuanLyDauSach.Static_VisiableButtonThemVao();
            QuanLyDauSach.Static_ChangeButtonThemVaoText("Thêm Vào Tác Giả");
        }
    }
}
