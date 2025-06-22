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
        const int AES_KEY_SIZE_XTS = 32; // for XTS mode

        [DllImport("AES_KeyGen.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GenerateAESKey")]
        public static extern void GenerateAESKey(byte[] key, byte[] iv);

        [DllImport("AES_KeyGen.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SaveKeyToFile")]
        public static extern void SaveKeyToFile(string filename, byte[] key, byte[] iv);

        [DllImport("AES_KeyGen.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LoadKeyFromFile")]
        public static extern void LoadKeyFromFile(string filename, byte[] key, byte[] iv);

        //XTS mode
        [DllImport("AES_KeyGen.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GenerateAESKeyXTS")]
        public static extern void GenerateAESKeyXTS(byte[] key, byte[] iv);

        [DllImport("AES_KeyGen.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SaveKeyToFileXTS")]
        public static extern void SaveKeyToFileXTS(string filename, byte[] key, byte[] iv);

        [DllImport("AES_KeyGen.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LoadKeyFromFileXTS")]
        public static extern void LoadKeyFromFileXTS(string filename, byte[] key, byte[] iv);



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
            int keySize = comboBox1.SelectedItem.ToString() == "XTS" ? AES_KEY_SIZE_XTS : AES_KEY_SIZE;

            byte[] key = new byte[keySize];
            byte[] iv = new byte[AES_IV_SIZE];
            if (comboBox1.SelectedItem.ToString() == "XTS")
            {
                GenerateAESKeyXTS(key, iv);
            }else
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

            if ((mode == "XTS" && key.Length != AES_KEY_SIZE_XTS) || (mode != "XTS" && key.Length != AES_KEY_SIZE))
            {
                MessageBox.Show($"Invalid key length for mode {mode}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            AESEncrypt(key, iv, inputFile, outputFile, mode);

            // GCM/CCM giả định ghi tag vào cuối file mã hóa (xử lý trong DLL)
            if (mode == "GCM" || mode == "CCM")
            {
                MessageBox.Show("Encryption done. Tag is appended to output file.");
            }
            else
            {
                MessageBox.Show("Encryption done.");
            }

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

            if ((mode == "XTS" && key.Length != AES_KEY_SIZE_XTS) || (mode != "XTS" && key.Length != AES_KEY_SIZE))
            {
                MessageBox.Show($"Invalid key length for mode {mode}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AESDecrypt(key, iv, inputFile, outputFile, mode);

            if (mode == "GCM" || mode == "CCM")
            {
                MessageBox.Show("Decryption complete with tag verification.");
            }
            else
            {
                MessageBox.Show("Decryption done.");
            }
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
            int keySize = comboBox1.SelectedItem.ToString() == "XTS" ? AES_KEY_SIZE_XTS : AES_KEY_SIZE;
            byte[] key = new byte[keySize];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(key);
            textBox1.Text = BitConverter.ToString(key).Replace("-", "");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            byte[] iv = new byte[AES_IV_SIZE];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(iv);
            textBox2.Text = BitConverter.ToString(iv).Replace("-", "");
        }

        private void button11_Click(object sender, EventArgs e) //savekey
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Save AES Key and IV";
                sfd.Filter = "Key File (*.bin)|*.bin|All Files (*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    byte[] key = StringToByteArray(textBox1.Text);
                    byte[] iv = StringToByteArray(textBox2.Text);
                    if (comboBox1.SelectedItem.ToString() == "XTS")
                    {
                        SaveKeyToFileXTS(sfd.FileName, key, iv);
                    }
                    else
                        SaveKeyToFile(sfd.FileName, key, iv);


                    MessageBox.Show("Key saved successfully.");
                }
            }
        }

        private void button12_Click(object sender, EventArgs e) //loadkey
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Load AES Key and IV";
                ofd.Filter = "Key File (*.bin)|*.bin|All Files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    int keySize = comboBox1.SelectedItem.ToString() == "XTS" ? AES_KEY_SIZE_XTS : AES_KEY_SIZE;
                    byte[] key = new byte[keySize];
                    byte[] iv = new byte[AES_IV_SIZE];
                    if (comboBox1.SelectedItem.ToString() == "XTS")
                    {
                        LoadKeyFromFileXTS(ofd.FileName, key, iv);

                    }
                    else
                        LoadKeyFromFile(ofd.FileName, key, iv);

                    textBox1.Text = BitConverter.ToString(key).Replace("-", "");
                    textBox2.Text = BitConverter.ToString(iv).Replace("-", "");
                    MessageBox.Show("Key loaded successfully.");
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
