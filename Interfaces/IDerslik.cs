using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Interfaces
{
    public interface IDerslik
    {
        [Key]
        public int DerslikID { get; set; }
        public string DerslikAdi { get; set; }
        public int DerslikTuruID { get; set; }
        public int Kapasite { get; set; }
    }
}
