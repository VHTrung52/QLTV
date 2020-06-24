using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTN_QLTV.GUI.TroGiup
{
    public partial class TroGiupQuanLyThuVien : Form
    {
        public TroGiupQuanLyThuVien()
        {
            InitializeComponent();
        }

        private void TroGiupQuanLyThuVien_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"E:\$_SchPj\3_2\Thuc Tap Nhom\New folder\QuanLyThuVien\Annotation 2020-06-18 103514 - Copy (1).png");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Image = Image.FromFile(@"E:\$_SchPj\3_2\Thuc Tap Nhom\New folder\QuanLyThuVien\Annotation 2020-06-18 103514 - Copy (2).png");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Image = Image.FromFile(@"E:\$_SchPj\3_2\Thuc Tap Nhom\New folder\QuanLyThuVien\Annotation 2020-06-18 103514 - Copy (3).png");
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
