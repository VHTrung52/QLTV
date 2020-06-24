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
    public partial class MainTroGiup : Form
    {
        public MainTroGiup()
        {
            InitializeComponent();
        }
        public MainTroGiup(string formName)
        {
            InitializeComponent();
            if (formName == "QuanLyThuVien")
                OpenChildForm(new TroGiupQuanLyThuVien());
            else if(formName == "MainQuanLy")
                OpenChildForm(new TroGiupQuanLySachVaDuLieuSach());
            else if(formName == "QuanLyDocGia")
                OpenChildForm(new TroGiupQuanLyDocGia());
            else if (formName == "QuanLyPhieuMuon")
                OpenChildForm(new TroGiupQuanLyPhieuMuon());


        }
        private Form currentChildForm;
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                //open only form
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void MainTroGiup_Load(object sender, EventArgs e)
        {
            //OpenChildForm(new TroGiupQuanLyThuVien());
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonTrangChu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TroGiupQuanLyThuVien());
        }

        private void buttonSach_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TroGiupQuanLySachVaDuLieuSach());
        }

        private void buttonDocGia_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TroGiupQuanLyDocGia());
        }

        private void buttonPhieuMuon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TroGiupQuanLyPhieuMuon());
        }
    }
}
