using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Models
{
    public class MufredatDersModel
    {
        [Key]
        public int MufredatDersID { get; set; }
        public int MufredatID { get; set; }
        public int DersID { get; set; }
        public int DersDonem { get; set; }
    }
}
