
namespace XANGDAU
{
    partial class CaidatForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaidatForm));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.gradientPanel1 = new XANGDAU.GradientPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btphuchoidulieu = new System.Windows.Forms.Button();
            this.btsaoluudulieu = new System.Windows.Forms.Button();
            this.groupboxPLC = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TextboxIP = new System.Windows.Forms.TextBox();
            this.PLCStatus = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BtPlcConnect = new System.Windows.Forms.Button();
            this.cbCPUType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gradientPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupboxPLC.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipTitle = "MET System";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.AllowDrop = true;
            this.gradientPanel1.Angle = 0F;
            this.gradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(65)))), ((int)(((byte)(94)))));
            this.gradientPanel1.BottomColor = System.Drawing.Color.Empty;
            this.gradientPanel1.Controls.Add(this.groupBox4);
            this.gradientPanel1.Controls.Add(this.groupboxPLC);
            this.gradientPanel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(1467, 884);
            this.gradientPanel1.TabIndex = 54;
            this.gradientPanel1.TopColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(27)))), ((int)(((byte)(37)))));
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.btphuchoidulieu);
            this.groupBox4.Controls.Add(this.btsaoluudulieu);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox4.Location = new System.Drawing.Point(65, 265);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(533, 166);
            this.groupBox4.TabIndex = 86;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sao lưu và phục hồi";
            // 
            // btphuchoidulieu
            // 
            this.btphuchoidulieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btphuchoidulieu.ForeColor = System.Drawing.Color.Black;
            this.btphuchoidulieu.Location = new System.Drawing.Point(36, 97);
            this.btphuchoidulieu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btphuchoidulieu.Name = "btphuchoidulieu";
            this.btphuchoidulieu.Size = new System.Drawing.Size(453, 34);
            this.btphuchoidulieu.TabIndex = 88;
            this.btphuchoidulieu.Text = "Phục hồi dữ liệu";
            this.btphuchoidulieu.UseVisualStyleBackColor = true;
            this.btphuchoidulieu.Click += new System.EventHandler(this.btphuchoidulieu_Click);
            // 
            // btsaoluudulieu
            // 
            this.btsaoluudulieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btsaoluudulieu.ForeColor = System.Drawing.Color.Black;
            this.btsaoluudulieu.Location = new System.Drawing.Point(36, 46);
            this.btsaoluudulieu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btsaoluudulieu.Name = "btsaoluudulieu";
            this.btsaoluudulieu.Size = new System.Drawing.Size(453, 34);
            this.btsaoluudulieu.TabIndex = 87;
            this.btsaoluudulieu.Text = "Sao lưu dữ liệu";
            this.btsaoluudulieu.UseVisualStyleBackColor = true;
            this.btsaoluudulieu.Click += new System.EventHandler(this.btsaoluudulieu_Click);
            // 
            // groupboxPLC
            // 
            this.groupboxPLC.BackColor = System.Drawing.Color.Transparent;
            this.groupboxPLC.Controls.Add(this.label7);
            this.groupboxPLC.Controls.Add(this.TextboxIP);
            this.groupboxPLC.Controls.Add(this.PLCStatus);
            this.groupboxPLC.Controls.Add(this.label8);
            this.groupboxPLC.Controls.Add(this.BtPlcConnect);
            this.groupboxPLC.Controls.Add(this.cbCPUType);
            this.groupboxPLC.Controls.Add(this.label9);
            this.groupboxPLC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupboxPLC.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupboxPLC.Location = new System.Drawing.Point(65, 56);
            this.groupboxPLC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupboxPLC.Name = "groupboxPLC";
            this.groupboxPLC.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupboxPLC.Size = new System.Drawing.Size(533, 175);
            this.groupboxPLC.TabIndex = 72;
            this.groupboxPLC.TabStop = false;
            this.groupboxPLC.Text = "PLC";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(23, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 24);
            this.label7.TabIndex = 76;
            this.label7.Text = "CPU:";
            // 
            // TextboxIP
            // 
            this.TextboxIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextboxIP.Location = new System.Drawing.Point(135, 78);
            this.TextboxIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextboxIP.MaxLength = 20;
            this.TextboxIP.Name = "TextboxIP";
            this.TextboxIP.Size = new System.Drawing.Size(240, 27);
            this.TextboxIP.TabIndex = 51;
            this.TextboxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PLCStatus
            // 
            this.PLCStatus.BackColor = System.Drawing.Color.White;
            this.PLCStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PLCStatus.ForeColor = System.Drawing.Color.Red;
            this.PLCStatus.Location = new System.Drawing.Point(135, 121);
            this.PLCStatus.Name = "PLCStatus";
            this.PLCStatus.Size = new System.Drawing.Size(240, 27);
            this.PLCStatus.TabIndex = 51;
            this.PLCStatus.Text = "Chưa kết nối";
            this.PLCStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(23, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 24);
            this.label8.TabIndex = 50;
            this.label8.Text = "PLC IP:";
            // 
            // BtPlcConnect
            // 
            this.BtPlcConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtPlcConnect.ForeColor = System.Drawing.Color.Black;
            this.BtPlcConnect.Location = new System.Drawing.Point(389, 32);
            this.BtPlcConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtPlcConnect.Name = "BtPlcConnect";
            this.BtPlcConnect.Size = new System.Drawing.Size(125, 34);
            this.BtPlcConnect.TabIndex = 52;
            this.BtPlcConnect.Text = "Kết nối";
            this.BtPlcConnect.UseVisualStyleBackColor = true;
            this.BtPlcConnect.Click += new System.EventHandler(this.BtPlcConnect_Click);
            // 
            // cbCPUType
            // 
            this.cbCPUType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCPUType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCPUType.FormattingEnabled = true;
            this.cbCPUType.Items.AddRange(new object[] {
            "S7 1200",
            "S7 1500",
            "S7 200",
            "S7 300",
            "S7 400"});
            this.cbCPUType.Location = new System.Drawing.Point(135, 34);
            this.cbCPUType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCPUType.Name = "cbCPUType";
            this.cbCPUType.Size = new System.Drawing.Size(240, 28);
            this.cbCPUType.TabIndex = 75;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(23, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 24);
            this.label9.TabIndex = 51;
            this.label9.Text = "Trạng thái:";
            // 
            // CaidatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 884);
            this.Controls.Add(this.gradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CaidatForm";
            this.Text = "Caidat";
            this.Load += new System.EventHandler(this.CaidatForm_Load);
            this.gradientPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupboxPLC.ResumeLayout(false);
            this.groupboxPLC.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GradientPanel gradientPanel1;
        private System.Windows.Forms.Button BtPlcConnect;
        private System.Windows.Forms.Label PLCStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TextboxIP;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupboxPLC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbCPUType;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btphuchoidulieu;
        private System.Windows.Forms.Button btsaoluudulieu;
    }
}