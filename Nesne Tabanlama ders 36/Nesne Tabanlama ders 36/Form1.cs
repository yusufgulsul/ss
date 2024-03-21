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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection bglnt = new OleDbConnection("Provider = Microsoft.Jet.OleDb.4.0;Data Source = kutuphane.mdb");
        OleDbCommand comm;

        int kimlik;

        void Listele()
        {
            
            bglnt.Open();
            OleDbDataAdapter adaptr = new OleDbDataAdapter("Select * From kitaplar", bglnt);
            DataTable tablo = new DataTable();
            adaptr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            bglnt.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            Listele();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            kimlik = Convert.ToInt32( dataGridView1.CurrentRow.Cells[0].Value);
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO kitaplar (Adi , Yazar , Tur, Raf, Sayfa_sayisi ) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'," + textBox5.Text + ")";
            comm = new OleDbCommand(sorgu, bglnt);
            bglnt.Open();
            comm.ExecuteNonQuery();
            bglnt.Close();
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string silmeSorgusu = "DELETE FROM kitaplar WHERE Kimlik =" + kimlik;
            comm = new OleDbCommand(silmeSorgusu, bglnt);
            bglnt.Open();
            comm.ExecuteNonQuery();
            bglnt.Close();
            Listele();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form3 ogrenci_bilgisi = new Form3();
            ogrenci_bilgisi.Show();
            this.Hide();
        }
    }
}
