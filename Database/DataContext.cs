using Microsoft.EntityFrameworkCore;
using OgrenciBilgiSistemi.Models;
using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Database
{
    public class DataContext:DbContext
    {
        public DbSet<KullaniciModel> Kullanici { get; set; }
        public DbSet<BolumModel> Bolum { get; set; }
        public DbSet<DanismanlikModel> Danismanlik { get; set; }
        public DbSet<DegerlendirmeModel> Degerlendirme { get; set; }
        public DbSet<DersAcmaModel> DersAcma { get; set; }
        public DbSet<DersAlmaModel> DersAlma { get; set; }
        public DbSet<DersHavuzuModel> DersHavuzu { get; set; }
        public DbSet<IDerslik> Derslik { get; set; }
        public DbSet<DersProgramiModel> DersProgrami { get; set; }
        public DbSet<MesajlarModel> Mesajlar { get; set; }
        public DbSet<MufredatModel> Mufredat { get; set; }
        public DbSet<MufredatDersModel> MufredatDers { get; set; }
        public DbSet<OgrenciModel> Ogrenci { get; set; }
        public DbSet<OgretimElemaniModel> OgretimElemani { get; set; }
        public DbSet<SabitlerModel> Sabitler { get; set; }
        public DbSet<SinavModel> Sinav { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=EMIN;Database=ObsDB;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
