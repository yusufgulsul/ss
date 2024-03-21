using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nesne_Tabanlama_ders_36
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        OleDbConnection bglnt = new OleDbConnection("Provider = Microsoft.Jet.OleDb.4.0;Data Source = ogrenciler.mdb");
        OleDbCommand comm;
        int kimlik;

        void Listele()
        {
            
            bglnt.Open();
            OleDbDataAdapter adaptr = new OleDbDataAdapter("Select * From ogrenciler", bglnt);
            DataTable tablo = new DataTable();
            adaptr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            bglnt.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string silmeSorgusu = "DELETE FROM ogrenciler WHERE Kimlik =" + kimlik;
            comm = new OleDbCommand(silmeSorgusu, bglnt);
            bglnt.Open();
            comm.ExecuteNonQuery();
            bglnt.Close();
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string duzenleSorgusu = " UPDATE ogrenciler SET ogrenci_no = '" + textBox1.Text + "',ad = '" + textBox2.Text + "', soyad = '" + textBox3.Text + "', sinif='" + textBox4.Text + "',bolum = '" + textBox5.Text + "' WHERE Kimlik = " + kimlik;
            comm = new OleDbCommand(duzenleSorgusu, bglnt);
            bglnt.Open();
            comm.ExecuteNonQuery();
            bglnt.Close();
            Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO ogrenciler (ogrenci_no , ad , soyad, sinif, bolum ) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'," + textBox5.Text + ")";
            comm = new OleDbCommand(sorgu, bglnt);
            bglnt.Open();
            comm.ExecuteNonQuery();
            bglnt.Close();
            Listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {        
            Form1 Kitap_bilgisi = new Form1();
            Kitap_bilgisi.Show();
            this.Hide();
        }
    }
}
