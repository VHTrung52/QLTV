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

namespace TTN_QLTV.GUI
{
    public partial class QuanLyDocGia : Form
    {
        DocGiaBUS ctrlDocGia = new DocGiaBUS();

        public QuanLyDocGia()
        {
            InitializeComponent();
        }

        private void buttonChiTietPhieuMuon_Click(object sender, EventArgs e)
        {
            //chọn 1 phiếu mượn và ấn chi tiết phiếu mượn
            //hiện ra form phiếu mượn
            //datagird phiếu mượn chỉ có 1 phiếu mượn vừa chọn ở trên
            //datagrid sách là sách thuộc phiếu mượn
        }

        private void QuanLyDocGia_Load(object sender, EventArgs e)
        {
            dataGridViewDocGia.DataSource = ctrlDocGia.XemTatCaDocGia();
            dataGridViewDocGia.Refresh();
            textBoxCMNĐocGia.Text = "fuck";
            dataGridViewDocGia.Columns["MaDocGia"].HeaderText = "Mã";
            dataGridViewDocGia.Columns["HoTen"].HeaderText = "Họ tên";
            dataGridViewDocGia.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dataGridViewDocGia.Columns["SoDienThoai"].HeaderText = "SĐT";
        }

        private void ButtonThemDocGia_Click(object sender, EventArgs e)
        {
            //bool matchTenDG = Regex.IsMatch(textBoxTenDocGia.Text, @"^\s");
            //bool matchNgaySinh = Regex.IsMatch(textbox.Text, @"^\s");
            //bool matchCMND = Regex.IsMatch(textBoxChucVu.Text, @"^\s");
            //bool matchSDT = Regex.IsMatch(textBoxSDT.Text, @"^\s");
            //bool matchDiaChi = Regex.IsMatch(textBoxDiaChi.Text, @"^\s");
            //bool matchDayMon = Regex.IsMatch(comboBoxDayMon.Text, @"^\s");

            //textBoxTenGV.Text = textBoxTenGV.Text.Trim();
            //textBoxGT.Text = textBoxGT.Text.Trim();
            //textBoxChucVu.Text = textBoxChucVu.Text.Trim();
            //textBoxSDT.Text = textBoxSDT.Text.Trim();
            //textBoxDiaChi.Text = textBoxDiaChi.Text.Trim();
            //comboBoxDayMon.Text = comboBoxDayMon.Text.Trim();

            //if (textBoxTenGV.Text == "")
            //{
            //    MessageBox.Show("Tên giáo viên không Được Để Trống");
            //    textBoxTenGV.Focus();
            //}
            //else if (textBoxGT.Text == "")
            //{
            //    MessageBox.Show("Giới tính không Được Để Trống");
            //    textBoxGT.Focus();
            //}
            //else if (textBoxChucVu.Text == "")
            //{
            //    MessageBox.Show("Chức vụ không Được Để Trống");
            //    textBoxChucVu.Focus();
            //}
            //else if (textBoxSDT.Text == "")
            //{
            //    MessageBox.Show("Số điện thoại không Được Để Trống");
            //    textBoxSDT.Focus();
            //}
            //else if (textBoxDiaChi.Text == "")
            //{
            //    MessageBox.Show("Địa chỉ không Được Để Trống");
            //    textBoxDiaChi.Focus();
            //}
            //else if (comboBoxDayMon.Text == "")
            //{
            //    MessageBox.Show("Môn học không Được Để Trống");
            //    comboBoxDayMon.Focus();
            //}
            //else
            //{
            //    if (matchTenGV)
            //    {
            //        MessageBox.Show("Tên giáo viên không Được Để Tất Cả Là Khoảng Trắng");
            //        textBoxTenGV.Focus();
            //    }
            //    else if (matchGT)
            //    {
            //        MessageBox.Show("Giới tính không Được Để Tất Cả Là Khoảng Trắng");
            //        textBoxGT.Focus();
            //    }
            //    else if (matchChucVu)
            //    {
            //        MessageBox.Show("Chức vụ không Được Để Tất Cả Là Khoảng Trắng");
            //        textBoxChucVu.Focus();
            //    }
            //    else if (matchSDT)
            //    {
            //        MessageBox.Show("Số điện thoại không Được Để Tất Cả Là Khoảng Trắng");
            //        textBoxSDT.Focus();
            //    }
            //    else if (matchDiaChi)
            //    {
            //        MessageBox.Show("Địa chỉ không Được Để Tất Cả Là Khoảng Trắng");
            //        textBoxDiaChi.Focus();
            //    }
            //    else if (textBoxSDT.Text.Length > 11)
            //    {
            //        MessageBox.Show("SDT tối đa chỉ 11 số ");
            //        textBoxSDT.Focus();
            //    }
            //    else
            //    {

            //        DTO.GiaoVien gv = new DTO.GiaoVien("0", textBoxTenGV.Text, textBoxDiaChi.Text, textBoxGT.Text, textBoxSDT.Text, textBoxChucVu.Text, comboBoxDayMon.SelectedValue.ToString());

            //        if (controllerGV.ThemGV(gv))
            //        {
            //            MessageBox.Show("Thêm mới thành công");

            //            textBoxTenGV.Text = "";
            //            textBoxGT.Text = "";
            //            textBoxChucVu.Text = "";
            //            textBoxSDT.Text = "";
            //            textBoxDiaChi.Text = "";
            //            comboBoxDayMon.SelectedValue = 0;

            //            DanhSachGiaoVien.Dtgv.DataSource = controllerGV.XemTatCaGV();
            //            DanhSachGiaoVien.Dtgv.Refresh();
            //            int i = DanhSachGiaoVien.Dtgv.Rows.Count;
            //            DanhSachGiaoVien.TextboxSoLuong.Text = i.ToString();
            //            DanhSachGiaoVien.TextboxSoLuong.Refresh();
            //        }
            //        else MessageBox.Show("Thêm mới thất bại");
            //    }
            //}
        }
    }
}
