﻿using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Models
{
    public class MesajlarModel
    {
        [Key]
        public int MesajlarID { get; set; }
        public int GonderenID { get; set; }
        public int AliciID { get; set; }
        public string MesajBaslik { get; set; }
        public string MesajIcerik { get; set; }
        public DateTime MesajTarih { get; set; }
    }
}
