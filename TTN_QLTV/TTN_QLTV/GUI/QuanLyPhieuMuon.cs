﻿using System;
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
using TTN_QLTV.GUI.QuanLy;
using TTN_QLTV.GUI.QuanLy1;

namespace TTN_QLTV.GUI
{
    public partial class QuanLyPhieuMuon : Form
    {
        public static int maPhieuMuon;
        DocGiaBUS ctrlDocGia = new DocGiaBUS();
        PhieuMuonBUS ctrlPhieuMuon = new PhieuMuonBUS();
        int maPM;
        int maSach;
        public static int maDocGia = -1;
        private static QuanLyPhieuMuon formQuanLyPhieuMuon = null;
        public QuanLyPhieuMuon()
        {
            InitializeComponent();
            formQuanLyPhieuMuon = this;
            comboBoxLoaiTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            textBoxNgayTra.ReadOnly = true;
            textBoxThanhTien.ReadOnly = true;
            maPhieuMuon = -1;

        }
        public QuanLyPhieuMuon(int maPM)
        {
            maPhieuMuon = maPM;
            formQuanLyPhieuMuon = this;
            InitializeComponent();

            textBoxThanhTien.ReadOnly = true;
        }
        public static void fuck(int ma)
        {
            foreach (DataGridViewRow dataRow in formQuanLyPhieuMuon.dataGridViewPhieuMuon.Rows)
            {
                if (dataRow.Cells[0].Value.ToString() == ma.ToString())
                {
                    dataRow.Selected = true;
                    break;
                }
            }
            formQuanLyPhieuMuon.LoadData();
        }
        private void QuanLyPhieuMuon_Load(object sender, EventArgs e)
        {
            textBoxThongTinSach.Enabled = true;
            textBoxThongTinSach.ReadOnly = false;
            if (maPhieuMuon == -1)
            {
                dataGridViewPhieuMuon.DataSource = ctrlPhieuMuon.XemTatCaPhieuMuon();
                dataGridViewPhieuMuon.Refresh();
                LoadData();
                buttonThemPhieuMuon.Enabled = false;
                buttonSuaPhieuMuon.Enabled = true;
            }
            else if(maPhieuMuon == 0)
            {
                dataGridViewPhieuMuon.DataSource = ctrlPhieuMuon.XemTatCaPhieuMuon();
                dataGridViewPhieuMuon.Refresh();
                textBoxMaDocGia.Text = maDocGia.ToString();
                int index = dataGridViewPhieuMuon.SelectedRows[0].Index;

                maPM = Int16.Parse(dataGridViewPhieuMuon.Rows[index].Cells["MaPhieuMuon"].Value.ToString());

                dataGridViewSach.DataSource = ctrlPhieuMuon.XemDSSachPhieuMuon(maPM); ;
                dataGridViewPhieuMuon.Refresh();

                dataGridViewSach.Columns["MaSach"].HeaderText = "Mã sách";
                dataGridViewSach.Columns["MaDauSach"].HeaderText = "Mã đầu sách";
                dataGridViewSach.Columns["TenSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridViewSach.Columns["TenSach"].HeaderText = "Tên sách";
                dataGridViewSach.Columns["TinhTrang"].HeaderText = "Tình trạng";

                maPhieuMuon = maPM;
                buttonThemPhieuMuon.Enabled = true;
                buttonSuaPhieuMuon.Enabled = false;
            }    
            else
            {
                dataGridViewPhieuMuon.DataSource = ctrlPhieuMuon.XemTatCaPhieuMuon();
                dataGridViewPhieuMuon.Refresh();
                
                foreach (DataGridViewRow dataRow in dataGridViewPhieuMuon.Rows)
                {
                    if(dataRow.Cells[0].Value.ToString() == maPhieuMuon.ToString())
                    {
                        dataRow.Selected = true;
                        break;
                    }
                }
                LoadData();

                buttonThemPhieuMuon.Enabled = false;
                buttonSuaPhieuMuon.Enabled = true;
            }

            dataGridViewPhieuMuon.Columns["MaPhieuMuon"].HeaderText = "Mã phiếu";
            
            dataGridViewPhieuMuon.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
            dataGridViewPhieuMuon.Columns["MaDocGia"].HeaderText = "Mã độc giả";
            dataGridViewPhieuMuon.Columns["ThoiGian"].HeaderText = "Số ngày";
            dataGridViewPhieuMuon.Columns["NgayMuon"].HeaderText = "Ngày mượn";
            dataGridViewPhieuMuon.Columns["NgayTra"].HeaderText = "Ngày trả";
            dataGridViewPhieuMuon.Columns["ThanhTien"].HeaderText = "Thành Tiền";


        }
        private void LoadData()
        {
            int index = dataGridViewPhieuMuon.SelectedRows[0].Index;

            maPM = Int16.Parse(dataGridViewPhieuMuon.Rows[index].Cells["MaPhieuMuon"].Value.ToString());

            dataGridViewSach.DataSource = ctrlPhieuMuon.XemDSSachPhieuMuon(maPM); ;
            

            dataGridViewSach.Columns["MaSach"].HeaderText = "Mã sách";
            dataGridViewSach.Columns["MaDauSach"].HeaderText = "Mã đầu sách";
            dataGridViewSach.Columns["TenSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewSach.Columns["TenSach"].HeaderText = "Tên sách";
            dataGridViewSach.Columns["TinhTrang"].HeaderText = "Tình trạng";

            maPhieuMuon = maPM;

            textBoxMaPhieuMuon.Text = dataGridViewPhieuMuon.Rows[index].Cells["MaPhieuMuon"].Value.ToString();
            textBoxMaNhanVien.Text = dataGridViewPhieuMuon.Rows[index].Cells["MaNhanVien"].Value.ToString();
            textBoxMaDocGia.Text = dataGridViewPhieuMuon.Rows[index].Cells["MaDocGia"].Value.ToString();
            textBoxThoiGian.Text = dataGridViewPhieuMuon.Rows[index].Cells["ThoiGian"].Value.ToString();
            textBoxNgayMuon.Text = Convert.ToDateTime(dataGridViewPhieuMuon.Rows[index].Cells["NgayMuon"].Value.ToString()).ToShortDateString();
            textBoxNgayTra.Text = Convert.ToDateTime(dataGridViewPhieuMuon.Rows[index].Cells["NgayTra"].Value.ToString()).ToShortDateString();
            textBoxThanhTien.Text = dataGridViewPhieuMuon.Rows[index].Cells["ThanhTien"].Value.ToString();

            buttonSuaPhieuMuon.Enabled = true;
            textBoxNgayTra.ReadOnly = false;
        }
        private void buttonThemSach_Click(object sender, EventArgs e)
        {
            maPhieuMuon = Convert.ToInt32(dataGridViewPhieuMuon.CurrentRow.Cells[0].Value.ToString());
            MainMenu.Static_OpenChildForm(new MainQuanLy());
            MainQuanLy.StaticChangeTab(1);
            QuanLySach.Static_EnableButtonThemVaoPhieuMuon();
        }

        private void ButtonThemPhieuMuon_Click(object sender, EventArgs e)
        {
            bool matchMaNV = Regex.IsMatch(textBoxMaNhanVien.Text, @"^\s");
            bool matchMaDG = Regex.IsMatch(textBoxMaDocGia.Text, @"^\s");
            bool matchThoiGian = Regex.IsMatch(textBoxThoiGian.Text, @"^\s");
            bool matchNgayMuon = Regex.IsMatch(textBoxNgayMuon.Text, @"^\s");

            textBoxMaNhanVien.Text = textBoxMaNhanVien.Text.Trim();
            textBoxMaDocGia.Text = textBoxMaDocGia.Text.Trim();
            textBoxThoiGian.Text = textBoxThoiGian.Text.Trim();
            textBoxNgayMuon.Text = textBoxNgayMuon.Text.Trim();

            if (textBoxThoiGian.Text == "")
            {
                MessageBox.Show("Thời gian không Được Để Trống");
                textBoxThoiGian.Focus();
            }
            else if (textBoxNgayMuon.Text == "")
            {
                MessageBox.Show("Ngày mượn không Được Để Trống");
                textBoxNgayMuon.Focus();
            }
            else if (textBoxMaNhanVien.Text == "")
            {
                MessageBox.Show("Mã nhân viên không Được Để Trống");
                textBoxMaNhanVien.Focus();
            }
            else if (textBoxMaDocGia.Text == "")
            {
                MessageBox.Show("Mã độc giả không Được Để Trống");
                textBoxMaDocGia.Focus();
            }
            else
            {
                if (matchThoiGian)
                {
                    MessageBox.Show("Thời gian không Được Để Tất Cả Là Khoảng Trắng");
                    textBoxThoiGian.Focus();
                }
                else if (matchNgayMuon)
                {
                    MessageBox.Show("Ngày mượn không Được Để Tất Cả Là Khoảng Trắng");
                    textBoxNgayMuon.Focus();
                }
                else if (matchMaNV)
                {
                    MessageBox.Show("Mã nhân viên không Được Để Tất Cả Là Khoảng Trắng");
                    textBoxMaNhanVien.Focus();
                }
                else if (matchMaDG)
                {
                    MessageBox.Show("Mã độc giả không Được Để Tất Cả Là Khoảng Trắng");
                    textBoxMaDocGia.Focus();
                }
                else
                {
                    PhieuMuon phieumuon = new PhieuMuon(
                        Int16.Parse(textBoxMaNhanVien.Text), 
                        Int16.Parse(textBoxMaDocGia.Text), 
                        Int16.Parse(textBoxThoiGian.Text), 
                        DateTime.Parse(textBoxNgayMuon.Text),
                        DateTime.Parse(textBoxNgayTra.Text),
                        Convert.ToDecimal(0));

                    if (ctrlPhieuMuon.ThemPhieuMuon(phieumuon))
                    {
                        MessageBox.Show("Thêm mới phiếu mượn thành công");

                        textBoxMaDocGia.Text = "";
                        textBoxMaNhanVien.Text = "";
                        textBoxMaPhieuMuon.Text = "";
                        textBoxThoiGian.Text = "";
                        textBoxNgayMuon.Text = "";

                        if (maPhieuMuon == -1)
                        {
                            dataGridViewPhieuMuon.DataSource = ctrlPhieuMuon.XemTatCaPhieuMuon();
                            dataGridViewPhieuMuon.Refresh();
                        }
                        else
                        {
                            dataGridViewPhieuMuon.DataSource = ctrlDocGia.XemChiTietPhieuMuon(maPhieuMuon);
                            dataGridViewPhieuMuon.Refresh();
                        }

                    }
                    else MessageBox.Show("Thêm mới phiếu mượn thất bại");

                }
            }
        }

        private void ButtonSuaPhieuMuon_Click(object sender, EventArgs e)
        {
            PhieuMuon phieumuon = new PhieuMuon();

            phieumuon.MaPhieuMuon = Int16.Parse(textBoxMaPhieuMuon.Text);
            phieumuon.MaNhanVien = Int16.Parse(textBoxMaNhanVien.Text);
            phieumuon.MaDocGia = Int16.Parse(textBoxMaDocGia.Text);
            phieumuon.ThoiGian = Int16.Parse(textBoxThoiGian.Text);
            phieumuon.NgayMuon = DateTime.Parse(textBoxNgayMuon.Text);
            phieumuon.NgayTra = DateTime.Parse(textBoxNgayTra.Text);

            bool matchThoiGian = Regex.IsMatch(textBoxThoiGian.Text, @"^\s");
            bool matchNgayMuon = Regex.IsMatch(textBoxNgayMuon.Text, @"^\s");
            bool matchNgayTra = Regex.IsMatch(textBoxNgayTra.Text, @"^\s");

            textBoxThoiGian.Text = textBoxThoiGian.Text.Trim();
            textBoxNgayMuon.Text = textBoxNgayMuon.Text.Trim();
            textBoxNgayTra.Text = textBoxNgayTra.Text.Trim();

            if (textBoxThoiGian.Text == "")
            {
                MessageBox.Show("Thời gian không Được Để Trống");
                textBoxThoiGian.Focus();
            }
            else if (textBoxNgayMuon.Text == "")
            {
                MessageBox.Show("Ngày mượn không Được Để Trống");
                textBoxNgayMuon.Focus();
            }
            else if (textBoxNgayTra.Text == "")
            {
                MessageBox.Show("Ngày trả không Được Để Trống");
                textBoxNgayTra.Focus();
            }
            else
            {
                if (matchThoiGian)
                {
                    MessageBox.Show("Thời gian không Được Để Tất Cả Là Khoảng Trắng");
                    textBoxThoiGian.Focus();
                }
                else if (matchNgayMuon)
                {
                    MessageBox.Show("Ngày mượn không Được Để Tất Cả Là Khoảng Trắng");
                    textBoxNgayMuon.Focus();
                }
                else if (matchNgayTra)
                {
                    MessageBox.Show("Ngày trả không Được Để Tất Cả Là Khoảng Trắng");
                    textBoxNgayTra.Focus();
                }
                else
                {
                    if (ctrlPhieuMuon.SuaPhieuMuon(phieumuon))
                    {
                        MessageBox.Show("Sửa phiếu mượn thành công");

                        textBoxMaDocGia.Text = "";
                        textBoxMaNhanVien.Text = "";
                        textBoxMaPhieuMuon.Text = "";
                        textBoxThoiGian.Text = "";
                        textBoxNgayMuon.Text = "";
                        textBoxNgayTra.Text = "";

                        if (maPhieuMuon == -1)
                        {
                            dataGridViewPhieuMuon.DataSource = ctrlPhieuMuon.XemTatCaPhieuMuon();
                            dataGridViewPhieuMuon.Refresh();
                        }
                        else
                        {
                            dataGridViewPhieuMuon.DataSource = ctrlDocGia.XemChiTietPhieuMuon(maPhieuMuon);
                            dataGridViewPhieuMuon.Refresh();
                        }

                        buttonSuaPhieuMuon.Enabled = false;
                    }
                    else MessageBox.Show("Sửa phiếu mượn thất bại");

                }
            }
        }

        private void DataGridViewPhieuMuon_DoubleClick(object sender, EventArgs e)
        {
        }

        private void DataGridViewPhieuMuon_Click(object sender, EventArgs e)
        {
            
        }

        private void ButtonHuy_Click(object sender, EventArgs e)
        {
            textBoxThongTinPhieuMuon.Text = "";
            textBoxMaDocGia.Text = "";
            textBoxMaNhanVien.Text = "";
            textBoxMaPhieuMuon.Text = "";
            textBoxThoiGian.Text = "";
            textBoxNgayMuon.Text = "";
            textBoxNgayTra.Text = "";
            textBoxThanhTien.Text = "0.0000";

            textBoxNgayTra.ReadOnly = true;
            buttonThemPhieuMuon.Enabled = true;
            buttonSuaPhieuMuon.Enabled = false;
        }

        private void ButtonTimKiemPhieuMuon_Click(object sender, EventArgs e)
        {
            string keywords = textBoxThongTinPhieuMuon.Text;
            string loaiTT;
            if (keywords == "")
            {
                dataGridViewPhieuMuon.DataSource = ctrlPhieuMuon.XemTatCaPhieuMuon();
                dataGridViewPhieuMuon.Refresh();
                LoadData();
            }
            else
            {
                if (comboBoxLoaiTT.SelectedItem == null)
                {
                    MessageBox.Show("Chọn thông tin cần tìm kiếm");
                }
                else
                {
                    loaiTT = comboBoxLoaiTT.SelectedItem.ToString();
                    List<PhieuMuon> dsPhieuMuon;
                    List<PhieuMuon> items;

                    if (maPhieuMuon == -1)
                    {
                        dsPhieuMuon = ctrlPhieuMuon.XemTatCaPhieuMuon();
                        items = dsPhieuMuon;
                    }
                    else
                    {
                        dsPhieuMuon = ctrlDocGia.XemChiTietPhieuMuon(maPhieuMuon);
                        items = dsPhieuMuon;
                    }

                    switch (loaiTT)
                    {
                        case "Mã Phiếu Mượn":
                            items = dsPhieuMuon.FindAll(item => item.MaPhieuMuon.ToString().Contains(keywords));
                            break;
                        case "Mã Nhân Viên":
                            items = dsPhieuMuon.FindAll(item => item.MaNhanVien.ToString().Contains(keywords));
                            break;
                        case "Mã Độc Giả":
                            items = dsPhieuMuon.FindAll(item => item.MaDocGia.ToString().Contains(keywords));
                            break;
                        case "Ngày Mượn":
                            items = dsPhieuMuon.FindAll(item => item.NgayMuon.ToString().Contains(keywords));
                            break;
                        case "Ngày Trả":
                            items = dsPhieuMuon.FindAll(item => item.NgayTra.ToString().Contains(keywords));
                            break;
                        default:
                            MessageBox.Show("Tìm kiếm không hợp lệ");
                            break;
                    }

                    dataGridViewPhieuMuon.DataSource = items;
                    dataGridViewPhieuMuon.Refresh();
                }
            }
            
        }

        private void ButtonXoaSach_Click(object sender, EventArgs e)
        {
            int index = dataGridViewSach.SelectedRows[0].Index;

            maSach = Int16.Parse(dataGridViewSach.Rows[index].Cells["MaSach"].Value.ToString());

            if (ctrlPhieuMuon.XoaSachTrongPhieuMuon(maPhieuMuon, maSach))
            {
                MessageBox.Show("Xóa sách thành công");
                dataGridViewSach.DataSource = ctrlPhieuMuon.XemDSSachPhieuMuon(maPM);
                dataGridViewSach.Refresh();
            }
            else
            {
                MessageBox.Show("Xóa sách thất bại");
            }
        }

        private void ButtonTimKiemSach_Click(object sender, EventArgs e)
        {
            string keywords = textBoxThongTinSach.Text;

            if (maPhieuMuon == -1)
            {
                MessageBox.Show("Chọn phiếu nhập của độc giả để tìm kiếm");
            }
            else
            {
                if (keywords == "")
                {
                    dataGridViewSach.DataSource = ctrlPhieuMuon.XemDSSachPhieuMuon(maPhieuMuon);
                    dataGridViewSach.Refresh();
                }
                else
                {
                    dataGridViewSach.DataSource = ctrlPhieuMuon.TimKiemTTSach(maPhieuMuon, Int32.Parse(keywords));
                    dataGridViewSach.Refresh();
                }

                dataGridViewSach.Columns["MaSach"].HeaderText = "Mã sách";
                dataGridViewSach.Columns["MaDauSach"].HeaderText = "Mã đầu sách";
                dataGridViewSach.Columns["TenSach"].HeaderText = "Tên sách";
                dataGridViewSach.Columns["TinhTrang"].HeaderText = "Tình trạng";
            }
        }

        private void TextBoxThongTinSach_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dataGridViewPhieuMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonSuaPhieuMuon.Enabled = true;
            buttonThemPhieuMuon.Enabled = false;
            LoadData();
        }

        private void textBoxThoiGian_TextChanged(object sender, EventArgs e)
        {
            if(textBoxNgayMuon.Text != "" && textBoxThoiGian.Text != "")
            {
                DateTime tempdt;
                int tempI;
                if(DateTime.TryParse(textBoxNgayMuon.Text,out tempdt) == true && int.TryParse(textBoxThoiGian.Text,out tempI) == true)
                {
                    textBoxNgayTra.Text = Convert.ToDateTime(textBoxNgayMuon.Text).AddDays(Int16.Parse(textBoxThoiGian.Text)).ToShortDateString();
                }
            }
                
        }

        private void textBoxNgayMuon_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNgayMuon.Text != "" && textBoxThoiGian.Text != "")
            {
                DateTime tempdt;
                int tempI;
                if (DateTime.TryParse(textBoxNgayMuon.Text, out tempdt) == true && int.TryParse(textBoxThoiGian.Text, out tempI) == true)
                {
                    textBoxNgayTra.Text = Convert.ToDateTime(textBoxNgayMuon.Text).AddDays(Int16.Parse(textBoxThoiGian.Text)).ToShortDateString();
                }
            }
        }

        private void dataGridViewSach_DataSourceChanged(object sender, EventArgs e)
        {
            buttonXoaSach.Enabled = true;
            buttonTraSach.Enabled = true;
            if (dataGridViewSach.Rows.Count == 0)
            {
                buttonTraSach.Enabled = false;
                buttonXoaSach.Enabled = false;
            }    
                
        }

        private void buttonTraSach_Click(object sender, EventArgs e)
        {
            try
            {
                ctrlPhieuMuon.TraSach(maPM);
                LoadData();
                MessageBox.Show("Thành Công");
            }
            catch(Exception)
            {
                MessageBox.Show("Error");
            }    
            
        }
    }
}
