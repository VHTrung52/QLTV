using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTN_QLTV.DTO;
using TTN_QLTV.BUS;

namespace TTN_QLTV.GUI
{
    public partial class QuanLySach : Form
    {
        private List<DauSach> lds = new List<DauSach>();
        private List<TacGia> ltg = new List<TacGia>();
        private List<NhaXuatBan> lnxb = new List<NhaXuatBan>();
        private List<TheLoai> ltl = new List<TheLoai>();

        private BUSTacGia busTG = new BUSTacGia();
        private BUSNXB busNXB = new BUSNXB();
        private BUSTheLoai busTL = new BUSTheLoai();
        public QuanLySach()
        {
            InitializeComponent();
        }
        public static string tabName;
        private void QuanLySach_Load(object sender, EventArgs e)
        {
            if(tabName == "sach")
            {
                tabControlQuanLySach.SelectedTab = tabPageSach;
                buttonThemVaoPhieuMuon_Sach.Visible = true;
            }
        }
        // BẮT ĐẦU TAB ĐẦU SÁCH //
        // quy trình

        // hiện thông tin
        //1 - datagrid đầu sách hiện tất cả sách, các datagrid còn lại trống
        //2 - chọn 1 đầu sách trong datagridview
        //3 - các datagird view còn lại hiện thông tin của sách đó
        //4 - các thông tin khác hiện trên các textbox
        // thêm : 
        //1 - thêm 1 đầu sách với các textbox cơ bản 
        //1.1-viết 1 hàm tử động tạo mã mới để thêm
        //2 - ấn nút thêm , refresh datagrid view đầu sách
        //3 - chọn đầu sách vừa thêm để thêm tác giả, thể loại , nhà xuất bản bằng các button
        

        private void buttonSachThuoc_DauSach_Click(object sender, EventArgs e)
        {
            // chọn 1 đầu sách ở datagrid đầu sách và ấn Sách thuộc đầu sách
            //chuyển sang tab sach và hiện tất cả sách thuộc đầu sách vừa chọn ở datagrid sách
            // không hiện nút thêm vào
            tabControlQuanLySach.SelectedTab = tabPageSach;
            buttonThemVaoPhieuMuon_Sach.Visible = false;
        }
        private void buttonTimKiem_DauSach_Click(object sender, EventArgs e)
        {
            //Tìm kiếm đầu sách trả về kết quả ở datagird view DauSach ben duoi
            //tìm kiếm dựa trên text box thông tin đâù sách và combo box loại thông tin
            //trong loại thông tin có các tiêu chí để tìm kiếm theo
        }

        private void tabPageDauSach_Enter(object sender, EventArgs e)
        {
            //datagrid đầu sách hiện tất cả các sách
            //nút thêm vào visible = false;
            buttonThemVao_DauSach.Visible = false;
        }

        private void buttonThemTacGia_DauSach_Click(object sender, EventArgs e)
        {
            //chọn 1 đầu sách và chọn thêm tác giả
            //chuyển sang tab tác giả và hiện nút thêm vào đầu sách
            //chọn 1 tác giả xong ấn thêm vào đầu sách để thêm 
            //thêm vào bảng ds_tacgia
            tabControlQuanLySach.SelectedTab = tabPageTacGia;
            buttonThemVaoDauSach_TacGia.Visible = true;
        }
        private void buttonXoaTacGia_DauSach_Click(object sender, EventArgs e)
        {
            //Chọn 1 tác giả trong datagrid view ở trên xong chọn xoá 
            //xoá khỏi bảng ds_tacgia
        }
        private void buttonThemTheLoai_DauSach_Click(object sender, EventArgs e)
        {
            //chọn 1 đầu sách và chọn thêm thể loại
            //chuyển sang tab thể loại và hiện nút thêm vào đầu sách
            //chọn 1 thể loại xong ấn thêm vào đầu sách để thêm 
            //thêm vào bảng ds_theloai
            // ví dụ ở trên
        }
        private void buttonXoaTheLoai_DauSach_Click(object sender, EventArgs e)
        {
            //Chọn 1 thể loại trong datagrid view ở trên xong chọn xoá 
            //xoá khỏi bảng ds_theloai
        }
        private void buttonThemNhaXuatBan_DauSach_Click(object sender, EventArgs e)
        {
            //chọn 1 đầu sách và chọn thêm nha xuat ban
            //chuyển sang tab nha xuat ban và hiện nút thêm vào đầu sách
            //chọn 1 thể loại xong ấn thêm vào đầu sách để thêm 
            //thêm vào bảng ds_nha xuat ban
            // ví dụ ở trên
        }
        private void buttonXoaNhaXuatBan_DauSach_Click(object sender, EventArgs e)
        {
            //Chọn 1 thể loại trong datagrid view ở trên xong chọn xoá 
            //xoá khỏi bảng ds_theloai
        }
        private void buttonHuyDauSach_DauSach_Click(object sender, EventArgs e)
        {
           
        }
        private void buttonThemVao_DauSach_Click(object sender, EventArgs e)
        {

        }
        // KẾT THÚC TAB ĐẦU SÁCH //



        // BẮT ĐẦU TAB SÁCH //
        private void tabControlQuanLySach_Enter(object sender, EventArgs e)
        {
            buttonThemVaoPhieuMuon_Sach.Visible = false;
        }
        // KẾT THÚC TAB SÁCH //



        // BẮT ĐẦU TAB TÁC GIẢ //
        // 1- chọn 1 tác giả ở datagrid tác giả sẽ hiện các đầu sách của tác giả đó ở 
        // datagrid đầu sách
        private void SetUpDataGrVTacGia()
        {
            dataGridViewTacGia_TacGia.Columns["MaTacGia"].HeaderText = "Mã Tác Giả";
            dataGridViewTacGia_TacGia.Columns["TenTacGia"].HeaderText = "Tên Tác Giả";
            dataGridViewTacGia_TacGia.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
        }
        private void SetUpDataGrVDauSachTG()
        {
            dataGridViewDauSach_TacGia.Columns["MaDauSach"].HeaderText = "Mã Đầu Sách";
            dataGridViewDauSach_TacGia.Columns["TenDauSach"].HeaderText = "Tên Đầu Sách";
            dataGridViewDauSach_TacGia.Columns["MaKeSach"].HeaderText = "Mã Kệ Sách";
            dataGridViewDauSach_TacGia.Columns["SoLuongHienTai"].HeaderText = "Số Lượng Hiện Tại";
            dataGridViewDauSach_TacGia.Columns["TongSo"].HeaderText = "Tổng Số";
        }
        
        private void tabPageTacGia_Enter(object sender, EventArgs e)
        {
            buttonThemVaoDauSach_TacGia.Visible = false;
            ltg = busTG.ConvertTG(busTG.GetDanhSachTacGia());
            dataGridViewTacGia_TacGia.DataSource = null;
            dataGridViewTacGia_TacGia.DataSource = ltg;
            SetUpDataGrVTacGia();
        }
        private void buttonThemDauSach_TacGia_Click(object sender, EventArgs e)
        {
            //chuyển sang tab đầu sách 
            tabControlQuanLySach.SelectedTab = tabPageDauSach;
            //hiện nút themvao_dausach
            buttonThemVao_DauSach.Visible = true;
            //chọn đầu sách ở datagrid đầu sách ấn thêm vào để thêm vào ds_tacgia
        }
        private void buttonXoaDauSach_TacGia_Click(object sender, EventArgs e)
        {
            //chọn 1 đầu sách ở datagrid đầu sách và chọn xoá đầu sách để xoá khỏi ds_tacgia
            busTG.DelDauSach_TacGia(ltg[dataGridViewTacGia_TacGia.CurrentCell.RowIndex].MaTacGia,lds[dataGridViewDauSach_TacGia.CurrentCell.RowIndex].MaDauSach);
            dataGridViewDauSach_TacGia.DataSource = null;
            lds = busTG.ConvertDSTG(busTG.GetDanhSachDSTacGia(ltg[dataGridViewTacGia_TacGia.CurrentCell.RowIndex].MaTacGia));
            dataGridViewDauSach_TacGia.DataSource = lds;
            SetUpDataGrVDauSachTG();
        }
        private void buttonTimKiemDauSach_TacGia_Click(object sender, EventArgs e)
        {
            // 2- tìm kiếm đầu sách chỉ để tìm kiếm trong các đầu sách của tác giả đó 
            // tìm kiếm bằng tên hoặc mã đầu sách
            if(textBoxThongTinDauSach_TacGia.Text != "")
            {
                lds = busTG.ConvertDSTG(busTG.GetDanhSachDSTacGiafilter(ltg[dataGridViewTacGia_TacGia.CurrentCell.RowIndex].MaTacGia, textBoxThongTinDauSach_TacGia.Text));
            }
            else
            {
                lds = busTG.ConvertDSTG(busTG.GetDanhSachDSTacGia(ltg[dataGridViewTacGia_TacGia.CurrentCell.RowIndex].MaTacGia));
            }
            dataGridViewDauSach_TacGia.DataSource = null;
            dataGridViewDauSach_TacGia.DataSource = lds;
            SetUpDataGrVDauSachTG();
        }
        private void dataGridViewTacGia_TacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonSuaTacGia_TacGia.Enabled = true;
            buttonHuyTacGia_TacGia.Enabled = true;
            buttonTimKiemDauSach_TacGia.Enabled = true;
            buttonThemTacGia_TacGia.Enabled = false;
            buttonThemDauSach_TacGia.Enabled = true;
            buttonTimKiemTacGia_TacGia.Enabled = false;
            lds = busTG.ConvertDSTG(busTG.GetDanhSachDSTacGia(ltg[dataGridViewTacGia_TacGia.CurrentCell.RowIndex].MaTacGia));
            dataGridViewDauSach_TacGia.DataSource = lds;
            SetUpDataGrVDauSachTG();
            textBoxMaTacGia_TacGia.Text = ltg[dataGridViewTacGia_TacGia.CurrentCell.RowIndex].MaTacGia.ToString();
            textBoxTenTacGia_TacGia.Text = ltg[dataGridViewTacGia_TacGia.CurrentCell.RowIndex].TenTacGia;
            textBoxNgaySinh_TacGia.Text = ltg[dataGridViewTacGia_TacGia.CurrentCell.RowIndex].NgaySinh.ToString();
        }
        private void buttonHuyTacGia_TacGia_Click(object sender, EventArgs e)
        {
            buttonSuaTacGia_TacGia.Enabled = false;
            buttonTimKiemDauSach_TacGia.Enabled = false;
            buttonHuyTacGia_TacGia.Enabled = false;
            buttonThemDauSach_TacGia.Enabled = false;
            buttonXoaDauSach_TacGia.Enabled = false;
            buttonThemTacGia_TacGia.Enabled = true;
            buttonTimKiemTacGia_TacGia.Enabled = true;
            dataGridViewDauSach_TacGia.DataSource = null;
            textBoxMaTacGia_TacGia.Text = "";
            textBoxTenTacGia_TacGia.Text = "";
            textBoxNgaySinh_TacGia.Text = "";
            textBoxThongTinDauSach_TacGia.Text = "";
            textBoxThongTinTacGia_TacGia.Text = "";
        }
        private void buttonTimKiemTacGia_TacGia_Click(object sender, EventArgs e)
        {
            if(textBoxThongTinTacGia_TacGia.Text.ToString() != null)
            {
                ltg = busTG.ConvertTG(busTG.GetDanhSachTacGiafilter(textBoxThongTinTacGia_TacGia.Text.ToString()));
            }
            else
            {
                ltg = busTG.ConvertTG(busTG.GetDanhSachTacGia());
            }
            dataGridViewTacGia_TacGia.DataSource = null;
            dataGridViewTacGia_TacGia.DataSource = ltg;
            SetUpDataGrVTacGia();
            textBoxThongTinDauSach_TacGia.Text = "";
        }
        private void buttonThemTacGia_TacGia_Click(object sender, EventArgs e)
        {
            try
            {
                string[] str = textBoxNgaySinh_TacGia.Text.ToString().Split('-');
                DateTime date = new DateTime(Convert.ToInt32(str[2]), Convert.ToInt32(str[1]), Convert.ToInt32(str[0]));
                busTG.AddTacGia(textBoxTenTacGia_TacGia.Text.ToString(), textBoxNgaySinh_TacGia.Text.ToString());
                ltg = busTG.ConvertTG(busTG.GetDanhSachTacGia());
                dataGridViewTacGia_TacGia.DataSource = null;
                dataGridViewTacGia_TacGia.DataSource = ltg;
                SetUpDataGrVTacGia();
                textBoxMaTacGia_TacGia.Text = "";
                textBoxTenTacGia_TacGia.Text = "";
                textBoxNgaySinh_TacGia.Text = "";
            }
            catch
            {
                MessageBox.Show("Nhập sai ngày tháng năm!");
            }
        }
        private void dataGridViewDauSach_TacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonXoaDauSach_TacGia.Enabled = true;
        }
        private void textBoxNgaySinh_TacGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '-')
            {
                e.Handled = false;
            }
        }
        private void buttonSuaTacGia_TacGia_Click(object sender, EventArgs e)
        {
            busTG.EditTacGia(ltg[dataGridViewTacGia_TacGia.CurrentCell.RowIndex].MaTacGia, textBoxTenTacGia_TacGia.Text.ToString(), textBoxNgaySinh_TacGia.Text.ToString());
            ltg = busTG.ConvertTG(busTG.GetDanhSachTacGia());
            dataGridViewTacGia_TacGia.DataSource = null;
            dataGridViewTacGia_TacGia.DataSource = ltg;
            SetUpDataGrVTacGia();
        }
        // KẾT THÚC TAB TÁC GIẢ //


        // BẮT ĐẦU TAB NHÀ XUẤT BẢN //
        private void SetUpDataGrVNXB()
        {
            dataGridViewNhaXuatBan_NhaXuatBan.Columns["MaNhaXuatBan"].HeaderText = "Mã Nhà Xuất Bản";
            dataGridViewNhaXuatBan_NhaXuatBan.Columns["TenNhaXuatBan"].HeaderText = "Tên Nhà Xuất Bản";
        }
        private void SetUpDataGrVDauSachNXB()
        {
            dataGridViewDauSach_NhaXuatBan.Columns["MaDauSach"].HeaderText = "Mã Đầu Sách";
            dataGridViewDauSach_NhaXuatBan.Columns["TenDauSach"].HeaderText = "Tên Đầu Sách";
            dataGridViewDauSach_NhaXuatBan.Columns["MaKeSach"].HeaderText = "Mã Kệ Sách";
            dataGridViewDauSach_NhaXuatBan.Columns["SoLuongHienTai"].HeaderText = "Số Lượng Hiện Tại";
            dataGridViewDauSach_NhaXuatBan.Columns["TongSo"].HeaderText = "Tổng Số";
        }
        private void tabPageNhaXuatBan_Enter(object sender, EventArgs e)
        {
            buttonThemVaoDauSach_NhaXuatBan.Visible = false;
            lnxb = busNXB.ConvertNXB(busNXB.GetDanhSachNXB());
            dataGridViewNhaXuatBan_NhaXuatBan.DataSource = null;
            dataGridViewNhaXuatBan_NhaXuatBan.DataSource = lnxb;
            SetUpDataGrVNXB();
        }
        private void dataGridViewNhaXuatBan_NhaXuatBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonThemNhaXuatBan_NhaXuatBan.Enabled = true;
            buttonSuaNhaXuatBan_NhaXuatBan.Enabled = false;
            buttonTimKiemDauSach_NhaXuatBan.Enabled = true;
            buttonHuy_NhaXuatBan.Enabled = true;
            buttonThemNhaXuatBan_NhaXuatBan.Enabled = false;
            buttonThemDauSach_NhaXuatBan.Enabled = true;
            buttonTimKiemNhaXuatBan_NhaXuatBan.Enabled = false;
            lds = busNXB.ConvertDSNXB(busNXB.GetDanhSachDSNXB(lnxb[dataGridViewNhaXuatBan_NhaXuatBan.CurrentCell.RowIndex].MaNhaXuatBan));
            dataGridViewDauSach_NhaXuatBan.DataSource = lds;
            SetUpDataGrVDauSachNXB();
            textBoxMaNhaXuatBan_NhaXuatBan.Text = lnxb[dataGridViewNhaXuatBan_NhaXuatBan.CurrentCell.RowIndex].MaNhaXuatBan.ToString();
            textBoxTenNhaXuatBan_NhaXuatBan.Text = lnxb[dataGridViewNhaXuatBan_NhaXuatBan.CurrentCell.RowIndex].TenNhaXuatBan.ToString();
        }
        private void dataGridViewDauSach_NhaXuatBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonXoaDauSach_NhaXuatBan.Enabled = true;
        }
        private void buttonHuy_NhaXuatBan_Click(object sender, EventArgs e)
        {
            buttonThemNhaXuatBan_NhaXuatBan.Enabled = false;
            buttonSuaNhaXuatBan_NhaXuatBan.Enabled = true;
            buttonTimKiemDauSach_NhaXuatBan.Enabled = false;
            buttonThemNhaXuatBan_NhaXuatBan.Enabled = true;
            buttonHuy_NhaXuatBan.Enabled = false;
            buttonThemDauSach_NhaXuatBan.Enabled = false;
            buttonXoaDauSach_NhaXuatBan.Enabled = false;
            buttonTimKiemNhaXuatBan_NhaXuatBan.Enabled = true;
            dataGridViewDauSach_NhaXuatBan.DataSource = null;
            textBoxThongTinNhaXuatBan_NhaXuatBan.Text = "";
            textBoxMaNhaXuatBan_NhaXuatBan.Text = "";
            textBoxTenNhaXuatBan_NhaXuatBan.Text = "";
            textBoxThongTinDauSach_NhaXuatBan.Text = "";
        }
        private void buttonTimKiemDauSach_NhaXuatBan_Click(object sender, EventArgs e)
        {
            if (textBoxThongTinDauSach_NhaXuatBan.Text.ToString() != "")
            {
                lds = busNXB.ConvertDSNXB(busNXB.GetDanhSachDSNXBfilter(lnxb[dataGridViewNhaXuatBan_NhaXuatBan.CurrentCell.RowIndex].MaNhaXuatBan, textBoxThongTinDauSach_NhaXuatBan.Text.ToString()));
            }
            else
            {
                lds = busNXB.ConvertDSNXB(busNXB.GetDanhSachDSNXB(lnxb[dataGridViewNhaXuatBan_NhaXuatBan.CurrentCell.RowIndex].MaNhaXuatBan));
            }
            dataGridViewDauSach_NhaXuatBan.DataSource = null;
            dataGridViewDauSach_NhaXuatBan.DataSource = lds;
            textBoxThongTinDauSach_NhaXuatBan.Text = "";
            SetUpDataGrVDauSachNXB();
        }
        private void buttonTimKiemNhaXuatBan_NhaXuatBan_Click(object sender, EventArgs e)
        {
            if (textBoxThongTinNhaXuatBan_NhaXuatBan.Text.ToString() != "")
            {
                lnxb = busNXB.ConvertNXB(busNXB.GetDanhSachNXBfilter(textBoxThongTinNhaXuatBan_NhaXuatBan.Text.ToString()));
            }
            else
            {
                lnxb = busNXB.ConvertNXB( busNXB.GetDanhSachNXB());
            }
            dataGridViewNhaXuatBan_NhaXuatBan.DataSource = null;
            dataGridViewNhaXuatBan_NhaXuatBan.DataSource = lnxb;
            SetUpDataGrVNXB();
        }
        private void buttonThemNhaXuatBan_NhaXuatBan_Click(object sender, EventArgs e)
        {
            busNXB.AddNXB(textBoxTenNhaXuatBan_NhaXuatBan.Text.ToString());
            lnxb = busNXB.ConvertNXB(busNXB.GetDanhSachNXB());
            dataGridViewNhaXuatBan_NhaXuatBan.DataSource = null;
            dataGridViewNhaXuatBan_NhaXuatBan.DataSource = lnxb;
            SetUpDataGrVNXB();
        }
        private void buttonSuaNhaXuatBan_NhaXuatBan_Click(object sender, EventArgs e)
        {
            busNXB.EditNXB(lnxb[dataGridViewNhaXuatBan_NhaXuatBan.CurrentCell.RowIndex].MaNhaXuatBan, textBoxTenNhaXuatBan_NhaXuatBan.Text.ToString());
            lnxb = busNXB.ConvertNXB(busNXB.GetDanhSachNXB());
            dataGridViewNhaXuatBan_NhaXuatBan.DataSource = null;
            dataGridViewNhaXuatBan_NhaXuatBan.DataSource = lnxb;
            SetUpDataGrVNXB();
        }
        private void buttonXoaDauSach_NhaXuatBan_Click(object sender, EventArgs e)
        {
            busNXB.DelDauSach_NXB(lnxb[dataGridViewNhaXuatBan_NhaXuatBan.CurrentCell.RowIndex].MaNhaXuatBan,lds[dataGridViewDauSach_NhaXuatBan.CurrentCell.RowIndex].MaDauSach);
            lnxb = busNXB.ConvertNXB(busNXB.GetDanhSachNXB());
            dataGridViewNhaXuatBan_NhaXuatBan.DataSource = null;
            dataGridViewNhaXuatBan_NhaXuatBan.DataSource = lnxb;
            SetUpDataGrVDauSachNXB();
        }
        private void buttonThemDauSach_NhaXuatBan_Click(object sender, EventArgs e)
        {
            //chuyển sang tab đầu sách 
            tabControlQuanLySach.SelectedTab = tabPageDauSach;
            //hiện nút themvao_dausach
            buttonThemVao_DauSach.Visible = true;
            //chọn đầu sách ở datagrid đầu sách ấn thêm vào để thêm vào ds_tacgia
        }

        // KẾT THÚC TAB NHÀ XUẤT BẢN //


        // BẮT ĐẦU TAB THỂ LOẠI //
        private void SetUpDataGrVTheLoai()
        {
            dataGridViewTheLoai_TheLoai.Columns["MaTheLoai"].HeaderText = "Mã Thể Loại";
            dataGridViewTheLoai_TheLoai.Columns["TenTheLoai"].HeaderText = "Tên Thể Loại";
        }
        private void SetUpDataGrVDauSachTL()
        {
            dataGridViewDauSach_TheLoai.Columns["MaDauSach"].HeaderText = "Mã Đầu Sách";
            dataGridViewDauSach_TheLoai.Columns["TenDauSach"].HeaderText = "Tên Đầu Sách";
            dataGridViewDauSach_TheLoai.Columns["MaKeSach"].HeaderText = "Mã Kệ Sách";
            dataGridViewDauSach_TheLoai.Columns["SoLuongHienTai"].HeaderText = "Số Lượng Hiện Tại";
            dataGridViewDauSach_TheLoai.Columns["TongSo"].HeaderText = "Tổng Số";
        }
        private void tabPageTheLoai_Enter(object sender, EventArgs e)
        {
            buttonThemVaoDauSach_TheLoai.Visible = false;
            ltl = busTL.ConvertTL( busTL.GetDanhSachTheLoai());
            dataGridViewTheLoai_TheLoai.DataSource = null;
            dataGridViewTheLoai_TheLoai.DataSource = ltl;
            SetUpDataGrVTheLoai();
        }
        private void dataGridViewTheLoai_TheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonHuy_TheLoai.Enabled = true;
            buttonSuaTheLoai_TheLoai.Enabled = true;
            buttonTimKiemDauSach_TheLoai.Enabled = true;
            buttonThemDauSach_TheLoai.Enabled = true;
            buttonTimKiemTheLoai_TheLoai.Enabled = false;
            buttonThemTheLoai_TheLoai.Enabled = false;
            lds = busTL.ConvertDSTL(busTL.GetDanhSachDSTheLoai(ltl[dataGridViewTheLoai_TheLoai.CurrentCell.RowIndex].MaTheLoai));
            dataGridViewDauSach_TheLoai.DataSource = lds;
            SetUpDataGrVDauSachTL();
            textBoxMaTheLoai_TheLoai.Text = ltl[dataGridViewTheLoai_TheLoai.CurrentCell.RowIndex].MaTheLoai.ToString();
            textBoxTenTheLoai_TheLoai.Text = ltl[dataGridViewTheLoai_TheLoai.CurrentCell.RowIndex].TenTheLoai.ToString();
        }
        private void dataGridViewDauSach_TheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonXoaDauSach_TheLoai.Enabled = true;
        }
        private void buttonTimKiemDauSach_TheLoai_Click(object sender, EventArgs e)
        {
            if (textBoxThongTinDauSach_TheLoai.Text.ToString() != "")
            {
                lds = busTL.ConvertDSTL(busTL.GetDanhSachDSTheLoaifilter(ltl[dataGridViewTheLoai_TheLoai.CurrentCell.RowIndex].MaTheLoai, textBoxThongTinDauSach_TheLoai.Text.ToString()));
            }
            else
            {
                lds = busTL.ConvertDSTL(busTL.GetDanhSachDSTheLoai(ltl[dataGridViewTheLoai_TheLoai.CurrentCell.RowIndex].MaTheLoai));
            }
            dataGridViewDauSach_TheLoai.DataSource = null;
            dataGridViewDauSach_TheLoai.DataSource = lds;
            textBoxThongTinDauSach_TheLoai.Text = "";
            SetUpDataGrVDauSachTL();
        }

        private void buttonHuy_TheLoai_Click(object sender, EventArgs e)
        {
            buttonHuy_TheLoai.Enabled = false;
            buttonSuaTheLoai_TheLoai.Enabled = false;
            buttonTimKiemDauSach_TheLoai.Enabled = false;
            buttonThemDauSach_TheLoai.Enabled = false;
            buttonThemTheLoai_TheLoai.Enabled = true;
            buttonTimKiemTheLoai_TheLoai.Enabled = true;
            buttonXoaDauSach_TheLoai.Enabled = false;
            dataGridViewDauSach_NhaXuatBan.DataSource = null;
            textBoxThongTinTheLoai_TheLoai.Text = "";
            textBoxMaTheLoai_TheLoai.Text = "";
            textBoxTenTheLoai_TheLoai.Text = "";
            textBoxThongTinDauSach_TheLoai.Text = "";
        }

        private void buttonTimKiemTheLoai_TheLoai_Click(object sender, EventArgs e)
        {
            if (textBoxThongTinTheLoai_TheLoai.Text.ToString()!=null)
            {
                ltl = busTL.ConvertTL(busTL.GetDanhSachTheLoaifilter(textBoxThongTinTheLoai_TheLoai.Text.ToString()));
            }
            else
            {
                ltl = busTL.ConvertTL(busTL.GetDanhSachTheLoai());
            }
            dataGridViewTheLoai_TheLoai.DataSource = null;
            dataGridViewTheLoai_TheLoai.DataSource = ltl;
            SetUpDataGrVTheLoai();
        }

        private void buttonThemTheLoai_TheLoai_Click(object sender, EventArgs e)
        {
            busTL.AddTheLoai(textBoxTenTheLoai_TheLoai.Text.ToString());
            ltl = busTL.ConvertTL(busTL.GetDanhSachTheLoai());
            dataGridViewTheLoai_TheLoai.DataSource = null;
            dataGridViewTheLoai_TheLoai.DataSource = ltl;
            SetUpDataGrVTheLoai();
        }

        private void buttonSuaTheLoai_TheLoai_Click(object sender, EventArgs e)
        {
            busTL.EditTheLoai(ltl[dataGridViewTheLoai_TheLoai.CurrentCell.RowIndex].MaTheLoai, textBoxTenTheLoai_TheLoai.Text.ToString());
            ltl = busTL.ConvertTL(busTL.GetDanhSachTheLoai());
            dataGridViewTheLoai_TheLoai.DataSource = null;
            dataGridViewTheLoai_TheLoai.DataSource = ltl;
            SetUpDataGrVTheLoai();
        }

        private void buttonXoaDauSach_TheLoai_Click(object sender, EventArgs e)
        {
            busTL.DelDauSach_TheLoai(ltl[dataGridViewTheLoai_TheLoai.CurrentCell.RowIndex].MaTheLoai,lds[dataGridViewDauSach_TheLoai.CurrentCell.RowIndex].MaDauSach);
            lds = busTL.ConvertDSTL(busTL.GetDanhSachDSTheLoai(ltl[dataGridViewTheLoai_TheLoai.CurrentCell.RowIndex].MaTheLoai));
            dataGridViewDauSach_TheLoai.DataSource = null;
            dataGridViewDauSach_TheLoai.DataSource = lds;
            textBoxThongTinDauSach_TheLoai.Text = "";
            SetUpDataGrVDauSachTL();
        }

        private void buttonThemDauSach_TheLoai_Click(object sender, EventArgs e)
        {
            //chuyển sang tab đầu sách 
            tabControlQuanLySach.SelectedTab = tabPageDauSach;
            //hiện nút themvao_dausach
            buttonThemVao_DauSach.Visible = true;
            //chọn đầu sách ở datagrid đầu sách ấn thêm vào để thêm vào ds_tacgia
        }












        // KẾT THÚC TAB THỂ LOẠI //


        // BẮT ĐẦU TAB KỆ SÁCH //

        // KẾT THÚC TAB KỆ SÁCH //

    }
}
