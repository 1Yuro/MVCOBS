using Microsoft.EntityFrameworkCore;
using OgrenciBilgiSistemi.Database;
using OgrenciBilgiSistemi.Interfaces;
using OgrenciBilgiSistemi.Models;

namespace OgrenciBilgiSistemi.Repository
{
    public class KullaniciRepository:IKullanici
    {
        private readonly DataContext _dbContext;

        public KullaniciRepository(DataContext dbContext)
        {
            _dbContext = new DataContext();
        }

        public KullaniciModel GetDefaultUser()
        {
            return _dbContext.Kullanici.FirstOrDefault();
        }

        public KullaniciModel GetKullaniciByUsername(string kullaniciadi)
        {
            return _dbContext.Kullanici.FirstOrDefault(u => u.KullaniciAdi == kullaniciadi);
        }

        public KullaniciModel GetKullaniciByUsernameAndPassword(string kullaniciadi, string sifre)
        {
            return _dbContext.Kullanici.FirstOrDefault(u => u.KullaniciAdi == kullaniciadi && u.sifre == sifre);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public OgretimElemaniModel GetOgretimElemaniByKullaniciID(int kullaniciID)
        {
            return _dbContext.OgretimElemani.FirstOrDefault(u => u.KullaniciID == kullaniciID);
        }
        public OgrenciModel GetOgrenciByKullaniciID(int kullaniciID)
        {
            return _dbContext.Ogrenci.FirstOrDefault(u => u.KullaniciID == kullaniciID);
        }
    }
}
