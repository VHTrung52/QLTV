using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTN_QLTV.GUI.QuanLy;
using TTN_QLTV.GUI.TroGiup;

namespace TTN_QLTV.GUI
{
    public partial class MainMenu : Form
    {
        private static MainMenu formMainMenu = null;
        
        public MainMenu()
        {
            InitializeComponent();
            formMainMenu = this;
        }
        public static void Static_OpenChildForm(Form childForm)
        {
            formMainMenu.OpenChildForm(childForm);
        }

        private Form currentChildForm = null;
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


        private void MainMenu_Load(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLyThuVien());
            this.KeyPreview = true;
        }
        private void buttonTrangChu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLyThuVien());
        }

        private void buttonSach_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MainQuanLy());
        }

        private void buttonDocGia_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLyDocGia());
        }

        private void buttonPhieuMuon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLyPhieuMuon());
        }

        private void MainMenu_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void MainMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                MainTroGiup mainTroGiup = new MainTroGiup(currentChildForm.Name);
                mainTroGiup.Show();
            }
        }
    }
}
