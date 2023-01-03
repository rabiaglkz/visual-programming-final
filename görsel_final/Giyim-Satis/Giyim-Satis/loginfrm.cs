using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Giyim_Satis
{
    public partial class loginfrm : Form
    {
        public loginfrm()
        {
            InitializeComponent();
        }
        public MySqlConnection conn = new MySqlConnection("Server=localhost;Database=satis;Uid=root;Pwd='';");
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                if (conn.State != ConnectionState.Closed)
                {
                    MessageBox.Show("Bağlantı Başarılı Bir Şekilde Gerçekleşti");
                }
                else
                {
                    MessageBox.Show("Maalesef Bağlantı Yapılamadı...!");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Hata! " + err.Message, "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdText = "INSERT INTO login(usr, pwd) VALUES ('" + textBox2.Text + "', '" + textBox3.Text + "')";
            MySqlCommand cmd = new MySqlCommand(cmdText, conn);
            cmd.ExecuteNonQuery();
            Anasayfafrm a = new Anasayfafrm();
            a.Show();
            Hide();
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void lnkuyeol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (checkBox1.Checked)
                {
                    textBox3.PasswordChar = '\0';
                }
                else
                {
                    textBox3.PasswordChar = '*';
                }
            }
        }
    }
}
     

