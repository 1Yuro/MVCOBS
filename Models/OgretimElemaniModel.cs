using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Models
{
    public class OgretimElemaniModel
    {
        [Key]
        public int OgretimElemaniID { get; set; }
        public int BolumID { get; set; }
        public int KullaniciID { get; set; }
        public int UnvanID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public bool Cinsiyet { get; set; }
        public string KurumSicilNo { get; set; }
        public string TcNo { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Email { get; set; }
        public bool YonVarMi { get; set; }

    }
}
