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
    public partial class QuanLyNhaXuatBan : Form
    {
        private List<DauSach> lds = new List<DauSach>();
        private List<NhaXuatBan> lnxb = new List<NhaXuatBan>();
        private BUSNXB busNXB = new BUSNXB();
        public static int maNhaXuatBan;
        private static QuanLyNhaXuatBan formQuanLyNhaXuatBan = null;
        public QuanLyNhaXuatBan()
        {
            InitializeComponent();
            formQuanLyNhaXuatBan = this;
        }
        public static void Static_EnableButtonThemVaoDauSach()
        {
            if (formQuanLyNhaXuatBan != null)
                formQuanLyNhaXuatBan.EnableButtonThemVaoDauSach();
        }
        private void EnableButtonThemVaoDauSach()
        {
            buttonThemVaoDauSach.Enabled = true;
        }
        private void SetUpDataGrVNXB()
        {
            dataGridViewNhaXuatBan.Columns["MaNhaXuatBan"].HeaderText = "Mã Nhà Xuất Bản";
            dataGridViewNhaXuatBan.Columns["TenNhaXuatBan"].HeaderText = "Tên Nhà Xuất Bản";
        }
        private void SetUpDataGrVDauSachNXB()
        {
            dataGridViewDauSach.Columns["MaDauSach"].HeaderText = "Mã Đầu Sách";
            dataGridViewDauSach.Columns["TenDauSach"].HeaderText = "Tên Đầu Sách";
            dataGridViewDauSach.Columns["MaKeSach"].HeaderText = "Mã Kệ Sách";
            dataGridViewDauSach.Columns["SoLuongHienTai"].HeaderText = "Số Lượng Hiện Tại";
            dataGridViewDauSach.Columns["TongSo"].HeaderText = "Tổng Số";
        }

        private void dataGridViewNhaXuatBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonThem.Enabled = false;
            buttonSua.Enabled = true;
            lds = busNXB.ConvertDSNXB(busNXB.GetDanhSachDSNXB(lnxb[dataGridViewNhaXuatBan.CurrentCell.RowIndex].MaNhaXuatBan));
            dataGridViewDauSach.DataSource = lds;
            SetUpDataGrVDauSachNXB();
            textBoxMaNhaXuatBan.Text = lnxb[dataGridViewNhaXuatBan.CurrentCell.RowIndex].MaNhaXuatBan.ToString();
            textBoxTenNhaXuatBan.Text = lnxb[dataGridViewNhaXuatBan.CurrentCell.RowIndex].TenNhaXuatBan.ToString();
            dataGridViewDauSach.Columns["TenDauSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dũng
            DataGridViewRow currentRow = dataGridViewNhaXuatBan.CurrentRow;
            maNhaXuatBan = Convert.ToInt32(currentRow.Cells[0].Value);
        }

        private void QuanLyNhaXuatBan_Load(object sender, EventArgs e)
        {
            buttonThem.Enabled = false;
            buttonThemVaoDauSach.Enabled = false;
            lnxb = busNXB.ConvertNXB(busNXB.GetDanhSachNXB());
            dataGridViewNhaXuatBan.DataSource = null;
            dataGridViewNhaXuatBan.DataSource = lnxb;
            SetUpDataGrVNXB();
            lds = busNXB.ConvertDSNXB(busNXB.GetDanhSachDSNXB(lnxb[dataGridViewNhaXuatBan.CurrentCell.RowIndex].MaNhaXuatBan));
            dataGridViewDauSach.DataSource = lds;
            SetUpDataGrVDauSachNXB();
            textBoxMaNhaXuatBan.Text = lnxb[dataGridViewNhaXuatBan.CurrentCell.RowIndex].MaNhaXuatBan.ToString();
            textBoxTenNhaXuatBan.Text = lnxb[dataGridViewNhaXuatBan.CurrentCell.RowIndex].TenNhaXuatBan.ToString();
            dataGridViewDauSach.Columns["TenDauSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dũng
            DataGridViewRow currentRow = dataGridViewNhaXuatBan.CurrentRow;
            maNhaXuatBan = Convert.ToInt32(currentRow.Cells[0].Value);
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {  
            buttonSua.Enabled = false;
            buttonThem.Enabled = true;
            textBoxThongTin.Text = "";
            textBoxMaNhaXuatBan.Text = "";
            textBoxTenNhaXuatBan.Text = "";
            textBoxThongTinDauSach.Text = "";
        }

        private void buttonTimKiemDauSach_Click(object sender, EventArgs e)
        {
            if (textBoxThongTinDauSach.Text.ToString() != "")
            {
                lds = busNXB.ConvertDSNXB(busNXB.GetDanhSachDSNXBfilter(lnxb[dataGridViewNhaXuatBan.CurrentCell.RowIndex].MaNhaXuatBan, textBoxThongTinDauSach.Text.ToString()));
            }
            else
            {
                lds = busNXB.ConvertDSNXB(busNXB.GetDanhSachDSNXB(lnxb[dataGridViewNhaXuatBan.CurrentCell.RowIndex].MaNhaXuatBan));
            }
            dataGridViewDauSach.DataSource = null;
            dataGridViewDauSach.DataSource = lds;
             
            SetUpDataGrVDauSachNXB();
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            if (textBoxThongTin.Text.ToString() != "")
            {
                lnxb = busNXB.ConvertNXB(busNXB.GetDanhSachNXBfilter(textBoxThongTin.Text.ToString()));
            }
            else
            {
                lnxb = busNXB.ConvertNXB(busNXB.GetDanhSachNXB());
            }
            dataGridViewNhaXuatBan.DataSource = null;
            dataGridViewNhaXuatBan.DataSource = lnxb;
            SetUpDataGrVNXB();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            busNXB.AddNXB(textBoxTenNhaXuatBan.Text.ToString());
            lnxb = busNXB.ConvertNXB(busNXB.GetDanhSachNXB());
            dataGridViewNhaXuatBan.DataSource = null;
            dataGridViewNhaXuatBan.DataSource = lnxb;
            SetUpDataGrVNXB();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            busNXB.EditNXB(lnxb[dataGridViewNhaXuatBan.CurrentCell.RowIndex].MaNhaXuatBan, textBoxTenNhaXuatBan.Text.ToString());
            lnxb = busNXB.ConvertNXB(busNXB.GetDanhSachNXB());
            dataGridViewNhaXuatBan.DataSource = null;
            dataGridViewNhaXuatBan.DataSource = lnxb;
            SetUpDataGrVNXB();
        }

        private void buttonXoaDauSach_Click(object sender, EventArgs e)
        {
            busNXB.DelDauSach_NXB(lnxb[dataGridViewNhaXuatBan.CurrentCell.RowIndex].MaNhaXuatBan, lds[dataGridViewDauSach.CurrentCell.RowIndex].MaDauSach);
            lnxb = busNXB.ConvertNXB(busNXB.GetDanhSachNXB());
            dataGridViewNhaXuatBan.DataSource = null;
            dataGridViewNhaXuatBan.DataSource = lnxb;
            SetUpDataGrVDauSachNXB();
        }

        private void buttonThemVaoDauSach_Click(object sender, EventArgs e)
        {
            try
            {
                DauSachBUS dauSachBUS = new DauSachBUS();
                dauSachBUS.ThemNhaXuatBanChoDauSach(QuanLyDauSach.maDauSach, maNhaXuatBan);
                MessageBox.Show("---Thành Công---");
            }
            catch (Exception)
            {

                MessageBox.Show("Nhà xuất Bản Này Đã Có Trong Đầu Sách");
            }
        }

        private void buttonThemDauSach_Click(object sender, EventArgs e)
        {
            MainQuanLy.StaticChangeTab(0);
            QuanLyDauSach.Static_VisiableButtonThemVao();
            QuanLyDauSach.Static_ChangeButtonThemVaoText("Thêm Vào Nhà Xuất Bản");
        }
    }
}
