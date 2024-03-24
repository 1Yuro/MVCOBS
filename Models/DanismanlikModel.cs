using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Models
{
    public class DanismanlikModel
    {
        [Key]
        public int DanismanlikID { get; set; }
        public int OgrenciID { get; set; }
        public int OgrElmID { get; set; }

    }
}
