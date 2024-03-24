using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Interfaces
{
    public interface IDersAcma
    {
        [Key]
        public int DersAcmaID { get; set; }
        public int OgrElmID { get; set; }
        public int DersID { get; set; }
        public int Kontenjan { get; set; }
    }
}
