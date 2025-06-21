using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23521005_UI_FinalReport
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_ECDSA_Click(object sender, EventArgs e)
        {
            groupBox_ECDSA.Visible = true;
        }

        private void button_RSA_Click(object sender, EventArgs e)
        {
            groupBox_ECDSA.Visible = false;
        }

        private void button_priECDSA_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All files (*.*)|*.*"; // theo định *.pem

                try
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        textBox_priECDSA.Text = filePath;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Choose file error! ",ex.Message);
                }
                
            }
        }

        private void button_pubECDSA_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All files (*.*)|*.*";

                try
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        textBox_pubECDSA.Text = filePath;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Choose file error! ", ex.Message);
                }

            }

        }
    }
}
