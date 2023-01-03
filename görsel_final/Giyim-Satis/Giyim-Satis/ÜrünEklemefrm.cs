using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Giyim_Satis
{
    public partial class ÜrünEklemefrm : Form
    {
        public ÜrünEklemefrm()
        {
            InitializeComponent();
        }
        public MySqlConnection conn = new MySqlConnection("Server=localhost;Database=satis;Uid=root;Pwd='';");
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ÜrünEklemefrm_Load(object sender, EventArgs e)
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

        private void btnyerniürünekle_Click(object sender, EventArgs e)
        {
            string cmdText = "INSERT INTO ürün_ekleme(id, ürünbarkodno, ürünkategori, ürünmarka, ürünadi, ürünmiktarı, ürünalisfiyati, ürünsatisfiyati) VALUES('"+ txtid+"', '"+ txtbarkodno+"', '"+ txtkategori+"', '"+ txtmarka +"', '"+ txtmiktari+"', '"+txtürünadi+"', '"+txtalisfiyati+"', '"+txtsatisfiyati+"')";
            MySqlCommand cmd = new MySqlCommand(cmdText, conn);
            cmd.ExecuteNonQuery();
            
        }
    }
}
