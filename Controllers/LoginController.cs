using Microsoft.AspNetCore.Mvc;
using OgrenciBilgiSistemi.Database;
using OgrenciBilgiSistemi.Interfaces;
using OgrenciBilgiSistemi.Models;
using OgrenciBilgiSistemi.Repository;
using System.Drawing;
using System.Text.RegularExpressions;

namespace OgrenciBilgiSistemi.Controllers
{
    public class LoginController : Controller
    {

        List<KullaniciModel> kullanicilar;
        private readonly ISession _session;
        private readonly IKullanici _kullanici;
        // Sessionu const da çağırdık.
        public LoginController(IHttpContextAccessor httpContextAccesor, IKullanici kullaniciRepository)
        {
            _session = httpContextAccesor.HttpContext.Session;
            _kullanici = kullaniciRepository;
        }

        [Route("~/obs/login")]
        [HttpGet]
        public IActionResult Login()
        {
             var kullanici = _kullanici.GetDefaultUser();
             return View(kullanici);
        }
        // Kullanıcı girişinin hangi tipte olduğunu sağlar ve kullanıcı tipinin id tutar.Başarılı girişte başarısız giriş sayacını 0 yapar.
        // Kullanici id'yi redirectaction ile gönderirken id nin URL'de görünmesini engellemek için Session kullanıldı.
        [HttpPost]
        public IActionResult LoginCheck(string kullaniciadi, string sifre)
        {
            var basarisizkullanici = _kullanici.GetKullaniciByUsername(kullaniciadi);
            var kullanici = _kullanici.GetKullaniciByUsernameAndPassword(kullaniciadi, sifre);
            if (kullanici != null && IsPasswordValid(sifre) && kullanici.BasarisizGiris<3)
            {

                if (kullanici.KullaniciTur)
                {
                    //ogr elemanı ve ogrt elemanı giriş kontrolu
                    kullanici.BasarisizGiris = 0;
                    _kullanici.SaveChanges();
                    var ogrElm = _kullanici.GetOgretimElemaniByKullaniciID(kullanici.KullaniciID);
                    _session.SetInt32("OgrElmID", ogrElm.OgretimElemaniID);
                    return RedirectToAction("OgrElm", "obs");

                }
                else
                {
                    //ogrenci giriş kontrolu
                    kullanici.BasarisizGiris = 0;
                    _kullanici.SaveChanges();
                    var ogrenci = _kullanici.GetOgrenciByKullaniciID(kullanici.KullaniciID);
                    _session.SetInt32("OgrenciID", ogrenci.OgrenciID);
                    return RedirectToAction("Ogrenci", "obs");

                }

            }
            // Başarısız giriş durumu
            else if ((basarisizkullanici != null || basarisizkullanici.BasarisizGiris>=3) && kullanici == null)
            {
                // Kullanıcı bulunduysa başarısız giriş sayacını artır
                basarisizkullanici.BasarisizGiris++;
                _kullanici.SaveChanges();

                if (basarisizkullanici.BasarisizGiris >= 3)
                {
                    basarisizkullanici.SonGiris = DateTime.Now;
                    _kullanici.SaveChanges();

                    TimeSpan zamanFarki = DateTime.Now - basarisizkullanici.SonGiris.Value;
                    if (zamanFarki.TotalMinutes < 5)
                    {
                        ViewBag.Basarisiz = "5 dakika içinde tekrar deneyin.";
                        return View("Login", "obs");
                    }
                    else
                    {
                        // 5 dakika geçti, engelleme sona erdi
                        basarisizkullanici.BasarisizGiris = 0;
                        basarisizkullanici.SonGiris = null;
                        _kullanici.SaveChanges();
                        return View("Login", "obs");
                    }
                }
                else
                {
                    // Başarısız giriş sayısı 3'e ulaşmadı, hata mesajı göster
                    ViewBag.HataMesaji = "Kullanıcı adı veya şifre hatalı!";
                    return View("Login", "obs");
                }
            }
            else
            {
                // Kullanıcı bulunamadı, hata mesajı göster
                ViewBag.HataMesaji = "Kullanıcı adı veya şifre hatalı!";
                return View("Login", "obs");
            }

        }
        // Şifrenin büyük harf, rakam ve en az 8 karakter içerip içermediğini kontrol eder.
        [HttpPost]
        private bool IsPasswordValid(string password)
        {
            // Şifre karmaşıklığı kontrolü
            if (string.IsNullOrEmpty(password))
            {
                ViewBag.HataMesaji = "Şifre boş olamaz.";
                return false;
            }

            if (password.Length < 8)
            {
                ViewBag.HataMesaji = "Şifre en az 8 karakterden oluşmalıdır.";
                return false;
            }

            if (!Regex.IsMatch(password, "[a-z]"))
            {
                ViewBag.HataMesaji = "Şifre en az bir küçük harf içermelidir.";
                return false;
            }

            if (!Regex.IsMatch(password, "[A-Z]"))
            {
                ViewBag.HataMesaji = "Şifre en az bir büyük harf içermelidir.";
                return false;
            }

            if (!Regex.IsMatch(password, "[0-9]"))
            {
                ViewBag.HataMesaji = "Şifre en az bir rakam içermelidir.";
                return false;
            }

            return true;
        }
        [HttpGet]
        public IActionResult PasswordReset()
        {
             var kullanici = _kullanici.GetDefaultUser();
             return View(kullanici);
        }
        // Sifre resetleme kontrolleri
        [HttpPost]
        public IActionResult PasswordReset(string kullaniciAdi, string eskiSifre, string yeniSifre, string yeniSifreTekrar)
        {
            var kullanici = _kullanici.GetKullaniciByUsernameAndPassword(kullaniciAdi, eskiSifre);
            if (kullanici != null && IsPasswordValid(eskiSifre) && yeniSifre == yeniSifreTekrar)
            {
                if (IsPasswordValid(yeniSifre) && eskiSifre != yeniSifre)
                {
                    kullanici.sifre = yeniSifre;
                    _kullanici.SaveChanges();
                    ViewBag.Succesmessage = "Sifre Başarıyla kaydedildi";
                    return View("Login", "obs");
                }
                else if (IsPasswordValid(yeniSifre) && eskiSifre == yeniSifre)
                {
                    ViewBag.HataMesaji = "Eski şifre ile yeni şifre aynı olamaz";
                }
            }
            else
            {
                ViewBag.HataMesaji = "Eski sifre yanlış veya sifreler eşleşmiyor";
            }
            return View();

        }
    }

}