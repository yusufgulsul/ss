using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Nesne_Tabanlama_ders_36
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                

                string comm = "INSERT INTO Kullanicilar (KullaniciAdi, Sifre, Eposta) VALUES (@kullaniciAdi, @sifre, @eposta)";
                OleDbConnection bglnt = new OleDbConnection("Provider = Microsoft.Jet.OleDb.4.0;Data Source = kutuphane.mdb");
                 
                string ekleme_SORGUSU = " INTO ogrenciler SET kulanıcı_parola = '" + textBox1.Text + "',tel_no = '" + textBox2.Text + "', sifre = '" + textBox3.Text + "', sifre_tekrar='" ;
                
                bglnt.Open();
                
                bglnt.Close();               
  
                MessageBox.Show("Kayıt işlemi başarıyla tamamlandı!");
            }
            catch (Exception ex)
            {              
                MessageBox.Show("Hata: " + ex.Message);
            }
            
        }
    }
}
