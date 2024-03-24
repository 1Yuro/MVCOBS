using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Interfaces
{
    public interface IMufredat
    {
        [Key]
        public int MufredatID { get; set; }
        public string MufredatAdi { get; set; }
        public int BolumID { get; set; }
        public int AkademikYilID { get; set; }
        public bool Aktif { get; set; }
    }
}
