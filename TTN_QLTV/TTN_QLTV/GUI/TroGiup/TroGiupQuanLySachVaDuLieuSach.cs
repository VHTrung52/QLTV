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
    public partial class TroGiupQuanLySachVaDuLieuSach : Form
    {
        public TroGiupQuanLySachVaDuLieuSach()
        {
            InitializeComponent();
        }

        private void TroGiupQuanLySachVaDuLieuSach_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"E:\$_SchPj\3_2\Thuc Tap Nhom\New folder\QuanLySachVaDuLieuSach\Annotation 2020-06-25 033547 - Copy.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Image = Image.FromFile(@"E:\$_SchPj\3_2\Thuc Tap Nhom\New folder\QuanLySachVaDuLieuSach\Annotation 2020-06-25 033547 - Copy (2).png");
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.Image = Image.FromFile(@"E:\$_SchPj\3_2\Thuc Tap Nhom\New folder\QuanLySachVaDuLieuSach\Annotation 2020-06-25 035759.png");
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.Image = Image.FromFile(@"E:\$_SchPj\3_2\Thuc Tap Nhom\New folder\QuanLySachVaDuLieuSach\Annotation 2020-06-25 033547 - Copy (3).png");
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.Image = Image.FromFile(@"E:\$_SchPj\3_2\Thuc Tap Nhom\New folder\QuanLySachVaDuLieuSach\Annotation 2020-06-25 035540.png");
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
