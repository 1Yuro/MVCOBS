using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Interfaces
{
    public interface IDersHavuzu
    {
        [Key]
        public int DersID { get; set; }
        public string DersKodu { get; set; }
        public string DersAdi { get; set; }
        public int DersDiliID { get; set; }
        public int DersSeviyesiID { get; set; }
        public int DersTuruID { get; set; }
        public int Teorik { get; set; }
        public int Uygulama { get; set; }
        public int Kredi { get; set; }
        public int ECTS { get; set; }
    }
}
