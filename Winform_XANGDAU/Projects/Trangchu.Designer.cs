
namespace XANGDAU
{
    partial class TrangchuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrangchuForm));
            this.DateTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.gradientPanel1 = new XANGDAU.GradientPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbCustomerPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCustomerAddr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCustomerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxQRCode = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbThroat = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTankName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.lbT = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.lbThoigian = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.lbTrangthai = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbSetpoint = new System.Windows.Forms.Label();
            this.tbIDdonhang = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbThanhtien = new System.Windows.Forms.Label();
            this.lbDongia = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // DateTimeTimer
            // 
            this.DateTimeTimer.Interval = 10000;
            this.DateTimeTimer.Tick += new System.EventHandler(this.DateTimeTimer_Tick);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Angle = 70F;
            this.gradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(65)))), ((int)(((byte)(94)))));
            this.gradientPanel1.BottomColor = System.Drawing.Color.Empty;
            this.gradientPanel1.Controls.Add(this.label11);
            this.gradientPanel1.Controls.Add(this.label10);
            this.gradientPanel1.Controls.Add(this.tbCustomerPhone);
            this.gradientPanel1.Controls.Add(this.label6);
            this.gradientPanel1.Controls.Add(this.tbCustomerAddr);
            this.gradientPanel1.Controls.Add(this.label4);
            this.gradientPanel1.Controls.Add(this.tbCustomerName);
            this.gradientPanel1.Controls.Add(this.label3);
            this.gradientPanel1.Controls.Add(this.pictureBoxQRCode);
            this.gradientPanel1.Controls.Add(this.label2);
            this.gradientPanel1.Controls.Add(this.lbThroat);
            this.gradientPanel1.Controls.Add(this.label1);
            this.gradientPanel1.Controls.Add(this.lbTankName);
            this.gradientPanel1.Controls.Add(this.button1);
            this.gradientPanel1.Controls.Add(this.label9);
            this.gradientPanel1.Controls.Add(this.lbT);
            this.gradientPanel1.Controls.Add(this.lbTime);
            this.gradientPanel1.Controls.Add(this.lbThoigian);
            this.gradientPanel1.Controls.Add(this.lbDate);
            this.gradientPanel1.Controls.Add(this.lbTrangthai);
            this.gradientPanel1.Controls.Add(this.label8);
            this.gradientPanel1.Controls.Add(this.lbSetpoint);
            this.gradientPanel1.Controls.Add(this.tbIDdonhang);
            this.gradientPanel1.Controls.Add(this.label14);
            this.gradientPanel1.Controls.Add(this.label5);
            this.gradientPanel1.Controls.Add(this.lbThanhtien);
            this.gradientPanel1.Controls.Add(this.lbDongia);
            this.gradientPanel1.Controls.Add(this.label7);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(1100, 718);
            this.gradientPanel1.TabIndex = 48;
            this.gradientPanel1.TopColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(27)))), ((int)(((byte)(37)))));
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gainsboro;
            this.label11.Location = new System.Drawing.Point(21, 561);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(443, 17);
            this.label11.TabIndex = 109;
            this.label11.Text = "(Quý khách vui lòng quét mã QR để biết thêm thông tin về đơn hàng)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(490, 16);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(439, 29);
            this.label10.TabIndex = 108;
            this.label10.Text = "CÔNG TY XĂNG DẦU B12 HẢI DƯƠNG";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbCustomerPhone
            // 
            this.tbCustomerPhone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbCustomerPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustomerPhone.Location = new System.Drawing.Point(651, 523);
            this.tbCustomerPhone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbCustomerPhone.MaxLength = 200;
            this.tbCustomerPhone.Name = "tbCustomerPhone";
            this.tbCustomerPhone.Size = new System.Drawing.Size(278, 26);
            this.tbCustomerPhone.TabIndex = 107;
            this.tbCustomerPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(465, 526);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 20);
            this.label6.TabIndex = 106;
            this.label6.Text = "Số điện thoại (*):";
            // 
            // tbCustomerAddr
            // 
            this.tbCustomerAddr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbCustomerAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustomerAddr.Location = new System.Drawing.Point(650, 483);
            this.tbCustomerAddr.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbCustomerAddr.MaxLength = 200;
            this.tbCustomerAddr.Name = "tbCustomerAddr";
            this.tbCustomerAddr.Size = new System.Drawing.Size(278, 26);
            this.tbCustomerAddr.TabIndex = 105;
            this.tbCustomerAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(464, 486);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 104;
            this.label4.Text = "Địa chỉ (*):";
            // 
            // tbCustomerName
            // 
            this.tbCustomerName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustomerName.Location = new System.Drawing.Point(650, 444);
            this.tbCustomerName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbCustomerName.MaxLength = 200;
            this.tbCustomerName.Name = "tbCustomerName";
            this.tbCustomerName.Size = new System.Drawing.Size(278, 26);
            this.tbCustomerName.TabIndex = 103;
            this.tbCustomerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(464, 446);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 20);
            this.label3.TabIndex = 102;
            this.label3.Text = "Tên khách hàng (*):";
            // 
            // pictureBoxQRCode
            // 
            this.pictureBoxQRCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBoxQRCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxQRCode.Location = new System.Drawing.Point(92, 223);
            this.pictureBoxQRCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxQRCode.Name = "pictureBoxQRCode";
            this.pictureBoxQRCode.Size = new System.Drawing.Size(300, 325);
            this.pictureBoxQRCode.TabIndex = 101;
            this.pictureBoxQRCode.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(464, 207);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 99;
            this.label2.Text = "Họng xuất:";
            // 
            // lbThroat
            // 
            this.lbThroat.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbThroat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThroat.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbThroat.Location = new System.Drawing.Point(651, 205);
            this.lbThroat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbThroat.Name = "lbThroat";
            this.lbThroat.Size = new System.Drawing.Size(278, 24);
            this.lbThroat.TabIndex = 100;
            this.lbThroat.Text = "----";
            this.lbThroat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(464, 167);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 97;
            this.label1.Text = "Sản phẩm:";
            // 
            // lbTankName
            // 
            this.lbTankName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbTankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTankName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbTankName.Location = new System.Drawing.Point(651, 165);
            this.lbTankName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTankName.Name = "lbTankName";
            this.lbTankName.Size = new System.Drawing.Size(278, 24);
            this.lbTankName.TabIndex = 98;
            this.lbTankName.Text = "----";
            this.lbTankName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(146)))), ((int)(((byte)(193)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(651, 585);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(278, 41);
            this.button1.TabIndex = 96;
            this.button1.Text = "Xuất hóa đơn";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gainsboro;
            this.label9.Location = new System.Drawing.Point(464, 406);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 20);
            this.label9.TabIndex = 95;
            this.label9.Text = "Thời gian:";
            // 
            // lbT
            // 
            this.lbT.AutoSize = true;
            this.lbT.BackColor = System.Drawing.Color.Transparent;
            this.lbT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbT.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbT.Location = new System.Drawing.Point(464, 366);
            this.lbT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbT.Name = "lbT";
            this.lbT.Size = new System.Drawing.Size(84, 20);
            this.lbT.TabIndex = 94;
            this.lbT.Text = "Trạng thái:";
            // 
            // lbTime
            // 
            this.lbTime.BackColor = System.Drawing.Color.Transparent;
            this.lbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 34.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbTime.Location = new System.Drawing.Point(56, 52);
            this.lbTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(308, 61);
            this.lbTime.TabIndex = 46;
            this.lbTime.Text = "11:00 AM";
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbThoigian
            // 
            this.lbThoigian.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbThoigian.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThoigian.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbThoigian.Location = new System.Drawing.Point(651, 404);
            this.lbThoigian.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbThoigian.Name = "lbThoigian";
            this.lbThoigian.Size = new System.Drawing.Size(278, 24);
            this.lbThoigian.TabIndex = 92;
            this.lbThoigian.Text = "----";
            this.lbThoigian.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDate
            // 
            this.lbDate.BackColor = System.Drawing.Color.Transparent;
            this.lbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDate.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbDate.Location = new System.Drawing.Point(27, 12);
            this.lbDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(364, 45);
            this.lbDate.TabIndex = 47;
            this.lbDate.Text = "Chủ Nhật, 30-01-2020";
            this.lbDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTrangthai
            // 
            this.lbTrangthai.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbTrangthai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTrangthai.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbTrangthai.Location = new System.Drawing.Point(651, 364);
            this.lbTrangthai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTrangthai.Name = "lbTrangthai";
            this.lbTrangthai.Size = new System.Drawing.Size(278, 24);
            this.lbTrangthai.TabIndex = 93;
            this.lbTrangthai.Text = "----";
            this.lbTrangthai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(464, 247);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 20);
            this.label8.TabIndex = 50;
            this.label8.Text = "Thể tích (l):";
            // 
            // lbSetpoint
            // 
            this.lbSetpoint.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbSetpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSetpoint.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbSetpoint.Location = new System.Drawing.Point(651, 245);
            this.lbSetpoint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSetpoint.Name = "lbSetpoint";
            this.lbSetpoint.Size = new System.Drawing.Size(278, 24);
            this.lbSetpoint.TabIndex = 91;
            this.lbSetpoint.Text = "----";
            this.lbSetpoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbIDdonhang
            // 
            this.tbIDdonhang.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbIDdonhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIDdonhang.Location = new System.Drawing.Point(650, 125);
            this.tbIDdonhang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbIDdonhang.MaxLength = 20;
            this.tbIDdonhang.Name = "tbIDdonhang";
            this.tbIDdonhang.Size = new System.Drawing.Size(278, 26);
            this.tbIDdonhang.TabIndex = 90;
            this.tbIDdonhang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbIDdonhang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbIDdonhang_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Gainsboro;
            this.label14.Location = new System.Drawing.Point(464, 128);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 20);
            this.label14.TabIndex = 89;
            this.label14.Text = "Mã đơn (*):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(464, 287);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 20);
            this.label5.TabIndex = 87;
            this.label5.Text = "Đơn giá (VND/l):";
            // 
            // lbThanhtien
            // 
            this.lbThanhtien.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbThanhtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThanhtien.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbThanhtien.Location = new System.Drawing.Point(651, 324);
            this.lbThanhtien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbThanhtien.Name = "lbThanhtien";
            this.lbThanhtien.Size = new System.Drawing.Size(278, 24);
            this.lbThanhtien.TabIndex = 88;
            this.lbThanhtien.Text = "----";
            this.lbThanhtien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDongia
            // 
            this.lbDongia.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbDongia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDongia.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbDongia.Location = new System.Drawing.Point(651, 284);
            this.lbDongia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDongia.Name = "lbDongia";
            this.lbDongia.Size = new System.Drawing.Size(278, 24);
            this.lbDongia.TabIndex = 88;
            this.lbDongia.Text = "----";
            this.lbDongia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(464, 327);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 20);
            this.label7.TabIndex = 87;
            this.label7.Text = "Thành tiền (x1000VND):";
            // 
            // TrangchuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1100, 718);
            this.Controls.Add(this.gradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TrangchuForm";
            this.Text = "Trangchu";
            this.Load += new System.EventHandler(this.TrangchuForm_Load);
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQRCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Timer DateTimeTimer;
        private GradientPanel gradientPanel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbThanhtien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbDongia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbSetpoint;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbIDdonhang;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbT;
        private System.Windows.Forms.Label lbThoigian;
        private System.Windows.Forms.Label lbTrangthai;
        private System.Windows.Forms.Button button1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbThroat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTankName;
        private System.Windows.Forms.PictureBox pictureBoxQRCode;
        private System.Windows.Forms.TextBox tbCustomerAddr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCustomerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCustomerPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}