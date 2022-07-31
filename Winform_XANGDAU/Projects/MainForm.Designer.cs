
namespace XANGDAU
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelUserInfo = new System.Windows.Forms.Panel();
            this.lbFullName = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonMinimize = new System.Windows.Forms.PictureBox();
            this.buttonMaximize = new System.Windows.Forms.PictureBox();
            this.buttonClose = new System.Windows.Forms.PictureBox();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.MenuSukien = new System.Windows.Forms.Button();
            this.MenuLichsu = new System.Windows.Forms.Button();
            this.MenuTrangchu = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(95)))), ((int)(((byte)(134)))));
            this.panel1.Controls.Add(this.MenuSukien);
            this.panel1.Controls.Add(this.MenuLichsu);
            this.panel1.Controls.Add(this.MenuTrangchu);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 718);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(95)))), ((int)(((byte)(134)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(177, 173);
            this.panel2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(21, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 75);
            this.label1.TabIndex = 0;
            this.label1.Text = "PHẦN MỀM NHẬP XUẤT XĂNG DẦU";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelUserInfo
            // 
            this.panelUserInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(27)))), ((int)(((byte)(37)))));
            this.panelUserInfo.Controls.Add(this.buttonMinimize);
            this.panelUserInfo.Controls.Add(this.buttonMaximize);
            this.panelUserInfo.Controls.Add(this.buttonClose);
            this.panelUserInfo.Controls.Add(this.lbFullName);
            this.panelUserInfo.Controls.Add(this.picUser);
            this.panelUserInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUserInfo.Location = new System.Drawing.Point(177, 0);
            this.panelUserInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelUserInfo.Name = "panelUserInfo";
            this.panelUserInfo.Size = new System.Drawing.Size(990, 61);
            this.panelUserInfo.TabIndex = 0;
            this.panelUserInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelUserInfo_MouseDown);
            // 
            // lbFullName
            // 
            this.lbFullName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFullName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbFullName.Location = new System.Drawing.Point(599, 21);
            this.lbFullName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbFullName.Name = "lbFullName";
            this.lbFullName.Size = new System.Drawing.Size(226, 20);
            this.lbFullName.TabIndex = 1;
            this.lbFullName.Text = "Đỗ Hoàng Việt";
            this.lbFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(177, 61);
            this.panelContent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(990, 657);
            this.panelContent.TabIndex = 5;
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMinimize.Image = global::XANGDAU.Properties.Resources.minimize_w40;
            this.buttonMinimize.Location = new System.Drawing.Point(884, 18);
            this.buttonMinimize.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(22, 24);
            this.buttonMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonMinimize.TabIndex = 24;
            this.buttonMinimize.TabStop = false;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // buttonMaximize
            // 
            this.buttonMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMaximize.Image = ((System.Drawing.Image)(resources.GetObject("buttonMaximize.Image")));
            this.buttonMaximize.Location = new System.Drawing.Point(918, 20);
            this.buttonMaximize.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMaximize.Name = "buttonMaximize";
            this.buttonMaximize.Size = new System.Drawing.Size(16, 18);
            this.buttonMaximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonMaximize.TabIndex = 23;
            this.buttonMaximize.TabStop = false;
            this.buttonMaximize.Click += new System.EventHandler(this.buttonMaximize_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.Image = global::XANGDAU.Properties.Resources.close_w30;
            this.buttonClose.Location = new System.Drawing.Point(948, 20);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(20, 22);
            this.buttonClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonClose.TabIndex = 22;
            this.buttonClose.TabStop = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // picUser
            // 
            this.picUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picUser.BackColor = System.Drawing.Color.Transparent;
            this.picUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUser.Image = global::XANGDAU.Properties.Resources.AvatarUser;
            this.picUser.Location = new System.Drawing.Point(833, 12);
            this.picUser.Margin = new System.Windows.Forms.Padding(2);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(34, 37);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUser.TabIndex = 7;
            this.picUser.TabStop = false;
            this.picUser.Click += new System.EventHandler(this.picUser_Click);
            // 
            // MenuSukien
            // 
            this.MenuSukien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MenuSukien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuSukien.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuSukien.FlatAppearance.BorderSize = 0;
            this.MenuSukien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuSukien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuSukien.ForeColor = System.Drawing.Color.Gainsboro;
            this.MenuSukien.Image = global::XANGDAU.Properties.Resources.Event_w35;
            this.MenuSukien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MenuSukien.Location = new System.Drawing.Point(0, 335);
            this.MenuSukien.Margin = new System.Windows.Forms.Padding(2);
            this.MenuSukien.Name = "MenuSukien";
            this.MenuSukien.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.MenuSukien.Size = new System.Drawing.Size(177, 81);
            this.MenuSukien.TabIndex = 8;
            this.MenuSukien.Text = "             Sự kiện";
            this.MenuSukien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MenuSukien.UseVisualStyleBackColor = true;
            this.MenuSukien.Click += new System.EventHandler(this.MenuMophong_Click);
            // 
            // MenuLichsu
            // 
            this.MenuLichsu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MenuLichsu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuLichsu.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuLichsu.FlatAppearance.BorderSize = 0;
            this.MenuLichsu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuLichsu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuLichsu.ForeColor = System.Drawing.Color.Gainsboro;
            this.MenuLichsu.Image = global::XANGDAU.Properties.Resources.history_w35;
            this.MenuLichsu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MenuLichsu.Location = new System.Drawing.Point(0, 254);
            this.MenuLichsu.Margin = new System.Windows.Forms.Padding(2);
            this.MenuLichsu.Name = "MenuLichsu";
            this.MenuLichsu.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.MenuLichsu.Size = new System.Drawing.Size(177, 81);
            this.MenuLichsu.TabIndex = 7;
            this.MenuLichsu.Text = "             Lịch sử";
            this.MenuLichsu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MenuLichsu.UseVisualStyleBackColor = true;
            this.MenuLichsu.Click += new System.EventHandler(this.MenuBaocao_Click);
            // 
            // MenuTrangchu
            // 
            this.MenuTrangchu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MenuTrangchu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuTrangchu.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuTrangchu.FlatAppearance.BorderSize = 0;
            this.MenuTrangchu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuTrangchu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuTrangchu.ForeColor = System.Drawing.Color.Gainsboro;
            this.MenuTrangchu.Image = global::XANGDAU.Properties.Resources.Home_w35;
            this.MenuTrangchu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MenuTrangchu.Location = new System.Drawing.Point(0, 173);
            this.MenuTrangchu.Margin = new System.Windows.Forms.Padding(2);
            this.MenuTrangchu.Name = "MenuTrangchu";
            this.MenuTrangchu.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.MenuTrangchu.Size = new System.Drawing.Size(177, 81);
            this.MenuTrangchu.TabIndex = 0;
            this.MenuTrangchu.Text = "             Trang chủ";
            this.MenuTrangchu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MenuTrangchu.UseVisualStyleBackColor = true;
            this.MenuTrangchu.Click += new System.EventHandler(this.MenuTrangchu_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(95)))), ((int)(((byte)(134)))));
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::XANGDAU.Properties.Resources.Hust;
            this.pictureBox2.Location = new System.Drawing.Point(48, 16);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(76, 72);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 718);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelUserInfo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quan trắc thời tiết MET";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelUserInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button MenuTrangchu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button MenuSukien;
        private System.Windows.Forms.Button MenuLichsu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelUserInfo;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.Label lbFullName;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.PictureBox buttonMaximize;
        private System.Windows.Forms.PictureBox buttonClose;
        private System.Windows.Forms.PictureBox buttonMinimize;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolTip toolTip;
    }
}