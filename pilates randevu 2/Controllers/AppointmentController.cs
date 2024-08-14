using Microsoft.AspNetCore.Mvc;
using pilates_randevu_2.DTO;
using pilates_randevu_2.Models;
using pilates_randevu_2.VeriErisim.Soyut;

namespace pilates_randevu_2.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IRandevuKayıtRepository _randevuKayıtRepository;

        public AppointmentController(IRandevuKayıtRepository randevuKayıtRepository)
        {
            _randevuKayıtRepository = randevuKayıtRepository;
        }

        [HttpGet]
        public IActionResult Index(int kullaniciId,string adsoyad)
        {
            ViewBag.kullaniciId = kullaniciId;
            ViewBag.adsoyad = adsoyad;
            return View();
        }

        [HttpPost]
        public IActionResult Index(AppointmentCreateDTO appointmentCreateDTO)
        {
            RandevuKayıt randevuKayıt = new RandevuKayıt();

            randevuKayıt.egitmen_Adi = appointmentCreateDTO.egitmen_Adi;
            randevuKayıt.randevu_Bitis_Tarihi = appointmentCreateDTO.randevu_Bitis_Tarihi;
            randevuKayıt.randevu_Baslangic_Tarihi = appointmentCreateDTO.randevu_Baslangic_Tarihi;
            randevuKayıt.HizmetId = appointmentCreateDTO.HizmetId;
            randevuKayıt.KullaniciId = appointmentCreateDTO.KullaniciId;

            _randevuKayıtRepository.Insert(randevuKayıt);
            return View();
        }

    }
}
