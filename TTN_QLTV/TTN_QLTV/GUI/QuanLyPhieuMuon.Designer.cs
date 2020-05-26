namespace TTN_QLTV.GUI
{
    partial class QuanLyPhieuMuon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.comboBoxLoaiTT = new System.Windows.Forms.ComboBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.textBoxNgayTra = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxThoiGian = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBoxMaDocGia = new System.Windows.Forms.TextBox();
            this.buttonHuy = new System.Windows.Forms.Button();
            this.buttonSuaPhieuMuon = new System.Windows.Forms.Button();
            this.buttonThemPhieuMuon = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxNgayMuon = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxMaNhanVien = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxMaPhieuMuon = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBoxThongTinPhieuMuon = new System.Windows.Forms.TextBox();
            this.buttonTimKiemPhieuMuon = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.dataGridViewPhieuMuon = new System.Windows.Forms.DataGridView();
            this.groupBox29 = new System.Windows.Forms.GroupBox();
            this.buttonXoaSach = new System.Windows.Forms.Button();
            this.buttonThemSach = new System.Windows.Forms.Button();
            this.groupBox28 = new System.Windows.Forms.GroupBox();
            this.dataGridViewSach = new System.Windows.Forms.DataGridView();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.textBoxThongTinSach = new System.Windows.Forms.TextBox();
            this.buttonTimKiemSach = new System.Windows.Forms.Button();
            this.textBoxThanhTien = new System.Windows.Forms.TextBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.groupBox5.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhieuMuon)).BeginInit();
            this.groupBox29.SuspendLayout();
            this.groupBox28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSach)).BeginInit();
            this.groupBox27.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox11);
            this.groupBox5.Controls.Add(this.groupBox10);
            this.groupBox5.Controls.Add(this.groupBox9);
            this.groupBox5.Controls.Add(this.groupBox4);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.buttonHuy);
            this.groupBox5.Controls.Add(this.buttonSuaPhieuMuon);
            this.groupBox5.Controls.Add(this.buttonThemPhieuMuon);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Controls.Add(this.groupBox7);
            this.groupBox5.Controls.Add(this.buttonTimKiemPhieuMuon);
            this.groupBox5.Controls.Add(this.groupBox8);
            this.groupBox5.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(681, 686);
            this.groupBox5.TabIndex = 54;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Phiếu Mượn";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.comboBoxLoaiTT);
            this.groupBox10.Location = new System.Drawing.Point(271, 26);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox10.Size = new System.Drawing.Size(180, 63);
            this.groupBox10.TabIndex = 60;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Loại Thông Tin";
            // 
            // comboBoxLoaiTT
            // 
            this.comboBoxLoaiTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLoaiTT.FormattingEnabled = true;
            this.comboBoxLoaiTT.Items.AddRange(new object[] {
            "Mã Phiếu Mượn",
            "Mã Nhân Viên",
            "Mã Độc Giả",
            "Tên Độc Giả",
            "Ngày Mượn",
            "Ngày Trả"});
            this.comboBoxLoaiTT.Location = new System.Drawing.Point(7, 21);
            this.comboBoxLoaiTT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxLoaiTT.Name = "comboBoxLoaiTT";
            this.comboBoxLoaiTT.Size = new System.Drawing.Size(167, 27);
            this.comboBoxLoaiTT.TabIndex = 0;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.textBoxNgayTra);
            this.groupBox9.Location = new System.Drawing.Point(5, 254);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox9.Size = new System.Drawing.Size(287, 71);
            this.groupBox9.TabIndex = 59;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Ngày Trả";
            // 
            // textBoxNgayTra
            // 
            this.textBoxNgayTra.Location = new System.Drawing.Point(5, 28);
            this.textBoxNgayTra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNgayTra.Name = "textBoxNgayTra";
            this.textBoxNgayTra.Size = new System.Drawing.Size(273, 27);
            this.textBoxNgayTra.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxThoiGian);
            this.groupBox4.Location = new System.Drawing.Point(300, 177);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(259, 71);
            this.groupBox4.TabIndex = 55;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thời Gian (Ngày)";
            // 
            // textBoxThoiGian
            // 
            this.textBoxThoiGian.Location = new System.Drawing.Point(7, 27);
            this.textBoxThoiGian.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxThoiGian.Name = "textBoxThoiGian";
            this.textBoxThoiGian.Size = new System.Drawing.Size(247, 27);
            this.textBoxThoiGian.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBoxMaDocGia);
            this.groupBox6.Location = new System.Drawing.Point(377, 95);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(181, 71);
            this.groupBox6.TabIndex = 55;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Mã Độc Giả";
            // 
            // textBoxMaDocGia
            // 
            this.textBoxMaDocGia.Location = new System.Drawing.Point(7, 27);
            this.textBoxMaDocGia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxMaDocGia.Name = "textBoxMaDocGia";
            this.textBoxMaDocGia.Size = new System.Drawing.Size(167, 27);
            this.textBoxMaDocGia.TabIndex = 0;
            // 
            // buttonHuy
            // 
            this.buttonHuy.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHuy.Location = new System.Drawing.Point(565, 282);
            this.buttonHuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonHuy.Name = "buttonHuy";
            this.buttonHuy.Size = new System.Drawing.Size(104, 43);
            this.buttonHuy.TabIndex = 58;
            this.buttonHuy.Text = "Huỷ";
            this.buttonHuy.UseVisualStyleBackColor = true;
            this.buttonHuy.Click += new System.EventHandler(this.ButtonHuy_Click);
            // 
            // buttonSuaPhieuMuon
            // 
            this.buttonSuaPhieuMuon.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSuaPhieuMuon.Location = new System.Drawing.Point(565, 233);
            this.buttonSuaPhieuMuon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSuaPhieuMuon.Name = "buttonSuaPhieuMuon";
            this.buttonSuaPhieuMuon.Size = new System.Drawing.Size(104, 43);
            this.buttonSuaPhieuMuon.TabIndex = 57;
            this.buttonSuaPhieuMuon.Text = "Sửa";
            this.buttonSuaPhieuMuon.UseVisualStyleBackColor = true;
            this.buttonSuaPhieuMuon.Click += new System.EventHandler(this.ButtonSuaPhieuMuon_Click);
            // 
            // buttonThemPhieuMuon
            // 
            this.buttonThemPhieuMuon.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThemPhieuMuon.Location = new System.Drawing.Point(565, 185);
            this.buttonThemPhieuMuon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonThemPhieuMuon.Name = "buttonThemPhieuMuon";
            this.buttonThemPhieuMuon.Size = new System.Drawing.Size(104, 43);
            this.buttonThemPhieuMuon.TabIndex = 56;
            this.buttonThemPhieuMuon.Text = "Thêm";
            this.buttonThemPhieuMuon.UseVisualStyleBackColor = true;
            this.buttonThemPhieuMuon.Click += new System.EventHandler(this.ButtonThemPhieuMuon_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxNgayMuon);
            this.groupBox3.Location = new System.Drawing.Point(5, 177);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(287, 71);
            this.groupBox3.TabIndex = 53;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ngày Mượn";
            // 
            // textBoxNgayMuon
            // 
            this.textBoxNgayMuon.Location = new System.Drawing.Point(5, 27);
            this.textBoxNgayMuon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNgayMuon.Name = "textBoxNgayMuon";
            this.textBoxNgayMuon.Size = new System.Drawing.Size(273, 27);
            this.textBoxNgayMuon.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxMaNhanVien);
            this.groupBox2.Location = new System.Drawing.Point(188, 95);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(181, 71);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mã Nhân Viên";
            // 
            // textBoxMaNhanVien
            // 
            this.textBoxMaNhanVien.Location = new System.Drawing.Point(7, 27);
            this.textBoxMaNhanVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxMaNhanVien.Name = "textBoxMaNhanVien";
            this.textBoxMaNhanVien.Size = new System.Drawing.Size(167, 27);
            this.textBoxMaNhanVien.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxMaPhieuMuon);
            this.groupBox1.Location = new System.Drawing.Point(5, 95);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(176, 71);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mã Phiếu Mượn";
            // 
            // textBoxMaPhieuMuon
            // 
            this.textBoxMaPhieuMuon.Location = new System.Drawing.Point(7, 27);
            this.textBoxMaPhieuMuon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxMaPhieuMuon.Name = "textBoxMaPhieuMuon";
            this.textBoxMaPhieuMuon.ReadOnly = true;
            this.textBoxMaPhieuMuon.Size = new System.Drawing.Size(161, 27);
            this.textBoxMaPhieuMuon.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBoxThongTinPhieuMuon);
            this.groupBox7.Location = new System.Drawing.Point(5, 26);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Size = new System.Drawing.Size(260, 63);
            this.groupBox7.TabIndex = 48;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Thông Tin Phiếu Mượn";
            // 
            // textBoxThongTinPhieuMuon
            // 
            this.textBoxThongTinPhieuMuon.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxThongTinPhieuMuon.Location = new System.Drawing.Point(5, 21);
            this.textBoxThongTinPhieuMuon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxThongTinPhieuMuon.Name = "textBoxThongTinPhieuMuon";
            this.textBoxThongTinPhieuMuon.Size = new System.Drawing.Size(248, 27);
            this.textBoxThongTinPhieuMuon.TabIndex = 1;
            // 
            // buttonTimKiemPhieuMuon
            // 
            this.buttonTimKiemPhieuMuon.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTimKiemPhieuMuon.Location = new System.Drawing.Point(457, 26);
            this.buttonTimKiemPhieuMuon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTimKiemPhieuMuon.Name = "buttonTimKiemPhieuMuon";
            this.buttonTimKiemPhieuMuon.Size = new System.Drawing.Size(213, 58);
            this.buttonTimKiemPhieuMuon.TabIndex = 47;
            this.buttonTimKiemPhieuMuon.Text = "Tìm Kiếm";
            this.buttonTimKiemPhieuMuon.UseVisualStyleBackColor = true;
            this.buttonTimKiemPhieuMuon.Click += new System.EventHandler(this.ButtonTimKiemPhieuMuon_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.dataGridViewPhieuMuon);
            this.groupBox8.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(5, 331);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Size = new System.Drawing.Size(671, 353);
            this.groupBox8.TabIndex = 46;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Danh Sách Phiếu Mượn";
            // 
            // dataGridViewPhieuMuon
            // 
            this.dataGridViewPhieuMuon.AllowUserToResizeColumns = false;
            this.dataGridViewPhieuMuon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPhieuMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPhieuMuon.Location = new System.Drawing.Point(8, 26);
            this.dataGridViewPhieuMuon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewPhieuMuon.Name = "dataGridViewPhieuMuon";
            this.dataGridViewPhieuMuon.ReadOnly = true;
            this.dataGridViewPhieuMuon.RowHeadersWidth = 51;
            this.dataGridViewPhieuMuon.RowTemplate.Height = 24;
            this.dataGridViewPhieuMuon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPhieuMuon.Size = new System.Drawing.Size(657, 321);
            this.dataGridViewPhieuMuon.TabIndex = 3;
            this.dataGridViewPhieuMuon.Click += new System.EventHandler(this.DataGridViewPhieuMuon_Click);
            this.dataGridViewPhieuMuon.DoubleClick += new System.EventHandler(this.DataGridViewPhieuMuon_DoubleClick);
            // 
            // groupBox29
            // 
            this.groupBox29.Controls.Add(this.buttonXoaSach);
            this.groupBox29.Controls.Add(this.buttonThemSach);
            this.groupBox29.Controls.Add(this.groupBox28);
            this.groupBox29.Controls.Add(this.groupBox27);
            this.groupBox29.Controls.Add(this.buttonTimKiemSach);
            this.groupBox29.Location = new System.Drawing.Point(699, 12);
            this.groupBox29.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox29.Name = "groupBox29";
            this.groupBox29.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox29.Size = new System.Drawing.Size(676, 687);
            this.groupBox29.TabIndex = 55;
            this.groupBox29.TabStop = false;
            this.groupBox29.Text = "Sách";
            // 
            // buttonXoaSach
            // 
            this.buttonXoaSach.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonXoaSach.Location = new System.Drawing.Point(525, 281);
            this.buttonXoaSach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonXoaSach.Name = "buttonXoaSach";
            this.buttonXoaSach.Size = new System.Drawing.Size(139, 55);
            this.buttonXoaSach.TabIndex = 57;
            this.buttonXoaSach.Text = "Xoá Sách";
            this.buttonXoaSach.UseVisualStyleBackColor = true;
            this.buttonXoaSach.Click += new System.EventHandler(this.ButtonXoaSach_Click);
            // 
            // buttonThemSach
            // 
            this.buttonThemSach.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThemSach.Location = new System.Drawing.Point(525, 219);
            this.buttonThemSach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonThemSach.Name = "buttonThemSach";
            this.buttonThemSach.Size = new System.Drawing.Size(139, 55);
            this.buttonThemSach.TabIndex = 55;
            this.buttonThemSach.Text = "Thêm Sách";
            this.buttonThemSach.UseVisualStyleBackColor = true;
            this.buttonThemSach.Click += new System.EventHandler(this.buttonThemSach_Click);
            // 
            // groupBox28
            // 
            this.groupBox28.Controls.Add(this.dataGridViewSach);
            this.groupBox28.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox28.Location = new System.Drawing.Point(5, 331);
            this.groupBox28.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox28.Size = new System.Drawing.Size(664, 350);
            this.groupBox28.TabIndex = 53;
            this.groupBox28.TabStop = false;
            this.groupBox28.Text = "Danh Sách Mượn";
            // 
            // dataGridViewSach
            // 
            this.dataGridViewSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSach.Location = new System.Drawing.Point(5, 26);
            this.dataGridViewSach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewSach.Name = "dataGridViewSach";
            this.dataGridViewSach.ReadOnly = true;
            this.dataGridViewSach.RowHeadersWidth = 51;
            this.dataGridViewSach.RowTemplate.Height = 24;
            this.dataGridViewSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSach.Size = new System.Drawing.Size(652, 321);
            this.dataGridViewSach.TabIndex = 3;
            // 
            // groupBox27
            // 
            this.groupBox27.Controls.Add(this.textBoxThongTinSach);
            this.groupBox27.Location = new System.Drawing.Point(5, 26);
            this.groupBox27.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox27.Size = new System.Drawing.Size(429, 63);
            this.groupBox27.TabIndex = 49;
            this.groupBox27.TabStop = false;
            this.groupBox27.Text = "Thông Tin Sách";
            // 
            // textBoxThongTinSach
            // 
            this.textBoxThongTinSach.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxThongTinSach.Location = new System.Drawing.Point(5, 21);
            this.textBoxThongTinSach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxThongTinSach.Name = "textBoxThongTinSach";
            this.textBoxThongTinSach.Size = new System.Drawing.Size(417, 27);
            this.textBoxThongTinSach.TabIndex = 1;
            this.textBoxThongTinSach.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxThongTinSach_KeyPress);
            // 
            // buttonTimKiemSach
            // 
            this.buttonTimKiemSach.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTimKiemSach.Location = new System.Drawing.Point(451, 26);
            this.buttonTimKiemSach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTimKiemSach.Name = "buttonTimKiemSach";
            this.buttonTimKiemSach.Size = new System.Drawing.Size(213, 63);
            this.buttonTimKiemSach.TabIndex = 48;
            this.buttonTimKiemSach.Text = "Tìm Kiếm";
            this.buttonTimKiemSach.UseVisualStyleBackColor = true;
            this.buttonTimKiemSach.Click += new System.EventHandler(this.ButtonTimKiemSach_Click);
            // 
            // textBoxThanhTien
            // 
            this.textBoxThanhTien.Location = new System.Drawing.Point(7, 27);
            this.textBoxThanhTien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxThanhTien.Name = "textBoxThanhTien";
            this.textBoxThanhTien.Size = new System.Drawing.Size(247, 27);
            this.textBoxThanhTien.TabIndex = 0;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.textBoxThanhTien);
            this.groupBox11.Location = new System.Drawing.Point(300, 256);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox11.Size = new System.Drawing.Size(259, 71);
            this.groupBox11.TabIndex = 61;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Thành Tiền";
            // 
            // QuanLyPhieuMuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 736);
            this.Controls.Add(this.groupBox29);
            this.Controls.Add(this.groupBox5);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "QuanLyPhieuMuon";
            this.Text = " Quản Lý Phiếu Mượn";
            this.Load += new System.EventHandler(this.QuanLyPhieuMuon_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhieuMuon)).EndInit();
            this.groupBox29.ResumeLayout(false);
            this.groupBox28.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSach)).EndInit();
            this.groupBox27.ResumeLayout(false);
            this.groupBox27.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox textBoxThongTinPhieuMuon;
        private System.Windows.Forms.Button buttonTimKiemPhieuMuon;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DataGridView dataGridViewPhieuMuon;
        private System.Windows.Forms.GroupBox groupBox29;
        private System.Windows.Forms.GroupBox groupBox28;
        private System.Windows.Forms.DataGridView dataGridViewSach;
        private System.Windows.Forms.GroupBox groupBox27;
        private System.Windows.Forms.TextBox textBoxThongTinSach;
        private System.Windows.Forms.Button buttonTimKiemSach;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxThoiGian;
        private System.Windows.Forms.Button buttonHuy;
        private System.Windows.Forms.Button buttonSuaPhieuMuon;
        private System.Windows.Forms.Button buttonThemPhieuMuon;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxMaNhanVien;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxMaPhieuMuon;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBoxMaDocGia;
        private System.Windows.Forms.Button buttonThemSach;
        private System.Windows.Forms.Button buttonXoaSach;
        private System.Windows.Forms.TextBox textBoxNgayTra;
        private System.Windows.Forms.TextBox textBoxNgayMuon;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ComboBox comboBoxLoaiTT;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox textBoxThanhTien;
    }
}