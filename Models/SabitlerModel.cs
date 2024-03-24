using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Models
{
    public class SabitlerModel
    {
        [Key]
        public int SabitlerID { get; set; }
        public int SabitlerAdi { get; set; }
    }
}
