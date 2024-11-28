using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //veri tabanı bağlantısı için

namespace Stok.Kayit
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        SqlConnection baglanti = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=Malzeme Kayıt; Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {//EKLE
            string t1 = textBox1.Text; //Malzeme-Kodu   
            string t2 = textBox2.Text; //Malzeme-adi
            string t3 = textBox3.Text; //Yıllık-satış
            string t4 = textBox4.Text; //Birim-fiyat
            string t5 = textBox5.Text; //Min-stok 
            string t6 = textBox6.Text; //T-süresi 

            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Malzemeler (MalzemeKodu, MalzemeAdi, YillikSatis, BirimFiyat, MinStok, Tsüresi) VALUES ('"+t1+ "','"+t2+ "','"+t3+ "', '"+t4+ "', '"+t5+ "', '"+t6+ "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void listele()//veri tabanınındaki kayıtları goruntülenmesi 
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select *from Malzemeler",baglanti) ;
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {//SİL
            string t1 = textBox1.Text; //seçilen satırın malzeme kodunu alır
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM Malzemeler WHERE MalzemeKodu=('"+t1+"')",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close() ;
            listele();

        }

        private void button3_Click(object sender, EventArgs e)
        {//GÜNCELLE
            string t1 = textBox1.Text; //Malzeme-Kodu   
            string t2 = textBox2.Text; //Malzeme-adi
            string t3 = textBox3.Text; //Yıllık-satış
            string t4 = textBox4.Text; //Birim-fiyat
            string t5 = textBox5.Text; //Min-stok 
            string t6 = textBox6.Text; //T-süresi 

            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Malzemeler SET MalzemeKodu='" + t1 + "' , MalzemeAdi='" + t2 + "' ,YillikSatis='" + t3 + "' , BirimFiyat='" + t4 + "' , MinStok='" + t5 + "' , TSüresi='" + t6 + "' WHERE MalzemeKodu='"+t1+"'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();




        }
    }
}
