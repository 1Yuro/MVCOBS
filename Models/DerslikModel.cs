using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Models
{
    public class IDerslik
    {
        [Key]
        public int DerslikID { get; set; }
        public string DerslikAdi { get; set; }
        public int DerslikTuruID { get; set; }
        public int Kapasite { get; set; }
    }
}
