using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Models
{
    public class MüfredatDersModel
    {
        [Key]
        public int MufredatDersID { get; set; }
        public int MufredatID { get; set; }
        public int DersID { get; set; }
    }
}
