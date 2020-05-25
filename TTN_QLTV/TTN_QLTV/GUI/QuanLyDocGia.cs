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

namespace TTN_QLTV.GUI
{
    public partial class QuanLyDocGia : Form
    {
        DocGiaBUS ctrlDocGia = new DocGiaBUS();
        int maDG;
        int maPM;

        public QuanLyDocGia()
        {
            InitializeComponent();

            comboBoxLoaiThongTin_DocGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void buttonChiTietPhieuMuon_Click(object sender, EventArgs e)
        {
            //chọn 1 phiếu mượn và ấn chi tiết phiếu mượn
            //hiện ra form phiếu mượn
            //datagird phiếu mượn chỉ có 1 phiếu mượn vừa chọn ở trên
            //datagrid sách là sách thuộc phiếu mượn
            this.Hide();
            QuanLyPhieuMuon formQLPM = new QuanLyPhieuMuon(maPM);
            formQLPM.FormClosed += FormQLPM_FormClosed;
            formQLPM.Show();
        }

        private void FormQLPM_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void QuanLyDocGia_Load(object sender, EventArgs e)
        {
            maDG = -1;

            dataGridViewDocGia.DataSource = ctrlDocGia.XemTatCaDocGia();
            dataGridViewDocGia.Refresh();
            
            dataGridViewDocGia.Columns["MaDocGia"].HeaderText = "Mã";
            dataGridViewDocGia.Columns["MaDocGia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewDocGia.Columns["HoTen"].HeaderText = "Họ tên";
            //dataGridViewDocGia.Columns["HoTen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewDocGia.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dataGridViewDocGia.Columns["NgaySinh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewDocGia.Columns["SoDienThoai"].HeaderText = "SĐT";
            dataGridViewDocGia.Columns["SoDienThoai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dataGridViewDocGia.Columns["CMND"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            buttonSuaDocGia.Enabled = false;
            buttonChiTietPhieuMuon.Enabled = false;
        }

        private void ButtonThemDocGia_Click(object sender, EventArgs e)
        {
            bool matchTenDG = Regex.IsMatch(textBoxTenDocGia.Text, @"^\s");
            bool matchNgaySinh = Regex.IsMatch(textBoxNgaySinh_DocGia.Text, @"^\s");
            bool matchCMND = Regex.IsMatch(textBoxCMNĐocGia.Text, @"^\s");
            bool matchSDT = Regex.IsMatch(textBoxSoDienThoai_DocGia.Text, @"^\s");

            textBoxTenDocGia.Text = textBoxTenDocGia.Text.Trim();
            textBoxNgaySinh_DocGia.Text = textBoxNgaySinh_DocGia.Text.Trim();
            textBoxCMNĐocGia.Text = textBoxCMNĐocGia.Text.Trim();
            textBoxSoDienThoai_DocGia.Text = textBoxSoDienThoai_DocGia.Text.Trim();

            if (textBoxTenDocGia.Text == "")
            {
                MessageBox.Show("Tên độc giả không Được Để Trống");
                textBoxTenDocGia.Focus();
            }
            else if (textBoxNgaySinh_DocGia.Text == "")
            {
                MessageBox.Show("Ngày sinh không Được Để Trống");
                textBoxNgaySinh_DocGia.Focus();
            }
            else if (textBoxCMNĐocGia.Text == "")
            {
                MessageBox.Show("Chứng minh nhân dân không Được Để Trống");
                textBoxCMNĐocGia.Focus();
            }
            else if (textBoxSoDienThoai_DocGia.Text == "")
            {
                MessageBox.Show("Số điện thoại không Được Để Trống");
                textBoxSoDienThoai_DocGia.Focus();
            }
            else
            {
                if (matchTenDG)
                {
                    MessageBox.Show("Tên độc giả không Được Để Tất Cả Là Khoảng Trắng");
                    textBoxTenDocGia.Focus();
                }
                else if (matchNgaySinh)
                {
                    MessageBox.Show("Ngày sinh không Được Để Tất Cả Là Khoảng Trắng");
                    textBoxNgaySinh_DocGia.Focus();
                }
                else if (matchCMND)
                {
                    MessageBox.Show("Chứng minh nhân dân không Được Để Tất Cả Là Khoảng Trắng");
                    textBoxCMNĐocGia.Focus();
                }
                else if (matchSDT)
                {
                    MessageBox.Show("Số điện thoại không Được Để Tất Cả Là Khoảng Trắng");
                    textBoxSoDienThoai_DocGia.Focus();
                }
                else
                {

                    DocGia docgia = new DocGia(textBoxTenDocGia.Text, DateTime.Parse(textBoxNgaySinh_DocGia.Text), textBoxSoDienThoai_DocGia.Text, textBoxCMNĐocGia.Text);

                    if (ctrlDocGia.ThemDocGia(docgia))
                    {
                        MessageBox.Show("Thêm mới độc giả thành công");

                        textBoxTenDocGia.Text = "";
                        textBoxNgaySinh_DocGia.Text = "";
                        textBoxSoDienThoai_DocGia.Text = "";
                        textBoxCMNĐocGia.Text = "";

                        dataGridViewDocGia.DataSource = ctrlDocGia.XemTatCaDocGia();
                        dataGridViewDocGia.Refresh();

                    }
                    else MessageBox.Show("Thêm mới  độc giả thất bại");
                }
            }
        }

        private void DataGridViewDocGia_Click(object sender, EventArgs e)
        {
            int index = dataGridViewDocGia.SelectedRows[0].Index;

            maDG = Int16.Parse(dataGridViewDocGia.Rows[index].Cells["MaDocGia"].Value.ToString());
            
            dataGridViewPhieuMuon.DataSource = ctrlDocGia.XemPhieuMuonCuaDG(maDG);
            dataGridViewPhieuMuon.Refresh();

            dataGridViewPhieuMuon.Columns["MaPhieuMuon"].HeaderText = "Mã phiếu";

            dataGridViewPhieuMuon.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
            dataGridViewPhieuMuon.Columns["MaDocGia"].HeaderText = "Mã độc giả";
            dataGridViewPhieuMuon.Columns["ThoiGian"].HeaderText = "Số ngày";
            dataGridViewPhieuMuon.Columns["NgayMuon"].HeaderText = "Ngày mượn";
            dataGridViewPhieuMuon.Columns["NgayTra"].HeaderText = "Ngày trả";
        }

        private void DataGridViewDocGia_DoubleClick(object sender, EventArgs e)
        {
            int index = dataGridViewDocGia.SelectedRows[0].Index;

            textBoxMaDocGia.Text = dataGridViewDocGia.Rows[index].Cells["MaDocGia"].Value.ToString();
            textBoxTenDocGia.Text = dataGridViewDocGia.Rows[index].Cells["HoTen"].Value.ToString();
            textBoxNgaySinh_DocGia.Text = Convert.ToDateTime(dataGridViewDocGia.Rows[index].Cells["NgaySinh"].Value.ToString()).ToShortDateString();
            textBoxSoDienThoai_DocGia.Text = dataGridViewDocGia.Rows[index].Cells["SoDienThoai"].Value.ToString();
            textBoxCMNĐocGia.Text = dataGridViewDocGia.Rows[index].Cells["CMND"].Value.ToString();

            buttonSuaDocGia.Enabled = true; 
        }

        private void ButtonSuaDocGia_Click(object sender, EventArgs e)
        {
            DocGia docgia = new DocGia();

            docgia.MaDocGia = Int16.Parse(textBoxMaDocGia.Text);
            docgia.HoTen = textBoxTenDocGia.Text;
            docgia.NgaySinh = DateTime.Parse(textBoxNgaySinh_DocGia.Text);
            docgia.CMND = textBoxCMNĐocGia.Text;
            docgia.SoDienThoai = textBoxSoDienThoai_DocGia.Text;

            bool matchTenDG = Regex.IsMatch(textBoxTenDocGia.Text, @"^\s");
            bool matchNgaySinh = Regex.IsMatch(textBoxNgaySinh_DocGia.Text, @"^\s");
            bool matchCMND = Regex.IsMatch(textBoxCMNĐocGia.Text, @"^\s");
            bool matchSDT = Regex.IsMatch(textBoxSoDienThoai_DocGia.Text, @"^\s");

            textBoxTenDocGia.Text = textBoxTenDocGia.Text.Trim();
            textBoxNgaySinh_DocGia.Text = textBoxNgaySinh_DocGia.Text.Trim();
            textBoxCMNĐocGia.Text = textBoxCMNĐocGia.Text.Trim();
            textBoxSoDienThoai_DocGia.Text = textBoxSoDienThoai_DocGia.Text.Trim();

            if (textBoxTenDocGia.Text == "")
            {
                MessageBox.Show("Tên độc giả không Được Để Trống");
                textBoxTenDocGia.Focus();
            }
            else if (textBoxNgaySinh_DocGia.Text == "")
            {
                MessageBox.Show("Ngày sinh không Được Để Trống");
                textBoxNgaySinh_DocGia.Focus();
            }
            else if (textBoxCMNĐocGia.Text == "")
            {
                MessageBox.Show("Chứng minh nhân dân không Được Để Trống");
                textBoxCMNĐocGia.Focus();
            }
            else if (textBoxSoDienThoai_DocGia.Text == "")
            {
                MessageBox.Show("Số điện thoại không Được Để Trống");
                textBoxSoDienThoai_DocGia.Focus();
            }
            else
            {
                if (matchTenDG)
                {
                    MessageBox.Show("Tên độc giả không Được Để Tất Cả Là Khoảng Trắng");
                    textBoxTenDocGia.Focus();
                }
                else if (matchNgaySinh)
                {
                    MessageBox.Show("Ngày sinh không Được Để Tất Cả Là Khoảng Trắng");
                    textBoxNgaySinh_DocGia.Focus();
                }
                else if (matchCMND)
                {
                    MessageBox.Show("Chứng minh nhân dân không Được Để Tất Cả Là Khoảng Trắng");
                    textBoxCMNĐocGia.Focus();
                }
                else if (matchSDT)
                {
                    MessageBox.Show("Số điện thoại không Được Để Tất Cả Là Khoảng Trắng");
                    textBoxSoDienThoai_DocGia.Focus();
                }
                else
                {
                    if (ctrlDocGia.SuaDocGia(docgia))
                    {
                        MessageBox.Show("Sửa độc giả thành công");

                        textBoxMaDocGia.Text = "";
                        textBoxTenDocGia.Text = "";
                        textBoxNgaySinh_DocGia.Text = "";
                        textBoxCMNĐocGia.Text = "";
                        textBoxSoDienThoai_DocGia.Text = "";

                        buttonSuaDocGia.Enabled = false;
                    }
                    else MessageBox.Show("Sửa thất bại");

                    dataGridViewDocGia.DataSource = ctrlDocGia.XemTatCaDocGia();
                    dataGridViewDocGia.Refresh();
                }
            }

            
        }

        private void DataGridViewPhieuMuon_DoubleClick(object sender, EventArgs e)
        {

        }

        private void ButtonPhieuMuonMoi_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLyPhieuMuon formQLPM = new QuanLyPhieuMuon();
            formQLPM.FormClosed += FormQLPM_FormClosed;
            formQLPM.Show();
        }

        private void DataGridViewPhieuMuon_Click(object sender, EventArgs e)
        {

            int index = dataGridViewPhieuMuon.SelectedRows[0].Index;

            maPM = Int16.Parse(dataGridViewPhieuMuon.Rows[index].Cells["MaPhieuMuon"].Value.ToString());

            buttonChiTietPhieuMuon.Enabled = true;
        }

        private void ButtonHuy_Click(object sender, EventArgs e)
        {
            textBoxMaDocGia.Text = "";
            textBoxTenDocGia.Text = "";
            textBoxNgaySinh_DocGia.Text = "";
            textBoxSoDienThoai_DocGia.Text = "";
            textBoxCMNĐocGia.Text = "";
            textBoxThongTinDocGia.Text = "";
            comboBoxLoaiThongTin_DocGia.Text = "";
        }

        private void ButtonTimKiemDocGia_Click(object sender, EventArgs e)
        {
            string keywords = textBoxThongTinDocGia.Text;
            string loaiTT;
            if (comboBoxLoaiThongTin_DocGia.SelectedItem == null)
            {
                MessageBox.Show("Chọn thông tin cần tìm kiếm");
            }
            else
            {
                loaiTT = comboBoxLoaiThongTin_DocGia.SelectedItem.ToString();

                //get ra list
                //get kiểu search từ combo box -> gán vào 1 biến
                //switch case
                //dùng LinQ -> search

                List<DocGia> dsDocGia = ctrlDocGia.XemTatCaDocGia();
                List<DocGia> items = dsDocGia;

                switch (loaiTT)
                {
                    case "Mã Độc Giả":
                        items = dsDocGia.FindAll(item => item.MaDocGia.ToString().Contains(keywords));
                        break;
                    case "Tên Độc Giả":
                        items = dsDocGia.FindAll(item => item.HoTen.Contains(keywords));
                        break;
                    case "Số Điện Thoại":
                        items = dsDocGia.FindAll(item => item.SoDienThoai.Contains(keywords));
                        break;
                    case "CMND":
                        items = dsDocGia.FindAll(item => item.CMND.Contains(keywords));
                        break;
                    default:
                        MessageBox.Show("Tìm kiếm không hợp lệ");
                        break;
                }

                dataGridViewDocGia.DataSource = items;
                dataGridViewDocGia.Refresh();
            }
        }

        private void ButtonTimKiemPhieuMuon_Click(object sender, EventArgs e)
        {
            string keywords = textBoxThongTinPhieuMuon.Text;

            if (maDG == -1)
            {
                MessageBox.Show("Chọn phiếu nhập của độc giả để tìm kiếm");
            }
            else
            {
                if (keywords == "")
                {
                    dataGridViewPhieuMuon.DataSource = ctrlDocGia.XemPhieuMuonCuaDG(maDG);
                    dataGridViewPhieuMuon.Refresh();
                }
                else
                {
                    dataGridViewPhieuMuon.DataSource = ctrlDocGia.TimKiemTTPM(maDG, Int32.Parse(keywords));
                    dataGridViewPhieuMuon.Refresh();
                }

                dataGridViewPhieuMuon.Columns["MaPhieuMuon"].HeaderText = "Mã phiếu";
                dataGridViewPhieuMuon.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
                dataGridViewPhieuMuon.Columns["MaDocGia"].HeaderText = "Mã độc giả";
                dataGridViewPhieuMuon.Columns["ThoiGian"].HeaderText = "Số ngày";
                dataGridViewPhieuMuon.Columns["NgayMuon"].HeaderText = "Ngày mượn";
                dataGridViewPhieuMuon.Columns["NgayTra"].HeaderText = "Ngày trả";
            }
        }

        private void TextBoxThongTinPhieuMuon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
