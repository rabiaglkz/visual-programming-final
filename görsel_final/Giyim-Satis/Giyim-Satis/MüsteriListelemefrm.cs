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
    public partial class MüsteriListelemefrm : Form
    {
        public MüsteriListelemefrm()
        {
            InitializeComponent();
        }
        public MySqlConnection conn = new MySqlConnection("Server=localhost;Database=satis;Uid=root;Pwd='';");
        private void MüsteriListelemefrm_Load(object sender, EventArgs e)
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

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(txtMüsteriKodu.Text + " " + txtAdSoyad.Text + " " + txtTelefon.Text + " " + txtAdres.Text + " " + txtEmail.Text);
            txtMüsteriKoduAra.Clear();
            txtMüsteriKodu.Clear();
            txtAdSoyad.Clear();
            txtTelefon.Clear();
            txtAdres.Clear();
            txtEmail.Clear();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if(item is TextBox)
                {
                    (item as TextBox).Clear();
                }
            }

        }
    }
}
