using System;//Datetime sınıfını kullanabilmek için ekledik.

namespace WFA_PersonelTakip
{
    public class Personel
    {
        //todo: Aynı tckimlik no eklenmesin.
        public string TCKN { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        //todo: Aynı email eklenmesin.
        public string Telefon { get; set; }

        //todo: Aynı email eklenmesin.
        public string Email { get; set; }
        public string Adres { get; set; }

        public DateTime IseGiris { get; set; }
        public string Unvan { get; set; }

    }
}
