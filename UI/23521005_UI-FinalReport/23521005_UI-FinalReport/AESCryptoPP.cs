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
    public partial class AESCryptoPP: Form
    {
        public AESCryptoPP()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[] {
                "ECB", "CBC", "OFB", "CFB", "CTR", "XTS", "CCM", "GCM"
            });

            comboBox1.SelectedIndex = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All files (*.*)|*.*"; // theo định *.pem

                try
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        textBox1.Text = filePath;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Choose file error! ", ex.Message);
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All files (*.*)|*.*"; // theo định *.pem

                try
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        textBox2.Text = filePath;

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
