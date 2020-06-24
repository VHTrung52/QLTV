using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTN_QLTV.GUI.QuanLy1;

namespace TTN_QLTV.GUI.QuanLy
{
    public partial class MainQuanLy : Form
    {
        private static MainQuanLy formMainQuanLy = null;
        private bool first = true;
        public MainQuanLy()
        {
            InitializeComponent();
            formMainQuanLy = this;
        } 
        public static void StaticChangeTab(int index)
        {
            if (formMainQuanLy != null)
            {
                formMainQuanLy.ChangeTab(index);
            }
        }
        private void ChangeTab(int index)
        {
            tabControlQuanLy.SelectedIndex = index;
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
            if(childForm.Name == "QuanLyDauSach")
            {
                panelQuanLyDauSach.Controls.Add(childForm);
                panelQuanLyDauSach.Tag = childForm;
            }
            else if(childForm.Name == "QuanLySach")
            {
                panelQuanLySach.Controls.Add(childForm);
                panelQuanLySach.Tag = childForm;
            }
            else if (childForm.Name == "QuanLyTacGia")
            {
                panelQuanLyTacGia.Controls.Add(childForm);
                panelQuanLyTacGia.Tag = childForm;
            }
            else if (childForm.Name == "QuanLyNhaXuatBan")
            {
                panelQuanLyNhaXuatBan.Controls.Add(childForm);
                panelQuanLyNhaXuatBan.Tag = childForm;
            }
            else if (childForm.Name == "QuanLyTheLoai")
            {
                panelQuanLyTheLoai.Controls.Add(childForm);
                panelQuanLyTheLoai.Tag = childForm;
            }
            else if (childForm.Name == "QuanLyKeSach")
            {
                panelQuanLyKeSach.Controls.Add(childForm);
                panelQuanLyKeSach.Tag = childForm;
            }
            childForm.BringToFront();
            childForm.Show();
        }
        

        private void tabPageQuanLyDauSach_Enter(object sender, EventArgs e)
        {
            if (first == true)
            OpenChildForm(new QuanLyDauSach());
        }

        private void tabPageQuanLySach_Enter(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLySach());
            first = true;
        }

        private void tabPageQuanLyTacGia_Enter(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLyTacGia());
            first = true;
        }

        private void tabPageQuanLyNhaXuatBan_Enter(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLyNhaXuatBan());
            first = true;
        }

        private void tabPageQuanLyTheLoai_Enter(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLyTheLoai());
            first = true;
        }

        private void tabPageQuanLyKeSach_Enter(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLyKeSach());
            first = true;
        }

        private void MainQuanLy_Load(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLyDauSach());
            first = false;
        }
    }
}
