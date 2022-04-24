using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projewithsql001
{
    internal class Urun
    {
        int kode;
        string depo;
        string raf;
        string adi;
        string renk;
        string cinsiyet;
        string ketegori;
        float fiat;


        public int Kode { get => kode;set => kode = value; }
        public string Depo { get => depo; set => depo = value; }
        public string Raf { get => raf; set => raf = value; }
        public string Adi { get => adi; set => adi = value; }
        public string Renk { get => renk; set => renk = value; }
        public string Cinsiyet { get => cinsiyet; set => cinsiyet = value; }
        public string Ketagori { get => ketegori; set => ketegori = value; }
        public float Fiat { get => fiat; set => fiat = value; }
    }
}
