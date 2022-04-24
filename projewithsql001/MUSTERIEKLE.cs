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

    public partial class MUSTERIEKLE : Form
    {
        public MUSTERIEKLE()
        {
            InitializeComponent();
        }
        void Musteriekle()
        { //urun ekleme fonk tanititim
            Musteri Musteri =new Musteri();

            Musteri.TC = int.Parse(txt_Mtc.Text);
            Musteri.Adisoyadi = txt_Madisoyadi.Text;
            Musteri.Telefonno = int.Parse(txt_Mtelno.Text);
            Musteri.Cinsiyet = txt_Mcinsiyet.Text;
            Musteri.Yas = int.Parse( txt_Myas.Text);
            Musteri.Meslek = txt_Mmeslek.Text;

            Magaza.Musteriekle(Musteri);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection())//verı tabanı ile bağlantı kurmak
            {//Dışardan alınacak bilgiler refransını koydum
                connection.ConnectionString = @"Data Source=DESKTOP-EH33T15\SQLEXPRESS02;Initial Catalog=proje;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                connection.Open();//veri tabani actim
                using (SqlCommand command = new SqlCommand("SELECT count(*)FROM musteri WHERE tc='" + int.Parse(txt_Mtc.Text) + "'", connection))
                {//burda aynı kod olan sayıyıtıyorum 
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    object obj = command.ExecuteScalar();//burda bir object tanıtım ve command verdiği sayı Barindiriyor
                    if (Convert.ToInt32(obj) > 0)//eğer bu Müşteri aslında varsa ekleme yapmaz
                    {
                        MessageBox.Show(txt_Mtc.Text + "Müşteri eklemezsiniz Mişteri zaten MEVCUTUR");
                    }
                    else//yoksa yapar
                    {
                        MessageBox.Show(txt_Mtc.Text + "Müşteri OLAN TC Başarıyla Eklenmiştir");
                        Musteriekle();
                    }
                }//using sql command sonu
            }//using sqlconnectiction sonu 
        }

    }
}
