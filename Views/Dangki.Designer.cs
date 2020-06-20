namespace Kindle.Views
{
    partial class Dangki
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDangKi = new System.Windows.Forms.TextBox();
            this.txtPassdangki = new System.Windows.Forms.TextBox();
            this.txtXNPass = new System.Windows.Forms.TextBox();
            this.btnCloseDangki = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ten dang nhap : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mat khau : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Xac nhan mat khau :";
            // 
            // txtDangKi
            // 
            this.txtDangKi.Location = new System.Drawing.Point(343, 159);
            this.txtDangKi.Name = "txtDangKi";
            this.txtDangKi.Size = new System.Drawing.Size(231, 31);
            this.txtDangKi.TabIndex = 3;
            // 
            // txtPassdangki
            // 
            this.txtPassdangki.Location = new System.Drawing.Point(343, 201);
            this.txtPassdangki.Name = "txtPassdangki";
            this.txtPassdangki.Size = new System.Drawing.Size(231, 31);
            this.txtPassdangki.TabIndex = 4;
            // 
            // txtXNPass
            // 
            this.txtXNPass.Location = new System.Drawing.Point(343, 247);
            this.txtXNPass.Name = "txtXNPass";
            this.txtXNPass.Size = new System.Drawing.Size(231, 31);
            this.txtXNPass.TabIndex = 5;
            // 
            // btnCloseDangki
            // 
            this.btnCloseDangki.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCloseDangki.Location = new System.Drawing.Point(480, 318);
            this.btnCloseDangki.Name = "btnCloseDangki";
            this.btnCloseDangki.Size = new System.Drawing.Size(94, 46);
            this.btnCloseDangki.TabIndex = 6;
            this.btnCloseDangki.Text = "Close";
            this.btnCloseDangki.UseVisualStyleBackColor = false;
            this.btnCloseDangki.Click += new System.EventHandler(this.btnCloseDangki_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Location = new System.Drawing.Point(343, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 46);
            this.button1.TabIndex = 7;
            this.button1.Text = "Dang ki";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Info;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(63, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 63);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dang Ki";
            // 
            // Dangki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Kindle.Properties.Resources._8057a6909bb7d0d;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCloseDangki);
            this.Controls.Add(this.txtXNPass);
            this.Controls.Add(this.txtPassdangki);
            this.Controls.Add(this.txtDangKi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Dangki";
            this.Text = "Dangki";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDangKi;
        private System.Windows.Forms.TextBox txtPassdangki;
        private System.Windows.Forms.TextBox txtXNPass;
        private System.Windows.Forms.Button btnCloseDangki;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
    }
}