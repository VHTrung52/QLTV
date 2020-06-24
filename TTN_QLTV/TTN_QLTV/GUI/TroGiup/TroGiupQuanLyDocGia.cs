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
    public partial class TroGiupQuanLyDocGia : Form
    {
        public TroGiupQuanLyDocGia()
        {
            InitializeComponent();
        }

        private void TroGiupQuanLyDocGia_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"E:\$_SchPj\3_2\Thuc Tap Nhom\New folder\QuanLyDocGia\Annotation 2020-06-18 233124 - Copy.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Image = Image.FromFile(@"E:\$_SchPj\3_2\Thuc Tap Nhom\New folder\QuanLyDocGia\Annotation 2020-06-18 233124 - Copy (2).png");
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
