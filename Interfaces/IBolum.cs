using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Interfaces
{
    public interface IBolum
    {
        [Key]
        public int BolumID { get; set; }
        public string BolumAdi { get; set; }
        public int ProgramTuruID { get; set; }
        public int OgretimTuruID { get; set; }
        public int OgretimDiliID { get; set; }
        public string WebAdresi { get; set; }
    }
}
