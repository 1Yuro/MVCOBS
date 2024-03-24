using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Interfaces
{
    public interface IDersAlmaModel
    {
        [Key]
        public int DersAlmaID { get; set; }
        public int DersAcmaID { get; set; }
        public int OgrenciID { get; set; }
        public int DurumID { get; set; }
    }
}
