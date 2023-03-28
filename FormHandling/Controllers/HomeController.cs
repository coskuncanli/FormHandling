using FormHandling.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FormHandling.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Kayit()
        {
            return View();
        }

        // GET
        // 1.Kullanım Şekli
        //public IActionResult KayitGet(string ad, string soyad, int yas, string adres)
        //{
        //    return Content($"Ad: {ad}, Soyad: {soyad}, Yaş: {yas}, Adres: {adres}");
        //}

        // 2.Kullanım Şekli
        //public IActionResult KayitGet()
        //{
        //    string ad = HttpContext.Request.Query["ad"];
        //    string soyad = HttpContext.Request.Query["soyad"];
        //    int yas = int.Parse(HttpContext.Request.Query["yas"]);
        //    string adres = HttpContext.Request.Query["adres"];
        //    return Content($"Ad: {ad}, Soyad: {soyad}, Yaş: {yas}, Adres: {adres}");
        //}

        // POST
        // 1.Kullanım Şekli
        //[HttpPost]
        //public IActionResult KayitPost(string ad, string soyad, int yas, string adres)
        //{
        //    return Content($"Ad: {ad}, Soyad: {soyad}, Yaş: {yas}, Adres: {adres}");
        //}

        // 2.Kullanım Şekli (IFormCollection)
        //[HttpPost]
        //public IActionResult KayitPost(IFormCollection c)
        //{
        //    string ad = c["ad"];
        //    string soyad = c["soyad"];
        //    int yas = int.Parse(c["yas"]);
        //    string adres = c["adres"];
        //    return Content($"Ad: {ad}, Soyad: {soyad}, Yaş: {yas}, Adres: {adres}");
        //}

        // 3.Kullanım Şekli (Model Binding)
        [HttpPost]
        public IActionResult KayitPost(Kayit k)
        {
            return Content($"Ad: {k.Ad}, Soyad: {k.Soyad}, Yaş: {k.Yas}, Adres: {k.Adres}");
        }


        
        public IActionResult DosyaForm(IFormCollection collection)
        {
            return View();
        }

        [HttpPost]
        public IActionResult DosyaAl(IFormFile dosya)
        {
            if (dosya == null || dosya.Length == 0)
            {
                return Content("Dosya yüklenemedi");
            }
            else
            {
                var yol = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Dosyalar", dosya.FileName);
                FileInfo dosyaInfo = new FileInfo(dosya.FileName);
                if (dosyaInfo.Extension != ".txt")
                {
                    return Content("hatalı dosya türü");
                }
                else
                {
                    dosya.CopyTo(new FileStream(yol, FileMode.Create));
                    return Content("Dosya yüklendi...");
                }
                
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}