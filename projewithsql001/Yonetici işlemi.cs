using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projewithsql001
{
    public partial class Yonetici_işlemi : Form
    {
        public Yonetici_işlemi()
        {
            InitializeComponent();
        }

        private void Yonetici_işlemi_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mkontrulu mkontrulu = new Mkontrulu();
            mkontrulu.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        UİŞLEMİ uİŞLEMİ =new UİŞLEMİ();
            uİŞLEMİ.ShowDialog();
        }
    }
}
