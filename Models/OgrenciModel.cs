using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Models
{
    public class OgrenciModel
    {
        [Key]
        public int OgrenciID { get; set; }
        public int? KullaniciID { get; set; }
        public int? BolumID { get; set; }
        public string OgrenciNo { get; set; }
        public int? DurumID { get; set; }
        public DateTime KayitTarihi { get; set; }
        public DateTime? AyrilmaTarihi { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string TcNo { get; set; }
        public bool Cinsiyet { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Email { get; set; }
    }
}
