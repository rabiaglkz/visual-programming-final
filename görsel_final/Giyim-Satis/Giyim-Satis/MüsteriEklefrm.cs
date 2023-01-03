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
    public partial class MüsteriEklefrm : Form
    {
        public MüsteriEklefrm()
        {
            InitializeComponent();
        }
        public MySqlConnection conn = new MySqlConnection("Server=localhost;Database=satis;Uid=root;Pwd='';");
        private void lblMüsteriKodu_Click(object sender, EventArgs e)
        {

        }

        private void MüsteriEklefrm_Load(object sender, EventArgs e)
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

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string cmdText = "INSERT INTO müsteri_ekle (id, müsterikodu, müsteriadsoyad, müsteriadres, müsteriemail) VALUES('" + txtMüsteriKodu + "', '" + txtAdSoyad + "', '" + txtTelefon + "', '" + txtAdres + "', '" + txtEmail + "')";
            MySqlCommand cmd = new MySqlCommand(cmdText, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
