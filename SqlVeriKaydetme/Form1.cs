using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SqlVeriKaydetme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=.;Initial Catalog=Kayıtlar;Integrated Security=True;");
        private void verilerimigöster()
        {
           baglan.Open();
           SqlCommand komut = new SqlCommand("Select * from Gelenler ", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read()) 
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Adsoyad"].ToString();
                ekle.SubItems.Add(oku["Firma"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Mahalle"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerimigöster();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Insert into Gelenler (Adsoyad,Firma,Telefon,Mahalle) values ('" + textBox1.Text + "','" + textBox2.Text + "','"+textBox3.Text+"','"+comboBox1.Text+"')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerimigöster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            
        }

         
    }
}
