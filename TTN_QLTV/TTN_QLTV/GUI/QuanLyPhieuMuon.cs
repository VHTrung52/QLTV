using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTN_QLTV.GUI
{
    public partial class QuanLyPhieuMuon : Form
    {
        public QuanLyPhieuMuon()
        {
            InitializeComponent();
        }

        private void buttonThemSach_Click(object sender, EventArgs e)
        {
            QuanLySach qls = new QuanLySach();
            qls.ShowDialog();
            QuanLySach.tabName = "sach";
            
        }
    }
}
