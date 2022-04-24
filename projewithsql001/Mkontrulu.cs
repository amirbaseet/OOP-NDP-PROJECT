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
    public partial class Mkontrulu : Form
    {
        SqlConnection connection;
        SqlDataAdapter adapter;

        public Mkontrulu()
        {
            InitializeComponent();
        }
        void listeleme() {

            using (connection = new SqlConnection())//verı tabanı ile bağlantı kurmak
            {
                //bağlanacak veri tabanı adressi kompaylara vermek
                connection.ConnectionString = Magaza.Projeconnectionstring;

                connection.Open();//veri tabanımı açtım

                adapter = new SqlDataAdapter("SELECT * FROM musteri", connection);//veri tabandaki tüm verileri getirdim 

                DataTable table = new DataTable();//bir tablo oluşturdum

                adapter.Fill(table);//oluşturduğum tablete veri tabandaki getirdiğim belgileri doldurdum
                dataGridView1.DataSource = table;//bu tablo datagridview e gönderdim



            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MUSTERIEKLE mUSTERIEKLE = new MUSTERIEKLE();
            mUSTERIEKLE.ShowDialog();
        }

        private void Mkontrulu_Activated(object sender, EventArgs e)
        {
            listeleme();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Musterisilme musterisilme = new Musterisilme();
            musterisilme.ShowDialog();
        }
    }
}
