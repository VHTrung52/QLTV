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

namespace TTN_QLTV
{
    public partial class Form1 : Form
    {
        DauSachBUS dauSach;
        TacGiaBUS tacGia;
        TheLoaiBUS theLoai;
        NhaXuatBanBUS nhaXuatBan;
        public Form1()
        {
            InitializeComponent();
            dauSach = new DauSachBUS();
            tacGia = new TacGiaBUS();
            theLoai = new TheLoaiBUS();
            nhaXuatBan = new NhaXuatBanBUS();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewDauSach.DataSource = dauSach.XemTatCaDauSach();
            dataGridViewDauSach.Columns["TenDauSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTacGia.DataSource = tacGia.XemTacGia(dataGridViewDauSach.CurrentRow.Cells[0].Value.ToString());
            dataGridViewTheLoai.DataSource = theLoai.XemTheLoai(dataGridViewDauSach.CurrentRow.Cells[0].Value.ToString());
            dataGridViewNhaXuatBan.DataSource = nhaXuatBan.XemNhaXuatBan(dataGridViewDauSach.CurrentRow.Cells[0].Value.ToString());
            textBoxKeSach.Text = dataGridViewDauSach.CurrentRow.Cells[2].Value.ToString();
            comboBoxLoaiThongTin.SelectedIndex = 0;
        }

        private void dataGridViewDauSach_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            UpdateThongTin();
        }

        private void UpdateThongTin()
        {
            if (dataGridViewDauSach.CurrentRow != null)
            {
                dataGridViewTacGia.DataSource = tacGia.XemTacGia(dataGridViewDauSach.CurrentRow.Cells[0].Value.ToString());
                dataGridViewTheLoai.DataSource = theLoai.XemTheLoai(dataGridViewDauSach.CurrentRow.Cells[0].Value.ToString());
                dataGridViewNhaXuatBan.DataSource = nhaXuatBan.XemNhaXuatBan(dataGridViewDauSach.CurrentRow.Cells[0].Value.ToString());
                textBoxKeSach.Text = dataGridViewDauSach.CurrentRow.Cells[2].Value.ToString();
            }
            else
            {
                dataGridViewTacGia.DataSource = new DataTable();
                dataGridViewTheLoai.DataSource = new DataTable();
                dataGridViewNhaXuatBan.DataSource = new DataTable();
                textBoxKeSach.Text = "";
            }    
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            
            switch (comboBoxLoaiThongTin.Text)
            {
                case "Tên Tác Giả":
                    {
                        dataGridViewDauSach.DataSource = dauSach.XemTatCaDauSachTacGia(textBoxThongTinTimKiem.Text);
                        break;
                    }
                case "Tên Đầu Sách":
                    {
                        dataGridViewDauSach.DataSource = dauSach.XemTatCaDauSachDauSach(textBoxThongTinTimKiem.Text);
                        break;
                    }
                case "Thể Loại":
                    {
                        dataGridViewDauSach.DataSource = dauSach.XemTatCaDauSachTheLoai(textBoxThongTinTimKiem.Text);
                        break;
                    }
                case "Tên Nhà Xuất Bản":
                    {
                        dataGridViewDauSach.DataSource = dauSach.XemTatCaDauSachNXB(textBoxThongTinTimKiem.Text);
                        break;
                    }
                case "Kệ Sách":
                    {
                        if(Regex.IsMatch(textBoxThongTinTimKiem.Text, "^[0-9]*$"))
                        {
                            dataGridViewDauSach.DataSource = dauSach.XemTatCaDauSachKeSach(textBoxThongTinTimKiem.Text);
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Phải là 1 số");
                            break;
                        }                        
                    }
                default:
                    {
                        break;
                    }
            }
            UpdateThongTin();
        }
    }
}
