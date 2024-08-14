using pilates_randevu_2.Context;
using pilates_randevu_2.Models;
using pilates_randevu_2.VeriErisim.Soyut;

namespace pilates_randevu_2.VeriErisim.Somut
{
    public class KullaniciRepository : GenericRepository<Kullanici>, IKullaniciRepository
    {
        public KullaniciRepository(AppDbContext context) : base(context)
        {
        }

        public Kullanici GetByMail(string mail)
        {
            Kullanici kullanici = _context.Kullanicilar.Where(kullanici => kullanici.e_posta == mail).FirstOrDefault();
            return kullanici;
        }
    }
}
