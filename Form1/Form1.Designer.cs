namespace Form1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Login = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBoxInsta = new System.Windows.Forms.PictureBox();
            this.pictureBoxtwitter = new System.Windows.Forms.PictureBox();
            this.pictureBoxfb = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInsta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxtwitter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxfb)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(136, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.SystemColors.Window;
            this.txtUsername.Location = new System.Drawing.Point(86, 150);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(229, 22);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "Username";
            this.txtUsername.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtUsername_MouseClick);
            this.txtUsername.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.SystemColors.Window;
            this.txtPassword.Location = new System.Drawing.Point(89, 198);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(229, 22);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Text = "Password";
            this.txtPassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPassword_MouseClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(39, 155);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(41, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(39, 203);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(41, 22);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(86, 222);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 1);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(86, 174);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 1);
            this.panel2.TabIndex = 7;
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.Color.White;
            this.Login.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Login.Location = new System.Drawing.Point(116, 264);
            this.Login.Margin = new System.Windows.Forms.Padding(10);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(149, 39);
            this.Login.TabIndex = 8;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button2.Location = new System.Drawing.Point(116, 325);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 39);
            this.button2.TabIndex = 9;
            this.button2.Text = "Sign Up";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBoxInsta
            // 
            this.pictureBoxInsta.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxInsta.Image")));
            this.pictureBoxInsta.Location = new System.Drawing.Point(39, 430);
            this.pictureBoxInsta.Name = "pictureBoxInsta";
            this.pictureBoxInsta.Size = new System.Drawing.Size(61, 58);
            this.pictureBoxInsta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxInsta.TabIndex = 10;
            this.pictureBoxInsta.TabStop = false;
            this.pictureBoxInsta.Click += new System.EventHandler(this.pictureBoxInsta_Click);
            // 
            // pictureBoxtwitter
            // 
            this.pictureBoxtwitter.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxtwitter.Image")));
            this.pictureBoxtwitter.Location = new System.Drawing.Point(255, 430);
            this.pictureBoxtwitter.Name = "pictureBoxtwitter";
            this.pictureBoxtwitter.Size = new System.Drawing.Size(61, 58);
            this.pictureBoxtwitter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxtwitter.TabIndex = 11;
            this.pictureBoxtwitter.TabStop = false;
            this.pictureBoxtwitter.Click += new System.EventHandler(this.pictureBoxtwitter_Click);
            // 
            // pictureBoxfb
            // 
            this.pictureBoxfb.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxfb.Image")));
            this.pictureBoxfb.Location = new System.Drawing.Point(149, 430);
            this.pictureBoxfb.Name = "pictureBoxfb";
            this.pictureBoxfb.Size = new System.Drawing.Size(61, 58);
            this.pictureBoxfb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxfb.TabIndex = 12;
            this.pictureBoxfb.TabStop = false;
            this.pictureBoxfb.Click += new System.EventHandler(this.pictureBoxfb_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(337, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 28);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(364, 540);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBoxfb);
            this.Controls.Add(this.pictureBoxtwitter);
            this.Controls.Add(this.pictureBoxInsta);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInsta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxtwitter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxfb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBoxInsta;
        private System.Windows.Forms.PictureBox pictureBoxtwitter;
        private System.Windows.Forms.PictureBox pictureBoxfb;
        private System.Windows.Forms.Button btnClose;
    }
}

