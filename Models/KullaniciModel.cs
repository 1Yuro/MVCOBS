using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Models
{
    public class KullaniciModel
    {

        [Key]
        public int KullaniciID { get; set; }
        public string KullaniciAdi { get; set; }
        public string sifre { get; set; }
        public bool KullaniciTur { get; set; }
        public int? BasarisizGiris { get; set; }
        public DateTime? SonGiris { get; set; }
    }
}
