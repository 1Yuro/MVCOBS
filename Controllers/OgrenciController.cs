using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OgrenciBilgiSistemi.Database;
using OgrenciBilgiSistemi.Models;

namespace OgrenciBilgiSistemi.Controllers
{
    public class OgrenciController : Controller
    {
        DataContext dbo = new DataContext();
        [Route("~/obs/Ogrenci")]
        [HttpGet]
        public IActionResult Ogrenci()
        {
            var ogrenciid = HttpContext.Session.GetInt32("OgrenciID");
            using (dbo)
            {              
                ViewBag.Ogrenciid = ogrenciid;
                var ogrenci = dbo.Ogrenci.FirstOrDefault(u => u.OgrenciID == ogrenciid);
                return View(ogrenci);
            }
        }
        public IActionResult Duyuru(int ogrenciid)
        {
            using (dbo)
            {
                return View();
            }
        }
        public IActionResult OzlukBilgi(int ogrenciid)
        {
            using (dbo)
            {
                var ogrenci = dbo.Ogrenci.FirstOrDefault(u => u.OgrenciID == ogrenciid);
                ViewBag.Ogrenciid = ogrenciid;
                return View(ogrenci);
            }
        }
        public IActionResult DersKayit(int ogrenciid)
        {
            using (dbo)
            {
                var ogrenci = dbo.Ogrenci.FirstOrDefault(u => u.OgrenciID == ogrenciid);
                ViewBag.Ogrenciid = ogrenciid;
                var mufredat = dbo.Mufredat.FirstOrDefault(m => m.BolumID == ogrenci.BolumID);
                var cekilendersler = dbo.MufredatDers.Where(m => m.MufredatID == mufredat.MufredatID);
                var dersacmadersler = dbo.DersAcma.Where(d => cekilendersler.Select(a => a.DersID).Contains(d.DersID)).ToList();
                var acılandersler = dbo.DersHavuzu.Where(d => dersacmadersler.Select(a => a.DersID).Contains(d.DersID)).ToList();
                ViewBag.acılandersler = acılandersler;
                ViewBag.dersacmadersler = dersacmadersler;
                DersAlmaModel DersAlma = new DersAlmaModel();
                return View(DersAlma);
            }
        }
        public IActionResult Mesajlar(int ogrenciid) 
        {
            using (dbo) 
            {
                var ogrenci = dbo.Ogrenci.FirstOrDefault(u => u.OgrenciID == ogrenciid);
                ViewBag.Ogrenciid = ogrenciid;
                var ogrelm = dbo.OgretimElemani.Where(m => m.BolumID == ogrenci.BolumID);
                ViewBag.ogrelm= ogrelm.ToList(); ;
                MesajlarModel mesaj = new MesajlarModel();
                return View(mesaj);
            }
        }
        public IActionResult MesajlarIcerik(int ogrenciid ,int ogrelmid)
        {
            using (dbo)
            {
                var ogrencikullanici = dbo.Ogrenci.FirstOrDefault(u => u.OgrenciID == ogrenciid);
                var ogrelmkullanici = dbo.OgretimElemani.FirstOrDefault(u => u.OgretimElemaniID == ogrelmid);
                var mesajlar = dbo.Mesajlar
                    .Where(u =>
                        (u.GonderenID == ogrencikullanici.KullaniciID && u.AliciID == ogrelmkullanici.KullaniciID) ||
                        (u.GonderenID == ogrelmkullanici.KullaniciID && u.AliciID == ogrencikullanici.KullaniciID))
                    .OrderBy(u => u.MesajTarih)
                    .ToList();
                ViewBag.OgrenciKullaniciid = ogrencikullanici.KullaniciID;
                ViewBag.OgrElmKullaniciid = ogrelmkullanici.KullaniciID;
                var ogrelm = dbo.OgretimElemani.Where(m => m.BolumID == ogrencikullanici.BolumID);
                ViewBag.mesajlar = mesajlar.OrderBy(m => m.MesajTarih).ToList();
                ViewBag.OgrElmAdi = ogrelmkullanici.Adi;
                ViewBag.OgrElmSoydi = ogrelmkullanici.Soyadi;
                MesajlarModel mesaj = new MesajlarModel();
                return View(mesaj);
            }
        }

        public IActionResult OgrenciBelgesi(int ogrenciid)
        {
            using (dbo)
            {
                var ogrenci = dbo.Ogrenci.FirstOrDefault(u => u.OgrenciID == ogrenciid);
                ViewBag.Ogrenciid = ogrenciid;
                var bolum = dbo.Bolum.FirstOrDefault(m => m.BolumID == ogrenci.BolumID);
                ViewBag.bolumAdi = bolum.BolumAdi;
                if (bolum.OgretimDiliID == 1) 
                {
                    ViewBag.bolumdili = "Türkçe";
                }
                else
                {
                    ViewBag.bolumdili = "İngilizce";
                }
                ViewBag.Tarih = DateTime.Now;
                return View(ogrenci);
            }
        }
        public IActionResult Mufredat(int ogrenciid)
        {
            using (dbo)
            {
                List<DersHavuzuModel> dersler1 = new List<DersHavuzuModel>();
                List<DersHavuzuModel> dersler2 = new List<DersHavuzuModel>();
                List<DersHavuzuModel> dersler3 = new List<DersHavuzuModel>();
                List<DersHavuzuModel> dersler4 = new List<DersHavuzuModel>();
                List<DersHavuzuModel> dersler5 = new List<DersHavuzuModel>();
                List<DersHavuzuModel> dersler6 = new List<DersHavuzuModel>();
                List<DersHavuzuModel> dersler7 = new List<DersHavuzuModel>();
                List<DersHavuzuModel> dersler8 = new List<DersHavuzuModel>();

                var ogrenci = dbo.Ogrenci.FirstOrDefault(u => u.OgrenciID == ogrenciid);
                ViewBag.Ogrenciid = ogrenciid;
                var bolum = dbo.Bolum.FirstOrDefault(m => m.BolumID == ogrenci.BolumID);
                var mufredat = dbo.Mufredat.FirstOrDefault(m => m.BolumID == ogrenci.BolumID && m.Aktif == true);
                var mufredatders = dbo.MufredatDers.Where(m => m.MufredatID == mufredat.MufredatID);
                var dersler = dbo.DersHavuzu.Where(d => mufredatders.Select(md => md.DersID).Contains(d.DersID)).ToList();
                // mufredata ders ekleme kontrolu.
                foreach (var mufredatDers in mufredatders)
                {
                    if (mufredatDers.DersDonem == 1)
                    {
                        foreach(var Dersler in dersler) 
                        {
                            if(mufredatDers.DersID== Dersler.DersID)
                            {
                                dersler1.Add(Dersler);
                            }
                        }
                    }
                    else if (mufredatDers.DersDonem == 2)
                    {
                        foreach (var Dersler in dersler)
                        {
                            if (mufredatDers.DersID == Dersler.DersID)
                            {
                                dersler2.Add(Dersler);
                            }
                        }
                    }
                    else if (mufredatDers.DersDonem == 3)
                    {
                        foreach (var Dersler in dersler)
                        {
                            if (mufredatDers.DersID == Dersler.DersID)
                            {
                                dersler3.Add(Dersler);
                            }
                        }
                    }
                    else if (mufredatDers.DersDonem == 4)
                    {
                        foreach (var Dersler in dersler)
                        {
                            if (mufredatDers.DersID == Dersler.DersID)
                            {
                                dersler4.Add(Dersler);
                            }
                        }
                    }
                    else if (mufredatDers.DersDonem == 5)
                    {
                        foreach (var Dersler in dersler)
                        {
                            if (mufredatDers.DersID == Dersler.DersID)
                            {
                                dersler5.Add(Dersler);
                            }
                        }
                    }
                    else if (mufredatDers.DersDonem == 6)
                    {
                        foreach (var Dersler in dersler)
                        {
                            if (mufredatDers.DersID == Dersler.DersID)
                            {
                                dersler6.Add(Dersler);
                            }
                        }
                    }
                    else if (mufredatDers.DersDonem == 7)
                    {
                        foreach (var Dersler in dersler)
                        {
                            if (mufredatDers.DersID == Dersler.DersID)
                            {
                                dersler7.Add(Dersler);
                            }
                        }
                    }
                    else
                    {
                        foreach (var Dersler in dersler)
                        {
                            if (mufredatDers.DersID == Dersler.DersID)
                            {
                                dersler8.Add(Dersler);
                            }
                        }
                    }
                }

                decimal toplamKredi1 = dersler1.Sum(gelenders => (decimal)gelenders.Kredi);
                decimal toplamAKTS1 = dersler1.Sum(gelenders => (decimal)gelenders.ECTS);
                decimal toplamKredi2 = dersler2.Sum(gelenders => (decimal)gelenders.Kredi);
                decimal toplamAKTS2 = dersler2.Sum(gelenders => (decimal)gelenders.ECTS);
                decimal toplamKredi3 = dersler3.Sum(gelenders => (decimal)gelenders.Kredi);
                decimal toplamAKTS3 = dersler3.Sum(gelenders => (decimal)gelenders.ECTS);
                decimal toplamKredi4 = dersler4.Sum(gelenders => (decimal)gelenders.Kredi);
                decimal toplamAKTS4 = dersler4.Sum(gelenders => (decimal)gelenders.ECTS);
                decimal toplamKredi5 = dersler5.Sum(gelenders => (decimal)gelenders.Kredi);
                decimal toplamAKTS5 = dersler5.Sum(gelenders => (decimal)gelenders.ECTS);
                decimal toplamKredi6 = dersler6.Sum(gelenders => (decimal)gelenders.Kredi);
                decimal toplamAKTS6 = dersler6.Sum(gelenders => (decimal)gelenders.ECTS);
                decimal toplamKredi7 = dersler7.Sum(gelenders => (decimal)gelenders.Kredi);
                decimal toplamAKTS7 = dersler7.Sum(gelenders => (decimal)gelenders.ECTS);
                decimal toplamKredi8 = dersler8.Sum(gelenders => (decimal)gelenders.Kredi);
                decimal toplamAKTS8 = dersler8.Sum(gelenders => (decimal)gelenders.ECTS);
                ViewBag.bolumAdi = bolum.BolumAdi;
                ViewBag.dersler = dersler;
                ViewBag.dersler1 = dersler1;
                ViewBag.dersler2 = dersler2;
                ViewBag.dersler3 = dersler3;
                ViewBag.dersler4 = dersler4;
                ViewBag.dersler5 = dersler5;
                ViewBag.dersler6 = dersler6;
                ViewBag.dersler7 = dersler7;
                ViewBag.dersler8 = dersler8;
                ViewBag.toplamkredi1 = toplamKredi1;
                ViewBag.toplamkredi2 = toplamKredi2;
                ViewBag.toplamkredi3 = toplamKredi3;
                ViewBag.toplamkredi4 = toplamKredi4;
                ViewBag.toplamkredi5 = toplamKredi5;
                ViewBag.toplamkredi6 = toplamKredi6;
                ViewBag.toplamkredi7 = toplamKredi7;
                ViewBag.toplamkredi8 = toplamKredi8;
                ViewBag.toplamakts1 = toplamAKTS1;
                ViewBag.toplamakts2 = toplamAKTS2;
                ViewBag.toplamakts3 = toplamAKTS3;
                ViewBag.toplamakts4 = toplamAKTS4;
                ViewBag.toplamakts5 = toplamAKTS5;
                ViewBag.toplamakts6 = toplamAKTS6;
                ViewBag.toplamakts7 = toplamAKTS7;
                ViewBag.toplamakts8 = toplamAKTS8;
                ViewBag.Tarih = DateTime.Now;
                return View(ogrenci);
            }
        }

        public IActionResult DersProgrami(int ogrenciid)
        {
            using (dbo)
            {
                var ogrenci = dbo.Ogrenci.FirstOrDefault(u => u.OgrenciID == ogrenciid);
                // SQL KODU İLE ÇAĞIRMA
                var result = dbo.DersAlma
                    .Join(dbo.DersAcma, da => da.DersAcmaID, d => d.DersAcmaID, (da, d) => new { da, d })
                    .Join(dbo.DersHavuzu, jd => jd.d.DersID, dh => dh.DersID, (jd, dh) => new { jd, dh })
                    .Join(dbo.DersProgrami, jdh => jdh.jd.d.DersAcmaID, dp => dp.DersAcmaID, (jdh, dp) => new { jdh, dp })
                    .Where(j => j.jdh.jd.da.OgrenciID == ogrenciid && j.jdh.jd.da.DurumID == 63)
                    .Select(j => new
                    {
                        DersKodu = j.jdh.dh.DersKodu,
                        DersAdi = j.jdh.dh.DersAdi,
                        DersGunuID = j.dp.DersGunuID,
                        DersSaatiID = j.dp.DersSaatiID,
                        DersTeorikSaati = j.jdh.dh.Teorik,
                        DersUygulamaSaati = j.jdh.dh.Uygulama
                    })
                    .ToList();
                List<DersProgrami> yeniKayitlar = new List<DersProgrami>();
                // DersProgrami adında yeni bir class oluşturuldu. TeorikVeUygulama saatinin toplamı kadar for çalıştırıldı ve her biri için DersSaatID arttırıldı.
                foreach (var item in result)
                {
                    for (int i = 0; i < item.DersTeorikSaati + item.DersUygulamaSaati; i++)
                    {
                        yeniKayitlar.Add(new DersProgrami
                        {
                            DersKodu = item.DersKodu,
                            DersAdi = item.DersAdi,
                            DersGunuID = item.DersGunuID,
                            DersSaatiID = item.DersSaatiID+i, 
                        });
                    }
                }
                
                ViewBag.dersler = yeniKayitlar;
                ViewBag.Ogrenciid = ogrenciid;
                return View();
            }
        }
        public IActionResult NotListesi(int ogrenciid)
        {
            using (dbo)
            {
                var ogrenci = dbo.Ogrenci.FirstOrDefault(u => u.OgrenciID == ogrenciid);
                var result = dbo.DersHavuzu
                    .Join(dbo.DersAcma, dh => dh.DersID, da => da.DersID, (dh, da) => new { dh, da })
                    .Join(dbo.DersAlma, j1 => j1.da.DersAcmaID, dalma => dalma.DersAcmaID, (j1, dalma) => new { j1.dh, j1.da, dalma })
                    .Join(dbo.Sinav, j2 => j2.dalma.DersAcmaID, s => s.DersAcmaID, (j2, s) => new { j2.dh, j2.da, j2.dalma, s })
                    .Join(dbo.Degerlendirme, j3 => j3.s.SinavID, degerlendirme => degerlendirme.SinavID, (j3, degerlendirme) => new { j3.dh, j3.da, j3.dalma, j3.s, degerlendirme })
                    .Where(j4 => j4.dalma.OgrenciID == ogrenciid && (j4.s.SinavTuruID == 36 || j4.s.SinavTuruID == 37))
                    .GroupBy(j4 => new { j4.dh.DersKodu, j4.dh.DersAdi, j4.dh.ECTS })
                    .Select(group => new
                    {
                        DersKodu = group.Key.DersKodu,
                        DersAdi = group.Key.DersAdi,
                        ECTS = group.Key.ECTS,
                        VizeNotu = group.Max(item => item.s.SinavTuruID == 36 ? item.degerlendirme.SinavNotu : (int?)null) ?? 30,
                        FinalNotu = group.Max(item => item.s.SinavTuruID == 37 ? item.degerlendirme.SinavNotu : (int?)null) ?? 50
                    })
                    .ToList();
                ViewBag.cevap = result;
                ViewBag.Ogrenciid = ogrenciid;
                return View();
            }
        }

        public IActionResult Transkript(int ogrenciid)
        {
            using (dbo)
            {
                var ogrenci = dbo.Ogrenci.FirstOrDefault(u => u.OgrenciID == ogrenciid);
                var bolum = dbo.Bolum.FirstOrDefault(u => u.BolumID == ogrenci.BolumID);
                //Bir sürü iç içe combined
                var result = dbo.DersAlma
                    .Where(dal => dal.OgrenciID == ogrenciid && dal.DurumID >= 64 && dal.DurumID <= 72)
                    .Join(dbo.DersAcma, combined => combined.DersAcmaID, dac => dac.DersAcmaID, (combined, dac) => new { combined, dac })
                    .Join(dbo.DersHavuzu, combined => combined.dac.DersID, dh => dh.DersID, (combined, dh) => new { combined, dh })
                    .Join(dbo.MufredatDers, combined => combined.dh.DersID, md => md.MufredatDersID, (combined, md) => new
                    {
                        DersKodu = combined.dh.DersKodu,
                        DersAdi = combined.dh.DersAdi,
                        Teorik = combined.dh.Teorik,
                        Uygulama = combined.dh.Uygulama,
                        DurumID = combined.combined.combined.DurumID,
                        DersDonem = md.DersDonem
                    })
                    .ToList();
                ViewBag.Transkript = result;
                ViewBag.Ogrenciid = ogrenciid;
                ViewBag.BolumAdi = bolum.BolumAdi;
                ViewBag.Tarih = DateTime.Now;
                return View(ogrenci);
            }
        }
        public IActionResult SinavTakvimi(int ogrenciid)
        {
            using (dbo)
            {
                var ogrenci = dbo.Ogrenci.FirstOrDefault(u => u.OgrenciID == ogrenciid);
                var bolum = dbo.Bolum.FirstOrDefault(u => u.BolumID == ogrenci.BolumID);
                //Vize çekme işlemi.
                var vizetarihleri = (from dal in dbo.DersAlma
                              join o in dbo.Ogrenci on dal.OgrenciID equals o.OgrenciID
                              join b in dbo.Bolum on o.BolumID equals b.BolumID
                              join dac in dbo.DersAcma on dal.DersAcmaID equals dac.DersAcmaID
                              join dh in dbo.DersHavuzu on dac.DersID equals dh.DersID
                              join s in dbo.Sinav on dac.DersAcmaID equals s.DersAcmaID
                              where dal.OgrenciID == 2 && s.SinavTuruID == 36
                              select new
                              {
                                  DersKodu = dh.DersKodu,
                                  DersAdi = dh.DersAdi,
                                  SinavSaatiID = s.SinavSaatiID,
                                  SinavTarihi = s.SinavTarihi.Date
                              }).ToList();
                ViewBag.vizeler = vizetarihleri;
                ViewBag.Ogrenciid = ogrenciid;
                ViewBag.BolumAdi = bolum.BolumAdi;
                ViewBag.Tarih = DateTime.Now;
                return View(ogrenci);
            }
        }
        [HttpPost]
        public IActionResult DersKayitKontrol([FromBody] string dersKodu)
        {
            using (dbo)
            {
                return Ok();
            }
        }

        // Alıcı ve Gönderenlerin rolü belirlendi.
        [HttpPost]
        public IActionResult MesajGonder(MesajlarModel gonderilecekmesaj)
        {
            using (dbo)
            {
                gonderilecekmesaj.MesajTarih = DateTime.Now;
                dbo.Mesajlar.Add(gonderilecekmesaj);
                dbo.SaveChanges();
                var ogrelmkullanici = dbo.OgretimElemani.FirstOrDefault(u => u.KullaniciID == gonderilecekmesaj.AliciID);
                var ogrencikullanici = dbo.Ogrenci.FirstOrDefault(u => u.KullaniciID == gonderilecekmesaj.GonderenID);
                return RedirectToAction("MesajlarIcerik", "Ogrenci", new { ogrenciid= ogrencikullanici.OgrenciID, ogrelmid = ogrelmkullanici.OgretimElemaniID });
            }
        }

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
