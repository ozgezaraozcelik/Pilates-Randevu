using pilates_randevu_2.Models;

namespace pilates_randevu_2.DTO
{
    public class AppointmentCreateDTO
    {
        public string egitmen_Adi { get; set; }
        public DateTime randevu_Baslangic_Tarihi { get; set; }
        public DateTime randevu_Bitis_Tarihi { get; set; }
        public int KullaniciId { get; set; }
        public int HizmetId { get; set; }
    }
}
