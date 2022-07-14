
namespace XANGDAU
{
    partial class LichsuForm
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
            this.components = new System.ComponentModel.Container();
            this.AutoRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.gradientPanel1 = new XANGDAU.GradientPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btExportToExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSelectData = new System.Windows.Forms.ComboBox();
            this.cbAutoRefresh = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSapxepthoigian = new System.Windows.Forms.ComboBox();
            this.cbSelectDateTime = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panelDateTimePicker = new System.Windows.Forms.Panel();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btSearch = new System.Windows.Forms.Button();
            this.lbSoluongketqua = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbOrderType = new System.Windows.Forms.ComboBox();
            this.gradientPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelDateTimePicker.SuspendLayout();
            this.SuspendLayout();
            // 
            // AutoRefreshTimer
            // 
            this.AutoRefreshTimer.Interval = 5000;
            this.AutoRefreshTimer.Tick += new System.EventHandler(this.AutoRefreshTimer_Tick);
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Angle = 0F;
            this.gradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(65)))), ((int)(((byte)(94)))));
            this.gradientPanel1.BottomColor = System.Drawing.Color.Empty;
            this.gradientPanel1.Controls.Add(this.groupBox1);
            this.gradientPanel1.Controls.Add(this.groupBox2);
            this.gradientPanel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(1460, 820);
            this.gradientPanel1.TabIndex = 55;
            this.gradientPanel1.TopColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(27)))), ((int)(((byte)(37)))));
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Location = new System.Drawing.Point(43, 229);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(29, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox1.Size = new System.Drawing.Size(1384, 550);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dữ liệu";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(5, 26);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1374, 518);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "STT";
            this.columnHeader1.Width = 66;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ngày";
            this.columnHeader2.Width = 106;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Thời gian";
            this.columnHeader3.Width = 127;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Nhiệt độ";
            this.columnHeader4.Width = 127;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cbOrderType);
            this.groupBox2.Controls.Add(this.btExportToExcel);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbSelectData);
            this.groupBox2.Controls.Add(this.cbAutoRefresh);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbSapxepthoigian);
            this.groupBox2.Controls.Add(this.cbSelectDateTime);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.panelDateTimePicker);
            this.groupBox2.Controls.Add(this.btSearch);
            this.groupBox2.Controls.Add(this.lbSoluongketqua);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(43, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1384, 194);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // btExportToExcel
            // 
            this.btExportToExcel.BackColor = System.Drawing.SystemColors.Control;
            this.btExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExportToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExportToExcel.ForeColor = System.Drawing.Color.Black;
            this.btExportToExcel.Location = new System.Drawing.Point(681, 90);
            this.btExportToExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btExportToExcel.Name = "btExportToExcel";
            this.btExportToExcel.Size = new System.Drawing.Size(140, 33);
            this.btExportToExcel.TabIndex = 21;
            this.btExportToExcel.Text = "Xuất báo cáo";
            this.btExportToExcel.UseVisualStyleBackColor = false;
            this.btExportToExcel.Click += new System.EventHandler(this.btExportToExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(15, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sản phẩm:";
            // 
            // cbSelectData
            // 
            this.cbSelectData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.cbSelectData.ForeColor = System.Drawing.Color.Black;
            this.cbSelectData.FormattingEnabled = true;
            this.cbSelectData.Items.AddRange(new object[] {
            "Diezel",
            "RON 95",
            "RON 92",
            "E5",
            "Toàn bộ"});
            this.cbSelectData.Location = new System.Drawing.Point(119, 34);
            this.cbSelectData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSelectData.Name = "cbSelectData";
            this.cbSelectData.Size = new System.Drawing.Size(180, 28);
            this.cbSelectData.TabIndex = 2;
            // 
            // cbAutoRefresh
            // 
            this.cbAutoRefresh.AutoSize = true;
            this.cbAutoRefresh.BackColor = System.Drawing.Color.Transparent;
            this.cbAutoRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAutoRefresh.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cbAutoRefresh.Location = new System.Drawing.Point(144, 142);
            this.cbAutoRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbAutoRefresh.Name = "cbAutoRefresh";
            this.cbAutoRefresh.Size = new System.Drawing.Size(155, 24);
            this.cbAutoRefresh.TabIndex = 18;
            this.cbAutoRefresh.Text = "Tự động làm mới";
            this.cbAutoRefresh.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(327, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Thời gian:";
            // 
            // cbSapxepthoigian
            // 
            this.cbSapxepthoigian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSapxepthoigian.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.cbSapxepthoigian.ForeColor = System.Drawing.Color.Black;
            this.cbSapxepthoigian.FormattingEnabled = true;
            this.cbSapxepthoigian.Items.AddRange(new object[] {
            "Thời gian tăng dần",
            "Thời gian giảm dần"});
            this.cbSapxepthoigian.Location = new System.Drawing.Point(119, 82);
            this.cbSapxepthoigian.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSapxepthoigian.Name = "cbSapxepthoigian";
            this.cbSapxepthoigian.Size = new System.Drawing.Size(180, 28);
            this.cbSapxepthoigian.TabIndex = 17;
            this.cbSapxepthoigian.SelectedIndexChanged += new System.EventHandler(this.cbSapxepthoigian_SelectedIndexChanged);
            // 
            // cbSelectDateTime
            // 
            this.cbSelectDateTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.cbSelectDateTime.ForeColor = System.Drawing.Color.Black;
            this.cbSelectDateTime.FormattingEnabled = true;
            this.cbSelectDateTime.Items.AddRange(new object[] {
            "1 phút vừa qua",
            "30 phút vừa qua",
            "1 giờ vừa qua",
            "12 giờ vừa qua",
            "24 giờ vừa qua",
            "Tùy chọn"});
            this.cbSelectDateTime.Location = new System.Drawing.Point(437, 34);
            this.cbSelectDateTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSelectDateTime.Name = "cbSelectDateTime";
            this.cbSelectDateTime.Size = new System.Drawing.Size(185, 28);
            this.cbSelectDateTime.TabIndex = 4;
            this.cbSelectDateTime.SelectedIndexChanged += new System.EventHandler(this.cbSelectDateTime_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(15, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Sắp xếp:";
            // 
            // panelDateTimePicker
            // 
            this.panelDateTimePicker.BackColor = System.Drawing.Color.Transparent;
            this.panelDateTimePicker.Controls.Add(this.dateTimePickerEnd);
            this.panelDateTimePicker.Controls.Add(this.dateTimePickerStart);
            this.panelDateTimePicker.Controls.Add(this.label3);
            this.panelDateTimePicker.Controls.Add(this.label4);
            this.panelDateTimePicker.Location = new System.Drawing.Point(614, 30);
            this.panelDateTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelDateTimePicker.Name = "panelDateTimePicker";
            this.panelDateTimePicker.Size = new System.Drawing.Size(619, 39);
            this.panelDateTimePicker.TabIndex = 15;
            this.panelDateTimePicker.Visible = false;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            this.dateTimePickerEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(367, 6);
            this.dateTimePickerEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(244, 25);
            this.dateTimePickerEnd.TabIndex = 23;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            this.dateTimePickerStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(67, 6);
            this.dateTimePickerStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(244, 25);
            this.dateTimePickerStart.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(25, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Từ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(319, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Đến:";
            // 
            // btSearch
            // 
            this.btSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSearch.ForeColor = System.Drawing.Color.Black;
            this.btSearch.Location = new System.Drawing.Point(20, 135);
            this.btSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(107, 33);
            this.btSearch.TabIndex = 11;
            this.btSearch.Text = "Tìm kiếm";
            this.btSearch.UseVisualStyleBackColor = false;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // lbSoluongketqua
            // 
            this.lbSoluongketqua.AutoSize = true;
            this.lbSoluongketqua.BackColor = System.Drawing.Color.Transparent;
            this.lbSoluongketqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoluongketqua.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbSoluongketqua.Location = new System.Drawing.Point(327, 144);
            this.lbSoluongketqua.Name = "lbSoluongketqua";
            this.lbSoluongketqua.Size = new System.Drawing.Size(177, 20);
            this.lbSoluongketqua.TabIndex = 12;
            this.lbSoluongketqua.Text = "0 dữ liêu được tìm thấy";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(327, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "Loại đơn: ";
            // 
            // cbOrderType
            // 
            this.cbOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrderType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.cbOrderType.ForeColor = System.Drawing.Color.Black;
            this.cbOrderType.FormattingEnabled = true;
            this.cbOrderType.Items.AddRange(new object[] {
            "Nhập",
            "Xuất",
            "Toàn bộ"});
            this.cbOrderType.Location = new System.Drawing.Point(437, 86);
            this.cbOrderType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbOrderType.Name = "cbOrderType";
            this.cbOrderType.Size = new System.Drawing.Size(185, 28);
            this.cbOrderType.TabIndex = 23;
            // 
            // LichsuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1460, 820);
            this.Controls.Add(this.gradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LichsuForm";
            this.Text = "Baocao";
            this.Load += new System.EventHandler(this.LichsuForm_Load);
            this.gradientPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelDateTimePicker.ResumeLayout(false);
            this.panelDateTimePicker.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GradientPanel gradientPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSelectDateTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSelectData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Panel panelDateTimePicker;
        private System.Windows.Forms.Label lbSoluongketqua;
        private System.Windows.Forms.Timer AutoRefreshTimer;
        private System.Windows.Forms.ComboBox cbSapxepthoigian;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.CheckBox cbAutoRefresh;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Button btExportToExcel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbOrderType;
    }
}