using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Models
{
    public class DersAlmaModel
    {
        [Key]
        public int DersAlmaID { get; set; }
        public int DersAcmaID { get; set; }
        public int OgrenciID { get; set; }
        public int DurumID { get; set; }
    }
}
