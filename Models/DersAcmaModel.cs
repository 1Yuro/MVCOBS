using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Models
{
    public class DersAcmaModel
    {
        [Key]
        public int DersAcmaID { get; set; }
        public int OgrElmID { get; set; }
        public int DersID { get; set; }
        public int Kontenjan  { get; set; }
    }
}
