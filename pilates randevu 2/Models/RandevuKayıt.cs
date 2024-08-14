namespace pilates_randevu_2.Models
{
    public class RandevuKayıt
    {
        public int Id { get; set; }
        public string egitmen_Adi { get; set; }
        public DateTime randevu_Baslangic_Tarihi { get; set; }
        public DateTime randevu_Bitis_Tarihi { get; set; }
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
        public int HizmetId { get; set; }
        public Hizmet Hizmet { get; set; }
    }
}
