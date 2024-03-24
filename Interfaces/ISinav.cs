using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Interfaces
{
    public interface ISinav
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
