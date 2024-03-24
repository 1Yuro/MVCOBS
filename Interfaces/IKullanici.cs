using OgrenciBilgiSistemi.Models;
using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Interfaces
{
    public interface IKullanici
    {
        KullaniciModel GetKullaniciByUsername(string kullaniciadi);
        KullaniciModel GetKullaniciByUsernameAndPassword(string kullaniciadi, string sifre);
        OgretimElemaniModel GetOgretimElemaniByKullaniciID(int kullaniciID);
        OgrenciModel GetOgrenciByKullaniciID(int kullaniciID);
        public KullaniciModel GetDefaultUser();
        
        void SaveChanges();
    }
}
