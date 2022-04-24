using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace projewithsql001
{
   
    public partial class URUNSilme : Form
        
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        public URUNSilme()
        {
            InitializeComponent();
           
        }
        void Urun_listeleme()
        {

            using (connection = new SqlConnection())//verı tabanı ile bağlantı kurmak
            {
                //bağlanacak veri tabanı adressi kompaylara vermek
                connection.ConnectionString = @"Data Source=DESKTOP-EH33T15\SQLEXPRESS02;Initial Catalog=proje;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                connection.Open();//veri tabanımı açtım

                adapter = new SqlDataAdapter("SELECT * FROM stock WHERE kode='" + int.Parse(txt_USilme.Text) + "'", connection);

                DataTable table = new DataTable();

                adapter.Fill(table);//oluşturduğum tablete veri tabandaki getirdiğim belgileri doldurdum
                dataGridView1.DataSource = table;//bu tablo datagridview e gönderdim

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection())//Veri tabanı ile bağlantı kuruyorum
            {
                connection.ConnectionString = @"Data Source=DESKTOP-EH33T15\SQLEXPRESS02;Initial Catalog=proje;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                connection.Open();//verı tabanı adriisiyl bağlandım ve açtım
                using (SqlCommand command = new SqlCommand("SELECT count(*) FROM stock WHERE kode='" + int.Parse(txt_USilme.Text) + "'", connection))
                {//burda aynı kod olan sayıyıtıyorum
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    object obj=command.ExecuteScalar();//burda bir object tanıtım ve command verdiği sayı Barindiriyor
                    if (Convert.ToInt32(obj) > 0)//eğer bu urun aslında varsa silme yapar
                    {
                        Magaza.Urunsilme(int.Parse(txt_USilme.Text));
                        MessageBox.Show(txt_USilme.Text + "URUNU OLAN KODU Başarıyla silmiştir");

                    }
                    else//yoksa yapmaz
                    {
                        MessageBox.Show(txt_USilme.Text + "URUNU OLAN KODU ASLINDA YOKTUR");

                    }



                }
            }

            
        }
        
        private void Silme_Load(object sender, EventArgs e)
        {
          
        }

        private void txt_USilme_TextChanged(object sender, EventArgs e)
        {
            Urun_listeleme();
        }
    }
}
