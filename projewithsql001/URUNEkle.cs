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

namespace projewithsql001
{
    public partial class URUNEkle : Form
    {
        public URUNEkle()
        {
            InitializeComponent();
        }
        public void Urun_ekle() {//urun ekleme fonk tanititim
            Urun Urun = new Urun();
            Urun.Kode = Int32.Parse(txt_Ukode.Text);
            Urun.Depo = txt_Udepo.Text;
            Urun.Raf = txt_Uraf.Text;
            Urun.Adi = txt_Uadi.Text;
            Urun.Cinsiyet = txt_Ucinsiyet.Text;
            Urun.Ketagori = txt_Uketagori.Text;
            Urun.Renk = txt_Urenk.Text;
            Urun.Fiat = float.Parse(txt_Ufiat.Text);
            Magaza.Urunekle(Urun);
        }
        private void button1_Click(object sender, EventArgs e)
        {
          
            using (SqlConnection connection = new SqlConnection())//Veri tabanı ile bağlantı kuruyorum
            {
                connection.ConnectionString = @"Data Source=DESKTOP-EH33T15\SQLEXPRESS02;Initial Catalog=proje;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                connection.Open();//verı tabanı adriisiyl bağlandım ve açtım
                using (SqlCommand command = new SqlCommand("SELECT count(*) FROM stock WHERE kode='" + int.Parse(txt_Ukode.Text) + "'", connection))
                {//burda aynı kod olan sayıyıtıyorum
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    object obj = command.ExecuteScalar();//burda bir object tanıtım ve command verdiği sayı Barindiriyor
                    if (Convert.ToInt32(obj) > 0)//eğer bu urun aslında varsa ekleme yapmaz
                    {
                        MessageBox.Show(txt_Ukode.Text + "URUNU OLAN KODU ASLINDA MEVCUTUR");


                    }
                    else//yoksa yapar
                    {
                        MessageBox.Show(txt_Ukode.Text + "URUNU OLAN KODU Başarıyla Eklenmiştir");
                        Urun_ekle();
                    }



                }
            }
        }
    }
}
