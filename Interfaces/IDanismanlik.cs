using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Interfaces
{
    public interface IDanismanlik
    {
        [Key]
        public int DanismanlikID { get; set; }
        public int OgrenciID { get; set; }
        public int OgrElmID { get; set; }

    }
}
