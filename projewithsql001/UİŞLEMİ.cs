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
    public partial class UİŞLEMİ : Form
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        
        public UİŞLEMİ()
        {
            InitializeComponent();
        }

        void Urun_listeleme() {

            using (connection = new SqlConnection())//verı tabanı ile bağlantı kurmak
            {
                //bağlanacak veri tabanı adressi kompaylara vermek
                connection.ConnectionString = Magaza.Projeconnectionstring;

                connection.Open();//veri tabanımı açtım

                adapter = new SqlDataAdapter("SELECT * FROM stock", connection);//veri tabandaki tüm verileri getirdim 

                DataTable table=new DataTable();//bir tablo oluşturdum

                adapter.Fill(table);//oluşturduğum tablete veri tabandaki getirdiğim belgileri doldurdum
                dataGridView1.DataSource = table;//bu tablo datagridview e gönderdim

            }
            }
        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            URUNEkle Ekle =new URUNEkle();
            Ekle.ShowDialog();
        }

       

        private void Form2_Activated(object sender, EventArgs e)
        {
            Urun_listeleme();//form aktiv olduğu zaman yeni listeleme yapar

        }

        private void button2_Click(object sender, EventArgs e)
        {
            URUNSilme Silme =new URUNSilme();
            Silme.ShowDialog();
        }
    }
}
