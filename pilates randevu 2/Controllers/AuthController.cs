using Microsoft.AspNetCore.Mvc;
using pilates_randevu_2.DTO;
using pilates_randevu_2.Models;
using pilates_randevu_2.VeriErisim.Soyut;

namespace pilates_randevu_2.Controllers
{
    public class AuthController : Controller
    {
        private readonly IKullaniciRepository _kullaniciRepository;

        public AuthController(IKullaniciRepository kullaniciRepository)
        {
            _kullaniciRepository = kullaniciRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            Kullanici kullanici = _kullaniciRepository.GetByMail(loginDTO.e_posta);

            if (kullanici == null)
                return View();

            if(kullanici.sifre != loginDTO.sifre)
                return View();

            if (loginDTO.e_posta == "admin@gmail.com")
                return RedirectToAction("Index", "Admin", new { kullaniciId = kullanici.Id, adsoyad = kullanici.ad_soyad });
            else
                return RedirectToAction("Index", "Appointment", new { kullaniciId = kullanici.Id, adsoyad = kullanici.ad_soyad });
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterDTO registerDTO)
        {
            Kullanici kullanici = new Kullanici();

            kullanici.sifre = registerDTO.sifre;
            kullanici.ad_soyad = registerDTO.ad_soyad;
            kullanici.e_posta = registerDTO.e_posta;
            kullanici.dogum_Tarihi = registerDTO.dogum_Tarihi;

            _kullaniciRepository.Insert(kullanici);

            return RedirectToAction("Index", "Appointment");
        }

        public IActionResult SignOut()
        {
            ViewBag.kullaniciId = null;
            return RedirectToAction("Login");
        }
    }
}
