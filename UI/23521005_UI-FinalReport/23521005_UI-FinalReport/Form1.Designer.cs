namespace _23521005_UI_FinalReport
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
            this.button_ECDSA = new System.Windows.Forms.Button();
            this.button_RSA = new System.Windows.Forms.Button();
            this.button_cert = new System.Windows.Forms.Button();
            this.button_CSR = new System.Windows.Forms.Button();
            this.groupBox_ECDSA = new System.Windows.Forms.GroupBox();
            this.label_curveECDSA = new System.Windows.Forms.Label();
            this.label_priECDSA = new System.Windows.Forms.Label();
            this.label_pubECDSA = new System.Windows.Forms.Label();
            this.textBox_curveECDSA = new System.Windows.Forms.TextBox();
            this.textBox_priECDSA = new System.Windows.Forms.TextBox();
            this.textBox_pubECDSA = new System.Windows.Forms.TextBox();
            this.button_priECDSA = new System.Windows.Forms.Button();
            this.button_pubECDSA = new System.Windows.Forms.Button();
            this.button_genkeyECDSA = new System.Windows.Forms.Button();
            this.button_deECDSA = new System.Windows.Forms.Button();
            this.button_enECDSA = new System.Windows.Forms.Button();
            this.groupBox_ECDSA.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_ECDSA
            // 
            this.button_ECDSA.BackColor = System.Drawing.Color.Maroon;
            this.button_ECDSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ECDSA.ForeColor = System.Drawing.Color.White;
            this.button_ECDSA.Location = new System.Drawing.Point(22, 23);
            this.button_ECDSA.Name = "button_ECDSA";
            this.button_ECDSA.Size = new System.Drawing.Size(137, 29);
            this.button_ECDSA.TabIndex = 0;
            this.button_ECDSA.Text = "ECDSA";
            this.button_ECDSA.UseVisualStyleBackColor = false;
            this.button_ECDSA.Click += new System.EventHandler(this.button_ECDSA_Click);
            // 
            // button_RSA
            // 
            this.button_RSA.BackColor = System.Drawing.Color.Maroon;
            this.button_RSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_RSA.ForeColor = System.Drawing.Color.White;
            this.button_RSA.Location = new System.Drawing.Point(178, 23);
            this.button_RSA.Name = "button_RSA";
            this.button_RSA.Size = new System.Drawing.Size(137, 29);
            this.button_RSA.TabIndex = 1;
            this.button_RSA.Text = " RSA";
            this.button_RSA.UseVisualStyleBackColor = false;
            this.button_RSA.Click += new System.EventHandler(this.button_RSA_Click);
            // 
            // button_cert
            // 
            this.button_cert.BackColor = System.Drawing.Color.Maroon;
            this.button_cert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cert.ForeColor = System.Drawing.Color.White;
            this.button_cert.Location = new System.Drawing.Point(332, 23);
            this.button_cert.Name = "button_cert";
            this.button_cert.Size = new System.Drawing.Size(137, 29);
            this.button_cert.TabIndex = 2;
            this.button_cert.Text = "Sefl-Signed Cert";
            this.button_cert.UseVisualStyleBackColor = false;
            // 
            // button_CSR
            // 
            this.button_CSR.BackColor = System.Drawing.Color.Maroon;
            this.button_CSR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CSR.ForeColor = System.Drawing.Color.White;
            this.button_CSR.Location = new System.Drawing.Point(491, 23);
            this.button_CSR.Name = "button_CSR";
            this.button_CSR.Size = new System.Drawing.Size(137, 29);
            this.button_CSR.TabIndex = 3;
            this.button_CSR.Text = "CSR";
            this.button_CSR.UseVisualStyleBackColor = false;
            // 
            // groupBox_ECDSA
            // 
            this.groupBox_ECDSA.BackColor = System.Drawing.Color.Cornsilk;
            this.groupBox_ECDSA.Controls.Add(this.button_enECDSA);
            this.groupBox_ECDSA.Controls.Add(this.button_deECDSA);
            this.groupBox_ECDSA.Controls.Add(this.button_genkeyECDSA);
            this.groupBox_ECDSA.Controls.Add(this.button_pubECDSA);
            this.groupBox_ECDSA.Controls.Add(this.button_priECDSA);
            this.groupBox_ECDSA.Controls.Add(this.textBox_pubECDSA);
            this.groupBox_ECDSA.Controls.Add(this.textBox_priECDSA);
            this.groupBox_ECDSA.Controls.Add(this.textBox_curveECDSA);
            this.groupBox_ECDSA.Controls.Add(this.label_pubECDSA);
            this.groupBox_ECDSA.Controls.Add(this.label_priECDSA);
            this.groupBox_ECDSA.Controls.Add(this.label_curveECDSA);
            this.groupBox_ECDSA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox_ECDSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_ECDSA.ForeColor = System.Drawing.Color.Black;
            this.groupBox_ECDSA.Location = new System.Drawing.Point(22, 58);
            this.groupBox_ECDSA.Name = "groupBox_ECDSA";
            this.groupBox_ECDSA.Size = new System.Drawing.Size(960, 480);
            this.groupBox_ECDSA.TabIndex = 4;
            this.groupBox_ECDSA.TabStop = false;
            this.groupBox_ECDSA.Text = "Work Space";
            // 
            // label_curveECDSA
            // 
            this.label_curveECDSA.AutoSize = true;
            this.label_curveECDSA.Location = new System.Drawing.Point(40, 64);
            this.label_curveECDSA.Name = "label_curveECDSA";
            this.label_curveECDSA.Size = new System.Drawing.Size(106, 20);
            this.label_curveECDSA.TabIndex = 0;
            this.label_curveECDSA.Text = "Curve Name";
            // 
            // label_priECDSA
            // 
            this.label_priECDSA.AutoSize = true;
            this.label_priECDSA.Location = new System.Drawing.Point(40, 124);
            this.label_priECDSA.Name = "label_priECDSA";
            this.label_priECDSA.Size = new System.Drawing.Size(140, 20);
            this.label_priECDSA.TabIndex = 1;
            this.label_priECDSA.Text = "Private Key Path";
            // 
            // label_pubECDSA
            // 
            this.label_pubECDSA.AutoSize = true;
            this.label_pubECDSA.Location = new System.Drawing.Point(40, 189);
            this.label_pubECDSA.Name = "label_pubECDSA";
            this.label_pubECDSA.Size = new System.Drawing.Size(133, 20);
            this.label_pubECDSA.TabIndex = 2;
            this.label_pubECDSA.Text = "Public Key Path";
            // 
            // textBox_curveECDSA
            // 
            this.textBox_curveECDSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_curveECDSA.Location = new System.Drawing.Point(247, 62);
            this.textBox_curveECDSA.Name = "textBox_curveECDSA";
            this.textBox_curveECDSA.Size = new System.Drawing.Size(587, 22);
            this.textBox_curveECDSA.TabIndex = 3;
            // 
            // textBox_priECDSA
            // 
            this.textBox_priECDSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_priECDSA.Location = new System.Drawing.Point(247, 122);
            this.textBox_priECDSA.Name = "textBox_priECDSA";
            this.textBox_priECDSA.Size = new System.Drawing.Size(587, 22);
            this.textBox_priECDSA.TabIndex = 4;
            // 
            // textBox_pubECDSA
            // 
            this.textBox_pubECDSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_pubECDSA.Location = new System.Drawing.Point(247, 187);
            this.textBox_pubECDSA.Name = "textBox_pubECDSA";
            this.textBox_pubECDSA.Size = new System.Drawing.Size(587, 22);
            this.textBox_pubECDSA.TabIndex = 5;
            // 
            // button_priECDSA
            // 
            this.button_priECDSA.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_priECDSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_priECDSA.ForeColor = System.Drawing.Color.Black;
            this.button_priECDSA.Location = new System.Drawing.Point(852, 122);
            this.button_priECDSA.Name = "button_priECDSA";
            this.button_priECDSA.Size = new System.Drawing.Size(90, 22);
            this.button_priECDSA.TabIndex = 5;
            this.button_priECDSA.Text = "Browse...";
            this.button_priECDSA.UseVisualStyleBackColor = false;
            this.button_priECDSA.Click += new System.EventHandler(this.button_priECDSA_Click);
            // 
            // button_pubECDSA
            // 
            this.button_pubECDSA.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_pubECDSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_pubECDSA.ForeColor = System.Drawing.Color.Black;
            this.button_pubECDSA.Location = new System.Drawing.Point(852, 187);
            this.button_pubECDSA.Name = "button_pubECDSA";
            this.button_pubECDSA.Size = new System.Drawing.Size(90, 22);
            this.button_pubECDSA.TabIndex = 6;
            this.button_pubECDSA.Text = "Browse...";
            this.button_pubECDSA.UseVisualStyleBackColor = false;
            this.button_pubECDSA.Click += new System.EventHandler(this.button_pubECDSA_Click);
            // 
            // button_genkeyECDSA
            // 
            this.button_genkeyECDSA.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_genkeyECDSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_genkeyECDSA.ForeColor = System.Drawing.Color.Black;
            this.button_genkeyECDSA.Location = new System.Drawing.Point(247, 250);
            this.button_genkeyECDSA.Name = "button_genkeyECDSA";
            this.button_genkeyECDSA.Size = new System.Drawing.Size(168, 26);
            this.button_genkeyECDSA.TabIndex = 7;
            this.button_genkeyECDSA.Text = "Generate key";
            this.button_genkeyECDSA.UseVisualStyleBackColor = false;
            // 
            // button_deECDSA
            // 
            this.button_deECDSA.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_deECDSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_deECDSA.ForeColor = System.Drawing.Color.Black;
            this.button_deECDSA.Location = new System.Drawing.Point(666, 250);
            this.button_deECDSA.Name = "button_deECDSA";
            this.button_deECDSA.Size = new System.Drawing.Size(168, 26);
            this.button_deECDSA.TabIndex = 8;
            this.button_deECDSA.Text = "Decryprion";
            this.button_deECDSA.UseVisualStyleBackColor = false;
            // 
            // button_enECDSA
            // 
            this.button_enECDSA.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_enECDSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_enECDSA.ForeColor = System.Drawing.Color.Black;
            this.button_enECDSA.Location = new System.Drawing.Point(460, 250);
            this.button_enECDSA.Name = "button_enECDSA";
            this.button_enECDSA.Size = new System.Drawing.Size(168, 26);
            this.button_enECDSA.TabIndex = 9;
            this.button_enECDSA.Text = "Encryption";
            this.button_enECDSA.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.groupBox_ECDSA);
            this.Controls.Add(this.button_CSR);
            this.Controls.Add(this.button_cert);
            this.Controls.Add(this.button_RSA);
            this.Controls.Add(this.button_ECDSA);
            this.Name = "Form1";
            this.Text = "Crypto Functions GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_ECDSA.ResumeLayout(false);
            this.groupBox_ECDSA.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_ECDSA;
        private System.Windows.Forms.Button button_RSA;
        private System.Windows.Forms.Button button_cert;
        private System.Windows.Forms.Button button_CSR;
        private System.Windows.Forms.GroupBox groupBox_ECDSA;
        private System.Windows.Forms.Button button_priECDSA;
        private System.Windows.Forms.TextBox textBox_pubECDSA;
        private System.Windows.Forms.TextBox textBox_priECDSA;
        private System.Windows.Forms.TextBox textBox_curveECDSA;
        private System.Windows.Forms.Label label_pubECDSA;
        private System.Windows.Forms.Label label_priECDSA;
        private System.Windows.Forms.Label label_curveECDSA;
        private System.Windows.Forms.Button button_pubECDSA;
        private System.Windows.Forms.Button button_enECDSA;
        private System.Windows.Forms.Button button_deECDSA;
        private System.Windows.Forms.Button button_genkeyECDSA;
    }
}

