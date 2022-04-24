using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projewithsql001
{
    internal class Musteri
    {
        int tc;
        string adisoyadi;
        int telefonno;
        string cinsiyet;
        int yas;
        string sehir;
        string meslek;
        public int TC { get => tc; set => tc = value; }
        public string Adisoyadi { get => adisoyadi; set => adisoyadi = value; }
        public int Telefonno { get => telefonno; set => telefonno = value; }
        public string Cinsiyet { get => cinsiyet; set => cinsiyet = value; }    
        public int Yas { get => yas; set => yas = value; }   
        public string Sehir { get => sehir; set => sehir = value; }
        public string Meslek { get => meslek; set => meslek = value; }
    }
   
}
