using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Models
{
    public class DegerlendirmeModel
    {
        [Key]
        public int DegerlendirmeID { get; set; }
        public int SinavID { get; set; }
        public int OgrenciID { get; set; }
        public int SinavNotu { get; set; }
    }
}
