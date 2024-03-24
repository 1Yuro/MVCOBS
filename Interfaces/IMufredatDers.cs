using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Interfaces
{
    public interface IMufredatDers
    {
        [Key]
        public int MufredatDersID { get; set; }
        public int MufredatID { get; set; }
        public int DersID { get; set; }
        public int DersDonem { get; set; }
    }
}
