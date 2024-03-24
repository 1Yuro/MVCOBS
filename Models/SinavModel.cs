using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Models
{
    public class SinavModel
    {
        [Key]
        public int SinavID { get; set; }
        public int DersAcmaID { get; set; }
        public int SinavTuruID { get; set; }
        public int EtkiOrani { get; set; }
        public DateTime SinavTarihi { get; set; }
        public int SinavSaatiID { get; set; }
        public int DerslikID { get; set; }
        public int OgrElemaniID { get; set; }
    }
}
