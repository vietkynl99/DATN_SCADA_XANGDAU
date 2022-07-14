
namespace XANGDAU
{
    partial class PopUpMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopUpMenuForm));
            this.btChangePassword = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btChangePassword
            // 
            this.btChangePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(39)))), ((int)(((byte)(66)))));
            this.btChangePassword.FlatAppearance.BorderSize = 0;
            this.btChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btChangePassword.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btChangePassword.Image = global::XANGDAU.Properties.Resources.change_password_w20;
            this.btChangePassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btChangePassword.Location = new System.Drawing.Point(1, 1);
            this.btChangePassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btChangePassword.Name = "btChangePassword";
            this.btChangePassword.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btChangePassword.Size = new System.Drawing.Size(184, 37);
            this.btChangePassword.TabIndex = 1;
            this.btChangePassword.Text = "      Đổi mật khẩu";
            this.btChangePassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btChangePassword.UseVisualStyleBackColor = false;
            this.btChangePassword.Click += new System.EventHandler(this.btChangePassword_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(39)))), ((int)(((byte)(66)))));
            this.buttonLogout.FlatAppearance.BorderSize = 0;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonLogout.Image = global::XANGDAU.Properties.Resources.logout_w20;
            this.buttonLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLogout.Location = new System.Drawing.Point(1, 37);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.buttonLogout.Size = new System.Drawing.Size(184, 37);
            this.buttonLogout.TabIndex = 0;
            this.buttonLogout.Text = "      Đăng xuất";
            this.buttonLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // PopUpMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(186, 75);
            this.Controls.Add(this.btChangePassword);
            this.Controls.Add(this.buttonLogout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PopUpMenuForm";
            this.Text = "PopUpMenu";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btChangePassword;
        private System.Windows.Forms.Button buttonLogout;
    }
}