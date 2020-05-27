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

        DauSachBUS dauSachBUS = new DauSachBUS();
        private int maDauSach;
        private int maTacGia;
        private int maTheLoai;
        private int maNhaXuatBan;
        private int sach_MaDauSach;
        private int sach_MaSach;

        private string xoaTacGia;
        private string xoaTheLoai;
        private string xoaNhaXuatBan;
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

        #region Sách Thuộc Đầu Sách.
        private void dataGridViewDauSach_DauSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridViewDauSach_DauSach.CurrentRow;

            if (!string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
            {
                maDauSach = Convert.ToInt32(row.Cells[0].Value);

                dataGridViewTacGia_DauSach.DataSource = dauSachBUS.GetTenTacGia(maDauSach);

                dataGridViewTheLoai_DauSach.DataSource = dauSachBUS.GetTenTheLoai(maDauSach);

                dataGridViewNhaXuatBan_DauSach.DataSource = dauSachBUS.GetTenNhaXuatBan(maDauSach);

                textBoxMaDauSach_DauSach.Text = row.Cells[0].Value.ToString();
                textBoxTenDauSach_DauSach.Text = row.Cells[1].Value.ToString();
                textBoxMaKeSach_DauSach.Text = row.Cells[2].Value.ToString();
                textBoxSoLuongHienTai_DauSach.Text = row.Cells[3].Value.ToString();
                textBoxTongSo_DauSach.Text = row.Cells[4].Value.ToString();
            }
        }


        private void buttonSachThuoc_DauSach_Click(object sender, EventArgs e)
        {
            // chọn 1 đầu sách ở datagrid đầu sách và ấn Sách thuộc đầu sách
            //chuyển sang tab sach và hiện tất cả sách thuộc đầu sách vừa chọn ở datagrid sách
            // không hiện nút thêm vào
            tabControlQuanLySach.SelectedTab = tabPageSach;
            buttonThemVaoPhieuMuon_Sach.Visible = false;

            dataGridViewSach_Sach.DataSource = dauSachBUS.GetSachThuocDauSach(maDauSach);
            dataGridViewDauSach_Sach.DataSource = dauSachBUS.GetDauSachTheoMaDauSach(maDauSach);
            dataGridViewSach_Sach.Columns[0].HeaderText = "Mã Sách";
            dataGridViewSach_Sach.Columns[1].HeaderText = "Mã Đầu Sách";
            dataGridViewSach_Sach.Columns[2].HeaderText = "Tên Sách";
            dataGridViewSach_Sach.Columns[3].HeaderText = "Tình Trạng";

            dataGridViewDauSach_Sach.Columns[0].HeaderText = "Mã Đầu Sách";
            dataGridViewDauSach_Sach.Columns[1].HeaderText = "Tên Đầu Sách";
            dataGridViewDauSach_Sach.Columns[2].HeaderText = "Mã Kệ Sách";
            dataGridViewDauSach_Sach.Columns[3].HeaderText = "Số Lượng Hiện Tại";
            dataGridViewDauSach_Sach.Columns[4].HeaderText = "Tổng Số";

        }
        #endregion





        #region Tìm Kiếm Đầu Sách
        private void buttonTimKiem_DauSach_Click(object sender, EventArgs e)
        {
            //Tìm kiếm đầu sách trả về kết quả ở datagird view DauSach ben duoi
            //tìm kiếm dựa trên text box thông tin đâù sách và combo box loại thông tin
            //trong loại thông tin có các tiêu chí để tìm kiếm theo
            if (comboBoxLoaiThongTin_DauSach.Text == "Tác Giả")
            {
                dataGridViewDauSach_DauSach.DataSource = dauSachBUS.TimKiemDauSachTheoTacGia(textBoxTimKiemDauSach_DauSach.Text);
            }
            else if (comboBoxLoaiThongTin_DauSach.Text == "Đầu Sách")
            {
                dataGridViewDauSach_DauSach.DataSource = dauSachBUS.TimKiemDauSachTheoDauSach(textBoxTimKiemDauSach_DauSach.Text);
            }
            else if (comboBoxLoaiThongTin_DauSach.Text == "Thể Loại")
            {
                //dataGridViewDauSach_DauSach.DataSource = dauSachBUS.TimKiemDauSachTheoTheLoai(textBoxTimKiemDauSach_DauSach.Text);
                dataGridViewDauSach_DauSach.DataSource = dauSachBUS.TimKiemDauSachTheoNhieuTheLoai(textBoxTimKiemDauSach_DauSach.Text);
            }
            else if (comboBoxLoaiThongTin_DauSach.Text == "Nhà Xuất Bản")
            {
                dataGridViewDauSach_DauSach.DataSource = dauSachBUS.TimKiemDauSachTheoNhaXuatBan(textBoxTimKiemDauSach_DauSach.Text);
            }
            else if (comboBoxLoaiThongTin_DauSach.Text == "Kệ Sách")
            {
                dataGridViewDauSach_DauSach.DataSource = dauSachBUS.TimKiemDauSachTheoKeSach(textBoxTimKiemDauSach_DauSach.Text);
            }
            else
            {
                dataGridViewDauSach_DauSach.DataSource = dauSachBUS.GetDanhSachDauSach();
            }
        }
        #endregion




        private void tabPageDauSach_Enter(object sender, EventArgs e)
        {
            //datagrid đầu sách hiện tất cả các sách
            //nút thêm vào visible = false;
            buttonThemVao_DauSach.Visible = false;
            dataGridViewDauSach_DauSach.DataSource = dauSachBUS.GetDanhSachDauSach(); 
            dataGridViewDauSach_DauSach.Columns["TenDauSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewDauSach_DauSach.Columns[0].HeaderText = "Mã Đầu Sách";
            dataGridViewDauSach_DauSach.Columns[1].HeaderText = "Tên Đầu Sách";
            dataGridViewDauSach_DauSach.Columns[2].HeaderText = "Mã Kệ Sách";
            dataGridViewDauSach_DauSach.Columns[3].HeaderText = "Số Lượng Hiện Tại";
            dataGridViewDauSach_DauSach.Columns[4].HeaderText = "Tổng Số";
        }


        #region Thêm - Xóa Tác Giả ĐẦu Sách 
        private void buttonThemTacGia_DauSach_Click(object sender, EventArgs e)
        {
            //chọn 1 đầu sách và chọn thêm tác giả
            //chuyển sang tab tác giả và hiện nút thêm vào đầu sách
            //chọn 1 tác giả xong ấn thêm vào đầu sách để thêm 
            //thêm vào bảng ds_tacgia
            tabControlQuanLySach.SelectedTab = tabPageTacGia;
            buttonThemVaoDauSach_TacGia.Visible = true;

            dataGridViewDauSach_TacGia.DataSource = dauSachBUS.GetDauSachTheoMaDauSach(maDauSach);
            dataGridViewTacGia_TacGia.DataSource = dauSachBUS.GetTacGia();

        }

        /*private void dataGridViewTacGia_TacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentRow = dataGridViewTacGia_TacGia.CurrentRow;
            maTacGia = Convert.ToInt32(currentRow.Cells[0].Value);
        }*/

        private void buttonThemVaoDauSach_TacGia_Click(object sender, EventArgs e)
        {
            try
            {
                dauSachBUS.ThemTacGiaChoDauSach(maDauSach, maTacGia);
                MessageBox.Show("---Thành Công---");
            }
            catch (Exception)
            {

                MessageBox.Show("Tác Giả Này Đã Có Trong Đầu Sách");
            }
            dataGridViewTacGia_DauSach.DataSource = dauSachBUS.GetTenTacGia(maDauSach);
        }

        private void dataGridViewTacGia_DauSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentRow = dataGridViewTacGia_DauSach.CurrentRow;
            xoaTacGia = currentRow.Cells[0].Value.ToString();
        }


        private void buttonXoaTacGia_DauSach_Click(object sender, EventArgs e)
        {
            //Chọn 1 tác giả trong datagrid view ở trên xong chọn xoá 
            //xoá khỏi bảng ds_tacgia
            try
            {
                dauSachBUS.XoaTacGia_DauSach(maDauSach, xoaTacGia);
                MessageBox.Show("---Thành Công---");
            }
            catch (Exception)
            {
                MessageBox.Show("Tác Giả Này Chưa Có Trong Đầu Sách");
            }
            dataGridViewTacGia_DauSach.DataSource = dauSachBUS.GetTenTacGia(maDauSach);
        }

        #endregion




        #region Thêm Xóa Thể Loại Đầu Sách
        private void buttonThemTheLoai_DauSach_Click(object sender, EventArgs e)
        {
            //chọn 1 đầu sách và chọn thêm thể loại
            //chuyển sang tab thể loại và hiện nút thêm vào đầu sách
            //chọn 1 thể loại xong ấn thêm vào đầu sách để thêm 
            //thêm vào bảng ds_theloai
            // ví dụ ở trên

            tabControlQuanLySach.SelectedTab = tabPageTheLoai;
            buttonThemVaoDauSach_TheLoai.Visible = true;

            dataGridViewDauSach_TheLoai.DataSource = dauSachBUS.GetDauSachTheoMaDauSach(maDauSach);
            dataGridViewTheLoai_TheLoai.DataSource = dauSachBUS.GetTheLoai();
        }

        /*private void dataGridViewTheLoai_TheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentRow = dataGridViewTheLoai_TheLoai.CurrentRow;
            maTheLoai = Convert.ToInt32(currentRow.Cells[0].Value);
        }*/

        private void buttonThemVaoDauSach_TheLoai_Click(object sender, EventArgs e)
        {
            try
            {
                dauSachBUS.ThemTheLoaiChoDauSach(maDauSach, maTheLoai);
                MessageBox.Show("---Thành Công---");
            }
            catch (Exception)
            {

                MessageBox.Show("Thể Loại Này Đã Có Trong Đầu Sách");
            }
            dataGridViewTheLoai_DauSach.DataSource = dauSachBUS.GetTenTheLoai(maDauSach);
        }

        private void dataGridViewTheLoai_DauSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentRow = dataGridViewTheLoai_DauSach.CurrentRow;
            xoaTheLoai = currentRow.Cells[0].Value.ToString();
        }

        private void buttonXoaTheLoai_DauSach_Click(object sender, EventArgs e)
        {
            //Chọn 1 thể loại trong datagrid view ở trên xong chọn xoá 
            //xoá khỏi bảng ds_theloai

            try
            {
                dauSachBUS.XoaTheLoai_DauSach(maDauSach, xoaTheLoai);
                MessageBox.Show("---Thành Công---");
            }
            catch (Exception)
            {

                MessageBox.Show("Thể Loại Này Chưa Có Trong Đầu Sách");
            }
            dataGridViewTheLoai_DauSach.DataSource = dauSachBUS.GetTenTheLoai(maDauSach);

        }
        #endregion




        #region Thêm Xóa Nhà Xuất Bản Đầu Sách
        private void buttonThemNhaXuatBan_DauSach_Click(object sender, EventArgs e)
        {
            //chọn 1 đầu sách và chọn thêm nha xuat ban
            //chuyển sang tab nha xuat ban và hiện nút thêm vào đầu sách
            //chọn 1 thể loại xong ấn thêm vào đầu sách để thêm 
            //thêm vào bảng ds_nha xuat ban
            // ví dụ ở trên
            tabControlQuanLySach.SelectedTab = tabPageNhaXuatBan;
            buttonThemVaoDauSach_NhaXuatBan.Visible = true;

            dataGridViewDauSach_NhaXuatBan.DataSource = dauSachBUS.GetDauSachTheoMaDauSach(maDauSach);
            dataGridViewNhaXuatBan_NhaXuatBan.DataSource = dauSachBUS.GetNhaXuatBan();

        }

        /*private void dataGridViewNhaXuatBan_NhaXuatBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentRow = dataGridViewNhaXuatBan_NhaXuatBan.CurrentRow;
            maNhaXuatBan = Convert.ToInt32(currentRow.Cells[0].Value);
        }*/


        private void buttonThemVaoDauSach_NhaXuatBan_Click(object sender, EventArgs e)
        {
            try
            {
                dauSachBUS.ThemNhaXuatBanChoDauSach(maDauSach, maNhaXuatBan);
                MessageBox.Show("---Thành Công---");
            }
            catch (Exception)
            {

                MessageBox.Show("Nhà xuất Bản Này Đã Có Trong Đầu Sách");
            }
            dataGridViewNhaXuatBan_DauSach.DataSource = dauSachBUS.GetTenNhaXuatBan(maDauSach);
        }

        private void dataGridViewNhaXuatBan_DauSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentRow = dataGridViewNhaXuatBan_DauSach.CurrentRow;
            xoaNhaXuatBan = currentRow.Cells[0].Value.ToString();
        }

        private void buttonXoaNhaXuatBan_DauSach_Click(object sender, EventArgs e)
        {
            //Chọn 1 thể loại trong datagrid view ở trên xong chọn xoá 
            //xoá khỏi bảng ds_nhaxuatban

            try
            {
                dauSachBUS.XoaNhaXuatBan_DauSach(maDauSach, xoaNhaXuatBan);
                MessageBox.Show("---Thành Công---");
            }
            catch (Exception)
            {

                MessageBox.Show("Thể Loại Này Chưa Có Trong Đầu Sách");
            }
            dataGridViewNhaXuatBan_DauSach.DataSource = dauSachBUS.GetTenNhaXuatBan(maDauSach);
        }

        #endregion



       
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


        #region Thêm Đầu Sách
        private void buttonThemDauSach_DauSach_Click(object sender, EventArgs e)
        {
            bool IsTenDauSach = Regex.IsMatch(textBoxTenDauSach_DauSach.Text, @"^\s");
            bool IsSoLuongHienTai = Regex.IsMatch(textBoxSoLuongHienTai_DauSach.Text, @"\d");
            bool IsTongSo = Regex.IsMatch(textBoxTongSo_DauSach.Text, @"\d");
            bool IsMaKeSach = Regex.IsMatch(textBoxMaKeSach_DauSach.Text, @"\d");

            textBoxTenDauSach_DauSach.Text = textBoxTenDauSach_DauSach.Text.Trim();
            textBoxSoLuongHienTai_DauSach.Text = textBoxSoLuongHienTai_DauSach.Text.Trim();
            textBoxTongSo_DauSach.Text = textBoxTongSo_DauSach.Text.Trim();
            textBoxMaKeSach_DauSach.Text = textBoxMaKeSach_DauSach.Text.Trim();


            if (textBoxTenDauSach_DauSach.Text == "")
            {
                MessageBox.Show("Tên Đầu Sách Không Được Để Trống!");
                textBoxTenDauSach_DauSach.Focus();
            }
            else if (textBoxSoLuongHienTai_DauSach.Text == "")
            {
                MessageBox.Show("Số Lượng Đầu Sách Hiện Tại Không Được Để Trống");
                textBoxSoLuongHienTai_DauSach.Focus();
            }
            else if (textBoxTongSo_DauSach.Text == "")
            {
                MessageBox.Show("Tổng Số Lượng Đầu Sách Không Được Để Trống");
                textBoxTongSo_DauSach.Focus();
            }
            else if (textBoxMaKeSach_DauSach.Text == "")
            {
                MessageBox.Show("Mã Kệ Sách Không Được Để Trống");
                textBoxMaKeSach_DauSach.Focus();
            }
            else
            {
                if (IsTenDauSach)
                {
                    MessageBox.Show("Tên Đầu Sách không Được Để Nhiều Khoảng Trắng");
                    textBoxTenDauSach_DauSach.Focus();
                }
                else if (!IsSoLuongHienTai)
                {
                    MessageBox.Show("Số Lượng Đầu Sách Hiện Tại Phải Là Số Nguyên");
                    textBoxSoLuongHienTai_DauSach.Focus();
                }
                else if (!IsTongSo)
                {
                    MessageBox.Show("Tổng Số Đầu Sách Phải Là 1 Số Nguyên");
                    textBoxTongSo_DauSach.Focus();
                }
                else if (!IsMaKeSach)
                {
                    MessageBox.Show("Mã Kệ Sách Phải Là 1 Số Nguyên");
                    textBoxMaKeSach_DauSach.Focus();
                }
                else
                {
                    if (MessageBox.Show("Bạn Có Chắc Chắn Muốn Thêm Đầu Sách Này Không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            textBoxTenDauSach_DauSach.Text = XoaKiTuTrang(textBoxTenDauSach_DauSach.Text);

                            dauSachBUS.ThemDauSach(textBoxTenDauSach_DauSach.Text, Convert.ToInt32(textBoxMaKeSach_DauSach.Text), Convert.ToInt32(textBoxSoLuongHienTai_DauSach.Text), Convert.ToInt32(textBoxTongSo_DauSach.Text));

                            dataGridViewDauSach_DauSach.DataSource = dauSachBUS.GetDanhSachDauSach();
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
        #endregion

        private void buttonHuyDauSach_DauSach_Click(object sender, EventArgs e)
        {
            textBoxMaDauSach_DauSach.Text = "";
            textBoxTenDauSach_DauSach.Text = "";
            textBoxSoLuongHienTai_DauSach.Text = "";
            textBoxTongSo_DauSach.Text = "";
            textBoxMaKeSach_DauSach.Text = "";
        }



        #region Sửa Đầu Sách
        private void buttonSuaDauSach_DauSach_Click(object sender, EventArgs e)
        {
            bool IsTenDauSach = Regex.IsMatch(textBoxTenDauSach_DauSach.Text, @"^\s");
            bool IsSoLuongHienTai = Regex.IsMatch(textBoxSoLuongHienTai_DauSach.Text, @"\d");
            bool IsTongSo = Regex.IsMatch(textBoxTongSo_DauSach.Text, @"\d");
            bool IsMaKeSach = Regex.IsMatch(textBoxMaKeSach_DauSach.Text, @"\d");

            textBoxTenDauSach_DauSach.Text = textBoxTenDauSach_DauSach.Text.Trim();
            textBoxSoLuongHienTai_DauSach.Text = textBoxSoLuongHienTai_DauSach.Text.Trim();
            textBoxTongSo_DauSach.Text = textBoxTongSo_DauSach.Text.Trim();
            textBoxMaKeSach_DauSach.Text = textBoxMaKeSach_DauSach.Text.Trim();


            if (textBoxTenDauSach_DauSach.Text == "")
            {
                MessageBox.Show("Tên Đầu Sách Không Được Để Trống!");
                textBoxTenDauSach_DauSach.Focus();
            }
            else if (textBoxSoLuongHienTai_DauSach.Text == "")
            {
                MessageBox.Show("Số Lượng Đầu Sách Hiện Tại Không Được Để Trống");
                textBoxSoLuongHienTai_DauSach.Focus();
            }
            else if (textBoxTongSo_DauSach.Text == "")
            {
                MessageBox.Show("Tổng Số Lượng Đầu Sách Không Được Để Trống");
                textBoxTongSo_DauSach.Focus();
            }
            else if (textBoxMaKeSach_DauSach.Text == "")
            {
                MessageBox.Show("Mã Kệ Sách Không Được Để Trống");
                textBoxMaKeSach_DauSach.Focus();
            }
            else
            {
                if (IsTenDauSach)
                {
                    MessageBox.Show("Tên Đầu Sách không Được Để Nhiều Khoảng Trắng");
                    textBoxTenDauSach_DauSach.Focus();
                }
                else if (!IsSoLuongHienTai)
                {
                    MessageBox.Show("Số Lượng Đầu Sách Hiện Tại Phải Là Số Nguyên");
                    textBoxSoLuongHienTai_DauSach.Focus();
                }
                else if (!IsTongSo)
                {
                    MessageBox.Show("Tổng Số Đầu Sách Phải Là 1 Số Nguyên");
                    textBoxTongSo_DauSach.Focus();
                }
                else if (!IsMaKeSach)
                {
                    MessageBox.Show("Mã Kệ Sách Phải Là 1 Số Nguyên");
                    textBoxMaKeSach_DauSach.Focus();
                }
                else
                {
                    if (MessageBox.Show("Bạn Có Chắc Chắn Muốn Cập Nhật Lại Đầu Sách Này Không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            textBoxTenDauSach_DauSach.Text = XoaKiTuTrang(textBoxTenDauSach_DauSach.Text);

                            dauSachBUS.SuaDauSach(maDauSach, textBoxTenDauSach_DauSach.Text, Convert.ToInt32(textBoxMaKeSach_DauSach.Text), Convert.ToInt32(textBoxSoLuongHienTai_DauSach.Text), Convert.ToInt32(textBoxTongSo_DauSach.Text));

                            dataGridViewDauSach_DauSach.DataSource = dauSachBUS.GetDanhSachDauSach();
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
        #endregion



        private void buttonThemVao_DauSach_Click(object sender, EventArgs e)
        {
            try
            {
                dauSachBUS.ThemDauSachChoSach(sach_MaSach, maDauSach);
                dataGridViewSach_Sach.DataSource = dauSachBUS.GetTatCaSach();
                MessageBox.Show("--Thêm đầu sách thành công--");
            }
            catch (Exception)
            {

                MessageBox.Show("--Thất Bại--");
            }
        }



        // KẾT THÚC TAB ĐẦU SÁCH //



        // BẮT ĐẦU TAB SÁCH //
        
        private void tabPageSach_Enter(object sender, EventArgs e)
        {
            buttonThemVaoPhieuMuon_Sach.Visible = false;
            dataGridViewSach_Sach.DataSource = dauSachBUS.GetTatCaSach();
            //dataGridViewSach_Sach.Refresh();
           // dataGridViewSach_Sach.Columns["MaSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridViewSach_Sach.Columns["MaDauSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewSach_Sach.Columns["TenSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridViewSach_Sach.Columns["TinhTrang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewSach_Sach.Columns[0].HeaderText = "Mã Sách";
            
            dataGridViewSach_Sach.Columns[1].HeaderText = "Mã Đầu Sách";
            dataGridViewSach_Sach.Columns[2].HeaderText = "Tên Sách";
            dataGridViewSach_Sach.Columns[3].HeaderText = "Tình Trạng";
        }
        private void dataGridViewSach_Sach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridViewSach_Sach.CurrentRow;

            if (!string.IsNullOrEmpty(row.Cells[0].Value.ToString()) && !string.IsNullOrEmpty(row.Cells[1].Value.ToString()))
            {
                textBoxMaSach_Sach.Text = row.Cells[0].Value.ToString();
                textBoxMaDauSach_Sach.Text = row.Cells[1].Value.ToString();
                textBoxTenSach_Sach.Text = row.Cells[2].Value.ToString();
                checkBoxTinhTrang_Sach.Checked = (bool)row.Cells[3].Value;
                sach_MaSach = Convert.ToInt32(row.Cells[0].Value);

                dataGridViewDauSach_Sach.DataSource = dauSachBUS.DauSach_Sach(Convert.ToInt32(row.Cells[1].Value));
                dataGridViewDauSach_Sach.Columns[0].HeaderText = "Mã Đầu Sách";
                dataGridViewDauSach_Sach.Columns[1].HeaderText = "Tên Đầu Sách";
                dataGridViewDauSach_Sach.Columns[2].HeaderText = "Mã Kệ Sách";
                dataGridViewDauSach_Sach.Columns[3].HeaderText = "Số Lượng Hiện Tại";
                dataGridViewDauSach_Sach.Columns[4].HeaderText = "Tổng Số";
            }

        }

        #region Tìm Kiếm , Thêm , Sửa , Xóa , Hủy Sach (tabsach)

        private void buttonTimKiemSach_Sach_Click(object sender, EventArgs e)
        {
            dataGridViewSach_Sach.DataSource = dauSachBUS.TimKiemSach(textBoxTimKiem_Sach.Text);
        }


        private void buttonThemSach_Sach_Click(object sender, EventArgs e)
        {
            bool IsTenSach = Regex.IsMatch(textBoxTenSach_Sach.Text, @"^\s");

            textBoxTenSach_Sach.Text = textBoxTenSach_Sach.Text.Trim();


            if (textBoxTenSach_Sach.Text == "")
            {
                MessageBox.Show("Tên Sách Không Được Để Trống!");
                textBoxTenSach_Sach.Focus();
            }
            else
            {
                if (IsTenSach)
                {
                    MessageBox.Show("Tên Sách không Được Để Nhiều Khoảng Trắng");
                    textBoxTenSach_Sach.Focus();
                }
                else
                {
                    if (MessageBox.Show("Bạn Có Chắc Chắn Muốn Thêm Sách Này Không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            textBoxTenSach_Sach.Text = XoaKiTuTrang(textBoxTenSach_Sach.Text);

                            dauSachBUS.ThemSach_Sach(1, textBoxTenSach_Sach.Text, false);

                            dataGridViewSach_Sach.DataSource = dauSachBUS.GetTatCaSach();

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


        private void buttonSuaSach_Sach_Click(object sender, EventArgs e)
        {
            bool IsTenSach = Regex.IsMatch(textBoxTenSach_Sach.Text, @"^\s");
            bool IsMaDauSach = Regex.IsMatch(textBoxMaDauSach_Sach.Text, @"\d");

            textBoxTenSach_Sach.Text = textBoxTenSach_Sach.Text.Trim();
            textBoxMaDauSach_Sach.Text = textBoxMaDauSach_Sach.Text.Trim();


            if (textBoxTenSach_Sach.Text == "")
            {
                MessageBox.Show("Tên Sách Không Được Để Trống!");
                textBoxTenSach_Sach.Focus();
            }
            else if (textBoxMaDauSach_Sach.Text == "")
            {
                MessageBox.Show("Mã Đầu Sách Không Được Để Trống");
                textBoxMaDauSach_Sach.Focus();
            }
            else
            {
                if (IsTenSach)
                {
                    MessageBox.Show("Tên Sách không Được Để Nhiều Khoảng Trắng");
                    textBoxTenSach_Sach.Focus();
                }
                else if (!IsMaDauSach)
                {
                    MessageBox.Show("Mã Đầu Sách Phải Là Số Nguyên");
                    textBoxMaDauSach_Sach.Focus();
                }
                else
                {
                    if (MessageBox.Show("Bạn Có Chắc Chắn Muốn Sửa Thông Tin Sách Này Không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            textBoxTenSach_Sach.Text = XoaKiTuTrang(textBoxTenSach_Sach.Text);

                            dauSachBUS.SuaSach_Sach(Convert.ToInt32(textBoxMaSach_Sach.Text), Convert.ToInt32(textBoxMaDauSach_Sach.Text), textBoxTenSach_Sach.Text, checkBoxTinhTrang_Sach.Checked);

                            dataGridViewSach_Sach.DataSource = dauSachBUS.GetTatCaSach();

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


        private void buttonHuySach_Sach_Click(object sender, EventArgs e)
        {
            textBoxMaSach_Sach.Text = "";
            textBoxMaDauSach_Sach.Text = "";
            textBoxTenSach_Sach.Text = "";
            checkBoxTinhTrang_Sach.Checked = false;
        }


        private void buttonXoaSach_Sach_Click(object sender, EventArgs e)
        {
            try
            {
                dauSachBUS.XoaSach_Sach(Convert.ToInt32(textBoxMaSach_Sach.Text));

                dataGridViewSach_Sach.DataSource = dauSachBUS.GetTatCaSach();

                MessageBox.Show("----Thành Công----");
            }
            catch (Exception)
            {

                MessageBox.Show("Thất Bại!");
            }
        }




        #endregion



        #region Them , Xoa DauSach (tabSach)
        private void buttonThemDauSach_Sach_Click(object sender, EventArgs e)
        {
            tabControlQuanLySach.SelectedTab = tabPageDauSach;
            buttonThemVao_DauSach.Visible = true;

        }

        private void buttonXoaDauSach_Sach_Click(object sender, EventArgs e)
        {
            dauSachBUS.XoaDauSachChoSach(sach_MaSach);
            dataGridViewSach_Sach.DataSource = dauSachBUS.GetTatCaSach();
            MessageBox.Show("--Xóa đầu sách thành công--");
        }

        #endregion



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
            textBoxNgaySinh_TacGia.Text = ltg[dataGridViewTacGia_TacGia.CurrentCell.RowIndex].NgaySinh.ToShortDateString();
            dataGridViewDauSach_TacGia.Columns["TenDauSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
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
            dataGridViewDauSach_NhaXuatBan.Columns["TenDauSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
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
            dataGridViewDauSach_TheLoai.Columns["TenDauSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
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
