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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        OleDbConnection bglnt = new OleDbConnection("Provider = Microsoft.Jet.OleDb.4.0;Data Source = kutuphane.mdb");

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM kullanici";
            OleDbCommand comm = new OleDbCommand(sql, bglnt);
            bglnt.Open();

            OleDbDataReader oku = comm.ExecuteReader();
            oku.Read();

         
        
    
            if (oku.GetValue(1).ToString() == textBox1.Text && oku.GetValue(2).ToString() == textBox2.Text)
            {
                Form1 goster = new Form1();
                this.Hide();
                goster.Show();
               
            }

            bglnt.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
                checkBox1.Text = "Gizle";
            }
            else if (checkBox1.CheckState == CheckState.Unchecked)
            {
                textBox2.UseSystemPasswordChar = true;
                checkBox1.Text = "Göster";
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
       
    
        private void button2_Click(object sender, EventArgs e)
        {
            Form4 goster = new Form4();
            this.Hide();
            goster.Show();

        }
    }
}
