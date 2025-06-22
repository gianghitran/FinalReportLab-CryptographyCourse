using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23521005_UI_FinalReport
{
    public partial class AESCryptoPP: Form
    {
        const int AES_KEY_SIZE = 16;
        const int AES_IV_SIZE = 16;

        [DllImport("AES_KeyGen.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GenerateAESKey")]
        public static extern void GenerateAESKey(byte[] key, byte[] iv);

        [DllImport("AES_KeyGen.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SaveKeyToFile")]
        public static extern void SaveKeyToFile(string filename, byte[] key, byte[] iv);

        [DllImport("AES_KeyGen.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LoadKeyFromFile")]
        public static extern void LoadKeyFromFile(string filename, byte[] key, byte[] iv);

        [DllImport("AES_KeyGen.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "AESEncrypt")]
        public static extern void AESEncrypt(byte[] key, byte[] iv, string inputFile, string outputFile, string mode);

        [DllImport("AES_KeyGen.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "AESDecrypt")]
        public static extern void AESDecrypt(byte[] key, byte[] iv, string inputFile, string outputFile, string mode);




        public AESCryptoPP()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[] {
                "ECB", "CBC", "OFB", "CFB", "CTR", "XTS", "CCM", "GCM"
            });

            comboBox1.SelectedIndex = 0;
        }
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
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
        private void button3_Click(object sender, EventArgs e)//Genkey
        {
            byte[] key = new byte[AES_KEY_SIZE];
            byte[] iv = new byte[AES_IV_SIZE];
            GenerateAESKey(key, iv);

            textBox1.Text = BitConverter.ToString(key).Replace("-", "");
            textBox2.Text = BitConverter.ToString(iv).Replace("-", "");
        }
        private void button1_Click(object sender, EventArgs e) //Encrypt
        {
            string inputFile = richTextBox1.Text;
            string outputFile = richTextBox2.Text;
            string mode = comboBox1.SelectedItem.ToString();

            byte[] key = StringToByteArray(textBox1.Text);
            byte[] iv = StringToByteArray(textBox2.Text);

            AESEncrypt(key, iv, inputFile, outputFile, mode);
            MessageBox.Show("Encryption done.");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //Decrypt
        {
            string inputFile = richTextBox2.Text;
            string outputFile = richTextBox1.Text;
            string mode = comboBox1.SelectedItem.ToString();

            byte[] key = StringToByteArray(textBox1.Text);
            byte[] iv = StringToByteArray(textBox2.Text);

            AESDecrypt(key, iv, inputFile, outputFile, mode);
            MessageBox.Show("Decryption done.");
        }

        private void button9_Click(object sender, EventArgs e)//import plaintext
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.Text = ofd.FileName;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)// import ciphertext
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    richTextBox2.Text = sfd.FileName;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)//random key
        {
            byte[] key = new byte[AES_KEY_SIZE];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(key);
            textBox1.Text = BitConverter.ToString(key).Replace("-", "");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            byte[] iv = new byte[AES_IV_SIZE];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(iv);
            textBox2.Text = BitConverter.ToString(iv).Replace("-", "");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Save AES Key and IV";
                sfd.Filter = "Key File (*.bin)|*.bin|All Files (*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    byte[] key = StringToByteArray(textBox1.Text);
                    byte[] iv = StringToByteArray(textBox2.Text);
                    SaveKeyToFile(sfd.FileName, key, iv);
                    MessageBox.Show("Key saved successfully.");
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Load AES Key and IV";
                ofd.Filter = "Key File (*.bin)|*.bin|All Files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    byte[] key = new byte[AES_KEY_SIZE];
                    byte[] iv = new byte[AES_IV_SIZE];
                    LoadKeyFromFile(ofd.FileName, key, iv);
                    textBox1.Text = BitConverter.ToString(key).Replace("-", "");
                    textBox2.Text = BitConverter.ToString(iv).Replace("-", "");
                    MessageBox.Show("Key loaded successfully.");
                }
            }
        }
    }
}
