using pilates_randevu_2.Models;

namespace pilates_randevu_2.VeriErisim.Soyut
{
    public interface IKullaniciRepository : IGenericRepository<Kullanici>
    {
        Kullanici GetByMail(string mail);
    }
}
