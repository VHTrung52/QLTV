using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTN_QLTV.BUS;

namespace TTN_QLTV.GUI
{
    public partial class QuanLySach : Form
    {
        private TheLoaiBUS theLoaiBUS;
        private DauSachBUS dauSachBUS;
        private KeSachBus keSachBus;
        public QuanLySach()
        {
            theLoaiBUS = new TheLoaiBUS();
            dauSachBUS = new DauSachBUS();
            keSachBus = new KeSachBus();
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
        
        private void tabPageTacGia_Enter(object sender, EventArgs e)
        {
            buttonThemVaoDauSach_TacGia.Visible = false;
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
        }
        private void buttonTimKiemDauSach_TacGia_Click(object sender, EventArgs e)
        {
            // 2- tìm kiếm đầu sách chỉ để tìm kiếm trong các đầu sách của tác giả đó 
            // tìm kiếm bằng tên hoặc mã đầu sách
        }
        // KẾT THÚC TAB TÁC GIẢ //


        // BẮT ĐẦU TAB NHÀ XUẤT BẢN //
        private void tabPageNhaXuatBan_Enter(object sender, EventArgs e)
        {
            buttonThemVaoDauSach_NhaXuatBan.Visible = false;
        }
        // KẾT THÚC TAB NHÀ XUẤT BẢN //


        // BẮT ĐẦU TAB THỂ LOẠI //
        private void tabPageTheLoai_Enter(object sender, EventArgs e)
        {

        }





        // KẾT THÚC TAB THỂ LOẠI //


        // BẮT ĐẦU TAB KỆ SÁCH //

        private void dataGridViewKeSach_KeSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewDauSach_KeSach.DataSource = dauSachBUS.XemTatCaDauSachKeSach(dataGridViewKeSach_KeSach.CurrentRow.Cells[0].Value.ToString());
            buttonThemKeSach_KeSach.Enabled = false;
            buttonSuaKeSach_KeSach.Enabled = true;
            buttonHuy_KeSach.Enabled = true;
            textBoxMaKeSach_KeSach.Text = dataGridViewKeSach_KeSach.CurrentRow.Cells[0].Value.ToString();
            textBoxTenKeSach_KeSach.Text = dataGridViewKeSach_KeSach.CurrentRow.Cells[1].Value.ToString();
        }

        private void tabControlQuanLySach_Enter_1(object sender, EventArgs e)
        {
            dataGridViewKeSach_KeSach.DataSource = keSachBus.XemTatCaKeSach();
            dataGridViewDauSach_KeSach.DataSource = dauSachBUS.XemTatCaDauSachKeSach(dataGridViewKeSach_KeSach.Rows[0].Cells[0].Value.ToString());
            buttonSuaKeSach_KeSach.Enabled = false;
            buttonHuy_KeSach.Enabled = false;
        }

        private void buttonTimKiemKeSach_KeSach_Click(object sender, EventArgs e)
        {
            dataGridViewKeSach_KeSach.DataSource = keSachBus.TimKeSach(textBoxThongTinKeSach_KeSach.Text);
        }

        private void buttonHuy_KeSach_Click(object sender, EventArgs e)
        {
            buttonSuaKeSach_KeSach.Enabled = false;
            buttonHuy_KeSach.Enabled = false;
            buttonThemKeSach_KeSach.Enabled = true;
            textBoxMaKeSach_KeSach.Text = "";
            textBoxTenKeSach_KeSach.Text = "";
        }

        private void buttonThemKeSach_KeSach_Click(object sender, EventArgs e)
        {
            keSachBus.ThemKeSach(textBoxTenKeSach_KeSach.Text = dataGridViewKeSach_KeSach.CurrentRow.Cells[1].Value.ToString());
        }

        private void buttonSuaKeSach_KeSach_Click(object sender, EventArgs e)
        {
            keSachBus.SuaKeSach(dataGridViewKeSach_KeSach.CurrentRow.Cells[0].Value.ToString(),dataGridViewKeSach_KeSach.CurrentRow.Cells[1].Value.ToString());
        }


        // KẾT THÚC TAB KỆ SÁCH //

    }
}
