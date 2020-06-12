﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTN_QLTV.GUI;
using TTN_QLTV.GUI.QuanLy;

namespace TTN_QLTV
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new QuanLyPhieuMuon());
            //Application.Run(new QuanLyDocGia());
            Application.Run(new QuanLyThuVien());
            //Application.Run(new QuanLy2());
            //Application.Run(new GUI.QuanLy.MainQuanLy());
        }
    }
}
