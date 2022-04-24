using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace projewithsql001
{
    internal class Magaza
    {//***************************URURN FONKSIYONLARI BASLANGIC*****************************************************************************************************************************************************************************************************************************************************************************************************************************************************************
        public static string Projeconnectionstring= @"Data Source=DESKTOP-EH33T15\SQLEXPRESS02;Initial Catalog=proje;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static void Urunekle(Urun Eklenecekurun)
        {

            using (SqlConnection connection = new SqlConnection())//verı tabanı ile bağlantı kurmak
            {
                //bağlanacak veri tabanı adressi kompaylara vermek
                connection.ConnectionString = Projeconnectionstring;

                connection.Open();//veri tabanımı açtım

                //Dışardan alınacak bilgiler refransını koydum
                using (SqlCommand command = new SqlCommand("INSERT INTO stock(kode,depo,raf,adi,cinsiyet,ketagori,renk,fiat)Values(@kode,@depo,@raf,@adi,@cinsiyet,@ketagori,@renk,@fiat) ", connection))
                {

                    // " command.Parameters.AddWithValue("kodu bilgiler veritabana eklemek için kullanılır
                    command.Parameters.AddWithValue("kode", Eklenecekurun.Kode);
                    command.Parameters.AddWithValue("depo", Eklenecekurun.Depo);
                    command.Parameters.AddWithValue("raf", Eklenecekurun.Raf);
                    command.Parameters.AddWithValue("adi", Eklenecekurun.Adi);
                    command.Parameters.AddWithValue("cinsiyet", Eklenecekurun.Cinsiyet);
                    command.Parameters.AddWithValue("renk", Eklenecekurun.Renk);
                    command.Parameters.AddWithValue("ketagori", Eklenecekurun.Ketagori);
                    command.Parameters.AddWithValue("fiat", Eklenecekurun.Fiat.ToString());

                    command.ExecuteNonQuery();//sütünün sayısına  ve bilgileri donduruluyor
                }//using sql command sonu

            }//using sqlconnectiction sonu 
        }
        public static void Urunsilme(int kode)
        {

            using (SqlConnection connection = new SqlConnection())//veri tabanı ile bağlantı kurmak
            {
                //bağlanacak veri tabanı adressi kompaylara vermek
                connection.ConnectionString = Projeconnectionstring;

                connection.Open();//veri tabanımı açtım

                //Dışardan alınacak bilgiler refransını koydum ve AYNI kodu unun olan sutun silinecek
                using (SqlCommand command = new SqlCommand("DELETE FROM stock WHERE kode=@kode", connection))
                {
                    command.Parameters.AddWithValue("kode", kode);
                    command.ExecuteNonQuery();//sütünün sayısına  ve bilgileri donduruluyor
                }//using sql command sonu

                connection.Close();//veri tabani kapatim
            }//using sqlconnectiction sonu 
        }
        //***************************URURN FONKSIYONLARI BITIS**********************************************************************************************************************************************************************************************************************************************************************************



        //***************************MUSTERI FONKSIYONLARI BASLANGIC**********************************************************************************************************************************************************************************************************************************************************************************

        public static void Musteriekle(Musteri EklenecekMusteri) {

            using (SqlConnection connection = new SqlConnection())//verı tabanı ile bağlantı kurmak
            {//Dışardan alınacak bilgiler refransını koydum
                connection.ConnectionString = Projeconnectionstring;

                connection.Open();//veri tabani actim

                using (SqlCommand command = new SqlCommand("INSERT INTO musteri(tc,adisoyadi,telefonno,cinsiyet,yas,sehir,meslek)Values(@tc,@adisoyadi,@telefonno,@cinsiyet,@yas,@sehir,@meslek)", connection))
                {

                    // " command.Parameters.AddWithValue("kodu bilgiler veritabana eklemek için kullanılır
                    command.Parameters.AddWithValue("tc", EklenecekMusteri.TC.ToString());
                    command.Parameters.AddWithValue("adisoyadi", EklenecekMusteri.Adisoyadi);
                    command.Parameters.AddWithValue("telefonno", EklenecekMusteri.Telefonno.ToString());
                    command.Parameters.AddWithValue("cinsiyet", EklenecekMusteri.Cinsiyet);
                    command.Parameters.AddWithValue("yas", EklenecekMusteri.Yas.ToString());
                    command.Parameters.AddWithValue("sehir", EklenecekMusteri.Sehir);
                    command.Parameters.AddWithValue("meslek", EklenecekMusteri.Meslek);

                    command.ExecuteNonQuery();//sütünün sayısına  ve bilgileri donduruluyor
                }//using sql command sonu

            }//using sqlconnectiction sonu 





        }
        public static void Musterisilme(int tc) {
            using (SqlConnection connection = new SqlConnection())//verı tabanı ile bağlantı kurmak
            {//Dışardan alınacak bilgiler refransını koydum
                connection.ConnectionString = Projeconnectionstring;

                connection.Open();//veri tabani actim
                //Dışardan alınacak bilgiler refransını koydum ve AYNI tc inin olan sutun silinecek
                using (SqlCommand command = new SqlCommand("DELETE FROM musteri WHERE tc=@tc", connection)) {

                    command.Parameters.AddWithValue("tc",tc);
                    command.ExecuteNonQuery ();


                }//using sql command sonu
                connection.Close();//veri tabani kapatim

            }//using sqlconnectiction sonu 
        }
            //***************************MUSTERI FONKSIYONLARI BITIS**********************************************************************************************************************************************************************************************************************************************************************************

        }
}
