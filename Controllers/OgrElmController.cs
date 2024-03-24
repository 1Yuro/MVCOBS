using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using OgrenciBilgiSistemi.Database;
using OgrenciBilgiSistemi.Models;

namespace OgrenciBilgiSistemi.Controllers
{
    public class OgrElmController : Controller
    {
        DataContext dbo = new DataContext();
        List<BolumModel> Bolumler;
        List<DersHavuzuModel> Dersler;
        List<MufredatModel> Mufredatlar;
        List<DersHavuzuModel> havuzdersler;
        List<OgretimElemaniModel> ogrelm;
        [Route("~/obs/OgrElm")]
        [HttpGet]
        public IActionResult OgrElm()
        {
            
            using (dbo)
            {
                var ogrElmid = HttpContext.Session.GetInt32("OgrElmID");
                ViewBag.OgrElmid = ogrElmid;
                var ogrelm = dbo.OgretimElemani.FirstOrDefault(u => u.OgretimElemaniID == ogrElmid);
                if (ogrelm.YonVarMi) 
                {
                    return RedirectToAction("OgrtElm", "obs");
                }
                else 
                {
                    return View(ogrelm);
                }  
            }
        }
        [Route("~/obs/OgrtElm")]
        public IActionResult OgrtElm()
        {
            using (dbo)
            {
                var ogrElmid = HttpContext.Session.GetInt32("OgrElmID");
                ViewBag.OgrElmid = ogrElmid;
                var ogrelm = dbo.OgretimElemani.FirstOrDefault(u => u.OgretimElemaniID == ogrElmid);
                return View(ogrelm);
            }
        }
        public IActionResult OgrElmOzlukBilgi(int ogrElmid)
        {
            using (dbo)
            {
                var ogrelm = dbo.OgretimElemani.FirstOrDefault(u => u.OgretimElemaniID == ogrElmid);
                ViewBag.OgrElmid = ogrelm.OgretimElemaniID;
                return View(ogrelm);
            }
        }
        public IActionResult OgrenciKayit()
        {
            using (dbo)
            {
                Bolumler = dbo.Bolum.ToList();
                ViewBag.Bolumler = Bolumler;
                OgrenciModel ogr = new OgrenciModel();
                return View(ogr);
            }
        }
        public IActionResult OgrenciKayitKontrol(OgrenciModel Ogrenci)
        {
            using (dbo)
            {
                var cekilenvarmikullanici = dbo.Kullanici.FirstOrDefault(u => u.KullaniciAdi == Ogrenci.OgrenciNo);
                if (cekilenvarmikullanici == null) 
                {
                    KullaniciModel kullanici = new KullaniciModel();
                    kullanici.KullaniciAdi = Ogrenci.OgrenciNo;
                    kullanici.sifre = Ogrenci.TcNo;
                    kullanici.KullaniciTur = false;
                    dbo.Kullanici.Add(kullanici);
                    dbo.SaveChanges();
                }

                var cekilenkullanici = dbo.Kullanici.FirstOrDefault(u => u.KullaniciAdi == Ogrenci.OgrenciNo);
                Ogrenci.KullaniciID = cekilenkullanici.KullaniciID;
                Ogrenci.KayitTarihi = DateTime.Now;
                dbo.Ogrenci.Add(Ogrenci);
                dbo.SaveChanges();
                return RedirectToAction("OgrenciKayit", "OgrElm");
            }
        }
        public IActionResult MufredatKayit()
        {
            using (dbo)
            {
                Dersler = dbo.DersHavuzu.ToList();
                ViewBag.dersler = Dersler;
                Bolumler = dbo.Bolum.ToList();
                ViewBag.Bolumler = Bolumler;
                Mufredatlar = dbo.Mufredat.ToList();
                ViewBag.Mufredatlar = Mufredatlar;
                var aktifMufredatlar = Mufredatlar.Where(m => m.Aktif == true).ToList();
                ViewBag.aktifmufredatlar = aktifMufredatlar;
                havuzdersler = dbo.DersHavuzu.ToList();
                ViewBag.dersler = havuzdersler;

                MufredatModel mufredat = new MufredatModel();
                return View(mufredat);
            }
        }
        public IActionResult MufredatKayitKontrol(MufredatModel mufredat)
        {
            using (dbo)
            {
                mufredat.AkademikYilID = 59;
                dbo.Mufredat.Add(mufredat);
                dbo.SaveChanges();
                return RedirectToAction("MufredatKayit", "OgrElm");
            }
        }
        public IActionResult DersAcma(int ogrElmid) 
        {
            using (dbo)
            {
                var ogrelm = dbo.OgretimElemani.FirstOrDefault(u => u.OgretimElemaniID == ogrElmid);
                ViewBag.ogrelm = ogrelm;
                var aktifMufredat = dbo.Mufredat.FirstOrDefault(m => m.Aktif == true && m.BolumID == ogrelm.BolumID);
                ViewBag.aitmufredat = aktifMufredat;
                var aitderslerid = dbo.MufredatDers.Where(m => m.MufredatID == aktifMufredat.MufredatID);
                var ilgiliDersler = dbo.DersHavuzu.Where(d => aitderslerid.Select(a => a.DersID).Contains(d.DersID)).ToList();
                ViewBag.ilgilidersler=ilgiliDersler;
                DersAcmaModel DersAcma = new DersAcmaModel();
                return View(DersAcma);
            }
        }

        public IActionResult SınavListesi(int ogrElmid)
        {
            using (dbo)
            {
                var ogrelm = dbo.OgretimElemani.FirstOrDefault(u => u.OgretimElemaniID == ogrElmid);
                ViewBag.ogrelm = ogrelm;

                return View();
            }
        }
        public IActionResult Mesajlar(int ogrElmid) 
        {
            using (dbo)
            {
                ViewBag.OgrElmID = ogrElmid;
                var ogrelm = dbo.OgretimElemani.FirstOrDefault(u => u.OgretimElemaniID == ogrElmid);
                var DigerOgrElm = dbo.OgretimElemani.Where(m => m.BolumID == ogrelm.BolumID && m.OgretimElemaniID != ogrElmid)
                .ToList();
                var ogrenciler = dbo.Ogrenci.Where(m => m.BolumID == ogrelm.BolumID)
                .ToList();
                ViewBag.ogrelm = DigerOgrElm.ToList();
                ViewBag.ogrenciler = ogrenciler.ToList(); ;
                MesajlarModel mesaj = new MesajlarModel();
                return View(mesaj);
            }
        }
        public IActionResult MesajlarIcerik(int gonderilecekOgrElm ,int gonderenOgrElm)
        {
            using (dbo)
            {
                var OgrElm = dbo.OgretimElemani.FirstOrDefault(u => u.OgretimElemaniID == gonderenOgrElm);
                var ogrelmkullanici = dbo.OgretimElemani.FirstOrDefault(u => u.OgretimElemaniID == gonderilecekOgrElm);
                var mesajlar = dbo.Mesajlar
                    .Where(u =>
                        (u.GonderenID == OgrElm.KullaniciID && u.AliciID == ogrelmkullanici.KullaniciID) ||
                        (u.GonderenID == ogrelmkullanici.KullaniciID && u.AliciID == OgrElm.KullaniciID))
                    .OrderBy(u => u.MesajTarih)
                    .ToList();
                ViewBag.OgrElmKullaniciid = ogrelmkullanici.KullaniciID;
                ViewBag.SecilenOgrElmKullaniciid = OgrElm.KullaniciID;
                ViewBag.mesajlar = mesajlar.OrderBy(m => m.MesajTarih).ToList();
                ViewBag.GonderilecekAdi = OgrElm.Adi;
                ViewBag.GonderilecekSoyadi = OgrElm.Soyadi;
                MesajlarModel mesaj = new MesajlarModel();
                return View(mesaj);
            }
        }

        public IActionResult MesajlarIcerikOgrenci(int OgrenciID, int OgrElmID)
        {
            return View();
        }

        [HttpPost]
        public IActionResult MufredatGuncelle(int mufredatid)
        {
            using (dbo)
            {
                var gelenmufredat = dbo.Mufredat.FirstOrDefault(u => u.MufredatID == mufredatid);
                gelenmufredat.Aktif = false;
                dbo.SaveChanges();
                return Ok();
            }
        }
        [HttpPost]
        public IActionResult MufredatDersEkle([FromBody] MufredatDersModel model)
        {
            using (dbo)
            {
                dbo.MufredatDers.Add(model);
                dbo.SaveChanges();
                return Ok();
            }
        }
        //[HttpPost]
        //public IActionResult DersAcmaEkle(int mufredatid int dersid)
        //{
        //    using (dbo)
        //    {
        //        dbo.MufredatDers.Add(model);
        //        dbo.SaveChanges();
        //        return Ok();
        //    }
        //}
        [HttpGet]
        public IActionResult Cikis()
        {
            HttpContext.Session.Clear(); // Mevcut oturum verilerini temizle

            // Oturumu sonlandır
            HttpContext.SignOutAsync();

            // Çıkış yaptıktan sonra yönlendirilecek sayfa veya işlem
            return RedirectToAction("Login", "Login");
        }
    }
}

