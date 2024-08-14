using pilates_randevu_2.Context;
using pilates_randevu_2.Models;
using pilates_randevu_2.VeriErisim.Soyut;

namespace pilates_randevu_2.VeriErisim.Somut
{
    public class RandevuKayitRepository : GenericRepository<RandevuKayıt>, IRandevuKayıtRepository
    {
        public RandevuKayitRepository(AppDbContext context) : base(context)
        {
        }
    }
}
