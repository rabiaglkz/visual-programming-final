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
    public partial class Anasayfafrm : Form
    {
        public Anasayfafrm()
        {
            InitializeComponent();
        }
        public MySqlConnection conn = new MySqlConnection("Server=localhost;Database=satis;Uid=root;Pwd='';");

        private void Anasayfafrm_Load(object sender, EventArgs e)
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

        private void btnMüsteriEkle_Click(object sender, EventArgs e)
        {
            MüsteriEklefrm müsteriekle = new MüsteriEklefrm();
            müsteriekle.ShowDialog();
        }

        private void btnMüsteriListele_Click(object sender, EventArgs e)
        {
            MüsteriListelemefrm müsterilisteleme = new MüsteriListelemefrm();
            müsterilisteleme.ShowDialog();
        }

        private void btnkategori_Click(object sender, EventArgs e)
        {
            Kategorifrm kategori = new Kategorifrm();
            kategori.ShowDialog();
        }

        private void btnmarka_Click(object sender, EventArgs e)
        {
            Markafrm marka = new Markafrm();
            marka.ShowDialog();
        }

        private void btnÜrünEkleme_Click(object sender, EventArgs e)
        {
            ÜrünEklemefrm ürünekle = new ÜrünEklemefrm();
            ürünekle.ShowDialog();

        }

        private void btnÜrünListele_Click(object sender, EventArgs e)
        {
            ÜrünListelemefrm ürünlistele = new ÜrünListelemefrm();
            ürünlistele.ShowDialog();

        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            Satisfrm satis = new Satisfrm();
            satis.ShowDialog();
        }

        private void btnSatisListesi_Click(object sender, EventArgs e)
        {
            SatisListelemefrm satisliste = new SatisListelemefrm();
            satisliste.ShowDialog();
        }
    }
}
