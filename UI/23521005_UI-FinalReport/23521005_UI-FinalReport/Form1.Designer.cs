namespace _23521005_UI_FinalReport
{
    partial class RSA
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
            this.button_RSA = new System.Windows.Forms.Button();
            this.groupBox_RSA = new System.Windows.Forms.GroupBox();
            this.button_en = new System.Windows.Forms.Button();
            this.button_de = new System.Windows.Forms.Button();
            this.button_genkey = new System.Windows.Forms.Button();
            this.button_pub = new System.Windows.Forms.Button();
            this.button_pri = new System.Windows.Forms.Button();
            this.textBox_pub = new System.Windows.Forms.TextBox();
            this.textBox_pri = new System.Windows.Forms.TextBox();
            this.textBox_curve = new System.Windows.Forms.TextBox();
            this.label_pub = new System.Windows.Forms.Label();
            this.label_pri = new System.Windows.Forms.Label();
            this.label_curve = new System.Windows.Forms.Label();
            this.groupBox_RSA.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_RSA
            // 
            this.button_RSA.BackColor = System.Drawing.Color.Maroon;
            this.button_RSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_RSA.ForeColor = System.Drawing.Color.White;
            this.button_RSA.Location = new System.Drawing.Point(22, 23);
            this.button_RSA.Name = "button_RSA";
            this.button_RSA.Size = new System.Drawing.Size(137, 29);
            this.button_RSA.TabIndex = 1;
            this.button_RSA.Text = " RSA";
            this.button_RSA.UseVisualStyleBackColor = false;
            this.button_RSA.Click += new System.EventHandler(this.button_RSA_Click);
            // 
            // groupBox_RSA
            // 
            this.groupBox_RSA.BackColor = System.Drawing.Color.Cornsilk;
            this.groupBox_RSA.Controls.Add(this.button_en);
            this.groupBox_RSA.Controls.Add(this.button_de);
            this.groupBox_RSA.Controls.Add(this.button_genkey);
            this.groupBox_RSA.Controls.Add(this.button_pub);
            this.groupBox_RSA.Controls.Add(this.button_pri);
            this.groupBox_RSA.Controls.Add(this.textBox_pub);
            this.groupBox_RSA.Controls.Add(this.textBox_pri);
            this.groupBox_RSA.Controls.Add(this.textBox_curve);
            this.groupBox_RSA.Controls.Add(this.label_pub);
            this.groupBox_RSA.Controls.Add(this.label_pri);
            this.groupBox_RSA.Controls.Add(this.label_curve);
            this.groupBox_RSA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox_RSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_RSA.ForeColor = System.Drawing.Color.Black;
            this.groupBox_RSA.Location = new System.Drawing.Point(22, 58);
            this.groupBox_RSA.Name = "groupBox_RSA";
            this.groupBox_RSA.Size = new System.Drawing.Size(960, 480);
            this.groupBox_RSA.TabIndex = 4;
            this.groupBox_RSA.TabStop = false;
            this.groupBox_RSA.Text = "WORK SPACE";
            // 
            // button_en
            // 
            this.button_en.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_en.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_en.ForeColor = System.Drawing.Color.Black;
            this.button_en.Location = new System.Drawing.Point(460, 250);
            this.button_en.Name = "button_en";
            this.button_en.Size = new System.Drawing.Size(168, 26);
            this.button_en.TabIndex = 9;
            this.button_en.Text = "Encryption";
            this.button_en.UseVisualStyleBackColor = false;
            // 
            // button_de
            // 
            this.button_de.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_de.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_de.ForeColor = System.Drawing.Color.Black;
            this.button_de.Location = new System.Drawing.Point(666, 250);
            this.button_de.Name = "button_de";
            this.button_de.Size = new System.Drawing.Size(168, 26);
            this.button_de.TabIndex = 8;
            this.button_de.Text = "Decryprion";
            this.button_de.UseVisualStyleBackColor = false;
            // 
            // button_genkey
            // 
            this.button_genkey.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_genkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_genkey.ForeColor = System.Drawing.Color.Black;
            this.button_genkey.Location = new System.Drawing.Point(247, 250);
            this.button_genkey.Name = "button_genkey";
            this.button_genkey.Size = new System.Drawing.Size(168, 26);
            this.button_genkey.TabIndex = 7;
            this.button_genkey.Text = "Generate key";
            this.button_genkey.UseVisualStyleBackColor = false;
            // 
            // button_pub
            // 
            this.button_pub.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_pub.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_pub.ForeColor = System.Drawing.Color.Black;
            this.button_pub.Location = new System.Drawing.Point(852, 187);
            this.button_pub.Name = "button_pub";
            this.button_pub.Size = new System.Drawing.Size(90, 22);
            this.button_pub.TabIndex = 6;
            this.button_pub.Text = "Browse...";
            this.button_pub.UseVisualStyleBackColor = false;
            this.button_pub.Click += new System.EventHandler(this.button_pubECDSA_Click);
            // 
            // button_pri
            // 
            this.button_pri.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_pri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_pri.ForeColor = System.Drawing.Color.Black;
            this.button_pri.Location = new System.Drawing.Point(852, 122);
            this.button_pri.Name = "button_pri";
            this.button_pri.Size = new System.Drawing.Size(90, 22);
            this.button_pri.TabIndex = 5;
            this.button_pri.Text = "Browse...";
            this.button_pri.UseVisualStyleBackColor = false;
            this.button_pri.Click += new System.EventHandler(this.button_priECDSA_Click);
            // 
            // textBox_pub
            // 
            this.textBox_pub.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_pub.Location = new System.Drawing.Point(247, 187);
            this.textBox_pub.Name = "textBox_pub";
            this.textBox_pub.Size = new System.Drawing.Size(587, 22);
            this.textBox_pub.TabIndex = 5;
            // 
            // textBox_pri
            // 
            this.textBox_pri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_pri.Location = new System.Drawing.Point(247, 122);
            this.textBox_pri.Name = "textBox_pri";
            this.textBox_pri.Size = new System.Drawing.Size(587, 22);
            this.textBox_pri.TabIndex = 4;
            // 
            // textBox_curve
            // 
            this.textBox_curve.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_curve.Location = new System.Drawing.Point(247, 62);
            this.textBox_curve.Name = "textBox_curve";
            this.textBox_curve.Size = new System.Drawing.Size(587, 22);
            this.textBox_curve.TabIndex = 3;
            // 
            // label_pub
            // 
            this.label_pub.AutoSize = true;
            this.label_pub.Location = new System.Drawing.Point(40, 189);
            this.label_pub.Name = "label_pub";
            this.label_pub.Size = new System.Drawing.Size(133, 20);
            this.label_pub.TabIndex = 2;
            this.label_pub.Text = "Public Key Path";
            // 
            // label_pri
            // 
            this.label_pri.AutoSize = true;
            this.label_pri.Location = new System.Drawing.Point(40, 124);
            this.label_pri.Name = "label_pri";
            this.label_pri.Size = new System.Drawing.Size(140, 20);
            this.label_pri.TabIndex = 1;
            this.label_pri.Text = "Private Key Path";
            // 
            // label_curve
            // 
            this.label_curve.AutoSize = true;
            this.label_curve.Location = new System.Drawing.Point(40, 64);
            this.label_curve.Name = "label_curve";
            this.label_curve.Size = new System.Drawing.Size(106, 20);
            this.label_curve.TabIndex = 0;
            this.label_curve.Text = "Curve Name";
            // 
            // RSA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.groupBox_RSA);
            this.Controls.Add(this.button_RSA);
            this.Name = "RSA";
            this.Text = "[RSA] Crypto Functions GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_RSA.ResumeLayout(false);
            this.groupBox_RSA.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_RSA;
        private System.Windows.Forms.GroupBox groupBox_RSA;
        private System.Windows.Forms.Button button_pri;
        private System.Windows.Forms.TextBox textBox_pub;
        private System.Windows.Forms.TextBox textBox_pri;
        private System.Windows.Forms.TextBox textBox_curve;
        private System.Windows.Forms.Label label_pub;
        private System.Windows.Forms.Label label_pri;
        private System.Windows.Forms.Label label_curve;
        private System.Windows.Forms.Button button_pub;
        private System.Windows.Forms.Button button_en;
        private System.Windows.Forms.Button button_de;
        private System.Windows.Forms.Button button_genkey;
    }
}

