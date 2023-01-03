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
    public partial class ÜrünListelemefrm : Form
    {
        public ÜrünListelemefrm()
        {
            InitializeComponent();
        }
        public MySqlConnection conn = new MySqlConnection("Server=localhost;Database=satis;Uid=root;Pwd='';");
        DataSet daset = new DataSet();

        private void ÜrünListelemefrm_Load(object sender, EventArgs e)
        {
            ÜrünListele();

        }

        private void ÜrünListele()
        {
            conn.Open();
            MySqlDataAdapter satis = new MySqlDataAdapter("Select * from urun", conn);
            satis.Fill(daset, "urun");
            adtr.DataSource = daset.Tables["urun"];
            conn.Close();
        }

        private void adtr_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtbarkodno.Text = adtr.CurrentRow.Cells["barkodno"].Value.ToString();
            txtkategori.Text = adtr.CurrentRow.Cells["kategori"].Value.ToString();
            txtmarka.Text = adtr.CurrentRow.Cells["marka"].Value.ToString();
            txtürünadi.Text = adtr.CurrentRow.Cells["urunadi"].Value.ToString();
            txtmiktari.Text = adtr.CurrentRow.Cells["miktari"].Value.ToString();
            txtalisfiyati.Text = adtr.CurrentRow.Cells["alisfiyati"].Value.ToString();
            txtsatisfiyati.Text = adtr.CurrentRow.Cells["satisfiyati"].Value.ToString();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlCommand komut = new MySqlCommand("update urun set urunadi=@urunadi,miktari=@miktari,alisfiyati=@alisfiyati,satisfiyati=@satisfiyati where barkodno=@barkodno", conn);
            komut.Parameters.AddWithValue("@barkodno",txtbarkodno.Text);
            komut.Parameters.AddWithValue("@urunadi", txtürünadi.Text);
            komut.Parameters.AddWithValue("@miktari", txtmiktari.Text);
            komut.Parameters.AddWithValue("@alisfiyati", txtalisfiyati.Text);
            komut.Parameters.AddWithValue("@satisfiyati", txtsatisfiyati.Text);
            komut.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Güncelleme Yapıldı");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void btnmarkagüncelle_Click(object sender, EventArgs e)
        {
            if (txtbarkodno.Text!="")
            {
                conn.Open();
                MySqlCommand komut = new MySqlCommand("update urun set kategori=@kategori,marka=@marka where barkodno=@barkodno", conn);
                komut.Parameters.AddWithValue("@barkodno", txtbarkodno.Text);
                komut.Parameters.AddWithValue("@kategori", combokategori.Text);
                komut.Parameters.AddWithValue("@marka", combomarka.Text);

                komut.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Güncelleme Yapıldı");
            }
            else
            {
                MessageBox.Show("Barkodno yazılı değil");
            }
            
            foreach (Control item in this.Controls)
            {
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }
    }
}
