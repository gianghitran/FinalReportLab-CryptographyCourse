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
    public partial class MainMenu: Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           RSA newForm = new RSA(); 
            newForm.Show();             
        }

        private void button_Click(object sender, EventArgs e)
        {
            AESCryptoPP newForm = new AESCryptoPP();
            newForm.Show();
        }
    }

}
