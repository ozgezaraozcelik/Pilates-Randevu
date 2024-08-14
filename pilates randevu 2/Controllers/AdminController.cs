using Microsoft.AspNetCore.Mvc;
using pilates_randevu_2.DTO;
using pilates_randevu_2.Models;
using pilates_randevu_2.VeriErisim.Soyut;

namespace pilates_randevu_2.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRandevuKayıtRepository _randevuKayıtRepository;

        public AdminController(IRandevuKayıtRepository randevuKayıtRepository)
        {
            _randevuKayıtRepository = randevuKayıtRepository;
        }

        public IActionResult Index(int kullaniciId, string adsoyad)
        {
            ViewBag.kullaniciId = kullaniciId;
            ViewBag.adsoyad = adsoyad;
            List<RandevuKayıt> values = _randevuKayıtRepository.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            RandevuKayıt randevuKayıt = _randevuKayıtRepository.GetByID(id);

            AppointmentUpdateDTO dto = new AppointmentUpdateDTO();

            dto.Id = randevuKayıt.Id;
            dto.KullaniciId = randevuKayıt.KullaniciId;
            dto.HizmetId = randevuKayıt.HizmetId;
            dto.randevu_Baslangic_Tarihi = randevuKayıt.randevu_Baslangic_Tarihi;
            dto.randevu_Bitis_Tarihi = randevuKayıt.randevu_Bitis_Tarihi;
            dto.egitmen_Adi = randevuKayıt.egitmen_Adi;

            return View(dto);
        }

        [HttpPost]
        public IActionResult Update(AppointmentUpdateDTO appointmentUpdateDTO)
        {
            RandevuKayıt randevuKayıt = new RandevuKayıt();

            randevuKayıt.randevu_Bitis_Tarihi = appointmentUpdateDTO.randevu_Bitis_Tarihi;
            randevuKayıt.egitmen_Adi = appointmentUpdateDTO.egitmen_Adi;
            randevuKayıt.HizmetId = appointmentUpdateDTO.HizmetId;
            randevuKayıt.randevu_Baslangic_Tarihi = appointmentUpdateDTO.randevu_Baslangic_Tarihi;
            
            randevuKayıt.Id = appointmentUpdateDTO.Id;
            randevuKayıt.KullaniciId = appointmentUpdateDTO.KullaniciId;

            _randevuKayıtRepository.Update(randevuKayıt);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) 
        { 
            RandevuKayıt randevuKayıt = _randevuKayıtRepository.GetByID(id);

            if (randevuKayıt == null)
                return RedirectToAction("Index");

            _randevuKayıtRepository.Delete(randevuKayıt);

            return RedirectToAction("Index");
            
        }
    }
}
