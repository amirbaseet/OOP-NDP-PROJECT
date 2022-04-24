using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace projewithsql001
{
    public partial class Musterisilme : Form
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        public Musterisilme()
        {
            InitializeComponent();
        }
        void Urun_listeleme()
        {

            using (connection = new SqlConnection())//verı tabanı ile bağlantı kurmak
            {
                //bağlanacak veri tabanı adressi kompaylara vermek
                connection.ConnectionString = Magaza.Projeconnectionstring;

                connection.Open();//veri tabanımı açtım

                adapter = new SqlDataAdapter("SELECT * FROM musteri WHERE tc='" + int.Parse(txt_MSilme.Text)+"'", connection);//veri tabandaki tüm verileri getirdim 

                DataTable table = new DataTable();//bir tablo oluşturdum

                adapter.Fill(table);//oluşturduğum tablete veri tabandaki getirdiğim belgileri doldurdum
                dataGridView1.DataSource = table;//bu tablo datagridview e gönderdim

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection())//verı tabanı ile bağlantı kurmak
            {//Dışardan alınacak bilgiler refransını koydum
                connection.ConnectionString = Magaza.Projeconnectionstring;

                connection.Open();//veri tabani actim
                using (SqlCommand command = new SqlCommand("SELECT count(*)FROM musteri WHERE tc='" + Int32.Parse(txt_MSilme.Text) + "'", connection))
                {//burda aynı kod olan sayıyıtıyorum 
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    object obj = command.ExecuteScalar();//burda bir object tanıtım ve command verdiği sayı Barindiriyor
                    if (Convert.ToInt32(obj) > 0)//eğer bu Müşteri aslında varsa silme yapmaz
                    {
                        Magaza.Musterisilme(int.Parse(txt_MSilme.Text));
                        MessageBox.Show(txt_MSilme.Text + "Müşteri Başarıyla silmiştir");
                    }
                    else//yoksa yapar
                    {
                        MessageBox.Show(txt_MSilme.Text + "Müşteri  ASLINDA YOKTUR");
                    }
                }//using sql command sonu
            }//using sqlconnectiction sonu 
        }

        private void txt_MSilme_TextChanged(object sender, EventArgs e)
        {
            Urun_listeleme();
        }
    }
    }

