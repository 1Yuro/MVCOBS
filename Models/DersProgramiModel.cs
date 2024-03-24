using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Models
{
    public class DersProgramiModel
    {
        [Key]
        public int DersPrgID { get; set; }
        public int DersAcmaID { get; set; }
        public int DerslikID { get; set; }
        public int DersGunuID { get; set; }
        public int DersSaatiID { get; set; }
    }
}
